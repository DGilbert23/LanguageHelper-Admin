using LanguageHelper3._1.Classes;
using LanguageHelper3._1.Windows;
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

namespace LanguageHelper3._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //---- Constructor for MainWindow
        //-- Other than running IDE generated code, we set our shared Variable class'
        //- connectionString, mainGrid and dBController so they may be referenced easier by
        //- other Windows/Controls.
        //- In the future, methods containing only IDE generated code will not be documented.
        public MainWindow()
        {
            InitializeComponent();

            Variables.connectionString = Properties.Settings.Default.ConnectionString;
            Variables.mainGrid = dataGridMain;
            Variables.dBController = new DBController();
        }

        //---- Method handling the Window_Loaded event.
        //-- This method opens a WindowLogin window to handle the user authentication.  
        //- If successful, it uses the DBController class to fill the data grid.
        //- If not successful, the window closes itself and shutdown the application.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowLogin login = new WindowLogin();
            this.Hide();
            login.ShowDialog();

            if (Variables.validUser)
            {
                this.Show();
                this.WindowState = WindowState.Normal;

                Variables.dBController.FillDataGrid(dataGridMain);                
            }
            else
            {
                this.Close();
            }
        }

        //---- Method handling the Click event for the buttonShowRemovePanel button.
        //-- This method changes the visibility to Visible of the gridAuxilary if is current collapsed,
        //- sets the visibility of the AddPanel to Hidden if currently Visible,
        //- and sets the visibility of the RemovePanel to Visible.
        //- If the gridAuxilary is already Visible, and the RemovePanel is hidden, the gridAuxilary
        //- will be changed to Collapsed.  Otherwise the RemovePanel will simply be set to Visible, and
        //- the AddPanel set to Hidden.
        private void buttonShowRemovePanel_Click(object sender, RoutedEventArgs e)
        {
            if(gridAuxilary.Visibility == Visibility.Collapsed)
            {
                gridAuxilary.Visibility = Visibility.Visible;
                AddPanel.Visibility = Visibility.Hidden;
                RemovePanel.Visibility = Visibility.Visible;
            }
            else if(gridAuxilary.Visibility == Visibility.Visible && RemovePanel.Visibility == Visibility.Visible)
            {
                gridAuxilary.Visibility = Visibility.Collapsed;
            }
            else
            {
                AddPanel.Visibility = Visibility.Hidden;
                RemovePanel.Visibility = Visibility.Visible;
            }
        }

        //---- Method handling the Click event for the buttonShowAddPanel button.
        //-- This method changes the visibility to Visible of the gridAuxilary if is current collapsed,
        //- sets the visibility of the RemovePanel to Hidden if currently Visible,
        //- and sets the visibility of the AddPanel to Visible.
        //- If the gridAuxilary is already Visible, and the AddPanel is hidden, the gridAuxilary
        //- will be changed to Collapsed.  Otherwise the AddPanel will simply be set to Visible, and
        //- the RemovePanel set to Hidden.
        private void buttonShowAddPanel_Click(object sender, RoutedEventArgs e)
        {
            if (gridAuxilary.Visibility == Visibility.Collapsed)
            {
                gridAuxilary.Visibility = Visibility.Visible;
                RemovePanel.Visibility = Visibility.Hidden;
                AddPanel.Visibility = Visibility.Visible;
            }
            else if (gridAuxilary.Visibility == Visibility.Visible && AddPanel.Visibility == Visibility.Visible)
            {
                gridAuxilary.Visibility = Visibility.Collapsed;
            }
            else
            {
                RemovePanel.Visibility = Visibility.Hidden;
                AddPanel.Visibility = Visibility.Visible;
            }
        }

        private void ButtonShowCharts_Click(object sender, RoutedEventArgs e)
        {
            if (gridCharacterCharts.Visibility == Visibility.Collapsed)
            {
                gridCharacterCharts.Visibility = Visibility.Visible;
            }
            else
            {
                gridCharacterCharts.Visibility = Visibility.Collapsed;
            }        
        }
    }
}
