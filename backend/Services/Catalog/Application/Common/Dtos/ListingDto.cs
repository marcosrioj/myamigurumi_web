namespace Catalog.Application.Common.Dtos;

public record ListingDto(
    Guid Id,
    string Title,
    string Description,
    decimal Price,
    int Stock,
    string Category,
    string StoreName,
    bool IsCustomizable,
    string[] Tags,
    string[] MediaUrls,
    IEnumerable<ListingVariationDto> Variations
);

public record ListingVariationDto(Guid Id, string Name, string Color, string Size, decimal Price, int Stock);
