using Microsoft.EntityFrameworkCore;
using OpsPortal.API.Data;
using OpsPortal.API.Models;

namespace OpsPortal.API.Services
{
    public class OpsDataService : IOpsDataService
    {
        private readonly OpsPortalContext _context;

        public OpsDataService(OpsPortalContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await _context.Services
                .Include(s => s.Deployments)
                .ToListAsync();
        }

        public async Task<Service?> GetServiceByIdAsync(int id)
        {
            return await _context.Services
                .Include(s => s.Incidents)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Service> CreateServiceAsync(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Incident> ReportIncidentAsync(Incident incident)
        {
            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();
            return incident;
        }
    }
}