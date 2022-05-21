using MathSample.Enums;
using MathSample.Helpers;
using MathSample.StrContext;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            appendRename(rename);
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
        
        private void appendRename(string rename = "")
        {
            if (!string.IsNullOrEmpty(rename))
            {
                appendToResult(Tokens.AS, SqlGrammarLexer.AS);
                appendToResult(rename, SqlGrammarLexer.NAME);
            }
        }

        [Node("Table name", "Input", "Basic", "Input column name")]
        public void TableName(string tableName, string rename = "")
        {
            appendToResult(tableName, SqlGrammarLexer.NAME);
            appendRename(rename);
        }

        [Node("Rename", "Input", "Basic", "Input new name for column name")]
        public void Rename(string newName)
        {
            appendRename(newName);
        }

        [Node("Input string", "Input", "Basic")]
        public void String(string InputString, StringType type = StringType.Character)
        {
            var typeResult = string.Empty;
            int tokenType = SqlGrammarLexer.CHARACTER_STRING;

            switch (type)
            {
                case StringType.BinaryX:
                    typeResult = "X";
                    tokenType = SqlGrammarLexer.X_STRING;
                    break;
                case StringType.BinaryB:
                    typeResult = "B";
                    tokenType = SqlGrammarLexer.B_STRING;
                    break;
            }

            appendToResult($"{typeResult}\'{InputString}\'", tokenType);
        }

        [Node("Input time", "Input", "Basic")]
        public void Time(int hour = 0, int minute = 0, int second = 0)
        {
            appendToResult($"\'{hour}:{minute}:{second}\'", SqlGrammarLexer.TIME);
        }


        [Node("Sign", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Sign(Sing sing)
        {
            appendToResult(sing.GetDescription(), sing.GetTokenType());
        }

        [Node("Operator", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Operator(Operator Operator)
        {
            appendToResult(Operator.GetDescription(), Operator.GetTokenType());
        }

        [Node("Compare", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Compare(Compare compare)
        {
            appendToResult(compare.GetDescription(), compare.GetTokenType());
        }

        [Node("Aggregate function", "Input", "Basic", width: Constants.WidthOnlyOneWord)] // Use it with only "(" and  ")"
        public void Compare(AggregateFunction function)
        {
            appendToResult(function.GetDescription(), function.GetTokenType());
        }


        [Node("Number Int", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void IntNumber(int number)
        {
            appendToResult(number.ToString(), SqlGrammarLexer.INT);
        }

        [Node("Number Float", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void FloatNumber(float number)
        {
            appendToResult(number.ToString(CultureInfo.InvariantCulture), SqlGrammarLexer.FLOAT);
        }

        [Node("Number Exponential", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void ExponentialNumber(string number)
        {
            appendToResult(number.Replace(',', '.'), SqlGrammarLexer.EXP_NUMBER);
        }

        [Node("Number in a power", "Input", "Basic")]
        public void NumberInPower(decimal number, decimal pow)
        {
            appendToResult(number.ToString(CultureInfo.InvariantCulture), SqlGrammarLexer.FLOAT);
            appendToResult(Tokens.POW, SqlGrammarLexer.POW);
            appendToResult(pow.ToString(CultureInfo.InvariantCulture), SqlGrammarLexer.FLOAT);
        }

        [Node("Direction", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Direction(Direction direction)
        {
            appendToResult(direction.GetDescription(), direction.GetTokenType());
        }
    }
}
