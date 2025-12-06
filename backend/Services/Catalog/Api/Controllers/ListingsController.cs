using Catalog.Application.Common.Dtos;
using Catalog.Application.Features.Listings.Commands;
using Catalog.Application.Features.Listings.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IReadOnlyCollection<ListingDto>>> Get([FromQuery] string? category, [FromQuery] string? search, [FromQuery] bool customizable = false)
    {
        var listings = await mediator.Send(new GetListingsQuery(category, search, customizable));
        return Ok(listings);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateListingCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }
}
