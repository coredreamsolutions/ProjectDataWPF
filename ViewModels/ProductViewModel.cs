using Dapper;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProjectDataWPF.Models;
using ProjectDataWPF.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ProjectDataWPF.ViewModels
{
    public class ProductViewModel : ObservableObject
    {
        public ProductViewModel()
        {
            GetProducts();
            GetProductsCommand = new RelayCommand(GetProducts);
        }

        public ICommand GetProductsCommand { get; }

        public ObservableCollection<Product> Products { get; set; } = new();
        private void GetProducts()
        {
            using IDbConnection cnn = Database.GetConnection();

            var result = cnn.Query<Product>(
               $"SELECT * FROM ProductDefinitions ORDER BY ProductName ASC").ToList();

            Products = new ObservableCollection<Product>(result);
        }
    }
}
