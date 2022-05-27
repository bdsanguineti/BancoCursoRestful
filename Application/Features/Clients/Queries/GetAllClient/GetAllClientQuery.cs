﻿using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Queries.GetAllClient
{
    public class GetAllClientQuery : IRequest<PagedResponse<List<ClientDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQuery, PagedResponse<List<ClientDto>>>
        {
            private readonly IRepositoryAsync<Client> _repositoryAsync;

            private readonly IMapper _mapper;

            public GetAllClientQueryHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;

                _mapper = mapper;
            }

            public Task<PagedResponse<List<ClientDto>>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }            
        }
    }
}
