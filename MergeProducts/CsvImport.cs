using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace MergeProducts
{
    public class CsvImport : ICatalogAandB
    {
        public CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine,
            HeaderValidated = null,
            MissingFieldFound = null
        };

        private string catalogA { get; set; }
        private string catalogB { get; set; }
        private string barcodesA { get; set; }
        private string barcodesB { get; set; }

        public CsvImport(string catalogA, string catalogB, string barcodesA, string barcodesB)
        {
            this.catalogA = catalogA;
            this.catalogB = catalogB;
            this.barcodesA = barcodesA;
            this.barcodesB = barcodesB;
        }

        public IEnumerable<Catalog> GetCatalogA()
        {
            using (var reader = new StreamReader(this.catalogA))
            using (var csv = new CsvReader(reader, this.config))
            {
                return csv.GetRecords<Catalog>().ToList();
            }
        }

        public IEnumerable<Catalog> GetCatalogB()
        {
            using (var reader = new StreamReader(this.catalogB))
            using (var csv = new CsvReader(reader, this.config))
            {
                return csv.GetRecords<Catalog>().ToList();
            }
        }

        public IEnumerable<Barcodes> GetBarcodesA()
        {
            using (var reader = new StreamReader(this.barcodesA))
            using (var csv = new CsvReader(reader, this.config))
            {
                return csv.GetRecords<Barcodes>().ToList();
            }

        }

        public IEnumerable<Barcodes> GetBarcodesB()
        {
            using (var reader = new StreamReader(this.barcodesB))
            using (var csv = new CsvReader(reader, this.config))
            {
                return csv.GetRecords<Barcodes>().ToList();

            }
        }

    }
}