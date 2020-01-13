using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Storage
    {
        public List<Product> Content { get;  }

        public Storage()
        {
            Content = new List<Product>();

        }
        public void Add(Product product)         
        {
            Product ai = Content.Find(t => t == product);
            if (ai == null)
            {
                Content.Add(product);
            }
            else
            {
            
            }
        }
    }
}
