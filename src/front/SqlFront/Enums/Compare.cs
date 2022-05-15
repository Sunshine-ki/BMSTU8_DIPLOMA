using System;
using System.ComponentModel;

namespace MathSample.StrContext
{
    public enum Compare
    {
        [Description("=")]
        Equal = 0,
        [Description("!=")]
        NotEqual = 1,
        [Description(">")]
        GraterThan = 2,
        [Description("<")]
        LessThan = 3,
    }
}
