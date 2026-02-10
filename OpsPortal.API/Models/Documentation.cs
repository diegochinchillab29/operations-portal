namespace OpsPortal.API.Models
{
    public class Documentation
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string LinkUrl { get; set; } = string.Empty;
        public string Type { get; set; } = "Runbook";
    }
}