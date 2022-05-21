using MathSample.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MathSample.Enums
{
    public enum JoinType
    {
        [Description("CROSS JOIN")]
        CROSS_JOIN = 0,

        [TokenType(SqlGrammarLexer.LEFT)]
        [Description("LEFT")]
        LEFT = 1,
        
        [TokenType(SqlGrammarLexer.RIGHT)]
        [Description("RIGHT")]
        RIGHT = 2,

        [TokenType(SqlGrammarLexer.FULL)]
        [Description("FULL")]
        FULL = 3,

        [TokenType(SqlGrammarLexer.INNER)]
        [Description("INNER")]
        INNER = 4,
    }
}
