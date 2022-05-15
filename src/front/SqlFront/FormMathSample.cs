using MathSample.ContextStr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathSample
{
    public partial class FormMathSample : Form
    {
        //Context that will be used for our nodes
        MainContextStr context = new MainContextStr();

        public FormMathSample()
        {
            InitializeComponent();
        }

        private void FormMathSample_Load(object sender, EventArgs e)
        {
            //Context assignment
            controlNodeEditor.nodesControl.Context = context;
            controlNodeEditor.nodesControl.OnNodeContextSelected += NodesControlOnOnNodeContextSelected;

            //Loading sample from file
            // TODO: add by default start and end
            //controlNodeEditor.nodesControl.Serialize();
            //controlNodeEditor.nodesControl.Deserialize(File.ReadAllBytes("default.nds"));
        }

        private void NodesControlOnOnNodeContextSelected(object o)
        {
            controlNodeEditor.propertyGrid.SelectedObject = o;
        }
    }
}
