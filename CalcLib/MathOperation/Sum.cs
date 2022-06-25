namespace CalcLib.MathOperation;

class Sum : IMathOperation
{
    public double Perform(double[] parameters)
    {
        double output = 0;

        foreach (double item in parameters)
        {
            output += item;
        }

        return output;
    }

    public int GetPriority()
    {
        return 0;
    }
}
