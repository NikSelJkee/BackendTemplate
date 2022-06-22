using MediatR;

namespace BackendTemplate.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest
    {
        public long Id { get; set; }
    }
}
