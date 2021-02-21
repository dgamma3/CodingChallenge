using System.Linq;
using ConsoleApp6;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
       private const string DescriptionOfFirstItemOfCompanyA = "First Item Of Company A";
       private const string SKYOfFirstItemOfCompanyA = "001";
       private const string BarcodeOfFirstItemOfCompanyA = "abc";
       
       private const string DescriptionOfFirstItemOfCompanyB = "First Item of Company B" ;
       private const string SKYOfFirstItemOfCompanyB = "001";
       private const string BarcodeOfFirstItemOfCompanyB = "def";
       
       private const string SharedBarcodeOfFirstItem = "hij";
       private const string CompanyA = "A";
        private const string CompanyB = "B";
       

        [Test]
        public void Given_Empty_Products_For_Company_A_and_B_Return_No_Products()
        {
            //arrange
            var barcodeA =  new Barcodes[0];
            var catalogA =  new Catalog[0];

            var barcodeB =  new Barcodes[0];
            var catalogB =  new Catalog[0];

            //act
            var mergedProducts =  MergeProducts.MergeProducts.MergeProductsFromTwoCompanies(new TestImport(catalogA,catalogB,barcodeA,barcodeB));
            
            //assert
            Assert.IsFalse(mergedProducts.Any());
        }
        
        [Test]
        public void Given_Products_For_Company_A_and_Empty_Products_For_Company_B_Return_Company_A_Products()
        {
            //arrange
            var catalogA =   new[]
            {
                new Catalog()
                {
                    SKU = SKYOfFirstItemOfCompanyA,
                    Description = DescriptionOfFirstItemOfCompanyA
                }
            };
            
            var barcodeA =   new[]
            {
                new Barcodes()
                {
                    Barcode = BarcodeOfFirstItemOfCompanyA,
                    SKU = SKYOfFirstItemOfCompanyA
                }
            };

            var barcodeB =  new Barcodes[0];
            var catalogB =  new Catalog[0];

            //act
            var mergedProducts =  MergeProducts.MergeProducts.MergeProductsFromTwoCompanies(new TestImport(catalogA,catalogB,barcodeA,barcodeB));
            
            //assert
            var onlyItem = mergedProducts.First();
            Assert.IsTrue(mergedProducts.Count() == 1);
            
            Assert.IsTrue(onlyItem.Description == DescriptionOfFirstItemOfCompanyA);
            Assert.IsTrue(onlyItem.SKU == SKYOfFirstItemOfCompanyA);
            Assert.IsTrue(onlyItem.Source == CompanyA);
        }
         
        [Test]
        public void Given_Products_For_Company_B_and_Empty_Products_For_Company_A_Return_Company_B_Products()
        {
            //arrange
            var barcodeA =  new Barcodes[0];
            var catalogA =  new Catalog[0];
            
            var catalogB =   new[]
            {
                new Catalog()
                {
                    SKU = SKYOfFirstItemOfCompanyB,
                    Description = DescriptionOfFirstItemOfCompanyB
                }
            };
            
            var barcodeB =   new[]
            {
                new Barcodes()
                {
                    Barcode = BarcodeOfFirstItemOfCompanyB,
                    SKU = SKYOfFirstItemOfCompanyB
                }
            };

            //act
            var mergedProducts =  MergeProducts.MergeProducts.MergeProductsFromTwoCompanies(new TestImport(catalogA,catalogB,barcodeA,barcodeB));
            
            //assert
            var onlyItem = mergedProducts.First();
            Assert.IsTrue(mergedProducts.Count() == 1);
            
            Assert.IsTrue(onlyItem.Description == DescriptionOfFirstItemOfCompanyB);
            Assert.IsTrue(onlyItem.SKU == SKYOfFirstItemOfCompanyB);
            Assert.IsTrue(onlyItem.Source == CompanyB);
        }
        
        [Test]
        public void Given_Products_Are_Only_Shared_Between_Company_A_And_B_Return_Merged_Products_That_Are_Not_Duplicated()
        {
            //arrange
            var catalogA =   new[]
            {
                new Catalog()
                {
                    SKU = SKYOfFirstItemOfCompanyA,
                    Description = DescriptionOfFirstItemOfCompanyA
                }
            };
            
            var barcodeA =   new[]
            {
                new Barcodes()
                {
                    Barcode = SharedBarcodeOfFirstItem,
                    SKU = SKYOfFirstItemOfCompanyA
                }
            };
            var catalogB =   new[]
            {
                new Catalog()
                {
                    SKU = SKYOfFirstItemOfCompanyB,
                    Description = DescriptionOfFirstItemOfCompanyB
                }
            };
            
            var barcodeB =   new[]
            {
                new Barcodes()
                {
                    Barcode = SharedBarcodeOfFirstItem,
                    SKU = SKYOfFirstItemOfCompanyB
                }
            };

            //act
            var mergedProducts =  MergeProducts.MergeProducts.MergeProductsFromTwoCompanies(new TestImport(catalogA,catalogB,barcodeA,barcodeB));
            
            //assert
            var onlyItem = mergedProducts.First();
            Assert.IsTrue(mergedProducts.Count() == 1);
            
            Assert.IsTrue(onlyItem.Description == DescriptionOfFirstItemOfCompanyA);
            Assert.IsTrue(onlyItem.SKU == SKYOfFirstItemOfCompanyA);
            Assert.IsTrue(onlyItem.Source == CompanyA);
        }
        
        [Test]
        public void Given_Products_Are_Not_Shared_Between_Company_A_And_B_Return_Merged_Products_That_Are_From_Company_A_And_B()
        {
            //arrange
            var catalogA =   new[]
            {
                new Catalog()
                {
                    SKU = SKYOfFirstItemOfCompanyA,
                    Description = DescriptionOfFirstItemOfCompanyA
                }
            };
            
            var barcodeA =   new[]
            {
                new Barcodes()
                {
                    Barcode = BarcodeOfFirstItemOfCompanyA,
                    SKU = SKYOfFirstItemOfCompanyA
                }
            };
            var catalogB =   new[]
            {
                new Catalog()
                {
                    SKU = SKYOfFirstItemOfCompanyB,
                    Description = DescriptionOfFirstItemOfCompanyB
                }
            };
            
            var barcodeB =   new[]
            {
                new Barcodes()
                {
                    Barcode = BarcodeOfFirstItemOfCompanyB,
                    SKU = SKYOfFirstItemOfCompanyB
                }
            };

            //act
            var mergedProducts =  MergeProducts.MergeProducts.MergeProductsFromTwoCompanies(new TestImport(catalogA,catalogB,barcodeA,barcodeB));
            
            //assert
            Assert.IsTrue(mergedProducts.Count() == 2);
            
            var firstItem = mergedProducts.First();
            Assert.IsTrue(firstItem.Description == DescriptionOfFirstItemOfCompanyA);
            Assert.IsTrue(firstItem.SKU == SKYOfFirstItemOfCompanyA);
            Assert.IsTrue(firstItem.Source == CompanyA);
            
            var secondItem = mergedProducts.Skip(1).First();
            Assert.IsTrue(secondItem.Description == DescriptionOfFirstItemOfCompanyB);
            Assert.IsTrue(secondItem.SKU == SKYOfFirstItemOfCompanyB);
            Assert.IsTrue(secondItem.Source == CompanyB);
        }
    }
}