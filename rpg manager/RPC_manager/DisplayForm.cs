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
    public partial class DisplayForm : Form
    {

        bool clickedReturn = false;

        public DisplayForm()
        {
            InitializeComponent();
        }



        // return
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

        private void DisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.menu != null && !clickedReturn)
            {
                MainForm.menu.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            string currentUserRole = dbActions.getRoleOfLoggedUser();

            if(comboBox1.SelectedIndex == 0)  // characters Category
            {
                List<string> allCharacters = null;

                if (currentUserRole.Equals("user"))
                {
                    allCharacters = dbActionsDisplayForm.getAllLoggedUSerCharacters(false);
                }
                else if (currentUserRole.Equals("admin"))
                {
                    allCharacters = dbActionsDisplayForm.getAllLoggedUSerCharacters(true);
                }

                foreach (var item in allCharacters)
                    {
                        Console.WriteLine(item);
                        listView1.Items.Add(item);
                    }

                
              
            }
            else if(comboBox1.SelectedIndex == 1)  // inanimate Category
            {

                List<string> allInanimates = null;

                if (currentUserRole.Equals("user"))
                {
                    allInanimates = dbActionsDisplayForm.getAllLoggedUserInanimates(false);
                }
                else if (currentUserRole.Equals("admin"))
                {
                    allInanimates = dbActionsDisplayForm.getAllLoggedUserInanimates(true);
                }

                foreach (var item in allInanimates)
                    {
                        Console.WriteLine(item);
                        listView1.Items.Add(item);
                    }
                
                


            }
        }
    }
}
