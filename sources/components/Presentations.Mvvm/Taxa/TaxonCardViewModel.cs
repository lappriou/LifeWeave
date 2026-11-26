using LifeWeave.Infrastructures.Data.Taxa;

using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Disposables.Fluent;

namespace LifeWeave.Presentations.Mvvm.Taxa;

public class TaxonCardViewModel : ViewModelBase, IDisposable
{
    private readonly CompositeDisposable _disposables = new();
    public const string ColLinkName = "Catalogue of Life";
    public const string ColTaxonUrlBase = "https://www.catalogueoflife.org/data/taxon/";
    
    public string ColHref
    {
        get;
        private set => this.RaiseAndSetIfChanged(ref field, value);
    }

    public const string GbifLinkName = "Gbif";
    public const string GbifTaxonUrlBase = "https://www.gbif.org/taxon/";

    public string GbifHref
    {
        get;
        private set => this.RaiseAndSetIfChanged(ref field, value);
    }

    public TaxonDataDto? Taxon
    {
        get;
        set => this.RaiseAndSetIfChanged(ref field, value);
    }

    public TaxonCardViewModel()
    {
        IObserver<TaxonDataDto?> taxonObserver = Observer.Create<TaxonDataDto?>(taxon =>
        {
            if (taxon != null)
            {
                ColHref = $"{ColTaxonUrlBase}{taxon.ColID}";
                GbifHref = $"{GbifTaxonUrlBase}{taxon.ColID}";
            }
        });

        this.WhenAnyValue(x => x.Taxon!)
            .Subscribe(taxonObserver)
            .DisposeWith(_disposables);
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
