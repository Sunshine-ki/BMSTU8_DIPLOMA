﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathSample.Models
{
    public class MyToken : IToken
    {
        public string Text { get; set; }

        public int Type { get; set; }

        public int Line { get; set; }

        public int Column { get; set; }

        public int Channel { get; set; }

        public int TokenIndex { get; set; }

        public int StartIndex { get; set; }

        public int StopIndex { get; set; }

        public ITokenSource TokenSource { get; set; }

        public ICharStream InputStream { get; set; }
    }

}
