namespace LifeWeave.Infrastructures.Data.Taxa;

public record TaxonDataDto
{
    public required Guid ID { get; set; }

    /// <summary>
    /// Get or Set the Catalog Of Life Identifiant
    /// </summary>
    public required string ColID { get; set; }

    public required string NameScientific { get; set; }
}
