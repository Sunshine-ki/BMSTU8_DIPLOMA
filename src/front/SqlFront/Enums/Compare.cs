using MathSample.Attributes;
using System;
using System.ComponentModel;

namespace MathSample.StrContext
{
    public enum Compare
    {
        [TokenType(SqlGrammarLexer.EQ)]
        [Description("=")]
        Equal = 0,

        [TokenType(SqlGrammarLexer.NEQ)]
        [Description("!=")]
        NotEqual = 1,

        [TokenType(SqlGrammarLexer.GT)]
        [Description(">")]
        GraterThan = 2,

        [TokenType(SqlGrammarLexer.LT)]
        [Description("<")]
        LessThan = 3,

        [TokenType(SqlGrammarLexer.LEQT)]
        [Description("<=")]
        LessEqualThan = 4,

        [TokenType(SqlGrammarLexer.GEQT)]
        [Description(">=")]
        GraterEqualThan = 5,
    }
}
