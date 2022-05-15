using Antlr4.Runtime;
using MathSample.Helpers;
using MathSample.Models;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathSample.TokensContext
{
    partial class MainTokensContext : INodesContext
    {
        public NodeVisual CurrentProcessingNode { get; set; }
        public event Action<string, NodeVisual, FeedbackType, object, bool> FeedbackInfo;

        public event Action<IList<IToken>> OnResult;
        private List<IToken> tokens = new List<IToken>();


        private void resetResult()
        {
            tokens = new List<IToken>();
        }

        private void appendToResult(IToken token)
        {
            tokens.Add(token);
        }

        private void appendToResult(string text, int type)
        {
            tokens.Add(new MyToken() { Text = text, Type = type });
        }

        private void outputTokens()
        {
            tokens.ForEach(token => 
                    Console.WriteLine($"{token.Type}: {token.Text}"));
        }

        [Node("Starter", "Helpers", "Basic", "Starts execution", true, true, width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Starter()
        {
            resetResult();
        }

        [Node("End", "Helpers", "Basic", "Shows input value in the message box.", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void End()
        {
            appendToResult("<EOF>", -1);
            outputTokens();
            onResultInvoke(tokens);

            var parser = new SqlParser(tokens);
            var isValid = parser.ParseQuery();
            parser.TryOutputErrorMessages();

            string msg = "Success";
            if (!isValid)
            {
                var errMsg = parser.GetFirstError();
                msg = errMsg is null ? "Parser error" : errMsg.Message;
            }

            MessageBox.Show(msg, "Show Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void onResultInvoke(IList<IToken> tokens)
        {
            OnResult?.Invoke(tokens);
        }
    }
}
