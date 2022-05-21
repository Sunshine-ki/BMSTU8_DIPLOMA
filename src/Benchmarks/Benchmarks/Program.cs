using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarks.Query;
using MathSample.Helpers;
using MoreLinq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class BenchmarkerQueryCompare
    {
        public int NumberOfItems = 10_000;

        [Benchmark]
        public void VeryEasyQueryTokens()
        {
            var tokens = new VeryEasyQuery().GetTokens();

            for (int i = 0; i < NumberOfItems; i++)
            {
                var parser = new SqlParser(tokens);
                var result = parser.ParseQuery();
            }
        }

        [Benchmark]
        public void VeryEasyQueryStr()
        {
            var queryStr = new VeryEasyQuery().GetStr();

            for (int i = 0; i < NumberOfItems; i++)
            {
                var parser = new SqlParserStr(queryStr);
                var result = parser.ParseQuery();
            }
        }


        [Benchmark]
        public void EasyQueryTokens()
        {
            var tokens = new EasyQuery().GetTokens();

            for (int i = 0; i < NumberOfItems; i++)
            {
                var parser = new SqlParser(tokens);
                var result = parser.ParseQuery();
            }
        }

        [Benchmark]
        public void EasyQueryStr()
        {
            var queryStr = new EasyQuery().GetStr();

            for (int i = 0; i < NumberOfItems; i++)
            {
                var parser = new SqlParserStr(queryStr);
                var result = parser.ParseQuery();
            }
        }

        [Benchmark]
        public void NormalQueryTokens()
        {
            var tokens = new NormalQuery().GetTokens();

            for (int i = 0; i < NumberOfItems; i++)
            {
                var parser = new SqlParser(tokens);
                var result = parser.ParseQuery();
            }
        }

        [Benchmark]
        public void NormalQueryStr()
        {
            var queryStr = new NormalQuery().GetStr();

            for (int i = 0; i < NumberOfItems; i++)
            {
                var parser = new SqlParserStr(queryStr);
                var result = parser.ParseQuery();
            }
        }

        [Benchmark]
        public void HardQueryTokens()
        {
            var tokens = new HardQuery().GetTokens();

            for (int i = 0; i < NumberOfItems; i++)
            {
                var parser = new SqlParser(tokens);
                var result = parser.ParseQuery();
            }
        }

        [Benchmark]
        public void HardQueryStr()
        {
            var queryStr = new HardQuery().GetStr();

            for (int i = 0; i < NumberOfItems; i++)
            {
                var parser = new SqlParserStr(queryStr);
                var result = parser.ParseQuery();
            }

        }

    }

    class Program
    {
        static async Task Main(string[] args)
        {
            //var queryStr = new HardQuery().GetStr();
            //var parser = new SqlParserStr(queryStr);
            //var result = parser.ParseQuery();
            //parser.TryOutputErrorMessages();
            //Console.WriteLine($"!!! RESULT = {result}");

            //var tokens = new HardQuery().GetTokens();
            //var parser = new SqlParser(tokens);
            //var result = parser.ParseQuery();
            //parser.TryOutputErrorMessages();
            //Console.WriteLine($"!!! RESULT = {result}");

            var summary = BenchmarkRunner.Run<BenchmarkerQueryCompare>();

            var columns = summary.Table.Columns.ToList();

            var methods = columns.Where(x => x.Header.ToLower().Equals("method"))
                                 .Select(x => x.Content).FirstOrDefault();

            var means = columns.Where(x => x.Header.ToLower().Equals("mean"))
                               .Select(x => x.Content).FirstOrDefault();


            methods.ForEach(x => Console.WriteLine(x));
            means.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Success");
        }
    }
}
