using MediatR;

namespace BackendTemplate.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
