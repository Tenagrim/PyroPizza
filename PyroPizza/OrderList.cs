using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class OrderList
    {
        public List<Order> orders;

        public OrderList()
        {
            orders = new List<Order>();
        }
        public void Add(Order o)
        {
            o.SetIndex(orders.Count);
            orders.Add(o);
        }
        public int IncCount()
        {
            return orders.Count;                     
        }
        public int DoneCount()
        {
            var selected = from p in orders
                           where p.Status == "Выполнен"
                           select p;
            return selected.Count();
        }
        public int InProgressCount()
        {
            return orders.Count - DoneCount();
        }
    }
}
