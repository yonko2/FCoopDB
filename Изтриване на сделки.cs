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
    public partial class Изтриване_на_сделки : Form
    {
        public Изтриване_на_сделки()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ctx = new FCoopDBContext();
            var searchedContractID = textBox1.Text;
            var searchedDeal = ctx.Deals
                .Where(x => x.ContractId == searchedContractID)
                .FirstOrDefault();
            if (searchedDeal == null) { MessageBox.Show("Няма такъв запис"); return; }
            ctx.Deals.Remove(searchedDeal);
            ctx.SaveChanges();
            MessageBox.Show("Успешно изтриване.");
        }
    }
}
