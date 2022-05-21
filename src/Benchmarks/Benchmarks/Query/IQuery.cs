using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarks.Query
{
    public interface IQuery
    {
        string GetStr();
        List<IToken> GetTokens();
    }
}
