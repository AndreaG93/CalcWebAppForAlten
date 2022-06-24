using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.MathToken
{
    public interface IMathToken : IMathExpression
    {

        public bool IsNumber();

        public bool IsEvaluated();

        public int GetTokenPriority();

        public void InsertInputToken(IMathToken input);

        public bool ContainsInputToken();
    }

}
