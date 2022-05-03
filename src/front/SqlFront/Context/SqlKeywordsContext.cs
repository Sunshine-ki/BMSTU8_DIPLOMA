﻿using SqlSimple.Enums;
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
            appendToResult(Tokens.SELECT);
        }

        [Node("Distinct", "Keywords", "Basic", width: Constants.WidthOnlyOneWord)]
        public void Distinct(Distinct distinct)
        {
            appendToResult(distinct.GetDescription());
        }

        [Node("All data", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void AllData()
        {
            appendToResult(Tokens.ALL_DATA);
        }

        [Node("Case", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Case()
        {
            appendToResult(Tokens.CASE);
        }

        [Node("When", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void When()
        {
            appendToResult(Tokens.WHEN);
        }

        [Node("Then", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Then()
        {
            appendToResult(Tokens.THEN);
        }

        [Node("Else", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Else()
        {
            appendToResult(Tokens.ELSE);
        }

        [Node("End case", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void EndCase()
        {
            appendToResult(Tokens.END);
        }

        [Node("From", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void From()
        {
            appendToResult(Tokens.FROM);
        }
    }
}
