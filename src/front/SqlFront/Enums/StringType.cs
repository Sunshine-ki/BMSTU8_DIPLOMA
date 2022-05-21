using System;
using System.ComponentModel;

namespace MathSample.Enums
{
    public enum StringType
    {
        [Description("character")]
        Character = 0,
        [Description("b_binary")]
        BinaryB,
        [Description("x_binary")]
        BinaryX,
    }
}
