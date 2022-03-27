using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathSample.Enums;
using MathSample.Helpers;
using NodeEditor;

namespace MathSample.Context
{
    // Main context of the sample, each
    // method corresponds to a node by attribute decoration
    public partial class MainContext : INodesContext
    {
        public NodeVisual CurrentProcessingNode { get; set; }
        public event Action<string, NodeVisual, FeedbackType, object, bool> FeedbackInfo;

        public event Action<string> OnResult;
        private StringBuilder _result = new StringBuilder();

        private void appendStringToResult(string str)
        {
            _result.Append(str);
            _result.Append(" ");
        }

        private void resetResult()
        {
            _result.Clear();
        }


        #region Input values
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
        #endregion

        #region Сharacters
        [Node("Separator", "Сharacters", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Separator()
        {
            appendStringToResult(",");
        }


        [Node("Left bracket", "Сharacters", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void LeftBracket()
        {
            appendStringToResult("(");
        }

        [Node("Right bracket", "Сharacters", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void RightBracket()
        {
            appendStringToResult(")");
        }
        #endregion


        #region SQL Keywords
        [Node("Select", "Keywords", "Basic", "Starts execution", true, true, width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Select()
        {
            resetResult();
            appendStringToResult("select");
        }

        [Node("End", "Keywords", "Basic", "Shows input value in the message box.", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void End()
        {
            var value = _result.ToString();
            OnResult?.Invoke(value);
            MessageBox.Show(value, "Show Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

    }
}
