using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoneyChaner = Money_Changer.MoneyChanger;

namespace Money_Changer
{
    public partial class Form1 : Form
    {
        MoneyChanger moneychanger;
        public Form1()
        {
            InitializeComponent();
            moneychanger = new MoneyChanger();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> symbolData = moneychanger.GetSymbols();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            comboBox1.DataSource = new BindingSource(symbolData, null);
            comboBox1.DisplayMember = "value";
            comboBox1.ValueMember = "key";
            comboBox2.DataSource = new BindingSource(symbolData, null);
            comboBox2.DisplayMember = "value";
            comboBox2.ValueMember = "key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fromCurrency = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            string toCurrency = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Key;
            double currentAmount = double.Parse(textBox3.Text);
            double finalValue = moneychanger.Convert(fromCurrency, toCurrency, currentAmount);
            label6.Text = finalValue.ToString();
            label5.Text = comboBox2.Text;
        }
    }
}
