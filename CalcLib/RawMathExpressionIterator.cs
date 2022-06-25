using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib;

public class RawMathExpressionIterator
{
    private int currentIndex { get; set; }

    private readonly char[] rawMathExpression;

    public RawMathExpressionIterator(char[] rawMathExpression)
    {
        this.rawMathExpression = rawMathExpression;
        this.currentIndex = -1;
    }

    public bool HasNext()
    {
        return this.currentIndex + 1 < this.rawMathExpression.Length;
    }

    public char GetNext()
    {
        this.Skip();

        return this.rawMathExpression[this.currentIndex];
    }

    public void Skip()
    {   
        this.currentIndex++;
    }

    public bool IsNextDigit()
    {
        return char.IsDigit(this.rawMathExpression[this.currentIndex + 1]);
    }

    public bool IsNextOpenRoundBracket()
    {
        return this.rawMathExpression[this.currentIndex + 1] == '(';
    }

    public bool IsNextClosedRoundBracket()
    {
        return this.rawMathExpression[this.currentIndex + 1] == ')';
    }

    public bool IsNextBlank()
    {
        return this.rawMathExpression[this.currentIndex + 1] == ' ';
    }
}
