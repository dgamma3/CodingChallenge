using System.Collections.Generic;
using MergeProducts;

namespace Tests
{
    public class TestImport : ICatalogAandB
    {

        private IEnumerable<Catalog> CatalogA { get; set; }
        private IEnumerable<Catalog> CatalogB { get; set; }
        private IEnumerable<Barcodes> BarcodesA { get; set; }
        private IEnumerable<Barcodes> BarcodesB { get; set; }
        public TestImport(IEnumerable<Catalog> catalogA, IEnumerable<Catalog> catalogB, IEnumerable<Barcodes> barcodesA, IEnumerable<Barcodes> barcodesB)
        {
            this.CatalogA = catalogA;
            this.CatalogB = catalogB;
            this.BarcodesA =  barcodesA;
            this.BarcodesB = barcodesB;
        }
        public IEnumerable<Catalog> GetCatalogA()
        {
            return this.CatalogA;
        }

        public IEnumerable<Catalog> GetCatalogB()
        {
            return this.CatalogB;
        }

        public IEnumerable<Barcodes> GetBarcodesA()
        {
            return BarcodesA;
        }

        public IEnumerable<Barcodes> GetBarcodesB()
        {
            return BarcodesB;
        }
    }
}