using DelFood.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using DelFood.PageMain;

namespace DelFood.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
        }

        private void btncreate_Click(object sender, RoutedEventArgs e)
        {
            if (ODBConnectionHelper.entObj.User.Count(x => x.Login == txtUser.Text) < 1)
            {
                if (txtPass.Password == txtpassans.Password)
                {
                    DataBase.User user = new DataBase.User
                    {
                        Login = txtUser.Text,
                        Password = txtpassans.Password,
                        IdRole = 1
                    };
                    ODBConnectionHelper.entObj.User.Add(user);
                    ODBConnectionHelper.entObj.SaveChanges();
                    FrameApp.frmObj.GoBack();
                    MessageBox.Show("Урааа, вы создали аккаунт");
                }
            }
            else
            {
                MessageBox.Show("Такой пользователь уже существует!");
            }
        }

        private void txtpassans_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPass.Password == txtpassans.Password)
            {
                btncreate.IsEnabled = true;
                txtpassans.Background = Brushes.LightGreen;
                txtpassans.BorderBrush = Brushes.Green;

            }
            else
            {
                btncreate.IsEnabled = false;
                txtpassans.Background = Brushes.LightCoral;
                txtpassans.BorderBrush = Brushes.Red;

            }

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
