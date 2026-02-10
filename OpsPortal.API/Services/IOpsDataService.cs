using OpsPortal.API.Models;

namespace OpsPortal.API.Services
{
    public interface IOpsDataService
    {
        Task<List<Service>> GetAllServicesAsync();
        Task<Service?> GetServiceByIdAsync(int id);
        Task<Service> CreateServiceAsync(Service service);
        Task<Incident> ReportIncidentAsync(Incident incident);
    }
}