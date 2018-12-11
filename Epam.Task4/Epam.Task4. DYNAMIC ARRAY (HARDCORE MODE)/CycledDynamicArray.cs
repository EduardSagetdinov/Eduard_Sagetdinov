using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.DYNAMIC_ARRAY__HARDCORE_MODE_
{
    public class CycledDynamicArray<T> : DYNAMIC_ARRAY__HARDCORE_MODE<T>
    {
        private CycledDynamicArray<T> car;

        public CycledDynamicArray(int n) : base(n)
        {
        }

        public CycledDynamicArray() : base()
        {
        }

        public CycledDynamicArray(IEnumerable<T> coll) : base(coll)
        {
        }
                
        public CycledDynamicArray<T> Cicled(IEnumerable<T> coll)
        {
            this.car = new CycledDynamicArray<T>(coll);
            foreach (var item in this.car)
            {
                this.car.AddRange(coll);
            }

            return this.car;
        }
    }
}
