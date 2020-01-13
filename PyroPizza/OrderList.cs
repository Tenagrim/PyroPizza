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
    }
}
