using Antlr4.Runtime;
using MathSample.Helpers.Listeners;
using MathSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathSample.Helpers
{
    public class SqlParser
    {
        private SqlGrammarParser _sqlParser;
        private CommonTokenStream _commonTokenStream;
        private SqlErrorListener _errorListenerParser;

        public SqlParser(List<IToken> tokens)
        {
            _errorListenerParser = new SqlErrorListener();
            _commonTokenStream = new CommonTokenStream();
            _commonTokenStream.Tokens = tokens;
            _sqlParser = new SqlGrammarParser(_commonTokenStream);
            //speakParser.RemoveErrorListeners();
            _sqlParser.AddErrorListener(_errorListenerParser);

        }

        public bool ParseQuery()
        {
            try
            {
                var context = _sqlParser.query();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }

            return _errorListenerParser.IsValid;
        }
    }

    public class SqlParserStr
    {
            private SqlGrammarLexer sqlLexer;
            private SqlGrammarParser sqlParser;
            private SqlErrorListener sqlErrorListener;

            public SqlParserStr(string sqlQuery)
            {
                var inputStream = new AntlrInputStream(sqlQuery);
                sqlLexer = new SqlGrammarLexer(inputStream);
                var commonTokenStream = new CommonTokenStream(sqlLexer);
                sqlParser = new SqlGrammarParser(commonTokenStream);
                //sqlParser.RemoveErrorListeners();
                sqlErrorListener = SqlErrorListener.CreateListener();
                sqlParser.AddErrorListener(sqlErrorListener);
            }

            public bool ParseQuery()
            {
                _ = sqlParser.query();
                return sqlErrorListener.IsValid;
            }

            public AntlrErrorModel GetFirstError()
            {
                if (sqlErrorListener.IsValid || sqlErrorListener.Errors.Count < 1)
                {
                    return null;
                }

                return sqlErrorListener.Errors.First();
            }

    }
}
