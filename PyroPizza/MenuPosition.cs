using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class MenuPosition
    {
        public static Random rand = new Random(0);
        public string Name { get; set; }
        public double Cost { get; set; }
        private int index;
        public int Index { get { return index; } }
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
        public void SetIndex(int i)
        {
            index = i;
        }

    }
}
