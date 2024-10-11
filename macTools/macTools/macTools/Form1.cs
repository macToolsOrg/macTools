using Microsoft.Win32;
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

namespace macTools
{
    public partial class macToolsCTRL : Form
    {
        string[] argus;
        string configPath = ".\\CONFIG.CFG";
        public macToolsCTRL(string[] args)
        {
            InitializeComponent();
            this.argus = args;
        }

        private void macToolsCTRL_Load(object sender, EventArgs e)
        {
            if (argus.Length > 0 && argus[1] == "keycombos") 
            {
                // Create and show Form2 as a modal dialog
                KeyCombos keycombos = new KeyCombos();
                this.Hide(); // Hide Form1 to ensure the application doesn't exit immediately
                keycombos.ShowDialog();

                // Close Form1 after Form2 is closed
                this.Close();
            }
        }

        private void invertScroll() 
        {
            try
            {
                // Specify the registry hive and the subkey path
                string subKeyPath = @"SYSTEM\CurrentControlSet\Enum\HID\VID_05AC&PID_0273&MI_02&COL01\6&148FF433&0&0000\Device Parameters";
                string valueName = "FlipFlopWheel";
                string newValue = "1";

                // Open the registry key for writing
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(subKeyPath))
                {
                    if (key != null)
                    {
                        // Set the value of the registry key
                        key.SetValue(valueName, newValue);
                        Console.WriteLine($"Successfully updated {valueName} to {newValue} in {subKeyPath}");
                    }
                    else
                    {
                        Console.WriteLine("Failed to open the registry key.");
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to write to the registry.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private int stringToIntParser(string s) 
        { 
            return int.Parse(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create and show Form2 as a modal dialog
            KeyCombos keycombos = new KeyCombos();
            this.Hide(); // Hide Form1 to ensure the application doesn't exit immediately
            keycombos.ShowDialog();

            // Close Form1 after Form2 is closed
            this.Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText(configPath, 
                checkBox1.Checked.ToString() + 
                "\n" + 
                checkBox2.Checked.ToString()); // Add more as more features are ready
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram aboutprogram = new AboutProgram();
            aboutprogram.ShowDialog();
        }
        private void helpSupportToolStripMenuItem_Click (object sender, EventArgs e)
        { 
        
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
