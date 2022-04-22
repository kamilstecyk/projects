using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Reflection;

namespace komis_samochodowy
{


    public partial class Form2 : Form
    {

       


        Form1 previusForm;
        Form5 formWithCars;

        // list of cars that we have in our service

        bool cancelClose = false;


        // arbitrary tabels to determine later from which panel we need to get data to store inforamation about reservation in file
        // sequence is the same
        Button[] tableOfBtns = null;
        Panel[] tableOfPanels = null;


        // list to store indexes of cars whichshould be dislayed after configuration
        List<int> indexesOfProperCars = null;


        // file "observations.txt"

        public static string observationsPath = Path.Combine(Form3.temp, "observations.txt");

        public Form2(Form1 form)
        {
            previusForm = form;
            InitializeComponent();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Visible = false;
            checkedListBox1.Visible = true;  // we have extended filters of search
        }

        private void Form2_Load(object sender, EventArgs e)
        {



            if(previusForm.noCars)
            {
                label6.Visible = true;
                return;
            }

            label6.Visible = false;

            // check listOfCars
            /*
           foreach(var el in previusForm.listOfCars)
            {
                Console.WriteLine(el);
            }
            */

            
            foreach(var el in previusForm.listOfCars)
            {
                comboBox1.Items.Add(el.MakeOfCar);   // we add available makes of cars in our store
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // we can display model of car based on choosed make of car

            // firstly we have to clear list of items in combobox


            // we have to clear all combobox below, because moc is the most important factor

            comboBox2.Items.Clear();
            comboBox5.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();

            foreach (var el in previusForm.listOfCars)
            {
                if(el.MakeOfCar.Equals(comboBox1.SelectedItem))
                {
                    comboBox2.Items.Add(el.Model);  // we add model
                }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            comboBox5.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();

            foreach (var el in previusForm.listOfCars)
            {
                if(el.MakeOfCar.Equals(comboBox1.SelectedItem) && el.Model.Equals(comboBox2.SelectedItem))
                {
                    comboBox5.Items.Add(el.Fuel);
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox3.Items.Clear();

            foreach (var el in previusForm.listOfCars)
            {
                if (el.MakeOfCar.Equals(comboBox1.SelectedItem) && el.Model.Equals(comboBox2.SelectedItem) && el.Fuel.Equals(comboBox5.SelectedItem))
                {
                    comboBox3.Items.Add((float)el.Engine);
                }
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();

            foreach (var el in previusForm.listOfCars)
            {
                if (el.MakeOfCar.Equals(comboBox1.SelectedItem) && el.Model.Equals(comboBox2.SelectedItem) && el.Fuel.Equals(comboBox5.SelectedItem) && el.Engine.Equals(comboBox3.SelectedItem))
                {
                    comboBox4.Items.Add(el.Colour);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            indexesOfProperCars = new List<int>();


            // we get values check in checkboxlist

            var addFilterData = checkedListBox1.CheckedItems;


            if (previusForm.noCars == false)  // we must have cars in store to start looking for particular car
            {
                // if nothing was choosed then we will display all cars


                bool[] wasChoosed = new bool[5];
                ComboBox[] comboboxes = new ComboBox[] { comboBox1, comboBox2, comboBox5, comboBox3, comboBox4 };

                // initialization
                for (int i = 0; i < wasChoosed.Length; ++i)
                {
                    wasChoosed[i] = false;
                }


                for (int i = 0; i < comboboxes.Length; ++i)
                {
                    if (comboboxes[i].SelectedIndex > -1)
                    {
                        wasChoosed[i] = true;
                    }
                }

             

                // frst we check the case when any combobx was selected, then we display all cars

                int counter = 0;
                for(int i=0;i<wasChoosed.Length;++i)
                {
                    if(wasChoosed[i] == false)
                    {
                        counter++;
                    }
                }


                

                if (counter == wasChoosed.Length)  // we dipslay every car
                {
                    for(int i=0;i<previusForm.listOfCars.Count;++i)
                    {
                        bool everyThingFulfilled = true;
                        int counterAddEq = 0;  /// arbitrary counter

                        if (addFilterData.Count > 0)  // this means that we have additonal filter criterion
                        {
                            string[] addDataOfCar = previusForm.listOfCars[i].getAdditionalEqTable();  // get list of car addditional equipment



                            if (addDataOfCar != null)
                            {
                                int count = addDataOfCar.Length;

                                for (int j = 0; j < addFilterData.Count; ++j)
                                {
                                    for (int z = 0; z < count; ++z)
                                    {
                                       

                                        if (addDataOfCar[z].Equals(addFilterData[j].ToString().Trim()))
                                        {
                                            ++counterAddEq;
                                            
                                        }
                                    }
                                }
                            }
                            else { everyThingFulfilled = false; } // this means that we have filters, but particular car doesnt have addditional eq
                        }

                        if (!counterAddEq.Equals(addFilterData.Count))
                        {
                            
                            everyThingFulfilled = false;  // we do not have all additional equipment
                        }


                        if (everyThingFulfilled)
                        {
                           
                            indexesOfProperCars.Add(previusForm.listOfCars[i].ID);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < previusForm.listOfCars.Count; ++i)
                    {

                        //Console.WriteLine(previusForm.listOfCars[i].Engine);
                        string[] carProperties = new string[] { previusForm.listOfCars[i].MakeOfCar, previusForm.listOfCars[i].Model, previusForm.listOfCars[i].Fuel, previusForm.listOfCars[i].Engine.ToString(), previusForm.listOfCars[i].Colour };
                        // Console.WriteLine(carProperties[3]);
                        // we check if particular car fulfill our requirements
                        // 4 index is engine and it is float so it requires convertion

                        bool everyThingFulfilled = true;

                        for (int j = 0; j < wasChoosed.Length; ++j)
                        {


                            if (wasChoosed[j] == true)
                            {

                                if (j == 3)
                                {
                                   
                                    float engineFloat = (float)Convert.ToDouble(carProperties[j]);


                                    if (!engineFloat.Equals(comboboxes[j].SelectedItem))
                                    {
                                        everyThingFulfilled = false;
                                        break;
                                    }

                                }
                                else
                                {
                                    if (!carProperties[j].Equals(comboboxes[j].SelectedItem))
                                    {
                                        everyThingFulfilled = false;
                                        break;
                                    }
                                }
                            }


                        }

                        int counterAddEq = 0;  /// arbitrary counter

                        if(addFilterData.Count > 0)  // this means that we have additonal filter criterion
                        {
                            string[] addDataOfCar = previusForm.listOfCars[i].getAdditionalEqTable();  // get list of car addditional equipment

                            

                            if (addDataOfCar != null)
                            {
                                int count = addDataOfCar.Length;

                                for (int j = 0; j < addFilterData.Count; ++j)  
                                {
                                    for(int z=0;z<count;++z)
                                    {
                                        //Console.WriteLine("1:'" + addDataOfCar[z] + "';2:'" + addFilterData[j].ToString().Trim());

                                        if(addDataOfCar[z].Equals(addFilterData[j].ToString().Trim()))
                                        {
                                            ++counterAddEq;
                                        }
                                    }
                                }
                            }
                            else { everyThingFulfilled = false; }
                        }

                        if( counterAddEq != addFilterData.Count)
                        {
                            everyThingFulfilled = false;  // we do not have all additional equipment
                        }




                        if (everyThingFulfilled)
                        {
                            indexesOfProperCars.Add(i);
                        }

                    }
                }
                

            }


            Form5 newForm = new Form5(previusForm, this, indexesOfProperCars);
            formWithCars = newForm;
            newForm.Show();
            this.Hide();  // we hide current window


            // we add our founded cars to form 5 dynamically



            // flow layout

            FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
            //flowLayoutPanel1.Anchor = AnchorStyles.None;

            flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)| System.Windows.Forms.AnchorStyles.Left)| System.Windows.Forms.AnchorStyles.Right)));
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            flowLayoutPanel1.Location = new System.Drawing.Point(27, 89);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(909, 437);
            flowLayoutPanel1.TabIndex = 2;


            // arbitrary tabels to determine later from which panel we need to get data to store inforamation about reservation in file
            tableOfBtns = new Button[indexesOfProperCars.Count];
            tableOfPanels = new Panel[indexesOfProperCars.Count];


            // informaton about 0 results
            if(indexesOfProperCars.Count == 0)
            {
                Panel panel1 = new Panel();

                panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
                panel1.BackColor = System.Drawing.Color.LightGray;
                panel1.Location = new System.Drawing.Point(470, 300);
                panel1.Margin = new System.Windows.Forms.Padding(10);
                panel1.Name = "panel1";
                panel1.Size = new System.Drawing.Size(886, 340); // 170 height
                panel1.TabIndex = 0;


                Label label22 = new Label();
                label22.Location = new System.Drawing.Point(21, 14);
                label22.Name = "label2";
                label22.Size = new System.Drawing.Size(886, 340);  
                label22.TabIndex = 1;
                label22.Text = "Niestety nie znaleziono szukanego samochodu :(";
                label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label22.Font = new Font("Arial", 18);

                panel1.Controls.Add(label22);
                flowLayoutPanel1.Controls.Add(panel1);

            }


            for (int i = 0; i < indexesOfProperCars.Count; ++i)
            {

                // id is the same as sequence of objects in listofcars

                string moc = previusForm.listOfCars[indexesOfProperCars[i]].MakeOfCar;
                string model = previusForm.listOfCars[indexesOfProperCars[i]].Model;
                string fuel = previusForm.listOfCars[indexesOfProperCars[i]].Fuel;
                string colour = previusForm.listOfCars[indexesOfProperCars[i]].Colour;
                float engine = (float)Convert.ToDouble(previusForm.listOfCars[indexesOfProperCars[i]].Engine);
                

                string additionalEquipment = previusForm.listOfCars[indexesOfProperCars[i]].getAllAdditionalEquipment();



                string pathToImage = getWholeFilenameWithExt(indexesOfProperCars[i].ToString());

                int idOfTheCar = indexesOfProperCars[i];


                bool noDisplayEngine = false;

                if(engine == 0)
                {
                    noDisplayEngine = true;
                }


                // 
                // panel1
                // 
                Panel panel1 = new Panel();

                panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
                panel1.BackColor = System.Drawing.Color.LightGray;
                panel1.Location = new System.Drawing.Point(10, 10);
                panel1.Margin = new System.Windows.Forms.Padding(10);
                panel1.Name = "panel1";
                panel1.Size = new System.Drawing.Size(886, 170);
                panel1.TabIndex = 0;
                // 
                // pictureBox1
                // 

                

                PictureBox pictureBox1 = new PictureBox();
                // pictureBox1.Image = Image.FromFile(pathToImage);
                pictureBox1.ImageLocation = pathToImage;
                pictureBox1.Location = new System.Drawing.Point(646, 0);
                pictureBox1.Name = "pictureBox1";
                pictureBox1.Size = new System.Drawing.Size(240, 170);
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                pictureBox1.TabIndex = 0;
                pictureBox1.TabStop = false;
                // 
                // label2
                // 

                Label label22 = new Label();
                label22.Location = new System.Drawing.Point(21, 14);
                label22.Name = "label2";
                label22.Size = new System.Drawing.Size(205, 25);
                label22.TabIndex = 1;
                label22.Text = moc + " " + model;
                label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label3
                // 

                Label label33 = new Label();
                label33.Location = new System.Drawing.Point(21, 54);
                label33.Name = "label3";
                label33.Size = new System.Drawing.Size(205, 25);
                label33.TabIndex = 2;

                if(!noDisplayEngine)
                {
                    label33.Text = fuel + " " + engine.ToString("0.0");
                }
                else
                {
                    label33.Text = fuel;
                }

                label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label4
                // 
                Label label44 = new Label();
                label44.Location = new System.Drawing.Point(21, 89);
                label44.Name = "label4";
                label44.Size = new System.Drawing.Size(205, 25);
                label44.TabIndex = 3;
                label44.Text = colour;
                label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label5
                // 
                Label label55 = new Label();
                label55.Location = new System.Drawing.Point(21, 130);
                label55.Name = "label5";
                //label55.AutoSize = true;
                label55.Size = new System.Drawing.Size(475, 40);
                label55.TabIndex = 4;
                label55.Text = additionalEquipment;
                label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;



                // we check if user has observedyet this car and depend on that we display different buttons

                bool fileExist = File.Exists(observationsPath);
                bool userObserve = false;

                if (fileExist) // we have to check
                {
                    Console.WriteLine("File " + observationsPath + " exists.");

                    string[] lines = File.ReadAllLines(observationsPath);


                    for (int j = 0; j < lines.Length; ++j)
                    {
                        string[] cols = lines[j].Split(';');

                        // we compare ids' and usernames
                        if (Int32.Parse(cols[0]) == indexesOfProperCars[i] && cols[1].Equals(previusForm.username))
                        {
                            userObserve = true;
                            break;
                        }

                    }

                }
               
                

                if (!userObserve)
                {
                    // 
                    // button1
                    // 
                    Button button11 = new Button();
                    button11.Cursor = System.Windows.Forms.Cursors.Hand;
                    button11.Location = new System.Drawing.Point(299, 54);
                    button11.Name = "button1";
                    button11.Size = new System.Drawing.Size(177, 35);
                    button11.TabIndex = 5;
                    button11.Text = "Obserwuj";
                    button11.UseVisualStyleBackColor = true;
                    button11.Click += new EventHandler(button11_clicked);

                    panel1.Controls.Add(button11);
                    tableOfBtns[i] = button11;

                }
                else
                {
                    

                    // 
                    // button2
                    // 
                    Button button22 = new Button();
                    button22.Cursor = System.Windows.Forms.Cursors.Hand;
                    button22.Location = new System.Drawing.Point(299, 54);
                    button22.Name = "button1";
                    button22.Size = new System.Drawing.Size(177, 35);
                    button22.TabIndex = 5;
                    button22.Text = "Przestań obserwować";
                    button22.UseVisualStyleBackColor = true;
                    //button22.Click += new EventHandler((sender, e) =>button22_clicked(sender, e, i));  this is good but in other event

         

                    button22.Click += delegate (object sender2, EventArgs e2) { button22_clicked(sender2, e2,idOfTheCar); };

                    panel1.Controls.Add(button22);
                    tableOfBtns[i] = button22;

                }





                // we adding control to panel


                panel1.Controls.Add(label55);
                panel1.Controls.Add(label44);
                panel1.Controls.Add(label33);
                panel1.Controls.Add(label22);
                panel1.Controls.Add(pictureBox1);


                // we add panel panel to flow layout

                flowLayoutPanel1.Controls.Add(panel1);

                
                tableOfPanels[i] = panel1;
            }

            // we add flow  layuout to form

            newForm.Controls.Add(flowLayoutPanel1);


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            resetComboboxes();
        }

        // click toobserve particular car
        private void button11_clicked(object sender, EventArgs e)
        {
            //Form4 reservationForm = new Form4(previusForm);
            //reservationForm.Show();
           // cancelClose = true;
           // this.Close();
            //formWithCars.Hide();

            ///Console.WriteLine("Sender: " + sender.);

            int indexOfReservedCar = -1;

            for(int i=0;i<tableOfBtns.Length;++i)
            {
                if (tableOfBtns[i] == (Button)sender)
                {
                    indexOfReservedCar = i;
                    break;
                }
            }


            int indexOfChoosedCar = indexesOfProperCars[indexOfReservedCar];

            // we will write to file with format:
            // idCar ; userName

            bool fileExist = File.Exists(observationsPath);

            if (fileExist)
            {
                Console.WriteLine("File " + observationsPath + " exists." );
            }
            else
            {
                using (File.Create(observationsPath)) ;
                Console.WriteLine("File " + observationsPath +  "does not exist.");
            }


            // we check if someone have reserved this car yet

            string[] lines = File.ReadAllLines(observationsPath);

            bool doesHaveCar = false;

            for(int i=0;i<lines.Length;++i)
            {
                string[] cols = lines[i].Split(';');

                // we compare ids' and usernames
                if( Int32.Parse(cols[0]) == indexOfChoosedCar && cols[1].Equals(previusForm.username))
                {
                    doesHaveCar = true;  
                    break;
                }

            }

            // we will write to file new record 
            if(!doesHaveCar)
            {
                using (StreamWriter sw = File.AppendText(observationsPath))
                {
                    string data = indexOfChoosedCar + ";" + previusForm.username;
                    sw.WriteLine(data);
                    Console.WriteLine("Zapisano do pliku " + observationsPath);
                }
            }
            else
            {
                
                Console.WriteLine("Nie zapisano do pliku " + observationsPath + " ,ponieważ już plik zawiera ten rekord!");
            }


            // we change button to unobsert btn

            // we change button to observe button

            Button sentBtn = (Button)sender;

            // we reset all event handlers
            RemoveClickEventsHandlers(sentBtn);

            sentBtn.Click += delegate (object sender2, EventArgs e2) { button22_clicked(sender2, e2, indexOfChoosedCar); };
            sentBtn.Text = "Przestań obserwować";



        }


        // click unobserve particular car
        private void button22_clicked(object sender, EventArgs e, int idOfCar)
        {
            // to unobserve we will need to delee particular line and overwrite file

            string[] lines = File.ReadAllLines(observationsPath);

            // we clear file

           System.IO.File.WriteAllText(observationsPath, string.Empty);

            

            Console.WriteLine("index of unobserved car to unobserve: " + idOfCar);

            // now we weill be appending lines, apart from that which contain unobserved car
            for (int i=0;i < lines.Length;++i)
            {
                string[] cols = lines[i].Split(';');

               if(Int32.Parse(cols[0]).Equals(idOfCar) && cols[1].Equals(previusForm.username))  // this is car to unobser
                {
                    continue;  // skip iteration for this
                }
               else
                {
                    using (StreamWriter sw = File.AppendText(observationsPath))
                    {
                        sw.WriteLine(lines[i]); // we append particular lines
                        Console.WriteLine("Zapisano do pliku " + observationsPath);
                    }

                }


            }


            // we change button to observe button

            Button sentBtn = (Button)sender;

            // we reset all event handlers
            RemoveClickEventsHandlers(sentBtn);

            sentBtn.Click += button11_clicked;
            sentBtn.Text = "Obserwuj";

        }


        // arbitrar function to get the full name with extension
        static public string getWholeFilenameWithExt(string partialName)
        {
            Console.WriteLine(partialName);
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@"C:\Users\user\source\repos\komis_samochodowy\komis_samochodowy\images");
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");

            foreach (FileInfo foundFile in filesInDir)
            {
                string fullName = foundFile.FullName;

                Console.WriteLine(fullName);
                return fullName;
            }

            return "";
        }


        public void resetComboboxes()
        {
            comboBox1.SelectedIndex = -1; // we reset selected item
            comboBox2.Items.Clear();
            comboBox5.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            previusForm.Show();
            cancelClose = true;
            this.Close();

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!cancelClose)
                Environment.Exit(0);
        }



        private void RemoveClickEventsHandlers(Button b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);

            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }
    }
}

