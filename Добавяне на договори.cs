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
    public partial class Добавяне_на_договори : Form
    {
        public Добавяне_на_договори()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
        }

        private void Добавяне_на_договори_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var newContract = new Contract();
            var ctx = new FCoopDBContext();
            newContract.ContractId = textBox5.Text;
            newContract.Date = DateTime.Parse(textBox1.Text);
            newContract.Term = int.Parse(textBox2.Text);
            newContract.Plant = textBox3.Text;
            newContract.AverageYield = int.Parse(textBox4.Text);

            ctx.Contracts.Add(newContract);
            ctx.SaveChanges();
            MessageBox.Show("Успешно добавяне.");
        }
    }
}
