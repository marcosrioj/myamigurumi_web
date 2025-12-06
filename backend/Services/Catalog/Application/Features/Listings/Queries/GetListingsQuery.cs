using Catalog.Application.Common.Dtos;
using Catalog.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Features.Listings.Queries;

public record GetListingsQuery(string? Category, string? Search, bool OnlyCustomizable) : IRequest<IReadOnlyCollection<ListingDto>>;

public class GetListingsQueryHandler(ICatalogDbContext context) : IRequestHandler<GetListingsQuery, IReadOnlyCollection<ListingDto>>
{
    public async Task<IReadOnlyCollection<ListingDto>> Handle(GetListingsQuery request, CancellationToken cancellationToken)
    {
        var query = context.Listings
            .Include(l => l.Category)
            .Include(l => l.Store)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Category))
        {
            query = query.Where(l => l.Category != null && l.Category.Slug == request.Category);
        }

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var search = request.Search.ToLowerInvariant();
            query = query.Where(l => l.Title.ToLower().Contains(search) || l.Tags.Any(t => t.ToLower().Contains(search)));
        }

        if (request.OnlyCustomizable)
        {
            query = query.Where(l => l.IsCustomizable);
        }

        var listings = await query.ToListAsync(cancellationToken);

        return listings
            .Select(l => new ListingDto(
                l.Id,
                l.Title,
                l.Description,
                l.Price,
                l.Stock,
                l.Category?.Name ?? "",
                l.Store?.Name ?? "",
                l.IsCustomizable,
                l.Tags,
                l.MediaUrls,
                l.Variations.Select(v => new ListingVariationDto(v.Id, v.Name, v.Color, v.Size, v.Price, v.Stock))
            ))
            .ToList();
    }
}
