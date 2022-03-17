using ExamplePrimitives.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// movement example https://wpf.2000things.com/tag/mousemove/

namespace ExamplePrimitives
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private UserControl1 currentUserControl = null;

        private void OnMouseMoveCanvas(object sender, MouseEventArgs e)
        {
            if (currentUserControl != null)
            {
                Point p = e.GetPosition(null);
                currentUserControl.L = (int)p.X;
                currentUserControl.R = (int)p.Y;
            }
        }

        private void OnMouseUpCanvas(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Released && e.ChangedButton == MouseButton.Left)
            {
                currentUserControl = null;
            }
        }
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserControl1 source = e.Source as UserControl1;

            if (e.ButtonState == MouseButtonState.Pressed && e.ChangedButton == MouseButton.Left)
            {
                currentUserControl = source;
            }

            //mrRec2.Title = "FROM";
            //mrRec2.Canvas.Left

            //mrRec2.L = 200;
            //mrRec2.R = 200;
        }
    }
}
