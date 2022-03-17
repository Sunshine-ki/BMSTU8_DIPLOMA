using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace ExamplePrimitives.Controls
{
    public partial class UserControl1 : UserControl, INotifyPropertyChanged
    {

        // TODO: !!! MVVM !!!

        public UserControl1()
        {
            InitializeComponent();
            this.DataContext = this;

            uniqName = generateID();
            Trace.WriteLine($"nameUniq= {uniqName}");

        }

        private string uniqName;
        public string UniqName
        {
            get => uniqName;
            set
            {
                uniqName = value;
                NotifyPropertyChanged();
            }
        }


        private string title = "SELECT"; 
        public string Title 
        { 
            get => title; 
            set
            { 
                title = value;
                NotifyPropertyChanged();
            } 
        }


        private int l = 25;
        public int L
        {
            get => l;
            set
            {
                l = value;
                NotifyPropertyChanged();
            }
        }


        private int r = 65;
        public int R
        {
            get => r;
            set
            {
                r = value;
                NotifyPropertyChanged();
            }
        }

        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }


        public string ParametrName { get; set; } = "name";


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
