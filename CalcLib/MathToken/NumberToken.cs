namespace CalcLib.MathToken;

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

    public void InsertInputToken(IMathToken input)
    {
        throw new NotImplementedException();
    }

    public bool ContainsInputToken()
    {
        return false;
    }
}
