using Antlr4.Runtime;
using SqlGrammarLibrary;
using SqlSimple.Helpers.Listeners;
using SqlSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSimple.Helpers
{
    public class SqlParser
    {
        private SqlSelectGrammarLexer sqlLexer;
        private SqlSelectGrammarParser sqlParser;
        private SqlErrorListener sqlErrorListener;

        public SqlParser(string sqlQuery)
        {
            var inputStream = new AntlrInputStream(sqlQuery);
            sqlLexer = new SqlSelectGrammarLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(sqlLexer);
            sqlParser = new SqlSelectGrammarParser(commonTokenStream);
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

//Console.WriteLine($"IsValid = {sqlErrorListener.IsValid}");
//if (!sqlErrorListener.IsValid)
//{
//    sqlErrorListener.OutputErrorMessages();
//}