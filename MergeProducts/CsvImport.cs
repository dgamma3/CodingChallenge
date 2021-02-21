using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using ClassLibrary4;
using CsvHelper;
using CsvHelper.Configuration;

namespace ConsoleApp6
{
    public class CsvImport : ICatalogAandB
    {
        public CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine,
            HeaderValidated = null,
            MissingFieldFound = null
        };

        private string catelogA { get; set; }
        private string catelogB { get; set; }
        private string barcodesA { get; set; }
        private string barcodesB { get; set; }

        public CsvImport(string catelogA, string catelogB, string barcodesA, string barcodesB)
        {
            this.catelogA = catelogA;
            this.catelogB = catelogB;
            this.barcodesA = barcodesA;
            this.barcodesB = barcodesB;
        }

        public IEnumerable<Catalog> GetCatalogA()
        {
            using (var reader = new StreamReader(catelogA))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<Catalog>().ToList();
            }
        }

        public IEnumerable<Catalog> GetCatalogB()
        {
            using (var reader = new StreamReader(catelogB))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<Catalog>().ToList();
            }
        }

        public IEnumerable<Barcodes> GetBarcodesA()
        {
            using (var reader = new StreamReader(barcodesA))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<Barcodes>().ToList();
            }

        }

        public IEnumerable<Barcodes> GetBarcodesB()
        {
            using (var reader = new StreamReader(barcodesB))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<Barcodes>().ToList();

            }
        }

    }
}