using BackendTemplate.Application.Companies.Commands.CreateCompany;
using BackendTemplate.Application.Companies.Commands.DeleteCompany;
using BackendTemplate.Application.Companies.Commands.UpdateCompany;
using BackendTemplate.Application.Companies.Queries.GetCompanies;
using BackendTemplate.Application.Companies.Queries.GetCompany;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendTemplate.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompaniesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var query = new GetCompaniesQuery();

            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(long id)
        {
            var query = new GetCompanyQuery { Id = id };

            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateCompany(CreateCompanyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompany(int id, UpdateCompanyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(long id)
        {
            var command = new DeleteCompanyCommand { Id = id };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
