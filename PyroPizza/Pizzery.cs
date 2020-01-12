using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Pizzery
    {
        public Staff staff;
        public Storage storage;
        public Menu menu;

        public Pizzery()
        {
            staff = new Staff();
            storage = new Storage();
            menu = new Menu();
        }
    }
}
