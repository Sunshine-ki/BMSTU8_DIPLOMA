using MathSample.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathSample.ContextStr
{
    partial class MainContextStr : INodesContext
    {
        [Node("Separator", "Сharacters", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Separator()
        {
            appendToResult(",");
        }

        [Node("Left bracket", "Сharacters", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void LeftBracket()
        {
            appendToResult("(");
        }

        [Node("Right bracket", "Сharacters", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void RightBracket()
        {
            appendToResult(")");
        }
    }
}
