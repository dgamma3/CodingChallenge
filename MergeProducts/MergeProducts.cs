using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeProducts
{
    public static class MergeProducts
    {
        public static IEnumerable<Result> MergeProductsFromTwoCompanies(ICatalogAandB input)
        {
            var catalogA = input.GetCatalogA().ToArray();
            var catalogB = input.GetCatalogB().ToArray();
            var barcodesFromB = input.GetBarcodesB().ToArray();
            var barcodesFromA = input.GetBarcodesA().ToArray();

            var sharedBarcodes = GetSharedBarcodes(barcodesFromB, barcodesFromA);
            var barcodesOnlyFromA = GetBarcodesOnlyFromA(sharedBarcodes, barcodesFromA);
            var barcodesOnlyFromB = GetBarcodesOnlyFromB(sharedBarcodes, barcodesFromB);

            var mergedBarcodes =
                CreateMergedBarcodes(sharedBarcodes, barcodesOnlyFromA, barcodesOnlyFromB, catalogA, catalogB);

            return mergedBarcodes;
        }
        
        private static IEnumerable<Result> CreateMergedBarcodes(Barcodes[] sharedBarcodes, Barcodes[] barcodesOnlyFromA,
            Barcodes[] barcodesOnlyFromB, Catalog[] catalogA, Catalog[] catalogB)
        {
            var mergedBarcodes = new HashSet<Result>();

            var transformedSharedBarcodes
                = TransformBarcodes(sharedBarcodes, catalogA, "A");
            var transformedBarcodesOnlyFromA = TransformBarcodes(barcodesOnlyFromA, catalogA, "A");
            var transformedBarcodesOnlyFromB = TransformBarcodes(barcodesOnlyFromB, catalogB, "B");

            transformedSharedBarcodes.UnionWith(transformedBarcodesOnlyFromA);
            transformedSharedBarcodes.UnionWith(transformedBarcodesOnlyFromB);

            return transformedSharedBarcodes;
        }

        private static HashSet<Result> TransformBarcodes(Barcodes[] barcodesToTransform, Catalog[] catalog,
            string sourceCompany)
        {
            return barcodesToTransform.Select(barcode => new Result()
            {
                SKU = barcode.SKU,
                Description = GetProductDescriptionGivenSku(barcode.SKU, catalog),
                Source = sourceCompany
            }).ToHashSet(new ComparerTwoResults());
        }

        private static string GetProductDescriptionGivenSku(string sku, Catalog[] catalog)
        {
            return catalog.First(x => string.Equals(x.SKU, sku)).Description;
        }

        public static Barcodes[] GetBarcodesOnlyFromB(Barcodes[] sharedBarcodes, Barcodes[] barcodesFromB)
        {
            return barcodesFromB.Except(sharedBarcodes, new ComparerTwoBarcodes()).ToArray();
        }

        private static Barcodes[] GetSharedBarcodes(Barcodes[] barcodesFromB, Barcodes[] barcodesFromA)
        {
            return barcodesFromA.Intersect(barcodesFromB, new ComparerTwoBarcodes()).ToArray();
        }

        public static Barcodes[] GetBarcodesOnlyFromA(Barcodes[] sharedBarcodes, Barcodes[] barcodesFromA)
        {
            return barcodesFromA.Except(sharedBarcodes, new ComparerTwoBarcodes()).ToArray();
        }
    }


    class ComparerTwoBarcodes : IEqualityComparer<Barcodes>
    {
        public bool Equals(Barcodes x, Barcodes y)
        {
            if (String.Equals(x.Barcode, y.Barcode))
            {
                return true;
            }

            return false;
        }
        
        public int GetHashCode(Barcodes barcodes)
        {
            return 0;
        }
    }

    class ComparerTwoResults : IEqualityComparer<Result>
    {
        public bool Equals(Result x, Result y)
        {
            if (String.Equals(x.Description.ToString(), y.Description.ToString()) &&
                String.Equals(x.Source.ToString(), y.Source.ToString()) &&
                String.Equals(x.SKU.ToString(), y.SKU.ToString()))
            {
                return true;
            }

            ;
            return false;
        }


        public int GetHashCode(Result barcodes)
        {
            return 0; //not used
        }
    }
}