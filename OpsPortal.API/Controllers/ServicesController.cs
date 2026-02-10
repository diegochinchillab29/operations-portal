using Microsoft.AspNetCore.Mvc;
using OpsPortal.API.Models;
using OpsPortal.API.Services;

namespace OpsPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IOpsDataService _opsService;
        private readonly ILogger<ServicesController> _logger;

        public ServicesController(IOpsDataService opsService, ILogger<ServicesController> logger)
        {
            _opsService = opsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetServices()
        {
            var services = await _opsService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _opsService.GetServiceByIdAsync(id);
            if (service == null)
            {
                return NotFound($"Service with ID {id} not found.");
            }
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<Service>> CreateService([FromBody] Service service)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdService = await _opsService.CreateServiceAsync(service);
                return CreatedAtAction(nameof(GetService), new { id = createdService.Id }, createdService);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating service");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{serviceId}/incidents")]
        public async Task<ActionResult<Incident>> ReportIncident(int serviceId, [FromBody] Incident incident)
        {
            if (serviceId != incident.ServiceId) return BadRequest("ID mismatch");

            var result = await _opsService.ReportIncidentAsync(incident);
            return Ok(result);
        }
    }
}