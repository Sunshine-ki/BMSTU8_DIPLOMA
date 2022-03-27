using SqlSimple.Enums;
using SqlSimple.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SqlSimple.Context
{
    public partial class MainContext : INodesContext
    {
        [Node("Column name", "Input", "Basic", "Input column name")]
        public void ColumnName(string columnName, string tableName = "", AggregateFunction function = AggregateFunction.None)
        {
            var name = string.Empty;
            if (string.IsNullOrEmpty(tableName))
            {
                name = columnName;
            }
            else
            {
                name = string.Concat(tableName, Constants.POINT, columnName);
            }
            
            if (function != AggregateFunction.None)
            {
                appendToResult(function.GetDescription());
                appendToResult(Constants.LPAREN);
                appendToResult(name);
                appendToResult(Constants.RPAREN);
            }
        }


        [Node("Rename", "Input", "Basic", "Input new name for column name")]
        public void Rename(string newName)
        {
            appendToResult(Constants.AS);
            appendToResult(newName);
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

        [Node("Aggregate function", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
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
            appendToResult(Constants.POW);
            appendToResult(pow.ToString(CultureInfo.InvariantCulture));
        }
    }
}
