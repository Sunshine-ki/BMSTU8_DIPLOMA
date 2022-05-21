using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarks.Query;
using LiveCharts;
using LiveCharts.Wpf;
using MathSample.Helpers;
using MoreLinq;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class BenchmarkerMethodsCompare
    {
        int NumberOfItems = 100_000;

        [Benchmark]
        public void ToUpperTest()
        {
            string log = "ЗаПиСыВаЙтЕсЬ нА нОкОтОчКи!!11111";
            string search = "коточ";
            var srch = search.ToUpper();

            for (int i = 0; i < NumberOfItems; i++)
            {
                var value = log.ToUpper().Contains(srch);
            }
        }

        [Benchmark]
        public void IndexOf()
        {
            string log = "ЗаПиСыВаЙтЕсЬ нА нОкОтОчКи!!11111";
            string search = "коточ";
            var srch = search.ToUpper();

            for (int i = 0; i < NumberOfItems; i++)
            {
                var value = log.ToUpper().Contains(srch);
            }
        }
    }

    public partial class MainWindow : Window
    {
        public SeriesCollection SeriesCollect { get; set; }
        public string[] LevelLabels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            LevelLabels = new[] { "Очень низкая", "Низкая", "Номинальная", "Высокая", "Очень высокая" };
            YFormatter = value => value.ToString();

            SeriesCollect = getDefaultGraph();
            fillGraph(SeriesCollect);
            init();

            DataContext = this;
        }

        private void init()
        {
            IQuery query = new VeryEasyQuery();

            var sqlStrParser = new SqlParserStr(query.GetStr());
            var strResult = sqlStrParser.ParseQuery();
            log($"strResult = {strResult}");

            var sqlTokenParser = new SqlParser(query.GetTokens());
            var tokensResult = sqlTokenParser.ParseQuery();
            log($"tokensResult = {tokensResult}");


            log("Success");
        }

        private void fillGraph(SeriesCollection time)
        {
            for (int i = 0; i < 5; i++)
            {
                time[0].Values.Add(1.0);
            }

            for (int i = 0; i < 5; i++)
            {
                time[1].Values.Add((double)i);
            }

        }

        private SeriesCollection getDefaultGraph()
        {
            return new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "String",
                        Values = new ChartValues<double>(),
                    },
                    new LineSeries
                    {
                        Title = "Tokens",
                        Values = new ChartValues<double>(),
                    },
                };
        }

        private void log(string str) => Trace.WriteLine(str);
    }
}
