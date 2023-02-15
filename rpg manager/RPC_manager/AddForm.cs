using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RPC_manager
{
    public partial class AddForm : Form
    {
        bool clickedReturn = false;

        Panel currentElementPanel = null;  // it is helpful while setting different fields of adding elements
        List<TextBox> displayedTextboxes = new List<TextBox>();
        List<ComboBox> displayedComboboxes = new List<ComboBox>();
        Dictionary<string, int> particularCategories = null;
        
        public AddForm()
        {
            InitializeComponent();

    

        }

        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.menu != null && !clickedReturn)
            {
                MainForm.menu.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)  // combobx with elements
        {

            clearInputsOnTheScreen();

            if (comboBox2.SelectedIndex == 0)  // Characters category
            {
                charactersInput1.Visible = true;
                charactersInput2.Visible = true;
            }
            else if(comboBox2.SelectedIndex == 1)   // inanimate category
            {
                inanimateInput1.Visible = true;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MainForm.menu != null)
            {
                MainForm.menu.Show();
                MainForm.menu.MainForm_Load(sender,e); ; // we reload form in case there are new elemens
                clickedReturn = true;
                this.Close();
            }
        }


        private void clearInputsOnTheScreen()
        {
            charactersInput1.Visible = false;
            charactersInput2.Visible = false;       
            inanimateInput1.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  // combobox with categories
        {

            // we clean panel with inputs 

            if(currentElementPanel != null)
            {
                currentElementPanel.Visible = false;

            }


            cleanCombobox(comboBox3);


            if (comboBox1.SelectedIndex == 0)  // Characters category
            {

                // we must firsly clean combobox

                cleanCombobox(comboBoxParticularCategories);

                // we will generate user's particular categories which have in db

                particularCategories = DbActionsAddForm.getLoggedUserAllCharactersCategories();

                if(particularCategories.Count == 0)
                {
                   // displayMessage("You must add category to add elements!");
                    displayMessageBox("You must add category to add elements!");
                }
                else
                {
                    foreach(var item in particularCategories.Keys)
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

                comboBox3.Items.Add("Cave");
                comboBox3.Items.Add("Tower");
                comboBox3.Items.Add("Coppice");
            }


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (currentElementPanel != null)
            {
                currentElementPanel.Visible = false;
            }

            if(comboBox1.SelectedIndex == 0)  // characters category
            {
               
                //addElementsPanelsCharacters[comboBox3.SelectedIndex].Visible = true;

                if(comboBox3.SelectedIndex == 0)  // dragon
                {
                    Panel DragonPanel = createPanelWithSpecifiedLabels("Dragon", new string[] { "Name", "WingSpan" }, Enum.GetNames(typeof(DragonSpecies)), "DragonSpecies");
                    this.Controls.Add(DragonPanel);

                    currentElementPanel = DragonPanel;

                }
                else if(comboBox3.SelectedIndex == 1) // Mag
                {
                    Panel MagPanel = createPanelWithSpecifiedLabels("Mag", new string[] { "Name", "LevelOfPower" }, Enum.GetNames(typeof(MagCircle)), "MagCircle");
                    this.Controls.Add(MagPanel);

                    currentElementPanel = MagPanel;

                }
                else if(comboBox3.SelectedIndex == 2) // Ent
                {
                    Panel EntPanel = createPanelWithSpecifiedLabels("Ent", new string[] { "NumberOfJars", "Name" }, Enum.GetNames(typeof(EntSpecies)), "EntSpecies");
                    this.Controls.Add(EntPanel);

                    currentElementPanel = EntPanel;

                }


            }
            else if(comboBox1.SelectedIndex == 1)  // Inanimate
            {
                //addElementsPanelInanimate[comboBox3.SelectedIndex].Visible = true;

                if(comboBox3.SelectedIndex == 0)  // Cave
                {
                    Panel CavePanel = createPanelWithSpecifiedLabels("Cave", new string[] { "Depth" });
                    this.Controls.Add(CavePanel);

                    currentElementPanel = CavePanel;

                }
                else if(comboBox3.SelectedIndex == 1)   // Tower
                {
                    Panel TowerPanel = createPanelWithSpecifiedLabels("Tower", new string[] { "Height", "Material", });
                    this.Controls.Add(TowerPanel);

                    currentElementPanel = TowerPanel;
                }
                else if(comboBox3.SelectedIndex == 2)  // Coppice
                {
                    Panel CoppicePanel = createPanelWithSpecifiedLabels("Coppice", new string[] { "Area" });
                    this.Controls.Add(CoppicePanel);

                    currentElementPanel = CoppicePanel;

                }


            }


            currentElementPanel.Visible = true;  // we display this panel with inputs



        }



        private Panel createPanelWithSpecifiedLabels(string name, string[] labelstexts, string[] tableEnumsValue = null,string comboBoxLabel = null)  // create as many labels with textboxes as length of labelstexts
        {


           


            Panel NewPanel = new Panel();  // this is main Panel

            NewPanel.Location = new System.Drawing.Point(586, 305);
            NewPanel.Name = name;
            NewPanel.Size = new System.Drawing.Size(303, 159);
            NewPanel.TabIndex = 15;
            NewPanel.Visible = false;

            int margin = 0;

            for (int i=0;i<labelstexts.Length;++i)
            {
                Panel NewPanel1 = new Panel();
                Label NewLabel7 = new Label();
                TextBox NewTextBox4 = new TextBox();

               
                NewPanel1.Location = new System.Drawing.Point(24, 7 + margin);
                NewPanel1.Name = name + "panel1";
                NewPanel1.Size = new System.Drawing.Size(252, 37);
                NewPanel1.TabIndex = 11;

                NewLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                NewLabel7.ForeColor = System.Drawing.Color.White;
                NewLabel7.Location = new System.Drawing.Point(12, 10);
                NewLabel7.Name = "label7" + name;
                NewLabel7.Size = new System.Drawing.Size(130, 18);
                NewLabel7.TabIndex = 6;
                NewLabel7.Text = labelstexts[i] + ":";
                NewLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


                NewTextBox4.Location = new System.Drawing.Point(147, 8);
                NewTextBox4.Name = "textBox4" + name;
                NewTextBox4.Size = new System.Drawing.Size(90, 20);
                NewTextBox4.TabIndex = 0;

                displayedTextboxes.Add(NewTextBox4); // we add in order to proccess input later 



                NewPanel1.Controls.Add(NewLabel7);
                NewPanel1.Controls.Add(NewTextBox4);
                NewPanel.Controls.Add(NewPanel1);

                margin += 50;

            }

            Console.WriteLine(tableEnumsValue);



            if(tableEnumsValue != null )
            {


                Panel NewPanel3 = new Panel();
                Label NewLabel9 = new Label();


                ComboBox newCombobox = new ComboBox();

               

                NewPanel3.Location = new System.Drawing.Point(24, 108+ 20);
                NewPanel3.Name = name + "3";
                NewPanel3.Size = new System.Drawing.Size(252, 37);
                NewPanel3.TabIndex = 12;



                newCombobox.FormattingEnabled = true;
                newCombobox.Location = new System.Drawing.Point(147, 10 );
                newCombobox.Name = "comboBox" + comboBoxLabel;
                newCombobox.Size = new System.Drawing.Size(90, 21);
                newCombobox.TabIndex = 7;

                NewLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                NewLabel9.ForeColor = System.Drawing.Color.White;
                NewLabel9.Location = new System.Drawing.Point(9, 10);
                NewLabel9.Name = "label9" + name;
                NewLabel9.Size = new System.Drawing.Size(140, 18);
                NewLabel9.TabIndex = 6;
                NewLabel9.Text = comboBoxLabel + ":";
                NewLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                displayedComboboxes.Add(newCombobox);  // we add in order to proccess input later 


                foreach (var value in tableEnumsValue)   // we fill combobox
                {
                    newCombobox.Items.Add(value);
                }

                NewPanel3.Controls.Add(newCombobox);
                NewPanel3.Controls.Add(NewLabel9);
                NewPanel.Controls.Add(NewPanel3);

            }



            return NewPanel;
        }




        private void button2_Click(object sender, EventArgs e)
        {

            foreach(var item in displayedTextboxes)
            {
                Console.WriteLine(item.Text + " " + item.Name);
            }


            foreach (var item in displayedComboboxes)
            {
                Console.WriteLine(item.Text + " " + item.Name);
            }


            // we add elements to category


            int selectedCategoryID = particularCategories.ElementAt(comboBoxParticularCategories.SelectedIndex).Value;


            if (comboBox1.SelectedIndex == 0)  // characters
            {
                try
                {

                    if (comboBox3.SelectedIndex == 0)  // dragon
                    {
                        DbActionsAddForm.addDragonForLoggedUser(displayedTextboxes[0].Text, int.Parse(displayedTextboxes[1].Text), displayedComboboxes[0].SelectedIndex, selectedCategoryID);
                    }

                    else if (comboBox3.SelectedIndex == 1)  // mag
                    {
                        DbActionsAddForm.addMagForLoggedUser(displayedTextboxes[0].Text, int.Parse(displayedTextboxes[1].Text), displayedComboboxes[0].SelectedIndex, selectedCategoryID);
                    }

                    else if (comboBox3.SelectedIndex == 2)  // ent
                    {
                        DbActionsAddForm.addEntForLoggedUser(int.Parse(displayedTextboxes[0].Text), displayedComboboxes[0].SelectedIndex, displayedTextboxes[1].Text, selectedCategoryID);
                    }

                    displayMessageBox("You successfully added element to choosed category in your catalog");
                 //   displayMessage("You successfully added element to choosed category in your catalog");
                }
                catch(FormatException ex)
                {
                    //displayMessage("Bad input type!");
                    displayMessageBox("Bad input type!");
                    DbActionsAddForm.resetContext();

                }
                catch(Exception ex2)
                {
                    displayMessageBox("You cannot add element with the same name ! ");
                    DbActionsAddForm.resetContext();

                }

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    if (comboBox3.SelectedIndex == 0)  // cave
                    {
                        DbActionsAddForm.addCaveForLoggedUser(int.Parse(displayedTextboxes[0].Text), selectedCategoryID);
                    }

                    else if (comboBox3.SelectedIndex == 1)  // tower
                    {
                        ;
                        DbActionsAddForm.addTowerForLoggedUser(int.Parse(displayedTextboxes[0].Text), displayedTextboxes[1].Text, selectedCategoryID);
                    }

                    else if (comboBox3.SelectedIndex == 2)  // coppice
                    {
                        DbActionsAddForm.addCoppiceForLoggedUser(int.Parse(displayedTextboxes[0].Text), selectedCategoryID);
                    }

                   
                    displayMessageBox("You successfully added element to choosed category in your catalog");
                  //  displayMessage("You successfully added element to choosed category in your catalog");
                }
                catch(FormatException ex)
                {
                    //displayMessage("Bad input type!");
                    displayMessageBox("Bad input type!");

                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            // categories frontend is hardcoded

            if(comboBox2.SelectedIndex == 0)  // Characters
            {

                try
                {
                    if (!DbActionsAddForm.addCharactersCategoryForLoggedUser(int.Parse(textBoxLevel.Text), int.Parse(textBoxPower.Text)))
                    {
                       // displayMessage("You have had such a category yet!");
                        displayMessageBox("You have had such a category yet!");
                    }
                    else
                    {
                        displayMessageBox("You successfully added category Characters");
                     //   displayMessage("You successfully added category Characters");
                    }

                    //DbActionsAddForm.showUsersCharacters();

                }
                catch (FormatException ex)
                {
                 //   displayMessage("Invalid types of inputs!");
                    displayMessageBox("Invalid types of inputs!");
                }
                catch(Exception ex2)
                {
                    displayMessageBox("You cannot add category of character with level and power better than the most powerful one in your catalog. If you want to add this category you should edit existing in your table and then try.");

                }
            }
            else if(comboBox2.SelectedIndex == 1)  // Inanimate
            {
                try
                {
                    if (!DbActionsAddForm.addInAnimateCategoryForLoggedUser(int.Parse(textBoxArea.Text)))
                    {
                //        displayMessage("You have had such a category yet!");
                        displayMessageBox("You have had such a category yet!");

                    }
                    else {
                        displayMessageBox("You successfully added category Characters");
                        //displayMessage("You successfully added category Inanimate"); 
                    }

                    DbActionsAddForm.showUsersInAnimates();

                }
                catch (FormatException ex)
                {
               //     displayMessage("Invalid types of inputs!");
                    displayMessageBox("Invalid types of inputs!");

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
    }
}
