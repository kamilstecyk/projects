using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class GuestForm : Form
    {
        static public Form1 prevForm;

        public GuestForm(Form1 givenPrevForm)
        {
            InitializeComponent();
            prevForm = givenPrevForm;
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            FrontendActions.RefreshAndAddToListViewAllBooks(listViewAllBooks);
        }

        private void GuestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Close();
        }
    }
}
