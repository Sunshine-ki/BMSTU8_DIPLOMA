using System;
using System.ComponentModel;

namespace MathSample.Enums
{
    public enum Operator
    {
        [Description("+")]
        Addition = 0,
        [Description("-")]
        Subtraction = 1,
        [Description("*")]
        multiplication = 2,
        [Description("/")]
        division = 3
    }
}
