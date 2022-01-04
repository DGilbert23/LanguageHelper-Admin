using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Globalization;

namespace LanguageHelper3._1.Classes
{
    class HelperMethods
    {
        public static void SetTBLanaguageJP(TextBox tbIn)
        {
            InputLanguageManager.SetInputLanguage(tbIn, CultureInfo.CreateSpecificCulture("ja-JP"));
        }

        public static void SetTBLanaguageEnglish(TextBox tbIn)
        {
            InputLanguageManager.SetInputLanguage(tbIn, CultureInfo.CreateSpecificCulture("en-US"));
        }

        public static void SetCBLanaguageJP(ComboBox cbIn)
        {
            InputLanguageManager.SetInputLanguage(cbIn, CultureInfo.CreateSpecificCulture("ja-JP"));
        }

        public static void SetCBLanaguageEnglish(ComboBox cbIn)
        {
            InputLanguageManager.SetInputLanguage(cbIn, CultureInfo.CreateSpecificCulture("en-US"));
        }
    }
}
