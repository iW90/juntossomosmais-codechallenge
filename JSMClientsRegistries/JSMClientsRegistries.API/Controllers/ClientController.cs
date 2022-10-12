﻿using JSMClientsRegistries.Application.Models.Requests;
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
        public async Task<IActionResult> Get([FromQuery] ElegibleListRequest request)
        {
            return await _elegibleListAsync.ExecuteAsync(request);
        }
    }
}
