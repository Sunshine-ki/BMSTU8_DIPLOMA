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
        [Node("Column name", "Input", "Basic", "Input column name")]
        public void ColumnName(string columnName, string tableName = "",
                AggregateFunction function = AggregateFunction.None, string rename = "")
        {
            if (function != AggregateFunction.None)
            {
                appendToResult(function.GetDescription(), function.GetTokenType());
                appendToResult(Tokens.LPAREN, SqlGrammarLexer.LPAREN);
                appendNameWithTable(columnName, tableName);
                appendToResult(Tokens.RPAREN, SqlGrammarLexer.RPAREN);
            }
            else
            {
                appendNameWithTable(columnName, tableName);
            }

            if (!string.IsNullOrEmpty(rename))
            {
                appendToResult(Tokens.AS, SqlGrammarLexer.AS);
                appendToResult(rename, SqlGrammarLexer.NAME);
            }

        }

        private void appendNameWithTable(string columnName, string tableName = "")
        {
            if (string.IsNullOrEmpty(tableName))
            {
                appendToResult(columnName, SqlGrammarLexer.NAME);
            }
            else
            {
                appendToResult(tableName, SqlGrammarLexer.NAME);
                appendToResult(Tokens.POINT, SqlGrammarLexer.POINT);
                appendToResult(columnName, SqlGrammarLexer.NAME);
            }
        }
    }
}
