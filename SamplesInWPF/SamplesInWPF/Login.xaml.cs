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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SamplesInWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        DataSet ds;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (IsUserValid(txtUsername.Text, txtPassword.Password))
            {
                MessageBox.Show($"Welcome! {txtUsername.Text}");
            }
            else
            {
                MessageBox.Show($"UserId or Password are incorrect!!");
            }
        }

        private bool IsUserValid(string user, string passwd)
        {
            try
            {
                conn.Open();
                string sqlQuery = $"Select Status from Login_Master where status=1 and Role='user' and userid='{user}' and password='{passwd}'";
                cmd = new SqlCommand(sqlQuery, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if(Convert.ToBoolean(dr["Status"]) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
