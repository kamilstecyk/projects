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
    public partial class Form1 : Form
    {

        static RegistrationForm regForm = null;
        static ChangePassword changeForm = null;
        static MainForm mainForm = null;
        public static Form1 logForm = null;

        public Form1()
        {
            InitializeComponent();
            logForm = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 )
            {

                displayMessage(msgLog, "Textboxes cannot be empty!");

                return;
            }



            if (dbActions.logIn(textBox1.Text,textBox2.Text))
            {
                hideMessage(msgLog);
            
                mainForm = new MainForm();
                mainForm.Show();

                this.Hide();

                // go to another form  ( main )


                return;

            }

            
            displayMessage(msgLog, "You wrote down login or password badly or such a user does not exist");
            textBox2.Text = "";  // we reset field


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
            changeForm = new ChangePassword(this);
            changeForm.Show();
        }


        public static void displayMessage(Label msgLabel, string content)
        {
            msgLabel.Text = content;
            msgLabel.Visible = true;
        }

        public static void hideMessage(Label msgLabel)
        {
            msgLabel.Visible = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor =  RegistrationForm.mainColor;
            button1.BackColor = RegistrationForm.fontColor;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = RegistrationForm.fontColor;
            button1.BackColor = RegistrationForm.mainColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dbActions.addAdmin();
        }
    }
}
