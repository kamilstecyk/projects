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
    public partial class ChangePasswordForm : Form
    {

        static public Form1 prevForm = null;


        public ChangePasswordForm(Form1 prev)
        {
            InitializeComponent();
            prevForm = prev;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {

                Messages.displayMessageBox("Textboxes cannot be empty and you cannot have spaces in them!");
                return;
            }


             if (!dbActions.updateUser(textBox1.Text, textBox2.Text, textBox3.Text))
             {

                Messages.displayMessageBox("Such a user does not exist");


                Console.WriteLine("I have noy found such a user. It was not updated");
                return;
              }
            


              Messages.displayMessageBox("You changed your password successfully!");

              pictureBox1.Visible = true;
              button1.Visible = false;
              Console.WriteLine("I found such a user. It was updated");

            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            prevForm.Show();
            this.Close();
        }

        private void ChangePasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }
    }
}
