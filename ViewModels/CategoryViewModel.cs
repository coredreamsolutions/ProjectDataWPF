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
    public class CategoryViewModel : ObservableObject
    {
        public CategoryViewModel()
        {
            GetCategoriesCommand = new RelayCommand(GetCategories);
        }

        public ICommand GetCategoriesCommand { get; }

        public ObservableCollection<Category> Categories { get; set; } = new();

        private void GetCategories()
        {

            using IDbConnection cnn = Database.GetConnection();

            var result = cnn.Query<Category>(
                $"SELECT * FROM CategoryDefinitions WHERE CategoryNumber > 0 ORDER BY CategoryName ASC;").ToList();

            Categories = new ObservableCollection<Category>(result);
        }
    }


}