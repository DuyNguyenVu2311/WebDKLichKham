using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebDKLichKham.Models;

namespace WebDKLichKham.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<Specialty> Specialties => Set<Specialty>();

    public DbSet<PatientProfile> PatientProfiles => Set<PatientProfile>();

    public DbSet<DoctorSchedule> DoctorSchedules => Set<DoctorSchedule>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<NewsletterSubscription> NewsletterSubscriptions => Set<NewsletterSubscription>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Doctor>()
            .Property(d => d.Fee)
            .HasPrecision(18, 2);

        builder.Entity<Specialty>()
            .HasIndex(s => s.Name)
            .IsUnique();

        builder.Entity<PatientProfile>()
            .HasIndex(p => p.UserId)
            .IsUnique();

        builder.Entity<Doctor>()
            .HasOne(d => d.SpecialtyInfo)
            .WithMany(s => s.Doctors)
            .HasForeignKey(d => d.SpecialtyId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<DoctorSchedule>()
            .HasOne(s => s.Doctor)
            .WithMany(d => d.Schedules)
            .HasForeignKey(s => s.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Appointment>()
            .HasOne(a => a.PatientProfile)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Appointment>()
            .HasIndex(a => a.AppointmentCode)
            .IsUnique();

        builder.Entity<Appointment>()
            .HasIndex(a => new { a.DoctorId, a.AppointmentDate, a.StartTime })
            .IsUnique();

        builder.Entity<NewsletterSubscription>()
            .HasIndex(n => n.Email)
            .IsUnique();
    }
}
