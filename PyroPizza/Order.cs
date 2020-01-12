using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Order
    {
        public int ID { get;  }
        public int AverCost { get; }
        public List<MenuPosition> Content { get; }
        public Order()
        {
        
        }
        public Order(List<MenuPosition> cont)
        {
            int aCost = 0;
            foreach (var i in cont)
                aCost += i.Cost;
            AverCost = aCost;
            Content = cont;
            ID = DateTime.Now.GetHashCode();
        }
    }
}
