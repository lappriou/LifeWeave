namespace LifeWeave.Infrastructures.Data.Taxons;

public record TaxonDataDto
{
    public required Guid ID { get; set; }
    public required string NameScientific { get; set; }
}
