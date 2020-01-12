using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Menu
    {
       public List<MenuPosition> Content { get; set;}
        public Menu()
        {
            Content = new List<MenuPosition>();
        }
        public void Add()
        {
        
        }
    }
}
