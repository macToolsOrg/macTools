using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using System.Windows.Input;

namespace macTools
{
    public partial class KeyCombos : Form
    {
        public KeyCombos()
        {
            InitializeComponent();
        }

        // Import the GetAsyncKeyState function from user32.dll
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private void KeyCombos_Load(object sender, EventArgs e)
        {
            var sim = new InputSimulator();
            while (true)
            {
                // Check if F4 is pressed
                if (IsKeyPressed(Keys.F4))
                {
                    
                    SendKeys.Send("^{ESC}");

                    // Optional: Add some delay to prevent multiple triggers
                    System.Threading.Thread.Sleep(200);
                }
                if (IsKeyPressed(Keys.F3))
                {
                    
                    sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.TAB);

                    // Optional: Add some delay to prevent multiple triggers
                    System.Threading.Thread.Sleep(200);
                }



                // Optional: Add a delay to reduce CPU usage
                System.Threading.Thread.Sleep(50);
            }
        }
        private static bool IsKeyPressed(Keys key)
        {
            return (GetAsyncKeyState(key) & 0x8000) != 0;
        }
    }
}
