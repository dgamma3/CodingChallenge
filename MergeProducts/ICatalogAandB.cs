using System.Collections.Generic;

namespace MergeProducts
{
    public interface ICatalogAandB
    {
        public IEnumerable<Catalog> GetCatalogA();
        
        public IEnumerable<Catalog> GetCatalogB();
        
        public IEnumerable<Barcodes> GetBarcodesA();
        
        public IEnumerable<Barcodes> GetBarcodesB();
    }
}