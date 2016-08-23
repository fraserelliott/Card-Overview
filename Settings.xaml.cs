using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace card_overview_wpf
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public static Color[] colors = { Colors.White, Colors.Black, Colors.Red, Colors.Blue };

        MainWindow window;
        
        public Settings()
        {
            InitializeComponent();
        }

        public void Show(MainWindow w)
        {
            Show();
            textBoxIconLocation.Text = w.GetIconLocation();
            listBoxTbBackgroundColour.SelectedIndex = Array.IndexOf(colors, w.GetTbBackgroundColor());
            listBoxTbTextColour.SelectedIndex = Array.IndexOf(colors, w.GetTbTextColor());
            textBoxBackgroundColour.Text = w.GetBackgroundColor();
            window = w;
        }

        private void buttonSet_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxIconLocation.Text == "")
            {
                System.Windows.MessageBox.Show("Please enter an icon location.");
            }
            /*
            else if (!Uri.IsWellFormedUriString(@textBoxIconLocation.Text, UriKind.RelativeOrAbsolute))
            {
                MessageBox.Show("Invalid icon location.");
            }
            */
            else
            {
                if (textBoxBackgroundColour.Text != "")
                {
                    if (textBoxBackgroundColour.Text.First() == '#' && textBoxBackgroundColour.Text.Length == 7)
                    {
                        string colorCode = textBoxBackgroundColour.Text;
                        colorCode = colorCode.Replace("#", "");
                        long output;
                        if (long.TryParse(colorCode, System.Globalization.NumberStyles.HexNumber, null, out output))
                        {
                            //Everything okay!
                            window.SetIconLocation(textBoxIconLocation.Text);
                            window.SetBackgroundColor("#" + colorCode);
                            window.SetTbBackgroundColor(colors[listBoxTbBackgroundColour.SelectedIndex]);
                            window.SetTbTextColor(colors[listBoxTbTextColour.SelectedIndex]);
                            window.SaveSettings();
                            Close();
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Invalid background colour code. Default: #00FF00");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Invalid background colour code. Default: #00FF00");
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Please enter a colour combination for the background colour. Default: #00FF00");
                }
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxIconLocation.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
