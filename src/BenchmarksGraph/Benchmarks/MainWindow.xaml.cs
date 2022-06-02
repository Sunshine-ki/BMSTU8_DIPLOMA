using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        public SeriesCollection SeriesCollect { get; set; }
        public string[] LevelLabels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            LevelLabels = new[] { "Очень простой", "Простой", "Нормальный", "Сложный"};
            YFormatter = value => value.ToString();

            SeriesCollect = getDefaultGraph();
            fillGraph(SeriesCollect);

            DataContext = this;
        }

        private void fillGraph(SeriesCollection time)
        {
            // Str[62.69, 320.49, 1671.47, 2099]
            // Tokens[41.33, 208.78, 534.41, 642.57]

            foreach(double elem in new List<double>() { 62.69, 320.49, 1671.47, 2099 })
            {
                time[0].Values.Add(elem);
            }

            foreach (double elem in new List<double>() { 41.33, 208.78, 534.41, 642.57 })
            {
                time[1].Values.Add(elem);
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
