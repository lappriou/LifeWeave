namespace LifeWeave.Infrastructures.Data.Taxa;

[Index(nameof(ColID), IsUnique = true)]
public class TaxonEFEntity
{
    public required Guid ID { get; set; }

    /// <summary>
    /// Get or Set the Catalog Of Life Identifiant
    /// </summary>
    public required string ColID { get; set; }
    public required string NameScientific { get; set; }
}
