namespace LifeWeave.Infrastructures.Data.Taxons;

public class TaxonReadDataService(AppDBContext _dbContext) : ITaxonReadDataService
{
    public async Task<IReadOnlyCollection<TaxonDataDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Taxons
            .Select(t => new TaxonDataDto
            {
                ID = t.ID,
                NameScientific = t.NameScientific
            })
            .ToArrayAsync();
    } 
}
