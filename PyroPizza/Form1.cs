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
            menus.Add(listBox1);
            menus.Add(listBox2);
            LoadMenu(PyroPizza, menus);
            LoadIndexes(PyroPizza.menu);
            textBox8.Text = PyroPizza.menu.deliveryCost.ToString();
            curOrder.deliveryCost = PyroPizza.menu.deliveryCost;
        }

        Pizzery PyroPizza = new Pizzery();
        Random rand = new Random(0);
        List<ListBox> menus = new List<ListBox>();
        List<int> selectedIndexes = new List<int>();
        Order curOrder = new Order();

        private void button1_Click(object sender, EventArgs e)
        {
            //Action1();
        }
        private void LoadMenu(Pizzery pp, List<ListBox> menus)
        {
            foreach (var i in menus)
            {
                LoadMenu(pp.menu, i);
            }
        }
        private void Action1()
        {
            PyroPizza.storage.Content.Add(new Product());
        }
        private void LoadIndexes(Menu m)
        {
            selectedIndexes.Clear();
            foreach (var i in m.Content)
                selectedIndexes.Add(i.Index);
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
                LoadMenu(PyroPizza, menus);
                //  listBox1.Items.Add(PyroPizza.menu.Content.Last().Name);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadMenu(PyroPizza.menu, listBox2);
            selectedIndexes.Clear();
            foreach (var i in PyroPizza.menu.Content)
                selectedIndexes.Add(i.Index);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            selectedIndexes.Clear();
            var selected = from pos in PyroPizza.menu.Content
                           where pos is Pizza
                           select pos;
            foreach (var i in selected)
            {
                listBox2.Items.Add(i.Name);
                selectedIndexes.Add(i.Index);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            selectedIndexes.Clear();
            var selected = from pos in PyroPizza.menu.Content
                           where pos is Drink
                           select pos;
            foreach (var i in selected)
            {
                listBox2.Items.Add(i.Name);
                selectedIndexes.Add(i.Index);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var selected = from pos in PyroPizza.menu.Content
                           where pos is OtherFood
                           select pos;
            foreach (var i in selected)
            {
                listBox2.Items.Add(i.Name);
                selectedIndexes.Add(i.Index);
            }
        }

        private MenuPosition GetMenuPosition(int index)
        {
            var select = from pos in PyroPizza.menu.Content
                         where pos.Index == index
                         select pos;
            if (select.Count() == 0) throw new ArgumentException("В меню нет позиции с заданным индексом");
            return select.First();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1) { ShowError("Выберите пункт меню для добавления к заказу"); return; }
            curOrder.Add(PyroPizza.menu, selectedIndexes[listBox2.SelectedIndex]);
            listBox4.Items.Add(GetMenuPosition(selectedIndexes[listBox2.SelectedIndex]).Name);
            textBox7.Text = curOrder.Cost + "р.";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex == -1) { ShowError("Выберите пункт заказа для удаления"); return; }
            curOrder.RemoveAt(listBox2.SelectedIndex);
            listBox4.Items.RemoveAt(listBox4.SelectedIndex);
            textBox7.Text = curOrder.Cost + "р.";
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            var select = from p in PyroPizza.staff.Workers
                         where p.Position == "кассир"
                         select p;
            foreach (var i in select)
                comboBox1.Items.Add(i.Name + " (" + i.Index + ")");
        }

        private void ShowWorker(Worker w)
        {
            textBox5.Text = w.Name;
            textBox6.Text = w.Position;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Worker w = new Worker();
            PyroPizza.staff.Add(w);
            listBox3.Items.Add(w.Name);
        }
        private Worker GetWorker(Pizzery p, string name)
        {
            var select = from w in p.staff.Workers
                         where w.Name == name
                         select w;

            if (select.Count() == 0) return null;
            else return select.First();
        }
        private Worker GetWorker(Pizzery p, int index)
        {
            var select = from w in p.staff.Workers
                         where w.Index == index
                         select w;

            if (select.Count() == 0) return null;
            else return select.First();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == -1) { return; }
            ShowWorker(GetWorker(PyroPizza, listBox3.SelectedIndex));
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            curOrder.delivery = checkBox2.Checked;

            textBox7.Text = curOrder.Cost + "р.";
        }

        private int GetCashierInd(string name)
        {
            string[] tmp = name.Split(' ');
            string s = tmp.Last().Trim(new char[] { '(', ')' });
            return Int32.Parse(s);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (curOrder.Content.Count == 0) { ShowError("Навозможно отправить на выполнение пустой заказ"); return; }
            if (comboBox1.SelectedIndex == -1) { ShowError("Для принятия заказа в работу нужен кассир"); return; }

            curOrder.AppendWorker(GetWorker(PyroPizza, GetCashierInd((string)comboBox1.SelectedItem)));
            curOrder.SetStatus("Выполняется");
            PyroPizza.orderList.Add(curOrder);
            curOrder = new Order();
            curOrder.deliveryCost = PyroPizza.menu.deliveryCost;
            ClearAcceptance();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PyroPizza.menu.deliveryCost = Int32.Parse(textBox8.Text);
            curOrder.deliveryCost = PyroPizza.menu.deliveryCost;
            ShowMsg("Стоимость доставки изменена");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            foreach (var i in PyroPizza.orderList.orders)
            {
                listBox5.Items.Add(i.ToString());
            }
        }
        private Order GetOrder(int index)
        {
            var selected = from o in PyroPizza.orderList.orders
                           where o.Index == index
                           select o;
            if (selected.Count() == 0) return null;
            else return selected.First();
        }
        private void ShowOrder(string details)
        {
            richTextBox2.Text = "";
            Order o = GetOrder(details);
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            foreach (var i in o.Content)
                listBox6.Items.Add(i.Name);
            richTextBox2.Text = GetTextMissProd(o);
        }

        private string GetTextMissProd(Order o)
        {
            string res = "";
            List<Product> ls = PyroPizza.storage.GetMissingProgucts(o);
            foreach (var i in ls)
                res += i.Name +" "+ i.CountOnStorage + " шт.\n";
            return res;
        }

        private Order GetOrder(string details)
        {
            string[] tmp = details.Split(' ');
            Order o = GetOrder(Int32.Parse(tmp[0]));
            return o;
        }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowOrder((string)listBox5.SelectedItem);
        }

        private void ClearAcceptance()
        {
            // listBox2.Items.Clear();
            listBox4.Items.Clear();
            checkBox2.Checked = false;
            textBox7.Text = "";
        }
        private void ShowPosition(string details, int index)
        {
            Order o = GetOrder(details);
            listBox7.Items.Clear();
            MenuPosition pos = o.Content[index];

            if (pos is Pizza)
            {
                Pizza pp = pos as Pizza;
                foreach (var i in pp.Ingredients)
                    listBox7.Items.Add(i.Name);
            }
            else if (pos is OtherFood)
            {
                OtherFood po = pos as OtherFood;
                foreach (var i in po.Ingredients)
                    listBox7.Items.Add(i.Name);
            }
            else
            {
                Drink d = pos as Drink;
                listBox7.Items.Add(d.Name + " " + d.Volume + "л.");
            }

        }
        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPosition((string)listBox5.SelectedItem, listBox6.SelectedIndex);
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            var select = from p in PyroPizza.staff.Workers
                         where p.Position == "повар"
                         select p;
            foreach (var i in select)
                comboBox2.Items.Add(i.Name + " (" + i.Index + ")");
        }
        private void PrepareOrder()
        {
            if (listBox5.SelectedIndex == -1) { ShowError("Выберите заказ для приготовления"); return; }
            Order o = GetOrder((string)listBox5.SelectedItem);
            List<Product> ls = PyroPizza.storage.GetMissingProgucts(o);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            PrepareOrder();
        }
        private void UpdateProdQueqe()
        {
            listBox9.Items.Clear();
            foreach (var i in PyroPizza.storage.ProductQuery)
            {
                listBox9.Items.Add(i.Name+" " +i.CountOnStorage + " шт.");
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            Order o = GetOrder((string)listBox5.SelectedItem);
            List<Product> ls = PyroPizza.storage.GetMissingProgucts(o);
            PyroPizza.storage.Request(ls);
            ShowMsg("Запрос на склад отправлен");
            UpdateProdQueqe();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            UpdateProdQueqe();
        }
        private void ShowProduct(Product p)
        {
            textBox9.Text = p.Name;
            textBox10.Text = p.Cost.ToString()+"р.";
            textBox11.Text = p.CountOnStorage.ToString()+ "шт.";
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = from p in PyroPizza.storage.Content
                           where p.Name == (string)listBox8.SelectedItem
                           select p;
            ShowProduct(selected.First());
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "") { ShowError("Введите количество");return; }
            PyroPizza.storage.AppendAllQeue(Int32.Parse(textBox12.Text));
           // listBox9.Items.Clear();
            UpdateStorListbox();
            UpdateProdQueqe();
        }
        private void UpdateStorListbox()
        {
            listBox8.Items.Clear();
            foreach (var i in PyroPizza.storage.Content)
                listBox8.Items.Add(i.Name);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender,e);
        }
    }
}
