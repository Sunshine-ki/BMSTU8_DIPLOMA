using SqlSimple.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSimple.Context
{
    public partial class MainContext : INodesContext
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
