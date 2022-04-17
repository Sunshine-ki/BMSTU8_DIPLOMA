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

        [Node("All data", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void AllData()
        {
            appendToResult(Constants.ALL_DATA);
        }


        [Node("Case", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Case()
        {
            appendToResult(Constants.CASE);
        }

        [Node("When", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void When()
        {
            appendToResult(Constants.WHEN);
        }

        [Node("Then", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Then()
        {
            appendToResult(Constants.THEN);
        }

        [Node("Else", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Else()
        {
            appendToResult(Constants.ELSE);
        }

        [Node("End case", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void EndCase()
        {
            appendToResult(Constants.END);
        }
    }
}
