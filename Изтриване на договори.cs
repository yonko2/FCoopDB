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
    public partial class Изтриване_на_договори : Form
    {
        public Изтриване_на_договори()
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
            var searchedContractId = textBox1.Text;
            var searchedContract = ctx.Contracts
                .Where(x => x.ContractId == searchedContractId)
                .FirstOrDefault();
            if (searchedContract == null) { MessageBox.Show("Няма такъв запис"); return; }
            ctx.Contracts.Remove(searchedContract);
            ctx.SaveChanges();
            MessageBox.Show("Успешно изтриване.");
        }
    }
}
