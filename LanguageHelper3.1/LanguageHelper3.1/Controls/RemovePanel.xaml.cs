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
    /// Interaction logic for RemovePanel.xaml
    /// </summary>
    public partial class RemovePanel : UserControl
    {
        public RemovePanel()
        {
            InitializeComponent();
        }

        //---- Method for Handling the buttonShowRemoveWord Click Event
        //-- If the RemoveWordPanel is currently Hidden, it will change its visibility to Visible,
        //-- and set the RemoveTranslation to Hidden.  Otherwise is currently Visible, it will change to
        //-- to hidden.
        private void buttonShowRemoveWord_Click(object sender, RoutedEventArgs e)
        {
            if(RemoveWordPanel.Visibility == Visibility.Hidden)
            {
                RemoveWordPanel.Visibility = Visibility.Visible;
                RemoveTranslationPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                RemoveWordPanel.Visibility = Visibility.Hidden;
            }
        }

        //---- Method for Handling the buttonShowRemoveTranslation Click Event
        //-- If the RemoveTranslationPanel is currently Hidden, it will change its visibility to Visible,
        //-- and set the RemoveWordPanel to Hidden.  Otherwise is currently Visible, it will change to
        //-- to hidden.
        private void buttonShowRemoveTranslation_Click(object sender, RoutedEventArgs e)
        {
            if (RemoveTranslationPanel.Visibility == Visibility.Hidden)
            {
                RemoveTranslationPanel.Visibility = Visibility.Visible;
                RemoveWordPanel.Visibility = Visibility.Hidden;

                RemoveTranslationPanel.cbHiragana.ItemsSource = null;
                Variables.dBController.FillComboBoxHiragana(RemoveTranslationPanel.cbHiragana);
            }
            else
            {
                RemoveTranslationPanel.Visibility = Visibility.Hidden;
            }
        }
    }
}
