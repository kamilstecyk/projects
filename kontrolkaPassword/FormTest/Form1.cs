using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // we can set minimum characters and special characters by attributes MinChars and SpecialChars which is a list of chars or we can set it in properties window

          // userControl11.MinChars = 5;
      //     userControl11.SpecialChars.Add('(');

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userControl11.verifyPassword(textBox1.Text);
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

      
    }
}
