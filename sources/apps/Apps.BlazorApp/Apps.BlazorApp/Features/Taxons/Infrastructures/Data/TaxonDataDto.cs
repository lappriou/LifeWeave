namespace LifeWeave.Apps.BlazorApp.Features.Taxons.Infrastructures.Data;

public record TaxonDataDto
{
    public required Guid ID { get; set; }
    public required string NameScientific { get; set; }
}
