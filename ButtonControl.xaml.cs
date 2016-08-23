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

namespace card_overview_wpf
{
    /// <summary>
    /// Interaction logic for ButtonControl.xaml
    /// </summary>
    public partial class ButtonControl : UserControl
    {
        private CardView cardview;

        public ButtonControl()
        {
            InitializeComponent();
        }

        public ButtonControl(CardView cv)
        {
            InitializeComponent();
            cardview = cv;
        }

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            cardview.Increment();
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            cardview.Decrement();
        }

        public CardView GetCardView()
        {
            return cardview;
        }

        public void SetVisibility(bool vis)
        {
            if (vis)
                Visibility = Visibility.Visible;
            else
                Visibility = Visibility.Hidden;
        }
    }
}
