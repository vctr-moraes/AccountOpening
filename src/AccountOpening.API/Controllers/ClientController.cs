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
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
    
        [HttpGet("{clientId:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetClientByIdAsync(
            [FromServices] IUseCase<GetClientByIdRequestDto, GetClientByIdResponseDto> getClientByIdUseCase,
            [FromRoute] Guid clientId)
        {
            try
            {
                var request = new GetClientByIdRequestDto { ClientId = clientId };
                var response = await getClientByIdUseCase.TryExecuteAsync(request);
            
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetClients(
            [FromServices] IUseCase<GetClientsRequestDto, GetClientsResponseDto> getClientsUseCase)
        {
            try
            {
                var response = await getClientsUseCase.TryExecuteAsync(new GetClientsRequestDto());
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("register-address")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterAddressAsync(
            [FromServices] IUseCase<RegisterAddressRequestDto, RegisterAddressResponseDto> registerAddressUseCase,
            [FromBody] RegisterAddressRequestDto registerAddressRequest)
        {
            try
            {
                await registerAddressUseCase.TryExecuteAsync(registerAddressRequest);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
