using MathSample.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathSample.TokensContext
{
    partial class MainTokensContext : INodesContext
    {
        [Node("Separator", "Сharacters", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Separator()
        {
            appendToResult(",", SqlGrammarLexer.COMMA);
        }

        [Node("Left bracket", "Сharacters", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void LeftBracket()
        {
            appendToResult("(", SqlGrammarLexer.LPAREN);
        }

        [Node("Right bracket", "Сharacters", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void RightBracket()
        {
            appendToResult(")", SqlGrammarLexer.RPAREN);
        }
    }
}
