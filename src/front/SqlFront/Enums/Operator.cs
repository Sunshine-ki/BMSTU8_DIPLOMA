﻿using System;
using System.ComponentModel;

namespace SqlSimple.Enums
{
    public enum Operator
    {
        [Description("+")]
        Addition = 0,
        [Description("-")]
        Subtraction = 1,
        [Description("*")]
        Multiplication = 2,
        [Description("/")]
        Division = 3
    }
}