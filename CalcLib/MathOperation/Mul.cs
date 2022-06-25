namespace CalcLib.MathOperation;


internal class Mul : IMathOperation
{
    public double Perform(double[] parameters)
    {
        double output = 1;

        foreach (double item in parameters)
        {
            output *= item;
        }

        return output;
    }

    public int GetPriority()
    {
        return 1;
    }
}

