namespace LifeWeave.Infrastructures.Data.Taxa;

public record TaxonDataDto
{
    public required Guid ID { get; set; }
    public required string NameScientific { get; set; }
}
