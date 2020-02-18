using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Pizza : MenuPosition
    {
        public static string rNames = "Маргарита,Маринара,Четыре сезона,Карбонара,Пицца с морепродуктами,Четыре сыра,Крудо,Неаполетано,Пицца по-апулийски,Монтанара,Эмилиана,Римская пицца,Фермерская пицца,Скьяччата,Пицца с прошутто,Пицца “Американо,Пицца с прошутто и грибами,Пицца Папайя,Сардиния,Пицца с тунцом";
        public int RequiredTime { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public double GetAverCost
        {
            get
            {
                double res = 0;
                foreach (var i in Ingredients)
                    res += i.Cost;
                return res;
            }
        }
        public Pizza(string name, double cost, List<Ingredient> ingredients, int reqTime)
        {
            Name = name;
            Cost = cost;
            Ingredients = ingredients;
            RequiredTime = reqTime;
        }
        public Pizza()
        {
            Name = rName();
            Cost = 230;
            Ingredients = new List<Ingredient>();
            Ingredients.Add(new Ingredient("Тесто тонкое", 43.6, 30));
            for (int i = 0; i < 5; i++)
                Ingredients.Add(new Ingredient());
            RequiredTime = 20;
        }
        public Pizza(string name, double cost, bool delivery = false)
        {
            Name = name;
            Cost = cost;
            Ingredients = new List<Ingredient>();
            Ingredients.Add(new Ingredient("Тесто тонкое", 43.6, 30));
            for (int i = 0; i < 5; i++)
                Ingredients.Add(new Ingredient());
            if (delivery)
                Ingredients.Add(new Ingredient("Коробка для пиццы", 20.3, 30));
            RequiredTime = 20;
        }
        private string rName()
        {
            string[] tmp = rNames.Split(',');
            return tmp[rand.Next(0, tmp.Length)];
        }
    }
}
