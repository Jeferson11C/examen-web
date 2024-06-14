using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730pc2u20211c211.API.Hr.Domain.Model.Queries;
using si730pc2u20211c211.API.Hr.Domain.Services;
using si730pc2u20211c211.API.Hr.Interfaces.REST.Resources;
using si730pc2u20211c211.API.Hr.Interfaces.REST.Transform;

namespace si730pc2u20211c211.API.Hr.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class JoinRequestsController(IJoinRequestCommandService joinRequestCommandService,IJoinRequestQueryService joinRequestQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateJoinRequest([FromBody] CreateJoinRequestResource resource)
    {
        var validateByJoinRequestCustomerAndFabricId =
            await joinRequestQueryService.Handle(
                new GetByJoinRequestCustomerAndFabricIdQuery(resource.Name, resource.DepartmentId));
        if (validateByJoinRequestCustomerAndFabricId == null)
        {
            var joinRequest =
                await joinRequestCommandService.Handle(CreateJoinRequestCommandFromResourceAssembler
                    .ToCommandFromResource(resource));
            if (joinRequest is null) return BadRequest("No join request was created, Please try again");

            var joinRequestResource = JoinRequestResourceFromEntityAssembler.ToResourceFromEntity(joinRequest);
            return Ok(joinRequestResource);
        }
        else return BadRequest("Join request already exists, with the same name and departmentId");
    }
}