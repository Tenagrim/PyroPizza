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
    partial class Form2 : Form
    {
        public Form2(Pizzery pizzery)
        {
            InitializeComponent();
            PyroPizza = pizzery;
            availIngrs = PyroPizza.GetKnownIngredients();
            ShowIngrs();
            ShowTextIngrs();
            label8.Location = label3.Location;
            textBox7.Location = richTextBox1.Location;
        }


        private void ShowIngrs()
        {
            listBox1.Items.Clear();
            foreach (var i in availIngrs)
                listBox1.Items.Add(i.Name);
        }
        List<Ingredient> ingrs = new List<Ingredient>();
        List<Ingredient> availIngrs;
        Pizzery PyroPizza;
        MenuPosition newPos;
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) { ShowError("Выберите из списка ингредиент для добавления"); return; }

            if (ingrs.Contains(availIngrs[listBox1.SelectedIndex])) { ShowError("Данный ингредиент уже добавлен"); return; }

            ingrs.Add(availIngrs[listBox1.SelectedIndex]);
            ShowTextIngrs();
        }
        private void ShowTextIngrs()
        {
            richTextBox1.Text = "";
            foreach (var i in ingrs)
            {
                richTextBox1.Text += i.Name + "\n";
            }
        }
        private void AddIngr()
        {
            if (checkBox1.Checked)
            {
                Ingredient ing = new Ingredient();
                availIngrs.Add(ing);
                PyroPizza.storage.Add(ing);
                listBox1.Items.Add(availIngrs.Last().Name);
            }
            else
            {
                if (!CheckIngrFields()) return;
                double cost;
                if (!Double.TryParse(textBox4.Text, out cost)) { ShowError("Неверно введена стоимость"); return; }

                Ingredient ingr = new Ingredient(textBox5.Text, cost, Int32.Parse(textBox6.Text));
                availIngrs.Add(ingr);
                listBox1.Items.Add(availIngrs.Last().Name);
            }
        }

        private bool CheckIngrFields()
        {
            if (textBox5.Text == "")
            { ShowError("Введите название"); return false; }
            else if (textBox4.Text == "")
            { ShowError("Введите стоимость"); return false; }
            else return true;
        }
        private bool CheckFields()
        {
            if (textBox1.Text == "")
            { ShowError("Введите название"); return false; }
            else if (textBox2.Text == "")
            { ShowError("Введите стоимость"); return false; }
            else if (textBox3.Text == "")
            { ShowError("Введите время приготовления"); return false; }
            else if (ingrs.Count == 0)
            { ShowError("Список ингредиентов пуст"); return false; }
            else
                return true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckFields()) return;
            double cost;
            if (!Double.TryParse(textBox2.Text, out cost)) { ShowError("Стоимость введена неверно"); return; }

            if (radioButton1.Checked)
            {
                newPos = GeNewPizza(cost);
            }
            else if (radioButton2.Checked)
            {
                if (textBox7.Text == "" ) { ShowError("Введите объем"); return; }
                double volume;
                if(Double.TryParse(textBox7.Text, out volume)) { ShowError("Объем введен неверно"); return; }
                newPos = GeNewDrink(cost, volume);
            }
            else if (radioButton3.Checked) 
            {
                newPos = GeNewOther(cost);
            }

            this.Close();
        }
        private Pizza GeNewPizza(double cost)
        {
            Pizza res;
            res = new Pizza(textBox1.Text, cost, ingrs, Int32.Parse(textBox3.Text));
            return res;
        }
        private Drink GeNewDrink(double cost, double volume)
        {
            Drink res;
            res = new Drink(textBox1.Text,cost,volume);
            return res;
        }
        private OtherFood GeNewOther(double cost)
        {
            OtherFood res;
            res = new OtherFood(textBox1.Text, cost, ingrs, Int32.Parse(textBox3.Text));
            return res;
        }
        public MenuPosition GetNewPos()
        {
            return newPos;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AddIngr();
        }
        private void _KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (!Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox7.Visible = false;
            label8.Visible = false;
            richTextBox1.Visible = true;
            label3.Visible = true;
            label5.Visible = true;
            textBox3.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            richTextBox1.Visible = false;
            label3.Visible = false;
            textBox7.Visible = true;
            label8.Visible = true;
            label5.Visible = false;
            textBox3.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox7.Visible = false;
            label8.Visible = false;
            richTextBox1.Visible = true;
            label3.Visible = true;
            label5.Visible = true;
            textBox3.Visible = true;
        }
    }
}
