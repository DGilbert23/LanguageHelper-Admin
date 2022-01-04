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
using LanguageHelper3._1.Classes;

namespace LanguageHelper3._1.Controls
{
    /// <summary>
    /// Interaction logic for AddWordPanel.xaml
    /// </summary>
    public partial class AddWordPanel : UserControl
    {
        public AddWordPanel()
        {
            InitializeComponent();
            HelperMethods.SetTBLanaguageJP(tbHiragana);
            HelperMethods.SetTBLanaguageJP(tbHiragana);
            HelperMethods.SetTBLanaguageEnglish(tbRomanji);
            HelperMethods.SetTBLanaguageEnglish(tbEnglish);
        }

        //---- Method Handling the buttonAddWord Click Event
        //-- First, this method checks if the tbHiragana and tbRomanji text boxes have content
        //- and if they do, it calls the DBController class to insert the data.  Next, it checks
        //- if the tbEnglish is content and if so calls the DBController to insert, then does the
        //- same for the tbKanji.  If the tbEnglish had content, the method calls the DBController
        //- to enter a translation for the information (Kanji is not checked as it is allowed to be
        //- null in the Translations table.  Each DBController call returns a bool value of true if
        //- successful, which is used at the end of the method to set the Visibilty of the labels
        //- lblError and lblSuccess.  If this value is true, the DBController is called once more
        //- to update the mainGrid.
        private void buttonAddWord_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;

            if (tbHiragana.Text != "" && tbRomanji.Text != "")
            {
                string kanji = null;
                string english = null;

                string hiragana = tbHiragana.Text;
                string romanji = tbRomanji.Text;
                success =  Variables.dBController.InsertHiragana(hiragana, romanji);

                if (tbEnglish.Text != "")
                {
                    english = tbEnglish.Text;
                    success = Variables.dBController.InsertEnglishWord(english);

                    if (tbKanji.Text != "")
                    {
                        kanji = tbKanji.Text;
                        success = Variables.dBController.InsertKanji(kanji);
                    }

                    success = Variables.dBController.InsertTranslation(hiragana, english, kanji);
                }         
            }
            
            if(success)
            {
                lblError.Visibility = Visibility.Collapsed;
                lblSuccess.Visibility = Visibility.Visible;
                tbHiragana.Text = "";
                tbKanji.Text = "";
                tbRomanji.Text = "";
                tbEnglish.Text = "";

                Variables.dBController.FillDataGrid(Variables.mainGrid);
            }
            else
            {
                lblError.Visibility = Visibility.Visible;
                lblSuccess.Visibility = Visibility.Collapsed;
            }
        }
    }
}
