using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Configurations.Commands.UpdateCompanySettings;
using Countify.Application.Features.Configurations.Queries.GetCompanySettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/settings")]
public class SettingsController : BaseController
{
    [HttpGet]
    [Authorize(CompanySettingsPolicies.CanViewCompanySettings)]
    public async Task<IActionResult> Get()
        => HandleResult(await Mediator.Send(new GetCompanySettingsQuery()));

    [HttpPut]
    [Authorize(CompanySettingsPolicies.CanEditCompanySettings)]
    public async Task<IActionResult> Update([FromBody] UpdateCompanySettingsCommand command)
        => HandleResult(await Mediator.Send(command));
}