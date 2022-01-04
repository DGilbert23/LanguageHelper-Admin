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
    /// Interaction logic for RemoveWordPanel.xaml
    /// </summary>
    public partial class RemoveWordPanel : UserControl
    {
        public RemoveWordPanel()
        {
            InitializeComponent();
        }


        //---- Method for Handling rbJPWord Checked Event
        //-- This method simply calls the DBController to fill the main ComboBox with Japanese words.
        private void rbJPWord_Checked(object sender, RoutedEventArgs e)
        {
            Variables.dBController.FillComboBoxHiragana(cbWordList);
            HelperMethods.SetCBLanaguageJP(cbWordList);
        }

        //---- Method for Handling rbEnglishWord Checked Event
        //-- This method simply calls the DBController to fill the main ComboBox with English words.
        private void rbEnglishWord_Checked(object sender, RoutedEventArgs e)
        {
            Variables.dBController.FillComboBoxEnglish(cbWordList);
            HelperMethods.SetCBLanaguageEnglish(cbWordList);
        }

        //---- Method for Handling the btnRemoveword Click Event
        //-- This method firsts creates a boolean variable, 'success' and sets it so false.  Then it checks 
        //- to see if an item was selected from the ComboBox cbWordList and if so, checks to see which 
        //- RadioButton is checked.  If rbJPWord is checked, the DBController is called to remove the 
        //- Japanese word, and its result is stored in 'success'.  If rbEnglishWord is checked then the
        //- DBController is called to remove the English word and its results is stored in 'success'.
        //- The 'success' variable is then used to determine which of the two labels to show (lblError or lblSuccess)
        //- and if the value is true, also calls the DBController to update the mainGrid.
        private void btnRemoveWord_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;

            if (cbWordList.SelectedValue != null)
            { 
                if (rbJPWord.IsChecked == true)
                {
                    success = Variables.dBController.RemoveJapaneseWord(cbWordList.SelectedValue.ToString());
                }
                else if (rbEnglishWord.IsChecked == true)
                {
                    success = Variables.dBController.RemoveEnglishWord(cbWordList.SelectedValue.ToString());
                }
            }

            if (success)
            {
                lblError.Visibility = Visibility.Hidden;
                lblSuccess.Visibility = Visibility.Visible;

                Variables.dBController.FillDataGrid(Variables.mainGrid);
            }
            else
            {
                lblError.Visibility = Visibility.Visible;
                lblSuccess.Visibility = Visibility.Hidden;
            }
        }
    }
}
