namespace LifeWeave.Infrastructures.Data.Taxa;

public interface ITaxonReadDataService
{
    /// <summary>
    /// Retrieves all unordered taxa.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>All unordered taxa.</returns>
    Task<IReadOnlyCollection<TaxonDataDto>> GetAsync(CancellationToken cancellationToken = default);
}
