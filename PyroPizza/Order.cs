using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    public enum orderStatus { accepted, inProgress, prepared, inDelivery, done, cancelled }
    [Serializable]
    class Order
    {
        public int ID { get; }
        public double AverCost { get; }
        public List<MenuPosition> Content { get; }
        public string Status { get; set; }
        public bool delivery { get; set; }
        public Order()
        {

        }
        public Order(List<MenuPosition> cont)
        {
            double aCost = 0;
            foreach (var i in cont)
                aCost += i.Cost;
            AverCost = aCost;
            Content = cont;
            ID = DateTime.Now.GetHashCode();
        }
    }
}
