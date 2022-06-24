using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.MathOperation
{
    internal class Mul : IMathOperation
    {
        public double Perform(double[] parameters)
        {
            double output = 1;

            foreach (double item in parameters)
            {
                output *= item;
            }

            return output;
        }

        public int GetPriority()
        {
            return 1;
        }
    }
}
