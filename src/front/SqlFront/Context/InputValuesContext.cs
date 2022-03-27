using MathSample.Enums;
using MathSample.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MathSample.Context
{
    public partial class MainContext : INodesContext
    {
        [Node("Column name", "Input", "Basic", "Input column name")]
        public void ColumnName(string columnName)
        {
            appendStringToResult(columnName);
        }

        [Node("Rename", "Input", "Basic", "Input new name for column name")]
        public void Rename(string newName)
        {
            appendStringToResult("as");
            appendStringToResult(newName);
        }


        [Node("Sign", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Sign(Sing sing)
        {
            appendStringToResult(sing.GetDescription());
        }

        [Node("Operator", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Operator(Operator Operator)
        {
            appendStringToResult(Operator.GetDescription());
        }


        [Node("Number Int", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void IntNumber(int number)
        {
            appendStringToResult(number.ToString());
        }

        [Node("Number Float", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void FloatNumber(float number)
        {
            appendStringToResult(number.ToString(CultureInfo.InvariantCulture));
        }

        [Node("Number Exponential", "Input", "Basic", width: Constants.WidthOnlyOneWord)]
        public void ExponentialNumber(string number)
        {
            appendStringToResult(number.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));
        }
    }
}
