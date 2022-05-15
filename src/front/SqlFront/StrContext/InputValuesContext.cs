using MathSample.Enums;
using MathSample.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace MathSample.StrContext
{
    partial class MainStrContext : INodesContext
    {
        [Node("Column name", "Input", "Basic", "Input column name")]
        public void ColumnName(string columnName, string tableName = "",
            AggregateFunction function = AggregateFunction.None, string rename = "")
        {
            var name = string.IsNullOrEmpty(tableName) ?
                       columnName :
                       string.Concat(tableName, Tokens.POINT, columnName);

            if (function != AggregateFunction.None)
            {
                appendToResult(function.GetDescription());
                appendToResult(Tokens.LPAREN);
                appendToResult(name);
                appendToResult(Tokens.RPAREN);
            }
            else
            {
                appendToResult(name);
            }

            if (!string.IsNullOrEmpty(rename)) appendToResult($"{Tokens.AS} {rename}");
        }

        [Node("Table name", "Input", "Basic", "Input column name")]
        public void TableName(string tableName, string rename = "")
        {
            appendToResult(tableName);
            if (!string.IsNullOrEmpty(rename)) appendToResult($"{Tokens.AS} {rename}");
        }

        [Node("Rename", "Input", "Basic", "Input new name for column name")]
        public void Rename(string newName)
        {
            appendToResult($"{Tokens.AS} {newName}");
        }

        [Node("Input string", "Input", "Basic")]
        public void String(string InputString, StringType type = StringType.Character)
        {
            var typeResult = string.Empty;
            switch (type)
            {
                case StringType.BinaryX:
                    typeResult = "X";
                    break;
                case StringType.BinaryB:
                    typeResult = "B";
                    break;
            }

            appendToResult($"{typeResult}\'{InputString}\'");
        }

        [Node("Input time", "Input", "Basic")]
        public void Time(int hour = 0, int minute = 0, int second = 0)
        {
            appendToResult($"\'{hour}:{minute}:{second}\'");
        }


        [Node("Sign", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Sign(Sing sing)
        {
            appendToResult(sing.GetDescription());
        }

        [Node("Operator", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Operator(Operator Operator)
        {
            appendToResult(Operator.GetDescription());
        }

        [Node("Compare", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Compare(Compare compare)
        {
            appendToResult(compare.GetDescription());
        }

        [Node("Aggregate function", "Input", "Basic", width: Constants.WidthOnlyOneWord)] // Use it with only "(" and  ")"
        public void Compare(AggregateFunction function)
        {
            appendToResult(function.GetDescription());
        }

        [Node("Number Int", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void IntNumber(int number)
        {
            appendToResult(number.ToString());
        }

        [Node("Number Float", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void FloatNumber(float number)
        {
            appendToResult(number.ToString(CultureInfo.InvariantCulture));
        }

        [Node("Number Exponential", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void ExponentialNumber(string number)
        {
            appendToResult(number.Replace(',', '.'));
        }

        [Node("Number in a power", "Input", "Basic")]
        public void NumberInPower(decimal number, decimal pow)
        {
            appendToResult(number.ToString(CultureInfo.InvariantCulture));
            appendToResult(Tokens.POW);
            appendToResult(pow.ToString(CultureInfo.InvariantCulture));
        }

        [Node("Limit", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Limit(int number)
        {
            appendToResult($"{Tokens.LIMIT} {number}");
        }

        [Node("Offset", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Offset(int number)
        {
            appendToResult($"{Tokens.OFFSET} {number}");
        }

        [Node("Direction", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Direction(Direction direction)
        {
            appendToResult(direction.GetDescription());
        }

    }
}
