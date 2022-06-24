using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{

    internal class MathExpressionParser
    {

        private readonly char[] rawExpression;

        public MathExpressionParser(string input)
        {
            this.rawExpression = input.ToCharArray();
        }

        public IMathExpression GetMathExpression()
        {
           
            Common.Integer currentIndex = new Common.Integer();

            return this.Parse(currentIndex, false); ;
        }

        private MathToken.IMathToken Parse(Common.Integer currentIndex, bool braketOpen)
        {
            MathToken.IMathToken? currentIMathToken;
            List<MathToken.IMathToken> mathTokens = new List<MathToken.IMathToken>();

            bool previuosTokenFoundIsAnOperator = false;
            bool isPreviousBraketClosed = false;


            while (currentIndex.value < rawExpression.Length)
            {
                char currentChar = rawExpression[currentIndex.value];

                if (currentChar == ' ')
                {
                    currentIndex.Increment();
                    previuosTokenFoundIsAnOperator = false;
                }
                else if (Char.IsDigit(currentChar))
                {
                    currentIMathToken = MathToken.NumberToken.Parse(this.rawExpression, currentIndex);
                    mathTokens.Add(currentIMathToken);
                    previuosTokenFoundIsAnOperator = false;
                }
                else if (currentChar == '(')
                {
                    currentIndex.Increment();
                    currentIMathToken = this.Parse(currentIndex, true);
                    mathTokens.Add(currentIMathToken);
                    previuosTokenFoundIsAnOperator = false;
                }
                else if (currentChar == ')')
                {
                    currentIndex.Increment();
                    isPreviousBraketClosed = true;
                    break;
                }
                else
                {
                    if (previuosTokenFoundIsAnOperator)
                    {
                        throw new Exception("Invalid Expression");
                    }

                    currentIMathToken = new MathToken.MathOperatorToken(currentChar);
                    mathTokens.Add(currentIMathToken);
                    currentIndex.Increment();
                    previuosTokenFoundIsAnOperator = true;
                }
            }

            if (braketOpen && !isPreviousBraketClosed)
            {
                throw new Exception("Invalid Expression");
            }

            return compactTokenAccordingToPriority(mathTokens);
        }


        private MathToken.IMathToken compactTokenAccordingToPriority(List<MathToken.IMathToken> input)
        {
            while (input.Count > 1)
            {
                int currentMaxPriorityTokenIndex = getHigherPriorityTokenIndex(input);

                MathToken.IMathToken targetToken = input[currentMaxPriorityTokenIndex];
                MathToken.IMathToken x = input[currentMaxPriorityTokenIndex - 1];
                MathToken.IMathToken y = input[currentMaxPriorityTokenIndex + 1];

                targetToken.InsertInputToken(x);
                targetToken.InsertInputToken(y);

                input.Remove(x);
                input.Remove(y);
            }

            return input[0];
        }

        private int getHigherPriorityTokenIndex(List<MathToken.IMathToken> input)
        {
            int output = -1;
            int currentMaxPriority = int.MinValue;


            for (int i = 0; i < input.Count; i++)
            {
                int currentPriority = input[i].GetTokenPriority();

                if ((currentPriority > currentMaxPriority) && (!input[i].ContainsInputToken()))
                {
                    output = i;
                    currentMaxPriority = currentPriority;
                }
            }

            return output;
        }
    }
}
