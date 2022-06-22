using BackendTemplate.Application.Companies.Queries.GetCompany;
using MediatR;

namespace BackendTemplate.Application.Companies.Queries.GetCompanies
{
    public class GetCompaniesQuery : IRequest<IEnumerable<CompanyDto>>
    {

    }
}
