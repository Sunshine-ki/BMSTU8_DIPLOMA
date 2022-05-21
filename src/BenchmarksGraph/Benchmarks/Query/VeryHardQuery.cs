using Antlr4.Runtime;
using MathSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarks.Query
{
    public class VeryHardQuery : IQuery
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
