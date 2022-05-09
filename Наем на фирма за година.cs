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
    public partial class Form7 : Form
    {
        FCoopDBContext context = new FCoopDBContext();
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rents = context.Contracts
                .Where(x => x.Date.Value.Year == int.Parse(textBox1.Text))
                .Select(x => x.Deal.Plot.Type)
                .ToList();

            int sum = 0;
            foreach (var rent in rents)
            {
                switch (rent)
                {
                    case 1:
                        sum += 45;
                        break;
                    case 2:
                        sum += 35;
                        break;
                    case 3:
                        sum += 25;
                        break;
                    default:
                        break;
                }
            }

            textBox1.Text = sum.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
