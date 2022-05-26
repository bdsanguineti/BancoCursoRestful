using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Queries.GetClientById
{
    public  class GetClientByIdQuery : IRequest<Response<ClientDto>>
    {
        public int Id { get; set; }

        public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Response<ClientDto>>
        {
            private readonly IRepositoryAsync<Client> _repositoryAsync;

            private readonly IMapper _mapper;

            public GetClientByIdQueryHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<ClientDto>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
            {
                var client = await _repositoryAsync.GetByIdAsync(request.Id);

                if (client == null)
                {
                    throw new KeyNotFoundException($"Registry not found with the Id {request.Id}");
                }
                else
                {
                    var dto = _mapper.Map<ClientDto>(client);

                    return new Response<ClientDto>(dto);                   
                }
            }
        }
    }
}
