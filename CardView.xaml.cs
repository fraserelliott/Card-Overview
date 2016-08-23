using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for CardView.xaml
    /// </summary>
    public partial class CardView : UserControl
    {
        private int cardId;
        private MainWindow window;

        public CardView(MainWindow w)
        {
            InitializeComponent();
            window = w;
        }

        private void imageCard_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        public void Increment()
        {
            textBoxCount.Text = (int.Parse(textBoxCount.Text) + 1).ToString();
        }

        public void Decrement()
        {
            if (int.Parse(textBoxCount.Text) > 0)
            {
                textBoxCount.Text = (int.Parse(textBoxCount.Text) - 1).ToString();
            }
        }

        public void SetTbBackgroundColor(Color color)
        {
            textBoxCount.Background = new SolidColorBrush(color);
        }

        public void SetTextColor(Color color)
        {
            textBoxCount.Foreground = new SolidColorBrush(color);
        }

        public void SetImage(int id)
        {
            try
            {
                if (id > 0)
                {
                    string s = window.GetIconLocation() + window.GetCardFilename(id);
                    imageCard.Source = new BitmapImage(new Uri(@s));
                    cardId = id;
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Image not found. Please configure the icon location in settings.");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) //Select Image
        {
            window.ShowSearchBox(this);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //Toggle visibility
        {
            if (imageCard.Visibility == Visibility.Visible)
            {
                textBoxCount.Visibility = Visibility.Hidden;
                imageCard.Visibility = Visibility.Hidden;
            }
            else
            {
                textBoxCount.Visibility = Visibility.Visible;
                imageCard.Visibility = Visibility.Visible;
            }
        }

        public void SetVisibility(bool vis)
        {
            if (!vis)
            {
                textBoxCount.Visibility = Visibility.Hidden;
                imageCard.Visibility = Visibility.Hidden;
            }
            else
            {
                textBoxCount.Visibility = Visibility.Visible;
                imageCard.Visibility = Visibility.Visible;
            }
        }

        public int GetCardId()
        {
            return cardId;
        }

        public bool GetVisibility()
        {
            return textBoxCount.Visibility == Visibility.Visible;
        }
    }
}
