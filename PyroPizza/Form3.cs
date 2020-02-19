using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PyroPizza
{
    partial class Form3 : Form
    {
        private Pizzery Pizzery;
        private Worker newWorker;
        public Form3()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;

        }
        private void ShowError(string msg)
        {
            MessageBox.Show(
             msg,
              "Ошибка",
            MessageBoxButtons.OK,
      MessageBoxIcon.Error);
        }
        private void ShowMsg(string msg)
        {
            MessageBox.Show(
             msg,
              "Ошибка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
        public Worker GetNewWorker()
        {
            return newWorker;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { ShowError("Введите Ф.И.О. работника"); return; }

            newWorker = new Worker(textBox1.Text, comboBox2.SelectedItem.ToString());
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
