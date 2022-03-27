using MathSample.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathSample.Context
{
    public partial class MainContext : INodesContext
    {
        [Node("Select", "Keywords", "Basic", "Starts execution", true, true, width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Select()
        {
            resetResult();
            appendStringToResult("select");
        }


    }
}
