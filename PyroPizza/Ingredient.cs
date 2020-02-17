using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PyroPizza
{
    [Serializable]
    class Ingredient : Product
    {
        public static Random rand = new Random(0);
        public Ingredient() 
        {
            string str;
            string[] names = null;
            using (var fin = new StreamReader("ingrNames.txt", Encoding.Default))
            {
                str = fin.ReadLine();
                names = str.Split(',');
            }
            if (names != null)
                Name = names[rand.Next(0, names.Length)];
            else
                Name = "Ингредиент " + (rand.Next(0, 99)).ToString();
            Cost = rand.Next(0, 100);
            count = 0;

            ManufactureDate = default;
            AcceptanceDate = default;

            ShelfLife = 0;
        }

        public Ingredient(string name, double cost, int cou)
        {

            Name = name;
            Cost = cost;
            count = cou;

            ManufactureDate = DateTime.MinValue;
            AcceptanceDate = DateTime.MinValue;

            ShelfLife = 10;

        }
        public Ingredient(string name, double cost)
        {

            Name = name;
            Cost = cost;
            count = 0;

            ManufactureDate = DateTime.MinValue;
            AcceptanceDate = DateTime.MinValue;

            ShelfLife = 30;
        }

        public Ingredient Clone()
        {
            return new Ingredient(Name, Cost, count);
        }
    }
}
