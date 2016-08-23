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
using System.Windows.Shapes;

namespace card_overview_wpf
{
    /// <summary>
    /// Interaction logic for CardWindow.xaml
    /// </summary>
    public partial class CardWindow : Window
    {
        public CardWindow()
        {
            InitializeComponent();
        }

        public void AddCardView(CardView cv)
        {
            mainCanvas.Children.Add(cv);
        }

        public void RemoveCardView(CardView cv)
        {
            mainCanvas.Children.Remove(cv);
        }

        public void SetBackgroundColor(string colorCode)
        {
            colorCode = colorCode.Replace("#", "");
            byte r = byte.Parse(colorCode.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(colorCode.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(colorCode.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        public void ClearAll()
        {
            mainCanvas.Children.Clear();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
