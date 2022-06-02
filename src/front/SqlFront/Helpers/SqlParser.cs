using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MathSample.Helpers.Listeners;
using MathSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static MathSample.SqlGrammarParser;

namespace MathSample.Helpers
{
    public abstract class SqlParserBase
    {
        protected SqlErrorListener _sqlErrorListener = SqlErrorListener.CreateListener();
        protected SqlGrammarParser _sqlParser;
        public QueryContext Query;

        public virtual AntlrErrorModel GetFirstError()
        {
            if (_sqlErrorListener.IsValid || _sqlErrorListener.Errors.Count < 1)
            {
                return null;
            }

            return _sqlErrorListener.Errors.First();
        }

        public void TryOutputErrorMessages()
        {
            if (_sqlErrorListener.IsValid) return;
            _sqlErrorListener.OutputErrorMessages();
        }

        public bool ParseQuery()
        {
            try
            {
                var context = _sqlParser.query();
                Query = context;
                //Console.WriteLine($"Tree: {context.ToStringTree()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }

            return _sqlErrorListener.IsValid;
        }
    }

    public class SqlParser : SqlParserBase
    {
        private CustomTokenStream _commonTokenStream;

        public SqlParser(List<IToken> tokens)
        {
            _commonTokenStream = new CustomTokenStream(tokens);
            _sqlParser = new SqlGrammarParser(_commonTokenStream);
            //speakParser.RemoveErrorListeners();
            _sqlParser.AddErrorListener(_sqlErrorListener);
        }
    }


    public class SqlParserStr : SqlParserBase
    {
            private SqlGrammarLexer _sqlLexer;

            public SqlParserStr(string sqlQuery)
            {
                var inputStream = new AntlrInputStream(sqlQuery);
                _sqlLexer = new SqlGrammarLexer(inputStream);
                var commonTokenStream = new CommonTokenStream(_sqlLexer);
                _sqlParser = new SqlGrammarParser(commonTokenStream);
                //sqlParser.RemoveErrorListeners();
                _sqlParser.AddErrorListener(_sqlErrorListener);
            }
    }
}
