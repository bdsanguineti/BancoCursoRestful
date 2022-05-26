using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.DeleteClientCommand
{
    public class DeleteClientCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Client> _repositoryAsync;

        public DeleteClientCommandHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _repositoryAsync.GetByIdAsync(request.Id);

            if (client == null)
            {
                throw new KeyNotFoundException($"Registry not found with the Id {request.Id}");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(client);

                return new Response<int>(client.Id);
            }
        }
    }
}
