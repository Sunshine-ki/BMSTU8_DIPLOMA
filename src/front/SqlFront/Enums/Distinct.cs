using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SqlSimple.Enums
{
    public enum Distinct
    {
        [Description("distinct")]
        Distinct = 0,
        [Description("all")]
        All = 1
    }
}
