using CalcLib.MathToken;

namespace CalcLib;

public class Calc
{
    public static double Compute(string mathExpression)
    {
        if (mathExpression == null)
        {
            throw new NullReferenceException("The math expression cannot be null");
        }

        if (mathExpression.Length == 0)
        {
            throw new ArgumentException("The math expression cannot be empty");
        }


        double output;
        IMathExpression parsedMathExpression;

        char[] rawMathExpression = mathExpression.ToCharArray();
        RawMathExpressionIterator iterator = new RawMathExpressionIterator(rawMathExpression);

        try
        {
            parsedMathExpression = Calc.Parse(iterator, false);
        }
        catch (Exception ex)
        {
            string errorMessage = string.Format("Error during math expression parsing => {0}", ex.Message);
            throw new ArgumentException(errorMessage, ex);
        }

        try
        {
            output = parsedMathExpression.GetResult();
        }
        catch (Exception ex)
        {
            string errorMessage = string.Format("Error during math expression solving => {0}", ex.Message);
            throw new Exception(errorMessage, ex);
        }


        return output;
    }

    private static IMathToken Parse(RawMathExpressionIterator iterator, bool startWithRoundBraketOpen)
    {
        IMathToken? currentToken = null;
        List<IMathToken> mathTokens = new List<IMathToken>();

        bool isPreviousOperator = false;
        bool endWithRoundBraketOpen = false;


        while (iterator.HasNext())
        {
            if (iterator.IsNextBlank())
            {
                iterator.Skip();
                isPreviousOperator = false;
            }
            else if (iterator.IsNextDigit())
            {
                currentToken = Calc.ParseDigit(iterator);
                isPreviousOperator = false;
            }
            else if (iterator.IsNextOpenRoundBracket())
            {
                iterator.Skip();
                currentToken = Calc.Parse(iterator, true);
                isPreviousOperator = false;
            }
            else if (iterator.IsNextClosedRoundBracket())
            {
                iterator.Skip();
                endWithRoundBraketOpen = true;
                break;
            }
            else if (isPreviousOperator)
            {
                string errorMessage = string.Format("'{0}' is an invalid character", iterator.GetNext());
                throw new ArgumentException(errorMessage);
            }
            else
            {
                currentToken = new MathOperatorToken(iterator.GetNext());
                isPreviousOperator = true;
            }

            if (currentToken != null)
            {
                mathTokens.Add(currentToken);
                currentToken = null;
            }
        }

        if (startWithRoundBraketOpen && !endWithRoundBraketOpen)
        {
            throw new Exception("Maybe you forgot a ')'!");
        }

        return compactTokenAccordingToPriority(mathTokens);
    }

    public static IMathToken ParseDigit(RawMathExpressionIterator iterator)
    {
        String numberAsString = "";

        do
        {
            numberAsString += iterator.GetNext();

        } while (iterator.HasNext() && iterator.IsNextDigit());

        double number = Convert.ToDouble(numberAsString);

        return new NumberToken(number);
    }

    private static IMathToken compactTokenAccordingToPriority(List<IMathToken> input)
    {
        while (input.Count > 1)
        {
            int currentMaxPriorityTokenIndex = getHigherPriorityTokenIndex(input);

            IMathToken targetToken = input[currentMaxPriorityTokenIndex];
            IMathToken x = input[currentMaxPriorityTokenIndex - 1];
            IMathToken y = input[currentMaxPriorityTokenIndex + 1];

            targetToken.InsertInputToken(x);
            targetToken.InsertInputToken(y);

            input.Remove(x);
            input.Remove(y);
        }

        return input[0];
    }

    private static int getHigherPriorityTokenIndex(List<IMathToken> input)
    {
        int output = -1;
        int currentMaxPriority = int.MinValue;


        for (int i = 0; i < input.Count; i++)
        {
            int currentPriority = input[i].GetTokenPriority();

            if (currentPriority > currentMaxPriority && !input[i].ContainsInputToken())
            {
                output = i;
                currentMaxPriority = currentPriority;
            }
        }

        return output;
    }
}
