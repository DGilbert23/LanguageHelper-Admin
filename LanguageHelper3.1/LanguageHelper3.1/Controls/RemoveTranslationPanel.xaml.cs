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
    /// Interaction logic for RemoveTranslationPanel.xaml
    /// </summary>
    public partial class RemoveTranslationPanel : UserControl
    {
        public RemoveTranslationPanel()
        {
            InitializeComponent();
            HelperMethods.SetCBLanaguageJP(cbHiragana);
            HelperMethods.SetCBLanaguageEnglish(cbEnglishTranslation);
        }

        private void cbHiragana_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbHiragana.SelectedValue != null)
            {
                Variables.dBController.FillComboBoxTranslations(cbEnglishTranslation, cbHiragana.SelectedValue.ToString());
            }
            else
            {
                cbEnglishTranslation.ItemsSource = null;
            }
        }

        private void btnRemoveTranslation_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;

            if (cbHiragana.SelectedValue != null && cbEnglishTranslation.SelectedValue != null)
            {
                success = Variables.dBController.RemoveTranslation(cbHiragana.SelectedValue.ToString(), cbEnglishTranslation.SelectedValue.ToString());
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
