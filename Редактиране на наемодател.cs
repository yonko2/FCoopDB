using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ф_КООП.Models;

namespace WinFormsApp9
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ctx = new FCoopDBContext();
            var searchedIdcardnum = textBox1.Text;
            var searchedClient = ctx.Clients
                .Where(x => x.IdcardNum == searchedIdcardnum)
                .FirstOrDefault();
            if (searchedClient == null) { MessageBox.Show("Няма такъв запис"); return; }
            searchedClient.Name = textBox2.Text;
            searchedClient.Residence = textBox3.Text;
            searchedClient.Address = textBox4.Text;
            searchedClient.Email = textBox5.Text;

            ctx.SaveChanges();
            MessageBox.Show("Успешно добавяне.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
            }
            else
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
            }
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }
    }
}
