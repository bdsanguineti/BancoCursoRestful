using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class PagedClientSpecification : Specification<Client>
    {
        public PagedClientSpecification(int pageSize, int pageNumber, string name, string lastName)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(name))
                Query.Search(x => x.Name, "%" + name + "%");

            if (!string.IsNullOrEmpty(lastName))
                Query.Search(x => x.LastName, "%" + name + "%");
        }
    }
}
