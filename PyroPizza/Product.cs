using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int ShelfLife { get; set; }
        public int CountOnStorage { get { return count; } }
        protected int count;
        public Product()
        {
            Name = "product";
            Cost = 0;
            AcceptanceDate = DateTime.Now;
            ManufactureDate = DateTime.Now;
            ShelfLife = 99;
            count = 1;
        }
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
            count = 0;
            AcceptanceDate = DateTime.Now;
            ManufactureDate = DateTime.Now;
            ShelfLife = 99;
        }
        public Product(string name, double cost, int cou)
        {
            Name = name;
            Cost = cost;
            count = cou;
            AcceptanceDate = DateTime.Now;
            ManufactureDate = DateTime.Now;
            ShelfLife = 99;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Cost.GetHashCode() + ShelfLife.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Product ai = obj as Product;
            if (ai == null)
                return false;
            else if (ai.Cost == Cost && ai.Name == Name )
                return true;
            else return false;
        }
        public void Add(int n)
        {
            count += n;
        }
        public void Spend(int n)
        {
            if (count < n) throw new ArgumentException("Недостаточно продуктов на складе");
            else
                count -= n;
        }
        public void Append(int c) 
        {
            count += c;
        }
        public void SetCount(int c)
        {
            count = c;
        }
        public Product Clone()
        {
            return new Product(Name, Cost, count);
        }
    }
}
