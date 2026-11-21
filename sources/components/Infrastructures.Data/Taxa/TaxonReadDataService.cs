namespace LifeWeave.Infrastructures.Data.Taxa;

public class TaxonReadDataService(AppDBContext _dbContext) : ITaxonReadDataService
{
    public async Task<IReadOnlyCollection<TaxonDataDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Taxa
            .Select(t => new TaxonDataDto
            {
                ID = t.ID,
                NameScientific = t.NameScientific
            })
            .ToArrayAsync();
    } 
}
