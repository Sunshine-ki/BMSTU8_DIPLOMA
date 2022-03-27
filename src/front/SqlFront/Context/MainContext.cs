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

        private void resetResult()
        {
            _result.Clear();
        }

        private void appendStringToResult(string str)
        {
            _result.Append(str);
            _result.Append(" ");
        }

        [Node("End", "Keywords", "Basic", "Shows input value in the message box.", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void End()
        {
            var value = _result.ToString();
            OnResult?.Invoke(value);
            MessageBox.Show(value, "Show Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
