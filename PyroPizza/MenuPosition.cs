using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class MenuPosition
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Cost.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            MenuPosition ai = obj as MenuPosition;
            if (ai == null)
                return false;
            else if (ai.Cost == Cost && ai.Name == Name)
                return true;
            else return false;
        }
    }
}
