using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebDKLichKham.Data;
using WebDKLichKham.Models;
using WebDKLichKham.Models.ViewModels;

namespace WebDKLichKham.Controllers;

public class HomeController(
    ILogger<HomeController> logger, 
    ApplicationDbContext context,
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly ApplicationDbContext _context = context;
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly SignInManager<IdentityUser> _signInManager = signInManager;

    public async Task<IActionResult> Index()
    {
        var model = new HomeDashboardViewModel
        {
            TotalDoctors = await _context.Doctors.CountAsync(d => d.IsActive),
            TotalAppointments = await _context.Appointments.CountAsync(),
            UpcomingSchedules = await _context.DoctorSchedules.CountAsync(s => s.WorkDate >= DateTime.Today),
            FeaturedDoctors = await _context.Doctors
                .Include(d => d.SpecialtyInfo)
                .Where(d => d.IsActive && d.IsFeatured)
                .OrderBy(d => d.Specialty)
                .Take(6)
                .ToListAsync(),
            FeaturedSpecialties = await _context.Specialties
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name)
                .Take(6)
                .ToListAsync(),
            // Chỉ lấy chuyên khoa có ít nhất 1 bác sĩ đang hoạt động – dùng cho form đặt lịch
            AllSpecialtiesWithDoctors = await _context.Specialties
                .Where(s => s.IsActive && _context.Doctors.Any(d => d.IsActive && d.SpecialtyId == s.Id))
                .OrderBy(s => s.Name)
                .ToListAsync(),
            Articles = WebDKLichKham.Data.ArticleRepository.GetAllArticles().Take(4).ToList()
        };

        return View(model);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> MedicalKnowledge(string categoryId = "neuro", string? diseaseId = null)
    {
        var categories = MedicalKnowledgeRepository.GetCategories();
        
        // Ensure valid categoryId, default to "neuro"
        if (string.IsNullOrEmpty(categoryId) || !categories.Any(c => c.Id.Equals(categoryId, StringComparison.OrdinalIgnoreCase)))
        {
            categoryId = "neuro";
        }

        var diseases = MedicalKnowledgeRepository.GetDiseasesByCategory(categoryId);
        
        // Find the active disease by diseaseId if provided; otherwise, fallback to the first one in the category
        SymptomDetail? activeDisease = null;
        if (!string.IsNullOrEmpty(diseaseId))
        {
            activeDisease = MedicalKnowledgeRepository.GetDiseaseById(diseaseId);
            // If the disease exists and has a different category, update the categoryId
            if (activeDisease != null)
            {
                categoryId = activeDisease.CategoryId;
                // Re-fetch diseases in the correct category
                diseases = MedicalKnowledgeRepository.GetDiseasesByCategory(categoryId);
            }
        }

        if (activeDisease == null && diseases.Any())
        {
            activeDisease = diseases.First();
        }

        var model = new MedicalKnowledgeViewModel
        {
            SearchQuery = null,
            ActiveCategory = categoryId,
            Categories = categories,
            DiseasesInCategory = diseases,
            ActiveSymptom = activeDisease,
            FeaturedArticles = WebDKLichKham.Data.ArticleRepository.GetAllArticles()
        };

        // Query doctors matching the specialty
        var targetSpecialty = categoryId.Equals("neuro", StringComparison.OrdinalIgnoreCase) ? "Nội thần kinh" : "Nội tổng hợp";
        model.Doctors = await _context.Doctors
            .Include(d => d.SpecialtyInfo)
            .Where(d => d.IsActive && d.Specialty == targetSpecialty)
            .Take(3)
            .ToListAsync();

        return View(model);
    }

    public IActionResult Services()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> SubmitRegister(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Register", model);
        }

        var existingUser = await _userManager.FindByNameAsync(model.PhoneNumber);
        if (existingUser != null)
        {
            ModelState.AddModelError("PhoneNumber", "Số điện thoại này đã được đăng ký tài khoản.");
            return View("Register", model);
        }

        var user = new IdentityUser
        {
            UserName = model.PhoneNumber,
            PhoneNumber = model.PhoneNumber,
            Email = $"{model.PhoneNumber}@phongkham.local",
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View("Register", model);
        }

        if (!await _userManager.IsInRoleAsync(user, "User"))
        {
            await _userManager.AddToRoleAsync(user, "User");
        }

        var fullAddress = string.Empty;
        if (!string.IsNullOrWhiteSpace(model.StreetAddress) && !string.IsNullOrWhiteSpace(model.Province))
        {
            var parts = new List<string> { model.StreetAddress };
            if (!string.IsNullOrWhiteSpace(model.Ward)) parts.Add(model.Ward);
            if (!string.IsNullOrWhiteSpace(model.District)) parts.Add(model.District);
            parts.Add(model.Province);
            fullAddress = string.Join(", ", parts);
        }
        else
        {
            fullAddress = model.Province;
        }

        var profile = new PatientProfile
        {
            UserId = user.Id,
            FullName = model.FullName,
            PhoneNumber = model.PhoneNumber,
            Address = fullAddress,
            DateOfBirth = model.DateOfBirth,
            Gender = model.Gender,
            IdentityCard = model.IdentityCard,
            InsuranceCode = model.InsuranceCode,
            Occupation = model.Occupation,
            Province = model.Province,
            District = model.District,
            Ward = model.Ward,
            StreetAddress = model.StreetAddress
        };

        _context.PatientProfiles.Add(profile);
        await _context.SaveChangesAsync();

        await _signInManager.SignInAsync(user, isPersistent: false);
        var regCookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = Request.IsHttps,
            SameSite = SameSiteMode.Lax,
            Expires = DateTimeOffset.UtcNow.AddHours(8)
        };
        Response.Cookies.Append("PortalRole", "Customer", regCookieOptions);
        Response.Cookies.Append("PortalUser", model.FullName, regCookieOptions);

        return RedirectToAction("PatientDashboard", "Portal");
    }

    [HttpPost]
    public async Task<IActionResult> SubmitLogin(string Role, string Username, string Password)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = Request.IsHttps,
            SameSite = SameSiteMode.Lax,
            Expires = DateTimeOffset.UtcNow.AddHours(8)
        };

        // --- Khôi phục bypass như cũ theo yêu cầu ---
        if (Username == "0775571311" && Password == "123456")
        {
            Response.Cookies.Append("PortalRole", "Customer", cookieOptions);
            Response.Cookies.Append("PortalUser", "Trần Văn Hoàng", cookieOptions);
            return RedirectToAction("PatientDashboard", "Portal");
        }

        if (Role == "Doctor" && Username == "bs.an" && Password == "123456")
        {
            Response.Cookies.Append("PortalRole", "Doctor", cookieOptions);
            Response.Cookies.Append("PortalUser", "BS. Nguyễn Văn An", cookieOptions);
            return RedirectToAction("DoctorDashboard", "Portal");
        }

        if (Username == "admin" && Password == "123456")
        {
            Response.Cookies.Append("PortalRole", "Admin", cookieOptions);
            Response.Cookies.Append("PortalUser", "Giám Đốc", cookieOptions);
            return RedirectToAction("AdminDashboard", "Portal");
        }
        // ------------------------------------------

        if (Role == "Customer")
        {
            var user = await _userManager.FindByNameAsync(Username);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, Password, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var profile = await _context.PatientProfiles.FirstOrDefaultAsync(p => p.UserId == user.Id);
                    var fullName = profile?.FullName ?? "Khách hàng";

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    Response.Cookies.Append("PortalRole", "Customer", cookieOptions);
                    Response.Cookies.Append("PortalUser", fullName, cookieOptions);
                    return RedirectToAction("PatientDashboard", "Portal");
                }
            }
        }
        else if (Role == "Doctor")
        {
            // Đăng nhập bác sĩ qua ASP.NET Identity
            var user = await _userManager.FindByNameAsync(Username)
                    ?? await _userManager.FindByEmailAsync(Username);
            if (user != null && await _userManager.IsInRoleAsync(user, "Doctor"))
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, Password, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    var displayName = user.UserName ?? "Bác sĩ";
                    Response.Cookies.Append("PortalRole", "Doctor", cookieOptions);
                    Response.Cookies.Append("PortalUser", displayName, cookieOptions);
                    return RedirectToAction("DoctorDashboard", "Portal");
                }
            }
        }
        else if (Role == "Admin")
        {
            var user = await _userManager.FindByEmailAsync(Username)
                    ?? await _userManager.FindByNameAsync(Username);
            if (user != null && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, Password, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    Response.Cookies.Append("PortalRole", "Admin", cookieOptions);
                    Response.Cookies.Append("PortalUser", "Giám Đốc", cookieOptions);
                    return RedirectToAction("AdminDashboard", "Portal");
                }
            }
        }
        
        TempData["LoginError"] = "Thông tin đăng nhập không chính xác hoặc không đúng vai trò!";
        return RedirectToAction("Login", "Home");
    }

    public async Task<IActionResult> LogoutPortal()
    {
        await _signInManager.SignOutAsync();
        Response.Cookies.Delete("PortalRole");
        Response.Cookies.Delete("PortalUser");
        return RedirectToAction("Index", "Home");
    }

    public IActionResult ArticleDetail(string id)
    {
        var article = WebDKLichKham.Data.ArticleRepository.GetAllArticles()
            .FirstOrDefault(a => a.Id == id);
        if (article == null)
        {
            return NotFound();
        }
        return View(article);
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult PrivacyPolicy()
    {
        return View();
    }

    public IActionResult TermsOfService()
    {
        return View();
    }

    public IActionResult Faqs()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitContact(string FullName, string Phone, string Email, string Department, string Message)
    {
        // Mô phỏng lưu vào CSDL hoặc gửi Email thông báo
        // TODO: Mở rộng thành bảng ContactMessages trong DbContext nếu cần
        TempData["SuccessMessage"] = "Cảm ơn bạn đã liên hệ. Thông tin của bạn đã được tiếp nhận và chuyên viên y tế sẽ gọi lại trong thời gian sớm nhất.";
        return RedirectToAction("Contact");
    }

    [HttpPost]
    public async Task<IActionResult> SubscribeNewsletter(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return Json(new { success = false, message = "Vui lòng nhập địa chỉ email." });
        }

        var emailRegex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        if (!emailRegex.IsMatch(email))
        {
            return Json(new { success = false, message = "Email không đúng định dạng. Vui lòng kiểm tra lại." });
        }

        email = email.Trim().ToLower();

        var existing = await _context.NewsletterSubscriptions.FirstOrDefaultAsync(s => s.Email == email);
        if (existing != null)
        {
            return Json(new { success = false, message = "Email này đã được đăng ký nhận tin trước đó." });
        }

        var subscription = new NewsletterSubscription
        {
            Email = email,
            SubscribedAt = DateTime.UtcNow
        };

        _context.NewsletterSubscriptions.Add(subscription);
        await _context.SaveChangesAsync();

        return Json(new { success = true, message = "Đăng ký nhận tin thành công! Cảm ơn bạn đã quan tâm đến Phòng khám Duy Tâm." });
    }
}
