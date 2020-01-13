using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class OtherFood : MenuPosition
    {
        public int RequiredTime { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public OtherFood(string name, double cost)
        {
            Name = name;
            Cost = cost;
            Ingredients = new List<Ingredient>();
            for (int i = 0; i < 5; i++)
                Ingredients.Add(new Ingredient());
            RequiredTime = 20;
        }
        public OtherFood()
        {
            Name = "Картошка";
            Cost = 150;
            Ingredients = new List<Ingredient>();
            for (int i = 0; i < 3; i++)
                Ingredients.Add(new Ingredient());
            RequiredTime = 10;
        }
        public OtherFood(string name, double cost, List<Ingredient> ingredients, int reqTime)
        {
            Name = name;
            Cost = cost;
            Ingredients = ingredients;
            RequiredTime = reqTime;
        }
    }
}
