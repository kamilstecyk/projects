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
    public partial class RemoveForm : Form
    {

        bool clickedReturn = false;

        List<TextBox> displayedTextboxes = new List<TextBox>();
        List<ComboBox> displayedComboboxes = new List<ComboBox>();
        Dictionary<string, int> particularCategories = null;   // text and id for category
        Dictionary<int, string> particularElements = null;    // text and id of the element


        public RemoveForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(EditForm_Load);
        }



        private void EditForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(AddForm_FormClosing);
            button3.Click += new EventHandler(button3_Click);

            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            comboBox3.SelectedIndexChanged += new EventHandler(comboBox3_SelectedIndexChanged);

        }



        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.menu != null && !clickedReturn)
            {
                MainForm.menu.Close();
            }
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  // combobox with categories
        {

            // we clean panel with inputs 


            cleanCombobox(comboBox3);


            if (comboBox1.SelectedIndex == 0)  // Characters category
            {

                // we must firsly clean combobox

                cleanCombobox(comboBoxParticularCategories);

                // we will generate user's particular categories which have in db

                particularCategories = DbActionsAddForm.getLoggedUserAllCharactersCategories();

                if (particularCategories.Count == 0)
                {
                    //displayMessage("You must add category to add elements!");
                    displayMessageBox("You must add category to add elements!");
                }
                else
                {
                    foreach (var item in particularCategories.Keys)
                    {
                        comboBoxParticularCategories.Items.Add(item);
                    }
                }


                // we add possible elements to add 

                comboBox3.Items.Add("Dragon");
                comboBox3.Items.Add("Mag");
                comboBox3.Items.Add("Ent");




            }
            else if (comboBox1.SelectedIndex == 1)  // inanimate category
            {
                // we must firsly clean combobox

                cleanCombobox(comboBoxParticularCategories);

                // we will generate user's particular categories which have in db

                particularCategories = DbActionsAddForm.getLoggedUserAllInanimatesCategories();

                if (particularCategories.Count == 0)
                {
                    //  displayMessage("You must add category to add elements!");
                    displayMessageBox("You must add category to add elements!");

                }
                else
                {
                    foreach (var item in particularCategories.Keys)
                    {
                        comboBoxParticularCategories.Items.Add(item);
                    }
                }



                // we add possible elements to add 

                comboBox3.Items.Add("Cave");
                comboBox3.Items.Add("Tower");
                comboBox3.Items.Add("Coppice");
            }


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectedCategoryID = particularCategories.ElementAt(comboBoxParticularCategories.SelectedIndex).Value;

            cleanCombobox(comboBox5);


           

            if (comboBox1.SelectedIndex == 0)  // characters category
            {

                if (radioButton2.Checked)   // we edit element part
                {
                    //addElementsPanelsCharacters[comboBox3.SelectedIndex].Visible = true;

                    if (comboBox3.SelectedIndex == 0)  // dragon
                    {

                        particularElements = dbActionsEditForm.getAllElementsCharactersForLoggedUSer(selectedCategoryID, 0);

                        foreach (var item in particularElements)
                        {
                            comboBox5.Items.Add(item);
                        }


                    }
                    else if (comboBox3.SelectedIndex == 1) // Mag
                    {
                       

                        particularElements = dbActionsEditForm.getAllElementsCharactersForLoggedUSer(selectedCategoryID, 1);

                        foreach (var item in particularElements)
                        {
                            comboBox5.Items.Add(item);
                        }

                    }
                    else if (comboBox3.SelectedIndex == 2) // Ent
                    {

                        particularElements = dbActionsEditForm.getAllElementsCharactersForLoggedUSer(selectedCategoryID, 2);

                        foreach (var item in particularElements)
                        {
                            comboBox5.Items.Add(item);
                        }

                    }
                }
               

            }
            else if (comboBox1.SelectedIndex == 1)  // Inanimate
            {
                //addElementsPanelInanimate[comboBox3.SelectedIndex].Visible = true;


                if (comboBox3.SelectedIndex == 0)  // Cave
                {
                   


                    particularElements = dbActionsEditForm.getAllElementsInAnimatesForLoggedUSer(selectedCategoryID, 0);

                    foreach (var item in particularElements)
                    {
                        comboBox5.Items.Add(item);
                    }

                }
                else if (comboBox3.SelectedIndex == 1)   // Tower
                {
                  

                    particularElements = dbActionsEditForm.getAllElementsInAnimatesForLoggedUSer(selectedCategoryID, 1);

                    foreach (var item in particularElements)
                    {
                        comboBox5.Items.Add(item);
                    }
                }
                else if (comboBox3.SelectedIndex == 2)  // Coppice
                {
                   

                    particularElements = dbActionsEditForm.getAllElementsInAnimatesForLoggedUSer(selectedCategoryID, 2);

                    foreach (var item in particularElements)
                    {
                        comboBox5.Items.Add(item);
                    }

                }
            }
         

        }


        private void displayMessage(string text)
        {
            operationMessage.Visible = true;
            operationMessage.Text = text;
        }

        private void displayMessageBox(string message)
        {


            string caption = "Added Element to Category";

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);

        }

        private void cleanCombobox(ComboBox cmbx)
        {
            cmbx.Items.Clear();
            cmbx.SelectedIndex = -1; // we reset selected value
            cmbx.Text = "";
        }

        private void charactersInput1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxParticularCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void comboBoxParticularCategories_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox3_SelectedIndexChanged(sender, e);
        }




        private void operationMessage_Click(object sender, EventArgs e)
        {

        }

        private void RemoveForm_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            comboBox5.Visible = true;
            label13.Visible = true;
            label6.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = false;
            comboBox5.Visible = false;
            label13.Visible = false;
            label6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (radioButton2.Checked)  // we delete element
            {
                int selectedElementID = particularElements.ElementAt(comboBox5.SelectedIndex).Key;

                if (comboBox1.SelectedIndex == 0)
                {
                    dbActionsRemoveForm.removeCharacterElement(comboBox3.SelectedIndex, selectedElementID);
                    displayMessageBox("You removed the element");
                }
                else if(comboBox1.SelectedIndex == 1)
                {
                    dbActionsRemoveForm.removeInAnimaterElement(comboBox3.SelectedIndex, selectedElementID);
                    displayMessageBox("You removed the element");

                }


            }
            else
            {
                int selectedCategoryID = particularCategories.ElementAt(comboBoxParticularCategories.SelectedIndex).Value;

                if (comboBox1.SelectedIndex == 0)
                {

                    dbActionsRemoveForm.removeCharacterCategory(selectedCategoryID);
                    displayMessageBox("You removed the whole category!");

                }
                else if(comboBox1.SelectedIndex == 1)
                {
                    dbActionsRemoveForm.removeInAnimateCategory(selectedCategoryID);
                    displayMessageBox("You removed the whole category!");

                }

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
