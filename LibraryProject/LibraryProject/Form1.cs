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

    // we create admin manually, inserting credentials directly to DB  with role = "Admin"

    public partial class Form1 : Form
    {

        static RegistrationForm regForm = null;
        static ChangePasswordForm changeForm = null;
        static MainForm mainForm = null;
        static GuestForm guestForm = null;
        static AdminForm adminForm = null;
        public static Form1 logForm = null;



        public Form1()
        {
            InitializeComponent();
            logForm = this;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {

                Messages.displayMessageBox("Your inputs cannot be empty!");

                return;
            }


            
             if (dbActions.logIn(textBox1.Text, textBox2.Text))
             {

                string loggedUserRole = dbActions.getUserRole(textBox1.Text);

                if(loggedUserRole.Equals("Admin"))
                {
                    adminForm = new AdminForm();
                    adminForm.Show();
                }
                else
                {
                    mainForm = new MainForm();
                    mainForm.Show();

                }

                this.Hide();

                return;

              }


            Messages.displayMessageBox("User with such credentials do not exist!");
            textBox2.Text = "";  // we reset field with password

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // we will back after registration
            regForm = new RegistrationForm(this);
            regForm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            changeForm = new ChangePasswordForm(this);
            changeForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine(dbActions.getLoggedUserID());
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // we ommit login procedure, we can recognize guest easily because loggedUserID is equal to -1

            guestForm = new GuestForm();
            guestForm.Show();

            this.Hide();


        }
    }
}
