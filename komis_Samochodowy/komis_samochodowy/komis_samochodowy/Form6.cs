using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace komis_samochodowy
{
    public partial class Form6 : Form
    {

        Form1 startForm;
        Form3 previousForm;

        bool backToMenu = false;
        public Form6(Form1 start,Form3 prev)
        {
            previousForm = prev;
            startForm = start;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // we close form
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backToMenu = true;
            startForm.Show();
            previousForm.Hide();
            this.Close();
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!backToMenu)
            {
                // we refresh form
                previousForm.Controls.Clear();
                previousForm.InitializeComponent();

                previousForm.Show();
            }
        }
    }
}
