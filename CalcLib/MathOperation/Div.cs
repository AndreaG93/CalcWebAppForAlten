namespace CalcLib.MathOperation;

internal class Div : IMathOperation
{
    public double Perform(double[] parameters)
    {

        double output = parameters[0];

        for (int i = 1; i < parameters.Length; i++)
        {
            output /= parameters[i];
        }

        return output;
    }

    public int GetPriority()
    {
        return 1;
    }
}
