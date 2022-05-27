using Application.Features.Clients.Commands.CreateClientCommand;
using Application.Features.Clients.Commands.DeleteClientCommand;
using Application.Features.Clients.Commands.UpdateClientCommand;
using Application.Features.Clients.Queries.GetAllClient;
using Application.Features.Clients.Queries.GetClientById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientController : BaseApiController
    {
        // GET api/<controller>
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllClientParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllClientQuery 
            { 
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize, 
                Name = filter.Name, 
                Lastname = filter.Lastname 
            }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetClientByIdQuery { Id = id }));
        }

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
