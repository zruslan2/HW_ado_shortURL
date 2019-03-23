using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HW_ado_1.Entities;
using HW_ado_1.Repository;

namespace HW_ado_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Links ln = new Links();
            ln.fullUrl = textBox1.Text;
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = _md5.GetMd5Hash(md5Hash, textBox1.Text);
                htmlFile.createFile(hash, ln.fullUrl);
                ftp.uploadFile(hash);
                ln.shortUrl = "http://f0287337.xsph.ru/" + hash + ".html";                
            }
            ln.usCount = 5;
            ln.finishDate = DateTime.Today.AddDays(Convert.ToDouble(textBox2.Text));
            ln.lDescription = textBox4.Text;
            //textBox3.Text = ln.fullUrl + Environment.NewLine + ln.shortUrl + Environment.NewLine + ln.usCount + Environment.NewLine + ln.finishDate+ Environment.NewLine+ln.lDescription;
            LinksRepository lr = new LinksRepository();
            lr.insertLink(ln);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
