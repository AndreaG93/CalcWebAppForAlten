using CalcLib.MathOperation;

namespace CalcLib.MathToken;

public class MathOperatorToken : IMathToken
{
    private bool isEvaluated;
    private IMathOperation mathOperation;
    private List<IMathToken> mathTokens;

    public MathOperatorToken(char mathSymbol)
    {
        this.mathTokens = new List<IMathToken>();
        this.mathOperation = MathOperationFactory.Build(mathSymbol);
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

