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
    public partial class RegistrationForm : Form
    {


        static Form1 prevForm = null;


        public RegistrationForm(Form1 prev)
        {
            InitializeComponent();
            prevForm = prev;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // validation of inputs

            if (!Verification.verifyLogin(textBox1.Text))
            {
                Messages.displayMessageBox ("Login should not contain spaces and be lenght of minimum 5 letters");
                return;
            }

            if (!Verification.verifyPassword(textBox2.Text))
            {
                Messages.displayMessageBox("Password should contain minimum eight characters, at least one uppercase letter, one lowercase letter and one number");
                return;
            }


            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox1.Text.Contains(" ") || textBox2.Text.Contains(" ") || textBox3.Text.Contains(" "))
            {

                Messages.displayMessageBox( "Textboxes cannot be empty and you cannot have spaces in them!");

                return;
            }


            if (!RegistrationFormLogic.checkIfPasswordMatches(textBox2.Text, textBox3.Text))  // user exists
            {

                Messages.displayMessageBox( "The paasswords fields does not match");

            }
            else
            {
                if (RegistrationFormLogic.register(textBox1.Text, textBox2.Text))
                {

                    Messages.displayMessageBox( "You are registered successfully! Now you are able to log in!");

                    button2.Visible = true;
                    button1.Visible = false;

                }
                else
                {

                    Messages.displayMessageBox( "You cannot register because user with such credentials exists ");

                }
            }

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            prevForm.Show();
            this.Close();
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();

        }
    }
}
