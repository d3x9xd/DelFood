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

namespace DelFood.User
{
    /// <summary>
    /// Логика взаимодействия для PageStore.xaml
    /// </summary>
    public partial class PageStore : Page
    {
        public PageStore()
        {
            InitializeComponent();
            MaterialList.ItemsSource = App.db.Product.Where(x => x.Name.Contains(TxbSearch.Text)).Take(15).ToList();
            ResultTxb.Text = MaterialList.Items.Count + "/" + App.db.Product.Where(x => x.Name.Contains(TxbSearch.Text)).Count().ToString();
        }
    

        private void CHX1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Это всё что вы хотите добавить в корзину?", "Серьезный вопрос", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                MessageBox.Show("Ваш товар был добавлен в корзину!");
            }
            else if (dialogResult == MessageBoxResult.No)
            {

            }
        }

        private void MaterialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                MaterialList.ItemsSource = App.db.Product.Take(15).ToList();

                ResultTxb.Text = MaterialList.Items.Count + "/" + App.db.Product.Count().ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MaterialList.ItemsSource = App.db.Product.Where(x => x.Name.Contains(TxbSearch.Text)).Take(15).ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
