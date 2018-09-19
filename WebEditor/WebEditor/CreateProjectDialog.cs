using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebEditor
{
    public partial class CreateProjectDialog : Form
    {
        public string Name = "";
        public CreateProjectDialog()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
        }
    }
}
