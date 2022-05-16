using MathSample.Attributes;
using System;
using System.ComponentModel;

namespace MathSample.StrContext
{
    public enum Sing
    {
        [TokenType(SqlGrammarLexer.PLUS)]
        [Description("+")]
        Positive = 0,

        [TokenType(SqlGrammarLexer.MINUS)]
        [Description("-")]
        Negative = 1
    }
}
