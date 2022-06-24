using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.MathToken
{
    class NumberToken : IMathToken
    {
        private readonly double number;

        public NumberToken(double number)
        {
            this.number = number;
        }

        public double GetResult()
        {
            return this.number;
        }

        public int GetTokenPriority()
        {
            return -1;
        }

        public bool IsEvaluated()
        {
            return true;
        }

        public bool IsNumber()
        {
            return true;
        }

        public static IMathToken Parse(char[] rawData, Common.Integer currentIndex)
        {
            String numberAsString = "";

            while (currentIndex.value < rawData.Length)
            {
                char currentChar = rawData[currentIndex.value];
                

                if (Char.IsDigit(currentChar))
                {
                    numberAsString += currentChar;
                }
                else
                {
                    break;
                }

                currentIndex.Increment();
            }

            double number = Convert.ToDouble(numberAsString);

            return new NumberToken(number);
        }

        public void InsertInputToken(IMathToken input)
        {
            throw new NotImplementedException();
        }

        public bool ContainsInputToken()
        {
            return false;
        }
    }
}
