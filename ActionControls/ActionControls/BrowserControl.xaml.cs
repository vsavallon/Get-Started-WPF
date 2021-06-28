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
namespace ActionControls
{
    /// <summary>
    /// Interaction logic for BrowserControl.xaml
    /// </summary>
    public partial class BrowserControl : UserControl
    {
        public BrowserControl()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog newFolder = new System.Windows.Forms.FolderBrowserDialog();
            newFolder.RootFolder = Environment.SpecialFolder.Desktop;
            newFolder.Description = "Choose Folder";
            newFolder.ShowNewFolderButton = false;
            if (newFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBox.Text = newFolder.SelectedPath;
            }
            //txtBox.Text = "You have just clicked the button";
        }
    }
}
