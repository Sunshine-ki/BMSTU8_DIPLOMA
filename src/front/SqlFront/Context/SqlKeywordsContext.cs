using SqlSimple.Enums;
using SqlSimple.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqlSimple.Context
{
    public partial class MainContext : INodesContext
    {
        [Node("Select", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Select()
        {
            appendToResult("select");
        }

        [Node("Distinct", "Keywords", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Distinct(Distinct distinct)
        {
            appendToResult(distinct.GetDescription());
        }
    }
}
