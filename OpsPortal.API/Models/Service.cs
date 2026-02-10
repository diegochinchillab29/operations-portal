using System.ComponentModel.DataAnnotations;

namespace OpsPortal.API.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? OwnerTeam { get; set; }
        public string? RepoUrl { get; set; }

        // Relationships
        public List<Deployment> Deployments { get; set; } = new();
        public List<Incident> Incidents { get; set; } = new();
        public List<Vulnerability> Vulnerabilities { get; set; } = new();
        public List<Documentation> Docs { get; set; } = new();
    }
}