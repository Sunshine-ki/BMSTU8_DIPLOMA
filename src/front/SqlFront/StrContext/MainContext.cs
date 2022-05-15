using MathSample.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathSample.StrContext
{
    partial class MainStrContext : INodesContext
    {
        public NodeVisual CurrentProcessingNode { get; set; }
        public event Action<string, NodeVisual, FeedbackType, object, bool> FeedbackInfo;

        public event Action<string> OnResult;
        private StringBuilder _result = new StringBuilder();

        private void resetResult()
        {
            _result.Clear();
        }

        private void appendToResult(string str)
        {
            _result.Append(str);
            _result.Append(" ");
        }

        [Node("Starter", "Helpers", "Basic", "Starts execution", true, true, width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Starter()
        {
            resetResult();
        }

        [Node("End", "Helpers", "Basic", "Shows input value in the message box.", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void End()
        {
            var sqlQuery = _result.ToString();
            onResultInvoke(sqlQuery);
            Console.WriteLine($"sqlQuery: {sqlQuery}");

            var parser = new SqlParserStr(sqlQuery);
            parser.ParseQuery();
            var err = parser.GetFirstError();

            string msg = err == null ? "Success" : err.Message;
            MessageBox.Show($"{msg} (query = {sqlQuery})", "Show Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void onResultInvoke(string sqlQuery)
        {
            OnResult?.Invoke(sqlQuery);
        }
    }
}
