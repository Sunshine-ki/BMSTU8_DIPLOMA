using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathSample.Models
{
    public class AntlrErrorModel
    {
        public string Message { get; set; }
        public int Line { get; set; }
        public int Offset { get; set; }
        public IToken Token { get; set; }
        public IRecognizer Recognizer { get; set; }

        public override string ToString() => $"line {Line}:{Offset} {Message}";
    }
}
