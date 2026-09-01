using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Application.Ports.DrivingPorts;
using Microsoft.AspNetCore.Mvc;

namespace AccountOpening.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseTypeAttribute(200)]
        [ProducesResponseTypeAttribute(400)]
        public async Task<IActionResult> RegisterClientAsync(
            [FromServices] IUseCase<RegisterClientRequestDto, RegisterClientResponseDto> registeringClientUseCase,
            [FromBody] RegisterClientRequestDto registerClientRequest)
        {
            try
            {
                var response = await registeringClientUseCase.TryExecuteAsync(registerClientRequest);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
