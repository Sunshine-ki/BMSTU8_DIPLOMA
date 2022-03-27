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
        public void ColumnName(string columnName, string tableName = "")
        {
            if (string.IsNullOrEmpty(tableName))
            {
                appendToResult(columnName);
            }
            else
            {
                appendToResult(tableName);
                appendToResult(".");
                appendToResult(columnName);
            }
        }

        [Node("Rename", "Input", "Basic", "Input new name for column name")]
        public void Rename(string newName)
        {
            appendToResult("as");
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
            appendToResult(number.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));
        }
    }
}
