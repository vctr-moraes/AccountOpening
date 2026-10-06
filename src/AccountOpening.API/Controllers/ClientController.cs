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
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPatch("{clientId:guid}/contacts")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterClientContactsAsync(
            [FromServices] IUseCase<RegisterClientContactsRequestDto, RegisterClientContactsResponseDto> registeringClientContactsUseCase,
            [FromRoute] Guid clientId,
            [FromBody] RegisterClientContactsRequestDto registerClientContactsRequest)
        {
            try
            {
                registerClientContactsRequest.ClientId = clientId;
                var response = await registeringClientContactsUseCase.TryExecuteAsync(registerClientContactsRequest);
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
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
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
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
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost("{clientId:guid}/address")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterAddressAsync(
            [FromServices] IUseCase<RegisterAddressRequestDto, RegisterAddressResponseDto> registerAddressUseCase,
            [FromRoute] Guid clientId,
            [FromBody] RegisterAddressRequestDto registerAddressRequest)
        {
            try
            {
                registerAddressRequest.ClientId = clientId;
                await registerAddressUseCase.TryExecuteAsync(registerAddressRequest);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost("{clientId:guid}/application-metadata")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterApplicationMetadataAsync(
            [FromServices] IUseCase<RegisterApplicationMetadataRequestDto, OpenAccountResponseDto> registerApplicationMetadataUseCase,
            [FromRoute] Guid clientId,
            [FromBody] RegisterApplicationMetadataRequestDto registerApplicationMetadataRequest)
        {
            try
            {
                registerApplicationMetadataRequest.ClientId = clientId;
                var response = await registerApplicationMetadataUseCase.TryExecuteAsync(registerApplicationMetadataRequest);
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
