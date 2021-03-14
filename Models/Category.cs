
using System.Collections.ObjectModel;


namespace ProjectDataWPF.Models
{
    public class Category
    {
        public int CategoryNumber { get; set; }
        public string CategoryName { get; set; }

        public ObservableCollection<Product> Products { get; set; }
    }
}
