using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.MathOperation
{
    internal class Div : IMathOperation
    {
        public double Perform(double[] parameters)
        {

            double output = parameters[0];

            for (int i = 1; i < parameters.Length; i++)
            {
                output /= parameters[i];
            }

            return output;
        }

        public int GetPriority()
        {
            return 1;
        }
    }
}
