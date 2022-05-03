using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlSimple.Enums;
using SqlSimple.Helpers;
using NodeEditor;
using Antlr4.Runtime;
using SqlGrammarLibrary;
using SqlSimple.Helpers.Listeners;

namespace SqlSimple.Context
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

            var parser = new SqlParser(sqlQuery);
            parser.ParseQuery();
            var err = parser.GetFirstError();

            string msg = err == null ? "Success" : err.Message;
            MessageBox.Show(msg, "Show Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void onResultInvoke(string sqlQuery)
        {
            OnResult?.Invoke(sqlQuery);
        }

    }
}
