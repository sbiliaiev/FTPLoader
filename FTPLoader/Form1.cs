using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentFTP;
using System.Net;

namespace FTPLoader
{
    public partial class Form1 : Form
    {
        FtpClient client;

        public Form1()
        {
            InitializeComponent();

            string test = "test string";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FtpClient("127.0.0.1");
            client.Port = 54218;
            client.Credentials = new NetworkCredential("dev_user", "dev_user_pass");
            client.Connect();

            List<string> cityList = new List<string>();

            // get a list of files and directories in the "/htdocs" folder
            foreach (FtpListItem item in client.GetListing("/"))
            {

                // if this is a file
                if (item.Type == FtpFileSystemObjectType.File)
                {

                    // get the file size
                    long size = client.GetFileSize(item.FullName);
                    Console.WriteLine(size);

                }

                // get modified date/time of the file or folder
                DateTime time = client.GetModifiedTime(item.FullName);

                // calculate a hash for the file on the server side (default algorithm)
                // FtpHash hash = client.GetHash(item.FullName);
                Console.WriteLine(item.FullName);
                cityList.Add(item.Name);
            }


            checkedListBox1.DataSource = cityList;

            string str = "573Report20170930050115_AE";
            Console.WriteLine(str);
            int index;
            index = str.IndexOf("Report");
            Console.WriteLine("index:" + index);
            string dateStr = str.Substring(index + 6, 8);
            Console.WriteLine("date = " + dateStr);
            DateTime currentDate = DateTime.Now;
            string currentDateStr = currentDate.ToString("yyyyMMdd");
            Console.WriteLine("current date str = " + currentDateStr);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*List<string> checkedItems = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
                checkedItems.Add(item.ToString());*/

            //if (e.NewValue == CheckState.Checked)
              //  checkedItems.Add(checkedListBox1.Items[e.Index].ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var city in checkedListBox1.CheckedItems)
            {
                foreach (FtpListItem item in client.GetListing(city.ToString() + "/Reports"))
                {
                    Console.WriteLine("item in city" + item.Name);
                }
            }
        }
    }
}
