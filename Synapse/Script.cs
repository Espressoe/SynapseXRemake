using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synapse
{
    public partial class Script : UserControl
    {
        public Script(string scriptname)
        {
            InitializeComponent();
            
            guna2Button3.Text = scriptname;
        }
    }
}
