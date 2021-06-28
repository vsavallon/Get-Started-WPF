using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WikiDesktop
{
    /// <summary>
    /// Interaction logic for WikiWindow.xaml
    /// </summary>
    public partial class WikiWindow : Window
    {
        public WikiWindow()
        {
            InitializeComponent();
        }

        static WikiWindow()
        {
            About.InputGestures.Add(new KeyGesture(Key.F3));
        }

        public static RoutedCommand About = new RoutedCommand();

        private void About_Wiki(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Welcome! This is the Wiki Desktop App....");
        }
    }
}
