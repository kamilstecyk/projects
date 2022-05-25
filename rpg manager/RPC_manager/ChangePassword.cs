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
    public partial class ChangePassword : Form
    {
        static public Form1 prevForm = null;

        public ChangePassword(Form1 prev)
        {
            InitializeComponent();
            prevForm = prev;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                // msgLog.Text = "Textboxes cannot be empty and you cannot have spaces in them!";
                //  msgLog.Visible = true;

                Form1.displayMessage(msgLog, "Textboxes cannot be empty and you cannot have spaces in them!");

                return;
            }


            if (!dbActions.updateUser(textBox1.Text,textBox2.Text,textBox3.Text))
            {
                // msgLog.Text = "Such a user does not exist";
                // msgLog.Visible = true;

                Form1.displayMessage(msgLog, "Such a user does not exist");


                Console.WriteLine("I have noy found such a user. It was not updated");
                return;
            }

            // msgLog.Text = "You changed your password successfully!";
            //   msgLog.Visible = true;

            Form1.displayMessage(msgLog, "You changed your password successfully!");

            pictureBox1.Visible = true;
            button1.Visible = false;
            Console.WriteLine("I found such a user. It was updated");
           

        }

        private void ChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            prevForm.Show();
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = RegistrationForm.fontColor;
            button1.BackColor = RegistrationForm.mainColor;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = RegistrationForm.mainColor;
            button1.BackColor = RegistrationForm.fontColor;
        }
    }
}
