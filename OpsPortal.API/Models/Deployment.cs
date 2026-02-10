using System.ComponentModel.DataAnnotations;

namespace OpsPortal.API.Models
{
    public class Deployment
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int EnvironmentId { get; set; }

        [Required]
        public string Version { get; set; } = string.Empty;
        public DateTime DeployedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Success";

        // Navigation properties
        public Service? Service { get; set; }
        public Environment? Environment { get; set; }
    }
}