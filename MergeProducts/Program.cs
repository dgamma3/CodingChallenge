using System.IO;
using System.Text;
using ConsoleApp6;

namespace MergeProducts
{
    static class Program
    {
      
        public static void Main(string[] args)
        {
            var csvInupts = new CsvImport("input/CodeA.csv", "input/CodeB.csv", "input/barcodeA.csv", "input/barcodeB.csv");
            
            var mergedSet = MergeProducts.MergeProductsFromTwoCompanies(csvInupts);
            
            StreamWriter sw = new StreamWriter("output/result_output.csv", false, Encoding.ASCII);

            sw.Write($"SKU, Description, Source\n");
            //Write out the numbers 1 to 10 on the same line.
            foreach (var e in mergedSet)
            {
                sw.Write($"{e.SKU}, {e.Description}, {e.Source}\n");
            }
          sw.Close();
            
        }
        
        


    }
}