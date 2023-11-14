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

namespace WhiteBoard
{
    /// <summary>
    /// Interaction logic for ColorPickerWindow.xaml
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
        public ColorPickerWindow()
        {
            InitializeComponent();
        }

        private void ChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Color = new SolidColorBrush(ColorPicker.Color);
            this.Close();
        }

        private void ColorPicker_MouseMove(object sender, MouseEventArgs e)
        {
            ChooseBtn.Background = new SolidColorBrush(ColorPicker.Color);

            var color = ColorPicker.Color;


            rgbLabel.Content = $"{color.R} {color.G} {color.B}";
            hexLabel.Content = $"{color.R:X2}{color.G:X2}{color.B:X2}";
            hsvlabel.Content = RgbToHsv(color.R, color.G, color.B);
        }

        private string RgbToHsv(double r, double g, double b)
        {
            double[] hsv = new double[3];
            r = r / 255.0;
            g = g / 255.0;
            b = b / 255.0;
            double max = new[] { r, g, b }.Max();
            double min = new[] { r, g, b }.Min();
            double delta = max - min;
            hsv[1] = max != 0 ? delta / max : 0;
            hsv[2] = max;
            if (hsv[1] == 0)
            {
                return $"{hsv[0]} {hsv[1]} {hsv[2]}";
            }
            if (r == max)
            {
                hsv[0] = ((g - b) / delta);
            }
            else if (g == max)
            {
                hsv[0] = ((b - r) / delta) + 2.0;
            }
            else if (b == max)
            {
                hsv[0] = ((r - g) / delta) + 4.0;
            }
            hsv[0] *= 60.0;
            if (hsv[0] < 0)
            {
                hsv[0] += 360.0;
            }
            return $"{hsv[0]} {hsv[1]} {hsv[2]}";
        }
    }
}
