using MathSample.Attributes;
using System;
using System.ComponentModel;

namespace MathSample.Enums
{
    public enum Direction
    {
        [TokenType(SqlGrammarLexer.ASC)]
        [Description("ASC")]
        Asc,

        [TokenType(SqlGrammarLexer.DESC)]
        [Description("DESC")]
        Desc,
    }
}
