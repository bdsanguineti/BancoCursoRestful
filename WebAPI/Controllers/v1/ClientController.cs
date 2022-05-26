using Application.Features.Clients.Commands.CreateClientCommand;
using Application.Features.Clients.Commands.DeleteClientCommand;
using Application.Features.Clients.Commands.UpdateClientCommand;
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

        // PUT api/controller/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdateClientCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        // DELETE api/controller/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteClientCommand { Id = id} ));
        }
    }
}
