using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.UpdateClientCommand
{
    public class UpdateClientCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<int>>
    { 
        private readonly IRepositoryAsync<Client> _repositoryAsync;

        private readonly IMapper _mapper;
        public UpdateClientCommandHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;

            _mapper = mapper;
        }       
        public async Task<Response<int>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _repositoryAsync.GetByIdAsync(request.Id);

            if (client == null)
            {
                throw new KeyNotFoundException($"Registry not found with the Id {request.Id}");
            }
            else
            {
                client.Name = request.Name;
                client.LastName = request.LastName;
                client.BirthDate = request.BirthDate;
                client.Telephone = request.Telephone;
                client.Email = request.Email;
                client.Address = request.Address;

                await _repositoryAsync.UpdateAsync(client);

                return new Response<int>(client.Id);
            }
        }    
    }
}