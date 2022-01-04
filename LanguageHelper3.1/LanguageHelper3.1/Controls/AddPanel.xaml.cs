using LanguageHelper3._1.Classes;
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

namespace LanguageHelper3._1.Controls
{
    /// <summary>
    /// Interaction logic for AddPanel.xaml
    /// </summary>
    public partial class AddPanel : UserControl
    {
        public AddPanel()
        {
            InitializeComponent();
        }

        //---- Method for Handling the buttonShowAddTranslation Click Event
        //-- If the AddWordPanel is currently Hidden, it will change its visibility to Visible,
        //-- and set the AddTranslationPanel to Hidden.  Otherwise is currently Visible, it will change to
        //-- to hidden.
        private void buttonShowAddWord_Click(object sender, RoutedEventArgs e)
        {
            if (AddWordPanel.Visibility == Visibility.Hidden)
            {
                AddWordPanel.Visibility = Visibility.Visible;
                AddTranslationPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                AddWordPanel.Visibility = Visibility.Hidden;
            }
        }

        //---- Method for Handling the buttonShowAddTranslation Click Event
        //-- If the AddTranslationPanel is currently Hidden, it will change its visibility to Visible,
        //- and set the AddWordPanel to Hidden, as well as filling the AddTranslationPanel's ComboxBox, cbHiragana,
        //- using the global DBController.  Otherwise, it will set the AddTranslationPanel's visibility to Hidden.
        private void buttonShowAddTranslation_Click(object sender, RoutedEventArgs e)
        {
            if (AddTranslationPanel.Visibility == Visibility.Hidden)
            {
                AddTranslationPanel.Visibility = Visibility.Visible;
                AddWordPanel.Visibility = Visibility.Hidden;

                AddTranslationPanel.cbHiragana.ItemsSource = null;
                Variables.dBController.FillComboBoxHiragana(AddTranslationPanel.cbHiragana);
            }
            else
            {
                AddTranslationPanel.Visibility = Visibility.Hidden;
            }
        }
    }
}
