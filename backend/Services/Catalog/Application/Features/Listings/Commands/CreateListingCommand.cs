using Catalog.Application.Common.Dtos;
using Catalog.Application.Common.Interfaces;
using Catalog.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Catalog.Application.Features.Listings.Commands;

public record CreateListingCommand(string Title, string Description, decimal Price, int Stock, Guid CategoryId, Guid StoreId, bool IsCustomizable, string[] Tags, string[] MediaUrls, IEnumerable<ListingVariationDto> Variations) : IRequest<Guid>;

public class CreateListingCommandValidator : AbstractValidator<CreateListingCommand>
{
    public CreateListingCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.StoreId).NotEmpty();
    }
}

public class CreateListingCommandHandler(ICatalogDbContext context) : IRequestHandler<CreateListingCommand, Guid>
{
    public async Task<Guid> Handle(CreateListingCommand request, CancellationToken cancellationToken)
    {
        var listing = new Listing
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            CategoryId = request.CategoryId,
            StoreId = request.StoreId,
            IsCustomizable = request.IsCustomizable,
            Tags = request.Tags,
            MediaUrls = request.MediaUrls,
            Variations = request.Variations.Select(v => new ListingVariation
            {
                Id = v.Id != Guid.Empty ? v.Id : Guid.NewGuid(),
                Name = v.Name,
                Color = v.Color,
                Size = v.Size,
                Price = v.Price,
                Stock = v.Stock
            }).ToArray()
        };

        await context.Listings.AddAsync(listing, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return listing.Id;
    }
}
