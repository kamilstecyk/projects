using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PasswordVerificator
{
    public partial class UserControl1: UserControl
    {

        private int minChars { get; set; } = 8;
        private List<char> specialChars { get; set; } = new List<char>() { '?', '!' }; // default special chars

          [
              Category("Conditions"),
              Description("Minimal characters in password")
          ]
        // The public property EndColor accesses endColor.  
        public  int MinChars
        {
            get
            {
                return minChars;
            }
            set
            {
                minChars = value;
                Refresh();
            }
        }



        [
           Category("Conditions"),
           Description("Required special chars in password")
       ]
        // The public property EndColor accesses endColor.  
        public List<char> SpecialChars
        {
            get
            {
                return specialChars;
            }
            set
            {
                specialChars = value;
                Refresh();     
            }

        }



        private string condition1Text;
        private string condition2Text;
        private string condition3Text;
        private string condition4Text;

        public UserControl1()
        {
            InitializeComponent();
            
        }


        // core function to verify our password
        
        public void verifyPassword(string password)
        {

            passwordContainsMinChars(password);
            passwordContainsMinSpecialChars(password);
            passwordAtLeastCapitalLetter(password);
            passwordAtLeastOneDigit(password);

        }


        private void passwordContainsMinChars(string password)
        {

            if(password.Length >= MinChars)
            {
                panel1.BackColor = Color.Green;
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;

            }
            else
            {
                panel1.BackColor = Color.Red;
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;

            }

        }
        
        private void passwordContainsMinSpecialChars(string password)
        {
            // string pattern = "(?=.*?[#?!@$%^&*-]){" + MinChars + ",}";

            StringBuilder pattern = new StringBuilder(".*[");
            
            if(SpecialChars.Count == 0)
            {
                panel2.BackColor = Color.Green;
                pictureBoxSuccess.Visible = true;
                pictureBoxFault.Visible = false;

                return;
            }

            foreach(var item in SpecialChars)
            {
                pattern.Append(item.ToString());
            }

            pattern.Append("].*");

            if(Regex.IsMatch(password, pattern.ToString()))
            {
                panel2.BackColor = Color.Green;
                pictureBoxSuccess.Visible = true;
                pictureBoxFault.Visible = false;

            }
            else
            {
                panel2.BackColor = Color.Red;
                pictureBoxFault.Visible = true;
                pictureBoxSuccess.Visible = false;

            }
        }

        private void passwordAtLeastCapitalLetter(string password)
        {
            string pattern = "(?=.*?[A-Z])";


            if(Regex.IsMatch(password, pattern))
            {
                panel3.BackColor = Color.Green;
                pictureBox4.Visible = true;
                pictureBox3.Visible = false;

            }
            else 
            {
                panel3.BackColor = Color.Red;
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
            }

        }

        private void passwordAtLeastOneDigit(string password)
        {
            string pattern = "(?=.*?[0-9])";


            if (Regex.IsMatch(password, pattern))
            {
                panel4.BackColor = Color.Green;
                pictureBox6.Visible = true;
                pictureBox5.Visible = false;
            }
            else
            {
                panel4.BackColor = Color.Red;
                pictureBox5.Visible = true;
                pictureBox6.Visible = false;
            }


        }


            private void updateLabels()
        {

            condition1Text = "At least " + MinChars + " characters"; ;
            // condition2Text = "At least " + SpecialChars + " special characters";

            StringBuilder condition2TextSB = new StringBuilder("Must have: ");


            foreach(var item in SpecialChars)
            {
                condition2TextSB.Append(item.ToString());
            }

            condition2Text = condition2TextSB.ToString();

            condition3Text = "At least one capital letter"; ;
            condition4Text = "At least one digit"; ;


            label1.Text = condition1Text;
            label2.Text = condition2Text;
            label3.Text = condition3Text;
            label4.Text = condition4Text;

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            updateLabels();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)   // to update labels on the screen when we change in the code properties
        {
            updateLabels();
            timer1.Stop();
        }
    }
}
