using System.ComponentModel.DataAnnotations;

namespace OpsPortal.API.Models
{
    public class Environment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public bool IsProduction { get; set; }
    }
}