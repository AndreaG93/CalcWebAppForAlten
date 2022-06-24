using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.MathOperation
{
    interface IMathOperation
    {
        public double Perform(double[] parameters);

        public int GetPriority();
    }
}
