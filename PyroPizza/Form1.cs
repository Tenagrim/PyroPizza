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
        }
        private Pizzery PyroPizza = new Pizzery();

        private void button1_Click(object sender, EventArgs e)
        {
            Action1();
        }
        private void Action1()
        {
            PyroPizza.storage.Content.Add(new Product());
        }
    }
}
