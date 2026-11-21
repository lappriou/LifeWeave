namespace LifeWeave.Apps.BlazorApp.Features.Taxons.Infrastructures.Data;

public class TaxonEFEntity
{
    public required Guid ID { get; set; }
    public required string NameScientific { get; set; }
}
