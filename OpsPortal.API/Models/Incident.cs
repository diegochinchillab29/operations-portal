using System.ComponentModel.DataAnnotations;

namespace OpsPortal.API.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string Severity { get; set; } = "Low";
        public string Status { get; set; } = "Open";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Service? Service { get; set; }
    }
}