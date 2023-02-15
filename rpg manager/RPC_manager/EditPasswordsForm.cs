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
    public partial class EditPasswordsForm : Form
    {


        Dictionary<int, string> users = new Dictionary<int, string>();
        bool clickedReturn = false;

        public EditPasswordsForm()
        {
            InitializeComponent();
            button3.Click += new EventHandler(button3_Click);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MainForm.menu != null)
            {
                MainForm.menu.Show();
                MainForm.menu.MainForm_Load(sender, e); ; // we reload form in case there are new elemens
                clickedReturn = true;
                this.Close();
            }
        }

        private void EditPasswordsForm_Load(object sender, EventArgs e)
        {

            users = dbActionsEditPasswordsForm.getAllUsers();
            
            foreach(var user in users)
            {
                listBox1.Items.Add(user.Value);
            }    

        }

        private void EditPasswordsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MainForm.menu != null && !clickedReturn)
            {
                MainForm.menu.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(Verification.verifyPassword(textBox1.Text))  // succcess verifiation so we can update password for user
            {
                int selectedUserID = users.ElementAt(listBox1.SelectedIndex).Key;
                dbActionsEditPasswordsForm.updateUserPassword(textBox1.Text, selectedUserID);
                displayMessageBox("You have successfully changed password of user with ID = " + selectedUserID);

                EditPasswordsForm_Load(sender, e);

            }
            else
            {
                displayMessageBox("Incorrect Passowrd! Password should  contain minimum eight characters, at least one uppercase letter, one lowercase letter and one number. Login cannot contain spaces and should contain minimum 5 letters");
            }
        }

        private void displayMessageBox(string message)
        {


            string caption = "Added Element to Category";

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);

        }

    }
}
