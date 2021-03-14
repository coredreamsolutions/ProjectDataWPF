using System.ComponentModel;

namespace ProjectDataWPF.Models
{
    public class Product
    {
      
        [DisplayName("Product #")]
        public string ProductNumber { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public bool PurchasedItem { get; set; }
        public bool SalesItem { get; set; }
        [DisplayName("Auto List")]
        public bool AutoCreatePOSItem { get; set; }
        [DisplayName("Category #")]
        public int CategoryNumber { get; set; }
        [DisplayName("Department #")]
        public int DepartmentNumber { get; set; }
        public bool Scannable { get; set; }


        public Category Category { get; set; }

        
    }
}

