using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API;

namespace DevilsAdvocate
{
    public partial class Form1 : Form
    {
        readonly ExploitAPI api = new ExploitAPI();

        public Form1()
        {
            InitializeComponent();
        }

        // Inject the exploit
        private void Attach_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        // Execute the Lua Script
        private void Execute_Click(object sender, EventArgs e)
        {
            string script = ScriptBox.Text;
            api.SendLuaScript(script);
        }

        // Clear the script box
        private void Clear_Click(object sender, EventArgs e)
        {
            ScriptBox.Clear();
        }

        // Open the file explorer
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialogfile = new OpenFileDialog();
            opendialogfile.Filter = "Lua File (*.lua)|*.lua|Text File (*.txt)|*.txt";
            opendialogfile.FilterIndex = 2;
            opendialogfile.RestoreDirectory = true;
            if (opendialogfile.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                ScriptBox.Text = "";
                System.IO.Stream stream;
                if ((stream = opendialogfile.OpenFile()) == null)
                    return;
                using (stream)
                    this.ScriptBox.Text = System.IO.File.ReadAllText(opendialogfile.FileName);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("An unexpected error has occured", "OOF!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        // Save the file
        private void Save_Click(object sender, EventArgs e)
        {

        }

        // Exit the program
        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // Minimise the window
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
