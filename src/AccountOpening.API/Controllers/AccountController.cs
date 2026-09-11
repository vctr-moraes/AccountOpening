using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Application.Ports.DrivingPorts;
using Microsoft.AspNetCore.Mvc;

namespace AccountOpening.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> OpenAccountAsync(
            [FromServices] IUseCase<OpenAccountRequestDto, OpenAccountResponseDto> openingAccountUseCase,
            [FromBody] OpenAccountRequestDto openAccountRequest)
        {
            try
            {
                var response = await openingAccountUseCase.TryExecuteAsync(openAccountRequest);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
