using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SqlSimple.Enums
{
    public enum Direction
    {
        [Description("ASC")]
        Asc,
        [Description("DESC")]
        Desc,
    }
}
