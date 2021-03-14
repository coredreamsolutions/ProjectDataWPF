using Dapper;
using ProjectDataWPF.Models;
using ProjectDataWPF.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace ProjectDataWPF.ViewModels
{
    public class CategoryViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }

        public void GetCategories()
        {
            using IDbConnection cnn = Database.GetConnection();

            var result = cnn.Query<Category>(
                $"SELECT * FROM CategoryDefinitions WHERE CategoryNumber > 0 ORDER BY CategoryName ASC;").ToList();

            Categories = new ObservableCollection<Category>(result);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
