using Microservice.BusinessLogic;
using Microservice.BusinessLogic.Master;
using Microservice.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bootcamp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        iSupplierService _supplierService = new SupplierService();
        SupplierParam supplierParam = new SupplierParam();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            var name = NameTextbox.Text;
            if(string.IsNullOrWhiteSpace(name) == true)
            {
                MessageBox.Show("Name Field must not be empty or whitespace");
            }
            else
            {
                supplierParam.Name = name;
                _supplierService.Insert(supplierParam);
            }
            
        }

        private void NameTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z .]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void NameTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LengthTextbox.Text = NameTextbox.Text.Length.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SupplierGrid.ItemsSource = _supplierService.Get();
            SupplierCombobox.ItemsSource = _supplierService.Get();

        }

        private void SupplierGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = SupplierGrid.SelectedItem;
            NameTextbox.Text = (SupplierGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var search = SearchBox.Text;
            var category = CategoryCombo.SelectedItem.ToString();
            if(category == "Id")
            {
                
            }

        }
    }
}
