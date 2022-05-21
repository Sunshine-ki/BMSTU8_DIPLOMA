using Antlr4.Runtime;
using MathSample.Models;
using System.Collections.Generic;
using System;

namespace Benchmarks.Query
{
    public class EasyQuery : IQuery
    {
        public string GetStr()
        {
            return "";
        }

        public List<IToken> GetTokens()
        {
            var tokens = new List<IToken>();
            tokens.Add(new MyToken() { Text = "<EOF>", Type = -1 });
            return tokens;
        }
    }
}
