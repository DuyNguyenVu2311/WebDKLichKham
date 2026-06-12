using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebDKLichKham.Models;

namespace WebDKLichKham.Data;

public static class AppDbSeeder
{
    private static readonly string[] Roles = ["Admin", "User"];

    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var scopedServices = scope.ServiceProvider;

        var roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scopedServices.GetRequiredService<UserManager<IdentityUser>>();
        var dbContext = scopedServices.GetRequiredService<ApplicationDbContext>();

        await dbContext.Database.EnsureCreatedAsync();

        // Add MedicalService column to Appointments if it doesn't exist (since DB is already created)
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'MedicalService') " +
            "ALTER TABLE [Appointments] ADD [MedicalService] NVARCHAR(150) NULL;"
        );

        // Add Passcode column to Appointments if it doesn't exist
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'Passcode') " +
            "ALTER TABLE [Appointments] ADD [Passcode] NVARCHAR(4) NOT NULL DEFAULT '0000';"
        );

        // Add FollowUpSymptoms column to Appointments if it doesn't exist
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'FollowUpSymptoms') " +
            "ALTER TABLE [Appointments] ADD [FollowUpSymptoms] NVARCHAR(50) NULL;"
        );

        // Add fields to PatientProfiles
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[PatientProfiles]') AND name = 'Gender') " +
            "ALTER TABLE [PatientProfiles] ADD [Gender] NVARCHAR(20) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[PatientProfiles]') AND name = 'IdentityCard') " +
            "ALTER TABLE [PatientProfiles] ADD [IdentityCard] NVARCHAR(50) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[PatientProfiles]') AND name = 'InsuranceCode') " +
            "ALTER TABLE [PatientProfiles] ADD [InsuranceCode] NVARCHAR(50) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[PatientProfiles]') AND name = 'Occupation') " +
            "ALTER TABLE [PatientProfiles] ADD [Occupation] NVARCHAR(100) NULL;"
        );

        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[PatientProfiles]') AND name = 'Country') " +
            "ALTER TABLE [PatientProfiles] ADD [Country] NVARCHAR(100) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[PatientProfiles]') AND name = 'Province') " +
            "ALTER TABLE [PatientProfiles] ADD [Province] NVARCHAR(100) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[PatientProfiles]') AND name = 'District') " +
            "ALTER TABLE [PatientProfiles] ADD [District] NVARCHAR(100) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[PatientProfiles]') AND name = 'Ward') " +
            "ALTER TABLE [PatientProfiles] ADD [Ward] NVARCHAR(100) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[PatientProfiles]') AND name = 'StreetAddress') " +
            "ALTER TABLE [PatientProfiles] ADD [StreetAddress] NVARCHAR(255) NULL;"
        );

        // Add fields to Appointments
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'IdentityCard') " +
            "ALTER TABLE [Appointments] ADD [IdentityCard] NVARCHAR(50) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'InsuranceCode') " +
            "ALTER TABLE [Appointments] ADD [InsuranceCode] NVARCHAR(50) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'Occupation') " +
            "ALTER TABLE [Appointments] ADD [Occupation] NVARCHAR(100) NULL;"
        );

        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'Country') " +
            "ALTER TABLE [Appointments] ADD [Country] NVARCHAR(100) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'Province') " +
            "ALTER TABLE [Appointments] ADD [Province] NVARCHAR(100) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'District') " +
            "ALTER TABLE [Appointments] ADD [District] NVARCHAR(100) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'Ward') " +
            "ALTER TABLE [Appointments] ADD [Ward] NVARCHAR(100) NULL;"
        );
        await dbContext.Database.ExecuteSqlRawAsync(
            "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[Appointments]') AND name = 'StreetAddress') " +
            "ALTER TABLE [Appointments] ADD [StreetAddress] NVARCHAR(255) NULL;"
        );

        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        const string adminEmail = "admin@phongkham.local";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser is null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "Admin@123");
            if (result.Succeeded)
            {
                await userManager.AddToRolesAsync(adminUser, Roles);
            }
        }
        else
        {
            var assignedRoles = await userManager.GetRolesAsync(adminUser);
            var missingRoles = Roles.Except(assignedRoles).ToArray();
            if (missingRoles.Length > 0)
            {
                await userManager.AddToRolesAsync(adminUser, missingRoles);
            }
        }

        var specialties = new[]
        {
            new Specialty { Name = "Nội tổng hợp", Description = "Khám và theo dõi các vấn đề sức khỏe nội khoa phổ biến ở người lớn.", IconClass = "medical_information" },
            new Specialty { Name = "Da liễu", Description = "Khám da liễu, tư vấn và theo dõi điều trị các bệnh lý da thường gặp.", IconClass = "dermatology" },
            new Specialty { Name = "Nhi khoa", Description = "Theo dõi sức khỏe trẻ em, dinh dưỡng và lịch tái khám định kỳ.", IconClass = "child_care" },
            new Specialty { Name = "Tai Mũi Họng", Description = "Khám và điều trị các bệnh lý tai mũi họng thường gặp.", IconClass = "hearing" },
            new Specialty { Name = "Sản phụ khoa", Description = "Khám phụ khoa, tư vấn sức khỏe sinh sản và theo dõi thai kỳ.", IconClass = "pregnant_woman" },
            new Specialty { Name = "Răng Hàm Mặt", Description = "Khám răng tổng quát, tư vấn điều trị và chăm sóc răng miệng.", IconClass = "dentistry" },
            new Specialty { Name = "Nội thần kinh", Description = "Chẩn đoán và điều trị não bộ, tủy sống, hệ thần kinh.", IconClass = "neurology" },
        };

        foreach (var specialty in specialties)
        {
            var existingSpecialty = await dbContext.Specialties.FirstOrDefaultAsync(s => s.Name == specialty.Name);
            if (existingSpecialty is null)
            {
                dbContext.Specialties.Add(specialty);
            }
            else
            {
                existingSpecialty.Description = specialty.Description;
                existingSpecialty.IsActive = true;
            }
        }

        await dbContext.SaveChangesAsync();

        var dbSpecialties = await dbContext.Specialties.ToListAsync();
        
        if (!await dbContext.Doctors.AnyAsync())
        {
            // Remove old doctors & appointments
            dbContext.Appointments.RemoveRange(dbContext.Appointments);
            dbContext.DoctorSchedules.RemoveRange(dbContext.DoctorSchedules);
            dbContext.Doctors.RemoveRange(dbContext.Doctors);
            dbContext.PatientProfiles.RemoveRange(dbContext.PatientProfiles);
            await dbContext.SaveChangesAsync();

            var doctors = new List<Doctor>();
        var firstNamesMale = new[] { "Nguyễn Văn", "Trần Thanh", "Phạm Quốc", "Lê Quốc", "Đỗ Hữu", "Bùi Văn", "Đinh Văn", "Đặng Minh", "Nguyễn Tấn", "Đỗ Quang" };
        var lastNamesMale = new[] { "An", "Bình", "Hưng", "Cường", "Thịnh", "Hải", "Tùng", "Châu", "Phúc", "Hùng" };
        var firstNamesFemale = new[] { "Hoàng Thị", "Vũ Ngọc", "Ngô Thị", "Đặng Thùy", "Hồ Thanh", "Phạm Thúy", "Trần Thị", "Lê Thu", "Đoàn Ngọc" };
        var lastNamesFemale = new[] { "Lan", "Mai", "Thu", "Dương", "Vân", "Vi", "Bình", "Hương", "Hà" };
        
        var rand = new Random(123);
        int docId = 1;
        
        foreach(var spec in dbSpecialties)
        {
            // 4 doctors per specialty
            for(int i=0; i<4; i++)
            {
                bool isMale = i % 2 == 0;
                string fullName = isMale 
                    ? $"BS. {firstNamesMale[rand.Next(firstNamesMale.Length)]} {lastNamesMale[rand.Next(lastNamesMale.Length)]}"
                    : $"BS. {firstNamesFemale[rand.Next(firstNamesFemale.Length)]} {lastNamesFemale[rand.Next(lastNamesFemale.Length)]}";
                
                doctors.Add(new Doctor
                {
                    FullName = fullName,
                    Specialty = spec.Name,
                    SpecialtyId = spec.Id,
                    PhoneNumber = $"09{rand.Next(10000000, 99999999)}",
                    Email = $"doc{docId}@phongkham.local",
                    Qualification = isMale ? "Bác sĩ chuyên khoa I" : "Thạc sĩ Y học",
                    ExperienceYears = rand.Next(5, 20),
                    Fee = new[] { 300000, 350000, 400000, 450000 }[rand.Next(0, 4)],
                    Workplace = (i < 2) ? "Cơ sở 1: TP. Thủ Đức" : "Cơ sở 2: Nhơn Trạch",
                    IsFeatured = (i == 0),
                    Biography = $"Khám và điều trị chuyên sâu về {spec.Name}.",
                    AvatarUrl = isMale ? "/images/avatar_male.png" : "/images/avatar_female.png"
                });
                docId++;
            }
        }

        dbContext.Doctors.AddRange(doctors);
        await dbContext.SaveChangesAsync();

        var persistedDoctors = await dbContext.Doctors.ToListAsync();
        var schedulesToAdd = new List<DoctorSchedule>();
        var today = DateTime.Today;
        int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
        var thisMonday = today.AddDays(-diff);

        // Tạo lịch theo tuần: Tuần trước, Tuần này, Tuần sau
        schedulesToAdd.AddRange(GenerateSchedulesForWeek(persistedDoctors, thisMonday.AddDays(-7)));
        schedulesToAdd.AddRange(GenerateSchedulesForWeek(persistedDoctors, thisMonday));
        schedulesToAdd.AddRange(GenerateSchedulesForWeek(persistedDoctors, thisMonday.AddDays(7)));

        dbContext.DoctorSchedules.AddRange(schedulesToAdd);
        await dbContext.SaveChangesAsync();

        // Seed Appointments
        var rng = new Random(456);
        var maleNames = new[] { 
            "Nguyễn Quốc Anh", "Trần Khắc Bảo", "Phạm Văn Cường", "Lê Đình Dũng", "Hoàng Anh Đức", 
            "Vũ Nhật Hùng", "Đỗ Minh Khang", "Bùi Trọng Lâm", "Ngô Thế Phong", "Đặng Quang Sơn", 
            "Hồ Tiến Thành", "Đinh Tuấn Vũ", "Trương Quốc Khánh", "Nguyễn Tuấn Tài", "Lý Trung Kiên", 
            "Vương Đình Hải", "Nguyễn Minh Triết", "Phạm Bảo Long", "Trần Việt Dũng", "Lê Thanh Hậu", 
            "Hoàng Gia Huy", "Vũ Đăng Khoa", "Đỗ Xuân Trường", "Nguyễn Đình Nghĩa", "Cao Tiến Phát", 
            "Phùng Trọng Phúc", "Trần Quang Đại", "Lê Mạnh Tuấn", "Phạm Đình Bảo", "Hồ Quang Hiếu",
            "Nguyễn Bá Ngọc", "Đặng Văn Lâm", "Trương Minh Đạt", "Bùi Xuân Huấn", "Ngô Minh Hùng"
        };
        var femaleNames = new[] {
            "Nguyễn Thu An", "Trần Bảo Bình", "Phạm Thúy Châu", "Lê Phương Dung", "Hoàng Tú Anh", 
            "Vũ Mai Hoa", "Đỗ Lan Hương", "Bùi Cẩm Nhung", "Ngô Thảo Nguyên", "Đặng Bích Ngọc", 
            "Hồ Diễm My", "Đinh Kim Oanh", "Trương Nhã Phương", "Nguyễn Mai Phương", "Lý Tuyết Mai", 
            "Vương Thúy Quỳnh", "Nguyễn Trúc Linh", "Phạm Hồng Ngọc", "Trần Minh Thư", "Lê Thanh Trúc", 
            "Hoàng Diệu Hiền", "Vũ Hương Giang", "Đỗ Thị Mến", "Nguyễn Cẩm Ly", "Cao Thanh Tâm", 
            "Phùng Ngọc Hà", "Trần Thị Ánh", "Lê Nhã Trân", "Phạm Kiều Loan", "Hồ Minh Đan",
            "Nguyễn Yến Nhi", "Đặng Phương Thanh", "Trương Thúy Loan", "Bùi Hồng Vân", "Ngô Bích Hằng"
        };
        
        var specialtyReasons = new Dictionary<string, string[]>
        {
            { "Nội tổng hợp", new[] { "Khám sức khỏe tổng quát", "Đau dạ dày cấp", "Tăng huyết áp vô căn", "Viêm phổi cộng đồng", "Kiểm tra đường huyết (Tiểu đường tuýp 2)", "Đau thắt ngực", "Trào ngược dạ dày thực quản (GERD)" } },
            { "Da liễu", new[] { "Viêm da cơ địa", "Điều trị mụn trứng cá nặng", "Nấm da đầu", "Khám vảy nến", "Nổi mày đay dị ứng", "Tư vấn điều trị sẹo rỗ", "Viêm da tiếp xúc" } },
            { "Nhi khoa", new[] { "Sốt cao liên tục (Nghi sốt xuất huyết)", "Viêm tiểu phế quản cấp", "Tiêu chảy cấp có mất nước", "Theo dõi Tay chân miệng", "Khám tư vấn dinh dưỡng", "Kiểm tra sức khỏe định kỳ", "Viêm tai giữa cấp (Nhi)" } },
            { "Tai Mũi Họng", new[] { "Viêm amidan hốc mủ", "Viêm xoang mạn tính", "Viêm tai giữa thanh dịch", "Nội soi lấy dị vật họng", "Khám hạt dây thanh quản", "Nội soi Tầm soát ung thư vòm họng", "Chảy máu cam kéo dài" } },
            { "Sản phụ khoa", new[] { "Khám thai định kỳ (Tuần 12)", "Siêu âm thai (Đo độ mờ da gáy)", "Tầm soát ung thư cổ tử cung (Pap smear)", "Khám viêm âm đạo", "Điều trị rối loạn kinh nguyệt", "Siêu âm canh noãn", "Khám tiền sản" } },
            { "Răng Hàm Mặt", new[] { "Trám răng thẩm mỹ", "Tiểu phẫu nhổ răng khôn (Răng 8)", "Cạo vôi răng và đánh bóng", "Điều trị viêm nha chu", "Tư vấn niềng răng (Invisalign)", "Lấy tủy răng", "Khám sâu răng" } },
            { "Nội thần kinh", new[] { "Đau nửa đầu (Migraine)", "Rối loạn tiền đình", "Tái khám sau Tai biến mạch máu não", "Đau dây thần kinh tọa", "Điều trị mất ngủ mạn tính", "Khám Parkinson", "Tê bì chân tay" } }
        };

        var appointmentsToAdd = new List<Appointment>();

        // Seed Patient Profiles
        var patientProfiles = new List<PatientProfile>();
        for (int i = 0; i < 50; i++)
        {
            patientProfiles.Add(new PatientProfile
            {
                UserId = $"mock-user-id-{i}",
                FullName = (i % 2 == 0) ? maleNames[rng.Next(maleNames.Length)] : femaleNames[rng.Next(femaleNames.Length)],
                PhoneNumber = $"09{rng.Next(10000000, 99999999)}",
                DateOfBirth = DateTime.Today.AddYears(-rng.Next(5, 70)).AddDays(-rng.Next(1, 365))
            });
        }
        dbContext.PatientProfiles.AddRange(patientProfiles);
        await dbContext.SaveChangesAsync();

        foreach (var sched in schedulesToAdd)
        {
            if (sched.WorkDate.Date > thisMonday.AddDays(6).Date) continue; // Future week -> no booking

            int fillCount = 0;
            if (sched.WorkDate.Date < thisMonday.Date)
            {
                fillCount = rng.Next((int)(sched.MaxAppointments * 0.8), sched.MaxAppointments); // past week
            }
            else
            {
                // this week
                int dayIndex = (int)sched.WorkDate.DayOfWeek - 1; // 0 to 6
                if (dayIndex == -1) dayIndex = 6; // Sunday is 0 in C#, but DayOfWeek.Sunday is 0, wait, -1 ?
                // Oh wait: (int)DayOfWeek.Sunday is 0. So 0 - 1 = -1.
                // Let's fix dayIndex mapping safely
                int safeDayIndex = sched.WorkDate.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)sched.WorkDate.DayOfWeek - 1;
                fillCount = safeDayIndex switch
                {
                    0 => (int)(sched.MaxAppointments * 0.75), // Mon
                    1 => (int)(sched.MaxAppointments * 0.85), // Tue
                    2 when sched.Shift == ScheduleShift.Morning   => sched.MaxAppointments, // Wed Morning Full
                    2 when sched.Shift == ScheduleShift.Afternoon => (int)(sched.MaxAppointments * 0.6),
                    3 => (int)(sched.MaxAppointments * 0.40), // Thu
                    4 => (int)(sched.MaxAppointments * 0.30), // Fri
                    5 => (int)(sched.MaxAppointments * 0.90), // Sat
                    6 => (int)(sched.MaxAppointments * 0.95), // Sun
                    _ => 0
                };
            }
            
            fillCount = Math.Max(0, Math.Min(fillCount, sched.MaxAppointments));

            
            var schedDoc = persistedDoctors.First(d => d.Id == sched.DoctorId);
            var specName = schedDoc.Specialty ?? "Nội tổng hợp";
            var specReasons = specialtyReasons.ContainsKey(specName) ? specialtyReasons[specName] : specialtyReasons["Nội tổng hợp"];

            for (int i = 0; i < fillCount; i++)
            {
                var isReturning = rng.NextDouble() > 0.4;
                PatientProfile? profile = isReturning ? patientProfiles[rng.Next(patientProfiles.Count)] : null;
                
                string name;
                string gender;
                if (profile != null)
                {
                    name = profile.FullName;
                    gender = maleNames.Contains(name) ? "Nam" : "Nữ";
                }
                else
                {
                    bool isMale = rng.NextDouble() > 0.5;
                    name = isMale ? maleNames[rng.Next(maleNames.Length)] : femaleNames[rng.Next(femaleNames.Length)];
                    gender = isMale ? "Nam" : "Nữ";
                }

                var reason = specReasons[rng.Next(specReasons.Length)];
                var medicalService = profile != null ? "Khám Lâm Sàng (Tái khám)" : "Khám Lâm Sàng & Chuyên Khoa";
                var dob = profile?.DateOfBirth ?? DateTime.Today.AddYears(-rng.Next(5, 70)).AddDays(-rng.Next(1, 365));

                appointmentsToAdd.Add(new Appointment
                {
                    DoctorId        = sched.DoctorId,
                    PatientProfileId = profile?.Id,
                    AppointmentCode = $"APT-{sched.DoctorId}-{sched.WorkDate:yyyyMMdd}-{sched.Shift}-{i:00}",
                    PatientName     = name,
                    PatientPhone    = $"09{rng.Next(10000000, 99999999)}",
                    PatientEmail    = $"bn_{name.Replace(" ", "").ToLower()}@example.com",
                    PatientGender   = gender,
                    PatientDateOfBirth = dob,
                    AppointmentDate = sched.WorkDate,
                    StartTime       = sched.StartTime.Add(TimeSpan.FromMinutes(i * 20)),
                    EndTime         = sched.StartTime.Add(TimeSpan.FromMinutes(i * 20 + 30)),
                    Status          = sched.WorkDate.Date < thisMonday.Date ? AppointmentStatus.Completed : AppointmentStatus.Confirmed,
                    ReasonForVisit  = reason,
                    MedicalService  = medicalService,
                    Notes           = profile != null ? "Bệnh nhân cũ đã có mã hồ sơ" : "Khách vãng lai, cần tạo hồ sơ mới",
                    Passcode        = "0000",
                    CreatedAt       = sched.WorkDate.AddDays(-rng.Next(1, 5))
                });
            }
        }

        dbContext.Appointments.AddRange(appointmentsToAdd);
        await dbContext.SaveChangesAsync();
        }

        // Luôn làm mới lịch làm việc từ tuần hiện tại trở đi mỗi khi app khởi động
        // Đảm bảo luôn có lịch cho 2 tuần tiếp theo
        await RefreshFutureSchedulesAsync(dbContext);
    }

    /// <summary>
    /// Xoá và tạo lại lịch làm việc từ đầu tuần hiện tại trở đi (tuần này + 2 tuần tiếp = 3 tuần).
    /// Chạy mỗi lần app khởi động để đảm bảo bác sĩ luôn có lịch có thể đặt.
    /// </summary>
    private static async Task RefreshFutureSchedulesAsync(ApplicationDbContext dbContext)
    {
        var today = DateTime.Today;
        int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
        var thisMonday = today.AddDays(-diff);

        // Xoá toàn bộ lịch từ đầu tuần này trở đi
        var schedulesToDelete = await dbContext.DoctorSchedules
            .Where(s => s.WorkDate >= thisMonday)
            .ToListAsync();
        dbContext.DoctorSchedules.RemoveRange(schedulesToDelete);
        await dbContext.SaveChangesAsync();

        var doctors = await dbContext.Doctors.ToListAsync();
        if (!doctors.Any()) return;

        var freshSchedules = new List<DoctorSchedule>();

        // Tạo lịch cho tuần hiện tại + 2 tuần tiếp theo = 21 ngày (3 tuần)
        freshSchedules.AddRange(GenerateSchedulesForWeek(doctors, thisMonday));
        freshSchedules.AddRange(GenerateSchedulesForWeek(doctors, thisMonday.AddDays(7)));
        freshSchedules.AddRange(GenerateSchedulesForWeek(doctors, thisMonday.AddDays(14)));

        dbContext.DoctorSchedules.AddRange(freshSchedules);
        await dbContext.SaveChangesAsync();
    }

    private static List<DoctorSchedule> GenerateSchedulesForWeek(List<Doctor> doctors, DateTime monday)
    {
        var schedules = new List<DoctorSchedule>();
        
        // Nhóm bác sĩ theo Chuyên khoa và Nơi làm việc
        var groups = doctors.GroupBy(d => new { SpecialtyId = d.SpecialtyId ?? 0, Workplace = d.Workplace ?? "" });
        
        foreach (var group in groups)
        {
            var groupDoctors = group.OrderBy(d => d.Id).ToList();
            int docCount = groupDoctors.Count;
            
            if (docCount == 0) continue;
            
            if (docCount == 1)
            {
                var doctor = groupDoctors[0];
                for (int day = 0; day < 7; day++)
                {
                    var date = monday.AddDays(day);
                    bool isWeekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
                    
                    if (isWeekend)
                    {
                        schedules.Add(CreateSchedule(doctor.Id, date, ScheduleShift.Morning, 15));
                        schedules.Add(CreateSchedule(doctor.Id, date, ScheduleShift.Afternoon, 15));
                    }
                    else
                    {
                        // Cho nghỉ 1 ca vào chiều thứ Tư (nếu chỉ có 1 bác sĩ)
                        if (date.DayOfWeek == DayOfWeek.Wednesday)
                        {
                            schedules.Add(CreateSchedule(doctor.Id, date, ScheduleShift.Morning, 15));
                        }
                        else
                        {
                            schedules.Add(CreateSchedule(doctor.Id, date, ScheduleShift.Morning, 15));
                            schedules.Add(CreateSchedule(doctor.Id, date, ScheduleShift.Afternoon, 15));
                        }
                    }
                }
                continue;
            }
            
            // Trường hợp có từ 2 bác sĩ trở lên trong cùng chuyên khoa tại 1 chi nhánh:
            // Phân bổ lịch nghỉ xoay vòng: mỗi bác sĩ nghỉ đúng 1 ca trong tuần (thứ 2 đến thứ 6).
            // Đảm bảo không trùng ngày nghỉ và ca nghỉ để luôn có ít nhất 1 bác sĩ chuyên khoa làm việc.
            for (int i = 0; i < docCount; i++)
            {
                var doctor = groupDoctors[i];
                
                // Chọn ngày nghỉ và ca nghỉ dựa trên SpecialtyId và số thứ tự bác sĩ
                int baseOffset = (group.Key.SpecialtyId + i) % 10;
                int dayOff = (baseOffset % 5) + 1; // 1 = T2, 2 = T3, 3 = T4, 4 = T5, 5 = T6
                var shiftOff = (baseOffset / 5 == 0) ? ScheduleShift.Morning : ScheduleShift.Afternoon;
                
                for (int day = 0; day < 7; day++)
                {
                    var date = monday.AddDays(day);
                    int dayOfWeekValue = (int)date.DayOfWeek;
                    bool isWeekend = dayOfWeekValue == 0 || dayOfWeekValue == 6; // CN hoặc T7
                    
                    if (isWeekend)
                    {
                        // Thứ 7 & Chủ Nhật bắt buộc đi làm cả 2 ca
                        schedules.Add(CreateSchedule(doctor.Id, date, ScheduleShift.Morning, 15));
                        schedules.Add(CreateSchedule(doctor.Id, date, ScheduleShift.Afternoon, 15));
                    }
                    else
                    {
                        // Ngày trong tuần
                        if (dayOfWeekValue == dayOff)
                        {
                            // Nghỉ ca shiftOff, làm ca còn lại (nghỉ 1 ca trong tuần)
                            var workShift = (shiftOff == ScheduleShift.Morning) ? ScheduleShift.Afternoon : ScheduleShift.Morning;
                            schedules.Add(CreateSchedule(doctor.Id, date, workShift, 15));
                        }
                        else
                        {
                            // Đi làm cả 2 ca
                            schedules.Add(CreateSchedule(doctor.Id, date, ScheduleShift.Morning, 15));
                            schedules.Add(CreateSchedule(doctor.Id, date, ScheduleShift.Afternoon, 15));
                        }
                    }
                }
            }
        }
        
        return schedules;
    }

    private static DoctorSchedule CreateSchedule(int doctorId, DateTime workDate, ScheduleShift shift, int maxAppts)
    {
        var st = shift == ScheduleShift.Morning ? new TimeSpan(7, 0, 0) 
               : shift == ScheduleShift.Afternoon ? new TimeSpan(13, 0, 0) 
               : new TimeSpan(18, 0, 0);
        var duration = shift == ScheduleShift.Morning || shift == ScheduleShift.Afternoon
            ? new TimeSpan(5, 0, 0)
            : new TimeSpan(2, 0, 0);
        return new DoctorSchedule
        {
            DoctorId = doctorId,
            WorkDate = workDate.Date,
            Shift = shift,
            StartTime = st,
            EndTime = st.Add(duration),
            MaxAppointments = maxAppts
        };
    }
}
