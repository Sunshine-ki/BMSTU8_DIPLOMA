using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathSample.Attributes
{
    class TokenTypeAttribute : Attribute
    {
        public int TokenType { get; }
        public TokenTypeAttribute(int tokeType) => TokenType = tokeType;
    }
}
