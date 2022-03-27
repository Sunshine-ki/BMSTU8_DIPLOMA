using MathSample.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathSample.Context
{
    public partial class MainContext : INodesContext
    {
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
    }
}
