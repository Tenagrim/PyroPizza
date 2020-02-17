using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Menu
    {
       public List<MenuPosition> Content { get;}
        public int deliveryCost;
        public int Count { get { return count; } }
        private int count; 
        public Menu()
        {
            Content = new List<MenuPosition>();
            count = 0;
            deliveryCost = 100;
        }
        public void Add(MenuPosition menuPosition)
        {
            Content.Add(menuPosition);
            menuPosition.SetIndex(count);
            count++;
        }
        public void RemoveAt(int index)
        {
            Content.RemoveAt(index);
        }
    }
}
