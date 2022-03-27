using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlSimple.Context;
using NodeEditor;

namespace SqlSimple
{
    public partial class SqlSimple : Form
    {
        //Context that will be used for our nodes
        MainContext context = new MainContext();

        public SqlSimple()
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
