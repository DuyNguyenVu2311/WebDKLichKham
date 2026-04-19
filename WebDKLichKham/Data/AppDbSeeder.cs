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

        var doctors = new[]
        {
            new Doctor
            {
                FullName = "BS. Nguyễn Văn An",
                Specialty = "Nội tổng quát",
                PhoneNumber = "0901234567",
                Email = "an@phongkham.local",
                Qualification = "Thạc sĩ Y khoa",
                ExperienceYears = 8,
                Fee = 250000,
                Biography = "Tư vấn và điều trị các vấn đề sức khỏe phổ biến cho phòng khám quy mô vừa và nhỏ."
            },
            new Doctor
            {
                FullName = "BS. Trần Thị Bình",
                Specialty = "Nhi khoa",
                PhoneNumber = "0907654321",
                Email = "binh@phongkham.local",
                Qualification = "Bác sĩ chuyên khoa I",
                ExperienceYears = 10,
                Fee = 300000,
                Biography = "Theo dõi sức khỏe trẻ em, tư vấn dinh dưỡng và lịch tái khám."
            },
            new Doctor
            {
                FullName = "BS. Lê Quốc Cường",
                Specialty = "Da liễu",
                PhoneNumber = "0911122233",
                Email = "cuong@phongkham.local",
                Qualification = "Thạc sĩ Da liễu",
                ExperienceYears = 6,
                Fee = 280000,
                Biography = "Khám các vấn đề da liễu thông dụng và hỗ trợ điều trị theo liệu trình."
            }
        };

        foreach (var seededDoctor in doctors)
        {
            var existingDoctor = await dbContext.Doctors.FirstOrDefaultAsync(d => d.Email == seededDoctor.Email);
            if (existingDoctor is null)
            {
                dbContext.Doctors.Add(seededDoctor);
            }
            else
            {
                existingDoctor.FullName = seededDoctor.FullName;
                existingDoctor.Specialty = seededDoctor.Specialty;
                existingDoctor.PhoneNumber = seededDoctor.PhoneNumber;
                existingDoctor.Qualification = seededDoctor.Qualification;
                existingDoctor.ExperienceYears = seededDoctor.ExperienceYears;
                existingDoctor.Fee = seededDoctor.Fee;
                existingDoctor.Biography = seededDoctor.Biography;
                existingDoctor.IsActive = true;
            }
        }

        await dbContext.SaveChangesAsync();

        if (await dbContext.DoctorSchedules.AnyAsync())
        {
            return;
        }

        var doctorEmails = doctors.Select(d => d.Email).ToArray();
        var persistedDoctors = await dbContext.Doctors
            .Where(d => d.Email != null && doctorEmails.Contains(d.Email))
            .OrderBy(d => d.Id)
            .ToListAsync();

        var nextMonday = DateTime.Today.AddDays(((int)DayOfWeek.Monday - (int)DateTime.Today.DayOfWeek + 7) % 7);
        if (nextMonday == DateTime.Today)
        {
            nextMonday = nextMonday.AddDays(7);
        }

        var schedules = persistedDoctors.SelectMany((doctor, doctorIndex) =>
            Enumerable.Range(0, 5).Select(offset => new DoctorSchedule
            {
                DoctorId = doctor.Id,
                WorkDate = nextMonday.AddDays(offset),
                Shift = offset % 2 == 0 ? ScheduleShift.Morning : ScheduleShift.Afternoon,
                StartTime = offset % 2 == 0 ? new TimeSpan(8, 0, 0) : new TimeSpan(13, 30, 0),
                EndTime = offset % 2 == 0 ? new TimeSpan(11, 30, 0) : new TimeSpan(17, 0, 0),
                MaxAppointments = 10 + doctorIndex * 2,
                Notes = "Lịch làm việc mẫu cho giai đoạn khởi tạo hệ thống."
            }));

        await dbContext.DoctorSchedules.AddRangeAsync(schedules);
        await dbContext.SaveChangesAsync();
    }
}
