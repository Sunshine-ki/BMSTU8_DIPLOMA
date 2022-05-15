using MathSample.Helpers;
using NodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathSample.StrContext
{
    partial class MainStrContext : INodesContext
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

        [Node("Where", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Where()
        {
            appendToResult(Tokens.WHERE);
        }

        [Node("Having", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Having()
        {
            appendToResult(Tokens.HAVING);
        }

        [Node("Union", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Union()
        {
            appendToResult(Tokens.UNION);
        }

        [Node("Except", "Keywords", "Basic", width: Constants.WidthOnlyOneWord, height: Constants.HeightOnlyOneWord)]
        public void Except()
        {
            appendToResult(Tokens.EXCEPT);
        }

        [Node("Order by", "Keywords", "Basic")]
        public void OrderBy(string columnName, Direction direction)
        {
            appendToResult($"{Tokens.ORDER_BY} {columnName} {direction}");
        }
    }
}
