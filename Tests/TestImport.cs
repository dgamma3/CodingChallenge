using System.Collections.Generic;
using ClassLibrary4;
using ConsoleApp6;

namespace Tests
{
    public class TestImport : ICatalogAandB
    {

        private IEnumerable<Catalog> CatelogA { get; set; }
        private IEnumerable<Catalog> CatelogB { get; set; }
        private IEnumerable<Barcodes> BarcodesA { get; set; }
        private IEnumerable<Barcodes> BarcodesB { get; set; }
        public TestImport(IEnumerable<Catalog> catelogA, IEnumerable<Catalog> catelogB, IEnumerable<Barcodes> barcodesA, IEnumerable<Barcodes> barcodesB)
        {
            this.CatelogA = catelogA;
            this.CatelogB = catelogB;
            this.BarcodesA =  barcodesA;
            this.BarcodesB = barcodesB;
        }
        public IEnumerable<Catalog> GetCatalogA()
        {
            return CatelogA;
        }

        public IEnumerable<Catalog> GetCatalogB()
        {
            return CatelogB;
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