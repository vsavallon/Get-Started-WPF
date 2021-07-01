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

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckValidations())
            {
                return;
            }
            if (IsUserIdAvail(txtUsername.Text))
            {
                SaveUser(txtUsername.Text, txtPassword.Password);
            }
            else
            {
                MessageBox.Show("User Already Registered!! PLease try another username or click on login...", "Username status", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool CheckValidations()
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Enter Username!");
                return false;
            }
            if(txtPassword.Password == "")
            {
                MessageBox.Show("Enter Password!");
                return false;
            }
            if(txtPassword.Password.Length <= 6)
            {
                MessageBox.Show("Must enter more than 6 characters in password box!");
                return false;
            }
            return true;
        }

        private void SaveUser(string userid, string password)
        {
            try
            {
                conn.Open();
                string query = "sp_insertUser";
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userid);
                cmd.Parameters.AddWithValue("@Passwd", password);
                int result = cmd.ExecuteNonQuery();
                if(result > 0)
                {
                    MessageBox.Show($"User Registered Successfully!!", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"Server Down, try after sometime!!", "Registration", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Server Not Responding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private bool IsUserIdAvail(string userid)
        {
            try
            {
                conn.Open();
                string sqlQuery = $"Select Status from Login_Master where Role='user' and userid='{userid}'";
                cmd = new SqlCommand(sqlQuery, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Convert.ToBoolean(dr["Status"]))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Server Not Responding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}
