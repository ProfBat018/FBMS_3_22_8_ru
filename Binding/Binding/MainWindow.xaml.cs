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

namespace Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class Test
    {
        public string Name { get; set; } = "Hakuna Matata";
    }
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Test test = new Test();
            
            this.DataContext = test;
        }
    }
}
