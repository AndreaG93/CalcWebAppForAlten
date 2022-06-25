namespace CalcLib.MathOperation;

interface IMathOperation
{
    public double Perform(double[] parameters);

    public int GetPriority();
}
