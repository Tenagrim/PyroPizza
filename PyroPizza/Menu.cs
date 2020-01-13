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
        public Menu()
        {
            Content = new List<MenuPosition>();
        }
        public void Add(MenuPosition menuPosition)
        {
            Content.Add(menuPosition);
        }
        public void RemoveAt(int index)
        {
            Content.RemoveAt(index);
        }
    }
}
