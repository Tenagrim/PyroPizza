using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    class Drink : MenuPosition
    {
        public double Volume { get; set; }
        public Product productInStorage { get; set; }
        public Drink() 
        {
            string str;
            string[] names = null;
            using (var fin = new StreamReader("drinkNames.txt", Encoding.Default))
            {
                str = fin.ReadLine();
                names = str.Split(',');
            }
            if (names != null)
                Name = names[rand.Next(0, names.Length)];
            else
                Name = "Напиток " + (rand.Next(0, 99)).ToString();
            Volume = rand.Next(1, 9) * 0.25;
            Cost = rand.Next(10, 150);
            productInStorage = new Product(Name,Cost);
        }
        public Drink(string name, double cost, double volume)
        {
            Name = name;
            Cost = cost;
            Volume = volume;
            productInStorage = new Product(name, cost);
        }
    }
}
