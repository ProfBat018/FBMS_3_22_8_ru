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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WhiteBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isMenuOpen = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            if (isMenuOpen)
            {

                ButtonMenu.SetResourceReference(StyleProperty, "OpenBtn");

                Storyboard sb = FindResource("CloseMenu") as Storyboard;
                sb.Begin();

                isMenuOpen = false;
            }
            else
            {
                ButtonMenu.SetResourceReference(StyleProperty, "CloseBtn");

                Storyboard sb = FindResource("OpenMenu") as Storyboard;
                sb.Begin();
                
                isMenuOpen = true;
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void MaximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BrushBtn_Click(object sender, RoutedEventArgs e)
        {
            var colorPickerWindow = new ColorPickerWindow();
            colorPickerWindow.ShowDialog();

            inkCanvas.DefaultDrawingAttributes.Color = App.Color.Color;
        }
    }
}
