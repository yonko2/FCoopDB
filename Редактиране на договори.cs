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
    public partial class Редактиране_на_довори : Form
    {
        public Редактиране_на_довори()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ctx = new FCoopDBContext();
            var searchedContractID = textBox5.Text;
            var searchedContract = ctx.Contracts
                .Where(x => x.ContractId == searchedContractID)
                .FirstOrDefault();
            if (searchedContract == null) { MessageBox.Show("Няма такъв запис"); return; }
            searchedContract.Date = DateTime.Parse(textBox1.Text);
            searchedContract.Term = int.Parse(textBox2.Text);
            searchedContract.Plant = textBox3.Text;
            searchedContract.AverageYield = int.Parse(textBox4.Text);
            ctx.SaveChanges();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
            }
            else
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
            }
        }

        private void Редактиране_на_довори_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
        }
    }
}
