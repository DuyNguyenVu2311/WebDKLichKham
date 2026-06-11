using System.ComponentModel.DataAnnotations;

namespace WebDKLichKham.Models;

public class NewsletterSubscription
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(256)]
    public string Email { get; set; } = null!;

    public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;
}
