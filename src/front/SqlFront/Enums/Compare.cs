using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SqlSimple.Enums
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
