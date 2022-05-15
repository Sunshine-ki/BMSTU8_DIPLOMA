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

        public override string ToString()
        {

            //Console.WriteLine($"From ToString() Token: {Token.Type} {Token.Text} {Token.StartIndex} {Token.StopIndex}");
            //Console.WriteLine($"From ToString() Recognizer: {Recognizer.Vocabulary.GetDisplayName(Token.Type)} ");
            //Console.WriteLine($"From ToString() Recognizer: {Recognizer.Vocabulary.GetLiteralName(Token.Type)} ");
            //Console.WriteLine($"From ToString() Recognizer: {Recognizer.Vocabulary.GetSymbolicName(Token.Type)} ");

            //Console.WriteLine($"From ToString() Recognizer: {Recognizer.InputStream.SourceName}");
            return $"line {Line}:{Offset} {Message}";
        }

    }
}
