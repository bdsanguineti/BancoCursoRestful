using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

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

            private readonly IDistributedCache _distributedCache;

            public GetAllClientQueryHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper, IDistributedCache distributedCache)
            {
                _repositoryAsync = repositoryAsync;

                _mapper = mapper;

                _distributedCache = distributedCache;
            }

            public async Task<PagedResponse<List<ClientDto>>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
            {
                var cacheKey = $"clientList_{request.PageSize}_{request.PageNumber}_{request.Name}_{request.Lastname}";

                string serializedClientList;

                var clientList = new List<Client>();

                var redisClientList = await _distributedCache.GetAsync(cacheKey);

                if (redisClientList != null)
                {
                    serializedClientList = Encoding.UTF8.GetString(redisClientList);

                    clientList = JsonConvert.DeserializeObject<List<Client>>(serializedClientList);
                }
                else
                {
                    clientList = await _repositoryAsync.ListAsync(new PagedClientSpecification(request.PageSize, request.PageNumber, request.Name, request.Lastname));

                    serializedClientList = JsonConvert.SerializeObject(clientList);

                    redisClientList = Encoding.UTF8.GetBytes(serializedClientList);

                    var options = new DistributedCacheEntryOptions()
                                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                                .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                    await _distributedCache.SetAsync(cacheKey, redisClientList, options);
                }


                var clientsDto = _mapper.Map<List<ClientDto>>(clientList);

                return new PagedResponse<List<ClientDto>>(clientsDto, request.PageNumber, request.PageSize);
            }            
        }
    }
}
