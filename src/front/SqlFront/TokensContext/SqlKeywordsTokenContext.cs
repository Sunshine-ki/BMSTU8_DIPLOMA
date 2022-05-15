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
    }
}
