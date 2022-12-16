using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO5
{
    public class T : IEquatable<T>
    {
        public string type { get; set; }

        public int cout { get; set; }

        public override string ToString()
        {
            return "cout: " + cout + "   Name: " + type;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            T objAsPart = obj as T;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return cout;
        }
        public bool Equals(T other)
        {
            if (other == null) return false;
            return (this.cout.Equals(other.cout));
        }
    }
}
