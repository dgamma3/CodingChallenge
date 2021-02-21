using System.Collections.Generic;

namespace ClassLibrary4
{
    public interface ICatalogAandB
    {
        public IEnumerable<ConsoleApp6.Catalog> GetCatalogA();
        
        public IEnumerable<ConsoleApp6.Catalog> GetCatalogB();
        
        public IEnumerable<ConsoleApp6.Barcodes> GetBarcodesA();
        
        public IEnumerable<ConsoleApp6.Barcodes> GetBarcodesB();
    }
}