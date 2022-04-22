using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memory_game
{
    public partial class InputMSGWindow : Form
    {
        int valueOnThescreen; // seconds
        Form formToChange;
        public InputMSGWindow(Form form,int val = 1)
        {
            valueOnThescreen = val;
            formToChange = form;
            InitializeComponent();
            numericUpDown1.Value = val/1000;  // we need seconds, not miliseconds
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.timer1.Interval = (int)numericUpDown1.Value*1000; // we change time of appearence after dislaying 2 cards
            this.Close();
        }
    }
}
