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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;
using System.IO;

namespace Needybar
{
    /// <summary>
    /// Interaction logic for LookupPage.xaml
    /// </summary>
    public partial class LookupPage : Page
    {
        private Encoding conversationEncoding = Encoding.UTF8;
        private string defaultServer = "test.dict.org";
        private readonly int defaultPort = 2628;
        private const int bufferSize = 4096;
        public LookupPage()
        {
            InitializeComponent();
        }
        protected void OnSearch(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            string word = txtSearchBox.Text.Trim();
            if (word.Length > 0)
                DefineWord(word);
            Mouse.OverrideCursor = null;
        }
        private void DefineWord(string word)
        {
            string command = "DEFINE * " + word;
            string strResult = ExecuteCommand(command);
            FlowDocument doc = new FlowDocument();
            Paragraph para1 = new Paragraph();
            para1.FontSize = 18;
            para1.Inlines.Add(new Bold(new Run(word)));
            doc.Blocks.Add(para1);
            Paragraph para2 = new Paragraph();
            para2.Inlines.Add(new Run(strResult));
            doc.Blocks.Add(para2);
            descriptionBox.Document = doc;
        }
        private string ExecuteCommand(string command)
        {
            StringBuilder response = new StringBuilder();
            using (TcpClient client = new TcpClient())
            {
                client.Connect(defaultServer, defaultPort);
                using (Stream clientStream = client.GetStream())
                {
                    response.Append(GetResponse(command + "\r\n", clientStream));
                    response.Append(GetResponse("QUIT\r\n", clientStream));
                }
            }
            return response.ToString();
        }
        private string GetResponse(string requestString, Stream clientStream)
        {
            byte[] request = conversationEncoding.GetBytes(requestString);
            clientStream.Write(request, 0, request.Length);
            clientStream.Flush();
            byte[] response = new byte[bufferSize];
            StringBuilder sb = new StringBuilder();
            int currentPosition = 0, bytesRead = 0;
            while ((bytesRead = clientStream.Read(response, 0, bufferSize)) > 0)
            {
                sb.Append(conversationEncoding.GetString(response, 0, bytesRead));
                currentPosition += bytesRead;
                if (bytesRead < bufferSize)
                    break;
            }
            return sb.ToString();
        }
    }
}
