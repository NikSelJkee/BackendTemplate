using MediatR;

namespace BackendTemplate.Application.Companies.Queries.GetCompany
{
    public class GetCompanyQuery : IRequest<CompanyDto>
    {
        public long Id { get; set; }
    }
}
