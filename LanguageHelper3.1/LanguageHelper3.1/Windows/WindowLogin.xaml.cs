using LanguageHelper3._1.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace LanguageHelper3._1.Windows
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string conString = Variables.connectionString + "User ID=" + tbUserName.Text.Trim() + ";Password=" + pbPassword.Password.Trim();

            try
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();
                connection.Close();

                Variables.connectionString = conString;
                Variables.validUser = true;
                this.Close();
            }
            catch (SqlException ex)
            {
                Console.Out.Write(ex.Message);
                labelError.Visibility = Visibility.Visible;

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbUserName.Focus();
        }
    }
}
