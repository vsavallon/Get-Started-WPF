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
using System.Windows.Forms;


namespace AvallonTech
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog newFolder = new FolderBrowserDialog();
            newFolder.RootFolder = Environment.SpecialFolder.Desktop;
            newFolder.Description = "Choose Folder";
            newFolder.ShowNewFolderButton = false;
            if(newFolder.ShowDialog() == DialogResult.OK)
            {
                txtSelectedPath.Text = newFolder.SelectedPath;
            }
        }
    }
}
