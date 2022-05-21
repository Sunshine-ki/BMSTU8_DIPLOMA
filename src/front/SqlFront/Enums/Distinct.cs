using MathSample.Attributes;
using System;
using System.ComponentModel;

namespace MathSample.Enums
{
    public enum Distinct
    {
        [TokenType(SqlGrammarLexer.DISTINCT)]
        [Description("distinct")]
        Distinct = 0,

        [TokenType(SqlGrammarLexer.ALL)]
        [Description("all")]
        All = 1
    }

}
