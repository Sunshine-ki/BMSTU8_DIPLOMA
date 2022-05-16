using MathSample.Attributes;
using System;
using System.ComponentModel;

namespace MathSample.Enums
{
    public enum AggregateFunction
    {
        [Description("none")]
        None = 0,

        [TokenType(SqlGrammarLexer.COUNT)]
        [Description("count")]
        Count = 1,

        [TokenType(SqlGrammarLexer.SUM)]
        [Description("sum")]
        Sum = 2,

        [TokenType(SqlGrammarLexer.AVG)]
        [Description("avg")]
        Avg = 3,

        [TokenType(SqlGrammarLexer.MIN)]
        [Description("min")]
        Min = 4,

        [TokenType(SqlGrammarLexer.MAX)]
        [Description("max")]
        Max = 5
    }
}
