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
    public partial class Form17 : Form
    {
        public Form17()
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
            ctx.Clients.Remove(searchedClient);
            ctx.SaveChanges();
            MessageBox.Show("Успешно изтриване.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
