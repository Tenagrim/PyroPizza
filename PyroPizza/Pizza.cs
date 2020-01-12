using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Pizza : MenuPosition
    {
        public int RequiredTime { get; set; }
        public List<Ingredient> Ingredients { get; set; }


    }
}
