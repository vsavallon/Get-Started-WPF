using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlankAspDotNet
{
    public partial class BlankWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.CalculateServiceClient client = new ServiceReference2.CalculateServiceClient("BasicHttpBinding_ICalculateService");
            lblText.Text = "Sum = ";
            lblText.Text += client.Add(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text)).ToString();
        }
    }
}