using Application.Features.Clients.Commands.CreateClientCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientController : BaseApiController
    {
        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(CreateClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
