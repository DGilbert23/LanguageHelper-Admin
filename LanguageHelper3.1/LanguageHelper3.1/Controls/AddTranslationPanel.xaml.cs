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
    /// Interaction logic for AddTranslationPanel.xaml
    /// </summary>
    public partial class AddTranslationPanel : UserControl
    {

        public AddTranslationPanel()
        {
            InitializeComponent();
            HelperMethods.SetCBLanaguageJP(cbHiragana);
            HelperMethods.SetCBLanaguageJP(cbKanji);
            HelperMethods.SetTBLanaguageEnglish(tbEnglish);
            HelperMethods.SetTBLanaguageJP(tbKanji);
        }        

        //---- Method Handling rbNewKanji Checked Event
        //-- When the RadioButton rbNewKanji is checked, this method enables the TextBox tbNewKanji,
        //- sets its visibility to Visible and the visibilty of the ComboBox cbKanji to Hidden.
        private void rbNewKanji_Checked(object sender, RoutedEventArgs e)
        {
            tbKanji.IsEnabled = true;
            tbKanji.Visibility = Visibility.Visible;
            cbKanji.Visibility = Visibility.Hidden;
        }

        //---- Method Handling rbOldKanji Checked Event
        //-- When the RadioButton rbOldKanji is checked, this method sets the visibility of the 
        //- ComboBox cbKanji to Visible, and the visibility of the TextBox tbKanji to Hidden.
        //- Afterwards, it uses the global DBController to fill the cbKanji ComboBox with Kanji records.
        private void rbOldKanji_Checked(object sender, RoutedEventArgs e)
        {
            tbKanji.Visibility = Visibility.Hidden;
            cbKanji.Visibility = Visibility.Visible;

            Variables.dBController.FillComboBoxKanji(cbKanji);
        }

        //---- Method Handling rbNoKanji Checked Event
        //-- When the RadioButton rbNoKanji is checked, this method disables the TextBox tbNewKanji,
        //- sets its visibility to Hidden and the visibilty of the ComboBox cbKanji to Hidden.
        private void rbNoKanji_Checked(object sender, RoutedEventArgs e)
        {
            tbKanji.IsEnabled = false;
            tbKanji.Visibility = Visibility.Visible;
            cbKanji.Visibility = Visibility.Hidden;
        }

        //---- Method Handling btnAddTranslation Click Event
        //-- This method first creates a boolean variable, 'success', that is false.  Then it checks if 
        //- the ComboBox cbHiragana's SelectedValue is not null (something was chosen) and if the TextBox
        //- tbEnglish's Text is an empty string (something was entered).  If so, it puts both of those fields 
        //- into their respective string variables as well as creates a 'kanji' string that is null.
        //- Next, if the RadioButton rbNewKanji is checked, the kanji string is set to the TextBox tbKanji's
        //- text.  If not, then if the rbOldKanji is checked, it is set to the cbKanji's SelectedValue.
        //- If neither are checked (also includes the option that rbNoKanji is checked) the 'kanji' string is 
        //- allowed to remain null.  After that, the global DBController is called to insert the new translation
        //- and its returned boolean is stored in the 'success' variable, and a second time to attempt to add the
        //- 'english' string to the EnglishWords table.  That variable is then used to, if true, display the 
        //- lblSuccess hide the lblError, and call the DBController to update the mainGrid. If false it will 
        //- display the lblError and hide the lblSuccess.
        private void btnAddTranslation_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;

            if(cbHiragana.SelectedValue != null && tbEnglish.Text != "")
            {
                string hiragana = cbHiragana.SelectedValue.ToString();
                string english = tbEnglish.Text;
                string kanji = null;

                if (rbNewKanji.IsChecked == true)
                {
                    kanji = tbKanji.Text;
                }
                else if(rbOldKanji.IsChecked == true)
                {
                    kanji = cbKanji.SelectedValue.ToString();
                }

                success = Variables.dBController.InsertTranslation(hiragana, english, kanji);
                success = Variables.dBController.InsertEnglishWord(english);
            }

            if(success)
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
