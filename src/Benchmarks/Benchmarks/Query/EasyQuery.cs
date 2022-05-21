using Antlr4.Runtime;
using MathSample.Models;
using System.Collections.Generic;
using System;
using MathSample;

namespace Benchmarks.Query
{
    public class EasyQuery : IQuery
    {
        public string GetStr()
        {
            return "select name, breed, age " +
                   "from cats " +
                   "where breed in ('Sphinx', 'Persian', 'MaineCoon') " +
                   "and age >= 1 " +
                   "and age < 5";
        }

        public List<IToken> GetTokens()
        {
            var tokens = new List<IToken>();
            tokens.Add(new MyToken() { Text = "select", Type = SqlGrammarLexer.SELECT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME});
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "breed", Type = SqlGrammarLexer.NAME});
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "from", Type = SqlGrammarLexer.FROM});
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "where", Type = SqlGrammarLexer.WHERE });
            tokens.Add(new MyToken() { Text = "breed", Type = SqlGrammarLexer.NAME});
            tokens.Add(new MyToken() { Text = "in", Type = SqlGrammarLexer.IN});
            tokens.Add(new MyToken() { Text = "(", Type = SqlGrammarLexer.LPAREN});
            tokens.Add(new MyToken() { Text = "'Sphinx'", Type = SqlGrammarLexer.CHARACTER_STRING });
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "'Persian'", Type = SqlGrammarLexer.CHARACTER_STRING });
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "'MaineCoon'", Type = SqlGrammarLexer.CHARACTER_STRING });
            tokens.Add(new MyToken() { Text = ")", Type = SqlGrammarLexer.RPAREN});
            tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND});
            tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ">=", Type = SqlGrammarLexer.GEQT });
            tokens.Add(new MyToken() { Text = "1", Type = SqlGrammarLexer.INT });
            tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND});
            tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "<", Type = SqlGrammarLexer.LT });
            tokens.Add(new MyToken() { Text = "1", Type = SqlGrammarLexer.INT });
            tokens.Add(new MyToken() { Text = "<EOF>", Type = -1 });
            return tokens;
        }
    }
}
