using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using FTPLoader;

namespace FTPLoader
{
    public partial class Prompt : Form
    {
        public Prompt()
        {
            InitializeComponent();
        }

        private void Prompt_Load(object sender, EventArgs e)
        {
            string city = Form1.CurrentCity;
            Console.WriteLine("Current City from 2-nd form" + city);
            label2.Text = "Город: " + city;
        }

        private void downloadPrevious_Click(object sender, EventArgs e)
        {
            Form1.download_Previous(Form1.CurrentItem);
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
