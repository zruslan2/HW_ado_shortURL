using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HW_ado_1.Repository;
using HW_ado_1.Entities;

namespace HW_ado_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            LinksRepository lr = new LinksRepository();
            List<shortLinks> ll = lr.ReadALL();           
            dataGridView1.DataSource = ll;
            dataGridView1.ReadOnly = true;                      
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {           
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool check_id(List<shortLinks> ll, int id)
        {
            bool b = false;
            foreach (shortLinks l in ll)
            {
                if (l.Id == id) b = true;
            }
            return b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LinksRepository lr = new LinksRepository();
            List<shortLinks> ll = lr.ReadALL();
            if (check_id(ll,Int32.Parse(textBox1.Text)))
            {
                textBox2.Text = lr.ReadById(Int32.Parse(textBox1.Text));
                lr.updateCount(Int32.Parse(textBox1.Text));
            }     
            else MessageBox.Show("Ошибка. Проверьте выбранный id");            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox2.Text);
        }
    }
}
