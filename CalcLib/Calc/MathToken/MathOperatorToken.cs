using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.MathToken
{
    public class MathOperatorToken : IMathToken
    {
        private bool isEvaluated;
        private MathOperation.IMathOperation mathOperation;
        private List<IMathToken> mathTokens;

        public MathOperatorToken(char mathSymbol)
        {
            this.mathTokens = new List<IMathToken>();
            this.mathOperation = MathOperation.MathOperationFactory.Build(mathSymbol);
            this.isEvaluated = false;
        }

        public double GetResult()
        {
            double[] mathTokenResults = new double[this.mathTokens.Count];

            for (int i = 0; i < this.mathTokens.Count; i++)
            {
                mathTokenResults[i] = this.mathTokens[i].GetResult();
            }

            return this.mathOperation.Perform(mathTokenResults);
        }
        public bool IsNumber()
        {
            return false;
        }

        public bool IsEvaluated()
        {
            return this.isEvaluated;
        }

        public void InsertInputToken(IMathToken input)
        {
            this.mathTokens.Add(input);
        }


        public int GetTokenPriority()
        {
            return this.mathOperation.GetPriority();     
        }

        public bool ContainsInputToken()
        {
            return this.mathTokens.Count != 0;
        }
    }
}
