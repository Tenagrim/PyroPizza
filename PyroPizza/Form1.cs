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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label6.Location = label3.Location;
            textBox4.Location = richTextBox1.Location;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Pizza newPizza = new Pizza();
            PyroPizza.menu.Add(newPizza);
            LoadMenu(PyroPizza.menu, listBox1);
            LoadMenu(PyroPizza.menu, listBox2);
        }
        Pizzery PyroPizza = new Pizzery();
        Random rand = new Random(0);

        private void button1_Click(object sender, EventArgs e)
        {
            //Action1();
        }
        private void Action1()
        {
            PyroPizza.storage.Content.Add(new Product());
        }
        private void LoadMenu(Menu m, ListBox ls)
        {
            ls.Items.Clear();
            foreach (var i in m.Content)
                ls.Items.Add(i.Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadMenu(PyroPizza.menu, listBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                AddNewRandPosition(PyroPizza.menu);
                AddLastToMenu(PyroPizza.menu, listBox1);
            }
            else
            {
                AddNewMenuPos(PyroPizza.menu);
            }
        }
        private void AddNewRandPosition(Menu menu)
        {
            MenuPosition mPos = GetRandomPos();
            menu.Add(mPos);
        }
        private void AddLastToMenu(Menu m, ListBox ls)
        {
            ls.Items.Add(m.Content.Last().Name);
        }
        private MenuPosition GetRandomPos()
        {
            int k = rand.Next(0, 3);
            switch (k)
            {
                case 0:
                    return new Pizza();
                case 1:
                    return new Drink();
                case 2:
                    return new OtherFood();
            };
            return null;
        }

        private void AddNewMenuPos(Menu menu)
        {
            MenuPosition p = null;
            Form2 form2 = new Form2(PyroPizza);
            form2.ShowDialog();
            p = form2.GetNewPos();
            if (p != null)
            {
                PyroPizza.menu.Add(p);
                listBox1.Items.Add(PyroPizza.menu.Content.Last().Name);
            }
        }
        private string GetTextIngrs(List<Ingredient> ingrs)
        {
            string res = "";
            foreach (var i in ingrs)
            {
                res += i.Name + "\n";
            }
            return res;
        }
        private void ShowMenuPositionEd(MenuPosition mPos)
        {
            Drink ad = mPos as Drink;
            OtherFood ao = mPos as OtherFood;
            Pizza ap = mPos as Pizza;
            if (ad != null)
            {
                textBox1.Text = ad.Name;
                textBox2.Text = ad.Cost.ToString() + " руб.";
                textBox4.Text = ad.Volume.ToString() + " л.";
                radioButton2.Checked = true;
            }
            else if (ao != null)
            {
                textBox1.Text = ao.Name;
                textBox2.Text = ao.Cost.ToString() + " руб.";
                richTextBox1.Text = GetTextIngrs(ao.Ingredients);
                textBox3.Text = ao.RequiredTime + " мин.";
                radioButton3.Checked = true;
            }
            else if (ap != null)
            {
                textBox1.Text = ap.Name;
                textBox2.Text = ap.Cost.ToString() + " руб.";
                richTextBox1.Text = GetTextIngrs(ap.Ingredients);
                textBox3.Text = ap.RequiredTime + " мин.";
                radioButton1.Checked = true;
            }
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
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                ShowMenuPositionEd(PyroPizza.menu.Content[listBox1.SelectedIndex]);
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label6.Visible = false;
                textBox4.Visible = false;
                label3.Visible = true;
                richTextBox1.Visible = true;
                label5.Visible = true;
                textBox3.Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label6.Visible = true;
                textBox4.Visible = true;
                label3.Visible = false;
                richTextBox1.Visible = false;
                label5.Visible = false;
                textBox3.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                label6.Visible = false;
                textBox4.Visible = false;
                label3.Visible = true;
                richTextBox1.Visible = true;
                label5.Visible = true;
                textBox3.Visible = true;
            }
        }
        public void ClearFieldsEd()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";
            textBox4.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                PyroPizza.menu.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                ClearFieldsEd();
            }
            else ShowError("Выберите позицию меню для ее удаления");
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
            
            }
        }
    }
}
