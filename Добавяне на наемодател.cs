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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void DO_Enter(object sender, EventArgs e)
        {

        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var newClient = new Client();
            var ctx = new FCoopDBContext();

            newClient.IdcardNum = textBox1.Text;
            newClient.Name = textBox2.Text;
            newClient.Residence = textBox3.Text;
            newClient.Address = textBox4.Text;
            newClient.Email = textBox5.Text;

            try
            {
                ctx.Clients.Add(newClient);
                ctx.SaveChanges();
                MessageBox.Show("Успешно добавяне.");
            }
            catch (Exception)
            {
                MessageBox.Show("Моля, попълнете вярно данните.");            
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
        }
    }
}
