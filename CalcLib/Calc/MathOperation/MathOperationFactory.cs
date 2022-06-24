using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.MathOperation
{
    internal class MathOperationFactory
    {
        public static IMathOperation Build(char mathSymbol)
        {
            IMathOperation? output;

            switch (mathSymbol)
            {
                case '+':
                    output = new Sum();
                    break;
                case '-':
                    output = new Sub();
                    break;
                case '*':
                    output = new Mul();
                    break;
                case '/':
                    output = new Div();
                    break;
                default:
                    string errorMessage = string.Format("'{}' is not a valid math operator!", mathSymbol);
                    throw new ArgumentException(errorMessage);
            }

            return output;
        }
    }
}
