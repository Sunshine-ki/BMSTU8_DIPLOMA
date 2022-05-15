using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Sharpen;
using MathSample.Models;
using System;
using System.Collections.Generic;

namespace MathSample.Helpers.Listeners
{
    public class SqlErrorListener : BaseErrorListener // https://putridparrot.com/blog/antlr-in-c/
    {
        public bool IsValid { get; private set; } = true;
        public List<AntlrErrorModel> Errors { get; private set; } = new List<AntlrErrorModel>();

        public static SqlErrorListener CreateListener() => new SqlErrorListener();

        public override void ReportAmbiguity(
          Parser recognizer, DFA dfa,
          int startIndex, int stopIndex,
          bool exact, BitSet ambigAlts,
          ATNConfigSet configs) => IsValid = false;


        public override void ReportAttemptingFullContext(
          Parser recognizer, DFA dfa,
          int startIndex, int stopIndex,
          BitSet conflictingAlts, SimulatorState conflictState) => IsValid = false;

        public override void ReportContextSensitivity(
          Parser recognizer, DFA dfa,
          int startIndex, int stopIndex,
          int prediction, SimulatorState acceptState) => IsValid = false;


        public override void SyntaxError(
          IRecognizer recognizer, IToken offendingSymbol,
          int line, int charPositionInLine,
         string msg, RecognitionException e)
        {
            IsValid = false;

            Errors.Add(new AntlrErrorModel()
            {
                Message = msg,
                Line = line,
                Token = offendingSymbol,
                Offset = charPositionInLine,
                Recognizer = recognizer
            });
        }

        public void OutputErrorMessages()
        {
            Console.WriteLine($"Error msg count = {Errors.Count}");
            Errors.ForEach(e => Console.WriteLine(e));
        }
    }
}
