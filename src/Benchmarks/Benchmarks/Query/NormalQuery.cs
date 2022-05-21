using Antlr4.Runtime;
using MathSample;
using MathSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarks.Query
{
    public class NormalQuery : IQuery
    {
        public string GetStr()
        {
            return "select owners.name, cats.name, breed, cats.age " +
                    "from cats " +
                    "inner join owners " +
                    "on owners.cat_name = cats.name " +
                    "where breed in ('sphinx', 'Persian', 'MaineCoon') " +
                    "and cats.age >= 1 " +
                    "and cats.age < 5 " +
                    "and cats.eyes = 'green' " +
                    "and cats.name like '%Barsik%' " +
                    "and owners.name in ('Alice', 'Katya')";
        }

        public List<IToken> GetTokens()
        {
            var tokens = new List<IToken>();
            tokens.Add(new MyToken() { Text = "select", Type = SqlGrammarLexer.SELECT });
            tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "breed", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "from", Type = SqlGrammarLexer.FROM });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "inner", Type = SqlGrammarLexer.INNER });
            tokens.Add(new MyToken() { Text = "join", Type = SqlGrammarLexer.JOIN });
            tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "on", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "cat_name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "=", Type = SqlGrammarLexer.EQ });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "where", Type = SqlGrammarLexer.WHERE });
            tokens.Add(new MyToken() { Text = "breed", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "in", Type = SqlGrammarLexer.IN });
            tokens.Add(new MyToken() { Text = "(", Type = SqlGrammarLexer.LPAREN });
            tokens.Add(new MyToken() { Text = "'Sphinx'", Type = SqlGrammarLexer.CHARACTER_STRING });
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "'Persian'", Type = SqlGrammarLexer.CHARACTER_STRING });
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "'MaineCoon'", Type = SqlGrammarLexer.CHARACTER_STRING });
            tokens.Add(new MyToken() { Text = ")", Type = SqlGrammarLexer.RPAREN });
            tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND });
            tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ">=", Type = SqlGrammarLexer.GEQT });
            tokens.Add(new MyToken() { Text = "1", Type = SqlGrammarLexer.INT });
            tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND });
            tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "<", Type = SqlGrammarLexer.LT });
            tokens.Add(new MyToken() { Text = "5", Type = SqlGrammarLexer.INT });
            tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "eyes", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "=", Type = SqlGrammarLexer.EQ });
            tokens.Add(new MyToken() { Text = "'green'", Type = SqlGrammarLexer.CHARACTER_STRING });
            tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "like", Type = SqlGrammarLexer.LIKE });
            tokens.Add(new MyToken() { Text = "'%Barsik%'", Type = SqlGrammarLexer.CHARACTER_STRING });
            tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND });
            tokens.Add(new MyToken() { Text = "owner", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "in", Type = SqlGrammarLexer.IN });
            tokens.Add(new MyToken() { Text = "(", Type = SqlGrammarLexer.LPAREN });
            tokens.Add(new MyToken() { Text = "'Alice'", Type = SqlGrammarLexer.CHARACTER_STRING });
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "'Katya'", Type = SqlGrammarLexer.CHARACTER_STRING });
            tokens.Add(new MyToken() { Text = ")", Type = SqlGrammarLexer.RPAREN });
            tokens.Add(new MyToken() { Text = "<EOF>", Type = -1 });
            return tokens;
        }
    }

}
