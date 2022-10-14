using JSMClientsRegistries.Application.Models.Requests;
using JSMClientsRegistries.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JSMClientsRegistries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUseCaseAsync<ElegibleListRequest, IActionResult> _elegibleListAsync;

        public ClientController(
            IUseCaseAsync<ElegibleListRequest, IActionResult> elegibleListAsync)
        {
            _elegibleListAsync = elegibleListAsync;
        }

        [HttpGet("ElegibleList")]
        public async Task<IActionResult> Get([FromQuery] ElegibleListRequest request, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest("pageNumber or pageSize must be must be greater than zero");
            return await _elegibleListAsync.ExecuteAsync(request, pageNumber, pageSize);
        }
    }
}
