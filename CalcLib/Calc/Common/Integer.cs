using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Common
{
    internal class Integer
    {
        public int value { get; set; }

        public Integer()
        {
            this.value = 0;
        }

        public void Increment()
        {
            this.value++;
        }
    }
}
