using MediatR;

namespace BackendTemplate.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<long>
    {
        public string Name { get; set; } = null!;
    }
}
