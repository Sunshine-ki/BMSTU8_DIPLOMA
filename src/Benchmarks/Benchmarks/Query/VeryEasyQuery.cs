using System;
using Antlr4.Runtime;
using MathSample;
using MathSample.Models;
using System.Collections.Generic;

namespace Benchmarks.Query
{
    public class VeryEasyQuery : IQuery
    {
        public string GetStr()
        {
            return "select name " +
                   "from cats";
        }

        public List<IToken> GetTokens()
        {
            var tokens = new List<IToken>();
            tokens.Add(new MyToken() { Text = "select", Type = SqlGrammarLexer.SELECT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "from", Type = SqlGrammarLexer.FROM });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "<EOF>", Type = -1 });
            return tokens;
        }
    }
}
