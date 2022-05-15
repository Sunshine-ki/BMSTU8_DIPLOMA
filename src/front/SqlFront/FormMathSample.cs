using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Antlr4.Runtime;
using MathSample.StrContext;
using MathSample.TokensContext;

namespace MathSample
{
    public partial class FormMathSample : Form
    {
        //Context that will be used for our nodes
        MainTokensContext context = new MainTokensContext();

        public FormMathSample()
        {
            InitializeComponent();
            //context.OnResult += onReceiveResult; 
        }

        private void FormMathSample_Load(object sender, EventArgs e)
        {
            //Context assignment
            controlNodeEditor.nodesControl.Context = context;
            controlNodeEditor.nodesControl.OnNodeContextSelected += NodesControlOnOnNodeContextSelected;

            //Loading sample from file
            controlNodeEditor.nodesControl.Serialize();
            controlNodeEditor.nodesControl.Deserialize(File.ReadAllBytes("default.nds"));
        }

        private void NodesControlOnOnNodeContextSelected(object o)
        {
            controlNodeEditor.propertyGrid.SelectedObject = o;
        }

        private void onReceiveResult(IList<IToken> tokens)
        {
            var path = "default.nds";
            var data = controlNodeEditor.nodesControl.Serialize();
            using (var fs = File.OpenWrite(path))
            {
                fs.Write(data, 0, data.Length);
            }
        }
    }
}
