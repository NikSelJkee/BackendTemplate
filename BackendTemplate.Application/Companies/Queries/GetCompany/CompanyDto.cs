using BackendTemplate.Domain.Entities;
using BackendTemplate.Application.Common.Mappings;
using BackendTemplate.Application.Games.Queries.GetGame;

namespace BackendTemplate.Application.Companies.Queries.GetCompany
{
    public class CompanyDto : IMapFrom<Company>
    {
        public CompanyDto()
        {
            Games = new List<GameDto>();
        }

        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public IList<GameDto> Games { get; set; }
    }
}