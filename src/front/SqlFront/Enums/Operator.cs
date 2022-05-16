using MathSample.Attributes;
using System;
using System.ComponentModel;

namespace MathSample.StrContext
{
    public enum Operator
    {
        [TokenType(SqlGrammarLexer.PLUS)]
        [Description("+")]
        Addition = 0,

        [TokenType(SqlGrammarLexer.MINUS)]
        [Description("-")]
        Subtraction = 1,

        [TokenType(SqlGrammarLexer.STAR)]
        [Description("*")]
        Multiplication = 2,

        [TokenType(SqlGrammarLexer.DIV)]
        [Description("/")]
        Division = 3
    }
}
