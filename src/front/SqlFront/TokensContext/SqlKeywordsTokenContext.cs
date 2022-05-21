using MathSample.Enums;
using MathSample.Helpers;
using MathSample.StrContext;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathSample.TokensContext
{
    partial class MainTokensContext : INodesContext
    {
        [Node("Select", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Select()
        {
            appendToResult(Tokens.SELECT, SqlGrammarLexer.SELECT);
        }


        [Node("Distinct", "Keywords", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Distinct(Distinct distinct)
        {
            appendToResult(distinct.GetDescription(), distinct.GetTokenType());
        }

        [Node("All data", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void AllData()
        {
            appendToResult(Tokens.ALL_DATA, SqlGrammarLexer.STAR);
        }

        [Node("Case", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Case()
        {
            appendToResult(Tokens.CASE, SqlGrammarLexer.CASE);
        }

        [Node("When", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void When()
        {
            appendToResult(Tokens.WHEN, SqlGrammarLexer.WHEN);
        }

        [Node("Then", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Then()
        {
            appendToResult(Tokens.THEN, SqlGrammarLexer.THEN);
        }

        [Node("Else", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Else()
        {
            appendToResult(Tokens.ELSE, SqlGrammarLexer.ELSE);
        }

        [Node("End case", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void EndCase()
        {
            appendToResult(Tokens.END, SqlGrammarLexer.END);
        }

        [Node("From", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void From()
        {
            appendToResult(Tokens.FROM, SqlGrammarLexer.FROM);
        }

        [Node("Where", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Where()
        {
            appendToResult(Tokens.WHERE, SqlGrammarLexer.WHERE);
        }

        [Node("Having", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Having()
        {
            appendToResult(Tokens.HAVING, SqlGrammarLexer.HAVING);
        }

        [Node("Union", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Union()
        {
            appendToResult(Tokens.UNION, SqlGrammarLexer.UNION);
        }

        [Node("Except", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Except()
        {
            appendToResult(Tokens.EXCEPT, SqlGrammarLexer.EXCEPT);
        }

        [Node("Order by", "Keywords", "Basic")]
        public void OrderBy(string columnName, Direction direction)
        {
            appendToResult(Tokens.ORDER, SqlGrammarLexer.ORDER);
            appendToResult(Tokens.BY, SqlGrammarLexer.BY);
            appendToResult(columnName, SqlGrammarLexer.NAME);
            appendToResult(direction.GetDescription(), direction.GetTokenType());
        }

        [Node("Limit", "Keywords", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Limit(int number)
        {
            appendToResult(Tokens.LIMIT, SqlGrammarLexer.LIMIT);
            appendToResult(number.ToString(), SqlGrammarLexer.INT);
        }

        [Node("Offset", "Keywords", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Offset(int number)
        {
            appendToResult(Tokens.OFFSET, SqlGrammarLexer.OFFSET);
            appendToResult(number.ToString(), SqlGrammarLexer.INT);
        }

        [Node("Join", "Keywords", "Basic")]
        public void Join(bool Natural, bool Outer, JoinType joinType = Enums.JoinType.LEFT)
        {
            if (joinType == Enums.JoinType.CROSS_JOIN)
            {
                appendToResult(Tokens.CROSS, SqlGrammarLexer.CROSS);
                appendToResult(Tokens.JOIN, SqlGrammarLexer.JOIN);
                return;
            }

            if (Natural)
            {
                appendToResult(Tokens.NATURAL, SqlGrammarLexer.NATURAL);
            }

            if (joinType == Enums.JoinType.INNER)
            {
                appendToResult(Tokens.INNER, SqlGrammarLexer.INNER);
                appendToResult(Tokens.JOIN, SqlGrammarLexer.JOIN);
                return;
            }

            appendToResult(joinType.GetDescription(), joinType.GetTokenType());
            appendToResult(Tokens.JOIN, SqlGrammarLexer.JOIN);
        }

        [Node("On", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void On()
        {
            appendToResult(Tokens.ON, SqlGrammarLexer.ON);
        }
    }
}
