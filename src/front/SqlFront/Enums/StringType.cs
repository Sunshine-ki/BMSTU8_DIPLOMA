using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SqlSimple.Enums
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
