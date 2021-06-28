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

namespace AvallonTech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int counter = 0;
            BlankCounter = counter + 120;
        }

        public int BlankCounter
        {
            get
            {
                return (int)GetValue(CounterProperty);
            }
            set
            {
                SetValue(CounterProperty, value);
            }
        }

        public static readonly DependencyProperty CounterProperty = DependencyProperty.Register("BlankCounter", typeof(int), typeof(MainWindow), new PropertyMetadata(0));

        

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
        }

        private void RedirectPage(object sender, RoutedEventArgs e)
        {
            Main.Content = new Login();
        }
    }
}
