using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebEditor
{
    public partial class MainForm : Form
    {
        string ProjectName = "";
        bool InHTML = true;
        public MainForm()
        {
            InitializeComponent();
        }

        private void scriptToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateProjectDialog dlg = new CreateProjectDialog();
            if (dlg.ShowDialog() == DialogResult.OK) NewProject(dlg.Name);
        }

        private void NewProject(string name)
        {
            Directory.CreateDirectory(name);
            Directory.CreateDirectory(name +  "\\media");
            Directory.CreateDirectory(name + "\\media" + "\\js");
            Directory.CreateDirectory(name + "\\media" + "\\img");
            StreamWriter w = File.AppendText(name + "\\media" + "\\js" + "\\jQuery.js");
            w.AutoFlush = true;
            w.WriteLine(Data.jQuery);
            w.Close();
            StreamWriter w2 = File.AppendText(name + "\\media" + "\\js" + "\\main.js");
            w2.AutoFlush = true;
            w2.WriteLine(Data.AutoJS);
            w2.Close();
            StreamWriter w3 = File.AppendText(name + "\\index.html");
            w3.AutoFlush = true;
            w3.WriteLine(Data.AutoHTML);
            w3.Close();
            ProjectName = name;
            SimpleButton(Data.ButtonKoefX, Data.ButtonKoefY, "Main Html", Open);
            SimpleButton(Data.ButtonKoefX, Data.ButtonKoefY + 100, "Main JS", Open);
        }
        private void Open(object sender, EventArgs e)
        {
            if (((Button)sender).Name == "Main Html") richTextBox1.Text = File.ReadAllText(ProjectName + "\\index.html");
            else if (((Button)sender).Name == "Main JS") richTextBox1.Text = File.ReadAllText(ProjectName + "\\media\\js\\main.js");
        }
        public void SimpleButton(int koefX, int koefY, string text, EventHandler click)
        {
            int x = 0;
            int y = 0;
            Button b = new Button();
            b.BackColor = Color.Black;
            b.ForeColor = Color.Gray;
            b.Font = new Font(new FontFamily("Arial"), 12);
            b.Location = new Point(x + koefX, y + koefY);
            b.Margin = new Padding(4, 5, 4, 5);
            b.Name = text;
            b.Size = new Size(115, 50);
            b.TabIndex = 0;
            b.Text = text;
            b.UseVisualStyleBackColor = false;
            b.Click += click;
            b.Visible = true;
            Controls.Add(b);
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show($"{e.X}, {e.Y}");
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
           // MessageBox.Show($"{e.X + treeView1.Location.X}, {treeView1.Height / 2}");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InHTML == true) { StreamWriter w = new StreamWriter(ProjectName + "\\index.html"); w.AutoFlush = true; w.Write(richTextBox1.Text); }
            else if (InHTML == false) { StreamWriter w = new StreamWriter(ProjectName + "\\media\\js\\main.js"); w.AutoFlush = true; w.Write(richTextBox1.Text); }
        }
    }
}
