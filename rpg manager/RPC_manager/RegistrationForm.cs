using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPC_manager
{
    public partial class RegistrationForm : Form
    {

        static Form1 prevForm = null;


        static public Color mainColor = Color.Firebrick;
        static public Color fontColor = Color.White;

        public RegistrationForm(Form1 prev)
        {
            InitializeComponent();
            prevForm = prev;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // validation of inputs

            if(!Verification.verifyLogin(textBox1.Text))
            {
                Form1.displayMessage(msgLog, "Login should not contain spaces and be lenght of minimum 5 letters");
                return;
            }

            if(!Verification.verifyPassword(textBox2.Text))
            {
                Form1.displayMessage(msgLog, "Password should contain minimum eight characters, at least one uppercase letter, one lowercase letter and one number");
                return;
            }


            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox1.Text.Contains(" ") || textBox2.Text.Contains(" ") || textBox3.Text.Contains(" "))
            {
            
                Form1.displayMessage(msgLog, "Textboxes cannot be empty and you cannot have spaces in them!");

                return;
            }


            if (!RegistrationLogic.checkIfPasswordMatches(textBox2.Text, textBox3.Text))  // user exists
            {
             
                Form1.displayMessage(msgLog, "The paasswords fields does not match");

            }
            else
            {
                if (RegistrationLogic.register(textBox1.Text, textBox2.Text))
                {
                 
                    Form1.displayMessage(msgLog, "You are registered successfully! Now you are able to log in!");

                    button2.Visible = true;
                    button1.Visible = false;

                }
                else
                {

                    Form1.displayMessage(msgLog, "You cannot register because user with such credentials exists ");


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


        private void button1_MouseLeave(object sender, EventArgs e)
        {
           
                //button1.Size = new Size(button1.Size.Width - 20, button1.Size.Height - 20);
                button1.ForeColor = mainColor;
                button1.BackColor = fontColor;
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = fontColor;
            button1.BackColor = mainColor;
        }
    }
}
