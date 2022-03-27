using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathSample.Context;
using NodeEditor;

namespace MathSample
{
    public partial class FormMathSample : Form
    {
        //Context that will be used for our nodes
        MainContext context = new MainContext();

        public FormMathSample()
        {
            InitializeComponent();
            context.OnResult += SomeMethod;
        }

        private void FormMathSample_Load(object sender, EventArgs e)
        {
            //Context assignment
            controlNodeEditor.nodesControl.Context = context;
            controlNodeEditor.nodesControl.OnNodeContextSelected += NodesControlOnOnNodeContextSelected;
        }

        private void NodesControlOnOnNodeContextSelected(object o)
        {
            controlNodeEditor.propertyGrid.SelectedObject = o;
        }

        public void SomeMethod(string str)
        {
            // TODO: Here to create a AST
            Console.WriteLine($"SomeMethod: {str}");
        }

    }
}
