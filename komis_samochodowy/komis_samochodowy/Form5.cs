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
    public partial class Form5 : Form
    {

        Form1 startForm;
        Form2 previousForm;

        bool displayReservation = false;
        bool cancelClose = false;

        List<int> indexesOfProperCars;

        public Form5(Form1 sf,Form2 pf, List<int> list)
        {
            startForm = sf;
            previousForm = pf;
            this.indexesOfProperCars = list;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // maybe it is better no to reset because after not finding for particular addditonal eq user wants to looking for more
            //previousForm.resetComboboxes(); // we reset comboboxes to have effect like new window
            previousForm.Show();
            cancelClose = true;
            this.Close();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!cancelClose)
                Environment.Exit(0);
        }
    }
}
