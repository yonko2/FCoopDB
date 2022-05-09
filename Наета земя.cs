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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            var ctx = new FCoopDBContext();
            dataGridView1.DataSource = ctx.Plots.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new Form19();
            this.Hide();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Form20();
            this.Hide();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Form21();
            this.Hide();
            form.ShowDialog();
        }
    }
}
