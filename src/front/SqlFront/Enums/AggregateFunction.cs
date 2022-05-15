using System;
using System.ComponentModel;

namespace MathSample.ContextStr
{
    public enum AggregateFunction
    {
        [Description("none")]
        None = 0,
        [Description("count")]
        Count = 1,
        [Description("sum")]
        Sum = 2,
        [Description("avg")]
        Avg = 3,
        [Description("min")]
        Min = 4,
        [Description("max")]
        Max = 5
    }
}
