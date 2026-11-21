namespace LifeWeave.Infrastructures.Data.Taxons;

public class TaxonEFEntity
{
    public required Guid ID { get; set; }
    public required string NameScientific { get; set; }
}
