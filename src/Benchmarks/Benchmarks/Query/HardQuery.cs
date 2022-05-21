using Antlr4.Runtime;
using MathSample;
using MathSample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarks.Query
{
    public class HardQuery : IQuery
    {
        public string GetStr()
        {
            return "select owners.name as own, count(owners.name) as con, cats.name as cn, breed as b, cats.age as ca, dogs.eyes as de, cats.eyes as ce " +
                    "from " +
                    "(select * " +
                    "from cats) " +
                    "inner join owners " +
                    "on owners.cat_name = cats.name " +
                    "where breed in ('sphinx', 'Persian', 'Maine') " +
                    "and cats.age >= 1 " +
                    "and cats.age < 5 " +
                    "and cats.eyes = 'green' " +
                    "and cats.name like '%Barsik%' " +
                    "and owners.name in ('Alice', 'Katya') " +
                    "having owners.age >= 5 " +
                    "and owners.age < 18 " +
                    "order by count(owners.name) desc";
        }

        public List<IToken> GetTokens()
        {
            var tokens = new List<IToken>();
            tokens.Add(new MyToken() { Text = "select", Type = SqlGrammarLexer.SELECT });
            tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "as", Type = SqlGrammarLexer.AS });
            tokens.Add(new MyToken() { Text = "own", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "count", Type = SqlGrammarLexer.COUNT });
            tokens.Add(new MyToken() { Text = "(", Type = SqlGrammarLexer.LPAREN});
            tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ")", Type = SqlGrammarLexer.RPAREN});
            tokens.Add(new MyToken() { Text = "as", Type = SqlGrammarLexer.AS });
            tokens.Add(new MyToken() { Text = "con", Type = SqlGrammarLexer.NAME });

            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "as", Type = SqlGrammarLexer.AS });
            tokens.Add(new MyToken() { Text = "cn", Type = SqlGrammarLexer.NAME });

            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "breed", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "as", Type = SqlGrammarLexer.AS });
            tokens.Add(new MyToken() { Text = "b", Type = SqlGrammarLexer.NAME });

            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "as", Type = SqlGrammarLexer.AS });
            tokens.Add(new MyToken() { Text = "ca", Type = SqlGrammarLexer.NAME });

            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "dogs", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "eyes", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "as", Type = SqlGrammarLexer.AS });
            tokens.Add(new MyToken() { Text = "de", Type = SqlGrammarLexer.NAME });

            tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "eyes", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "as", Type = SqlGrammarLexer.AS });
            tokens.Add(new MyToken() { Text = "ce", Type = SqlGrammarLexer.NAME });

            tokens.Add(new MyToken() { Text = "from", Type = SqlGrammarLexer.FROM });
            tokens.Add(new MyToken() { Text = "(", Type = SqlGrammarLexer.LPAREN});
            tokens.Add(new MyToken() { Text = "select", Type = SqlGrammarLexer.SELECT });
            tokens.Add(new MyToken() { Text = "*", Type = SqlGrammarLexer.STAR});
            tokens.Add(new MyToken() { Text = "from", Type = SqlGrammarLexer.FROM });
            tokens.Add(new MyToken() { Text = "cats", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ")", Type = SqlGrammarLexer.RPAREN});
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
            tokens.Add(new MyToken() { Text = "having", Type = SqlGrammarLexer.RPAREN });
            tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ">=", Type = SqlGrammarLexer.GEQT });
            tokens.Add(new MyToken() { Text = "5", Type = SqlGrammarLexer.INT });
            tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND });
            tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "<", Type = SqlGrammarLexer.LT });
            tokens.Add(new MyToken() { Text = "18", Type = SqlGrammarLexer.INT });
            tokens.Add(new MyToken() { Text = "order", Type = SqlGrammarLexer.ORDER });
            tokens.Add(new MyToken() { Text = "by", Type = SqlGrammarLexer.BY });
            tokens.Add(new MyToken() { Text = "count", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = "(", Type = SqlGrammarLexer.LPAREN });
            tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            tokens.Add(new MyToken() { Text = ")", Type = SqlGrammarLexer.RPAREN });
            tokens.Add(new MyToken() { Text = "desc", Type = SqlGrammarLexer.DESC });
            //tokens.Add(new MyToken() { Text = "union", Type = SqlGrammarLexer.UNION });
            //tokens.Add(new MyToken() { Text = "select", Type = SqlGrammarLexer.SELECT });
            //tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            //tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            //tokens.Add(new MyToken() { Text = "dogs", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            //tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            //tokens.Add(new MyToken() { Text = "breed", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            //tokens.Add(new MyToken() { Text = "dogs", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            //tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = "from", Type = SqlGrammarLexer.FROM });
            //tokens.Add(new MyToken() { Text = "dogs", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = "inner", Type = SqlGrammarLexer.INNER });
            //tokens.Add(new MyToken() { Text = "join", Type = SqlGrammarLexer.JOIN });
            //tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = "on", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = "owners", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            //tokens.Add(new MyToken() { Text = "dog_name", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = "=", Type = SqlGrammarLexer.EQ });
            //tokens.Add(new MyToken() { Text = "dogs", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            //tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = "where", Type = SqlGrammarLexer.WHERE });
            //tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ">=", Type = SqlGrammarLexer.GEQT });
            //tokens.Add(new MyToken() { Text = "1", Type = SqlGrammarLexer.INT });
            //tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND });
            //tokens.Add(new MyToken() { Text = "age", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = "<", Type = SqlGrammarLexer.LT });
            //tokens.Add(new MyToken() { Text = "5", Type = SqlGrammarLexer.INT });
            //tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND });
            //tokens.Add(new MyToken() { Text = "dogs", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            //tokens.Add(new MyToken() { Text = "eyes", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = "=", Type = SqlGrammarLexer.EQ });
            //tokens.Add(new MyToken() { Text = "'green'", Type = SqlGrammarLexer.CHARACTER_STRING });
            //tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND });
            //tokens.Add(new MyToken() { Text = "dogs", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            //tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = "like", Type = SqlGrammarLexer.LIKE });
            //tokens.Add(new MyToken() { Text = "'%Fenya%'", Type = SqlGrammarLexer.CHARACTER_STRING });
            //tokens.Add(new MyToken() { Text = "and", Type = SqlGrammarLexer.AND });
            //tokens.Add(new MyToken() { Text = "owner", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = ".", Type = SqlGrammarLexer.POINT });
            //tokens.Add(new MyToken() { Text = "name", Type = SqlGrammarLexer.NAME });
            //tokens.Add(new MyToken() { Text = "in", Type = SqlGrammarLexer.IN });
            //tokens.Add(new MyToken() { Text = "(", Type = SqlGrammarLexer.LPAREN });
            //tokens.Add(new MyToken() { Text = "'Masha'", Type = SqlGrammarLexer.CHARACTER_STRING });
            //tokens.Add(new MyToken() { Text = ",", Type = SqlGrammarLexer.COMMA });
            //tokens.Add(new MyToken() { Text = "'Pasha'", Type = SqlGrammarLexer.CHARACTER_STRING });
            //tokens.Add(new MyToken() { Text = ")", Type = SqlGrammarLexer.RPAREN });


            tokens.Add(new MyToken() { Text = "<EOF>", Type = -1 });
            return tokens;
        }
    }
}
