namespace CalcLib.MathToken;

public interface IMathToken : IMathExpression
{
    public bool IsNumber();

    public bool IsEvaluated();

    public int GetTokenPriority();

    public void InsertInputToken(IMathToken input);

    public bool ContainsInputToken();
}
