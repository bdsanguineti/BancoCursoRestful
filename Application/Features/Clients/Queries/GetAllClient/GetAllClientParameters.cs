using Application.Parameters;

namespace Application.Features.Clients.Queries.GetAllClient
{
    public class GetAllClientParameters : RequestParameter
    {
        public string Name { get; set; }
        public string Lastname { get; set; }

    }
}
