using System;
using System.ComponentModel;

namespace MathSample.Enums
{
    public enum Sing
    {
        [Description("+")]
        Positive = 0,
        [Description("-")]
        Negative = 1
    }
}
