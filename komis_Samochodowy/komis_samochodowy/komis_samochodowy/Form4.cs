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

namespace komis_samochodowy
{
    public partial class Form4 : Form
    {

        List<int> idsOfObservedCars = null;

        List<int> displayedCarsInList = null;  // indexes corresponds to selected index in listbox
        List<string> displayedData = null; 

        Form1 startForm;
        bool cancelClose = false;

        bool chooseDayFromPast = false;

        // path to file with content of reservations in format:
        // idOfCar ; username ; deadline 

        public static string reservationsPath = Path.Combine(Form3.temp, "reservations.txt");
        public Form4(Form1 form)
        {
            startForm = form;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startForm.Show();
            cancelClose = true;

            this.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!cancelClose)
                Environment.Exit(0);
        }

        private void Form4_Load(object sender, EventArgs e)
        {


            label5.Text = "Użytkownik: " + startForm.username;

            // we want to read from file

            // first we chech if it exists


            bool fileExist1 = File.Exists(Form2.observationsPath);
            if (fileExist1)
            {
                int counterOFItems = 0;
                idsOfObservedCars = new List<int>();

                string[] lines = File.ReadAllLines(Form2.observationsPath);

                foreach(var el in lines)
                {
                    string[] cols = el.Split(';');  // id ; username
                    string dataToCombobox = null;
                    
                    if(cols[1] == startForm.username)
                    {
                        // we seek for details of car

                        foreach(var item in startForm.listOfCars)
                        {
                            if(item.ID == Int32.Parse(cols[0]))
                            {
                                dataToCombobox = item.MakeOfCar + " " + item.Model + " " + item.Fuel;
                                comboBox1.Items.Add(dataToCombobox);
                                ++counterOFItems;
                                idsOfObservedCars.Add(item.ID);
                            }
                        }

                    }

                }

                if(counterOFItems == 0)
                {
                    label3.Text = "Nie obserwujesz żadnych aut!";
                }


            }
            else
            {
                label3.Text = "Nie obserwujesz żadnych aut!";
            }


            // we complete list with resrevations

            bool fileExist3 = File.Exists(reservationsPath);

            if(fileExist3)
            {
                displayedCarsInList = new List<int>();
                displayedData = new List<string>();

                string[] lines = File.ReadAllLines(reservationsPath);

                foreach(var line in lines)
                {
                    string[] cols = line.Split(';');

                    foreach(var item in startForm.listOfCars)
                    {
                        if(Int32.Parse(cols[0]).Equals(item.ID) && cols[1].Equals(startForm.username))
                        {
                            string dataToAdd = item.MakeOfCar + " " +  item.Model + " " + cols[2];
                            listBox1.Items.Add(dataToAdd);
                            displayedCarsInList.Add(item.ID);
                            displayedData.Add(cols[2]);
                        }
                    }

                }

            }

        }

        // add deadline
        private void button1_Click(object sender, EventArgs e)
        {


            // we cane reserve cars if we observe them
            // we want to display available in the combobox

            if (comboBox1.SelectedIndex > -1)  // we must choose car
            {

                bool fileExist2 = File.Exists(reservationsPath);

                if (fileExist2)
                {
                    Console.WriteLine("File " + reservationsPath + " exists.");
                }
                else
                {
                    using (File.Create(reservationsPath)) ;
                    Console.WriteLine("File " + reservationsPath + "does not exist.");
                }

                // we preapre data to add to file

                int selectedIndex = comboBox1.SelectedIndex;
                string dateReserved = dateTimePicker1.Value.ToShortDateString(); ;
                int choosedCarIndex = idsOfObservedCars[selectedIndex];


                // we need t o check if we have not have yet it in our file

                bool weHaveYet = false;
                string[] lines = File.ReadAllLines(reservationsPath);

                for(int i=0;i<lines.Length;++i)
                {
                    string[] cols = lines[i].Split(';');

                    // we cannot add two deadline on one car
                    // we need to prevent choose data from the past
                    if(Int32.Parse(cols[0]) == choosedCarIndex && cols[1].Equals(startForm.username) /*&& cols[2].Equals(dateReserved)*/)
                    {
                        weHaveYet = true;
                        break;
                    }


                }


                // we save data in file

                if (!weHaveYet && !chooseDayFromPast)
                {
                    using (StreamWriter sw = File.AppendText(reservationsPath))
                    {
                        //Console.WriteLine(dateReserved);

                        string dataToAdd = choosedCarIndex + ";" + startForm.username + ";" + dateReserved;
                        sw.WriteLine(dataToAdd);

                        // we need to add to listbox

                        //listBox1.Items.Add(dataToAdd);

                        foreach (var item in startForm.listOfCars)
                        {
                            if (choosedCarIndex.Equals(item.ID))
                            {
                                string data = item.MakeOfCar + " " + item.Model + " " + dateReserved;
                                listBox1.Items.Add(data);
                                displayedCarsInList.Add(item.ID);
                                displayedData.Add(dateReserved);
                            }
                        }

                    }
                    label3.Text = "";
                }
                else if(weHaveYet)
                {
                    label3.Text = "Już masz rezerwację na to auto!";
                }
                else if(chooseDayFromPast)
                {
                    label3.Text = "Wybrano dzień z przeszłości!";
                }
            }
            else
            {
                label3.Text = "Musisz wybrać auto!";
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            Console.WriteLine(selectedIndex);

            foreach(var el in idsOfObservedCars)
            {
                Console.WriteLine(el);
            }

            
            string pathToImage = Form2.getWholeFilenameWithExt(idsOfObservedCars[selectedIndex].ToString());
            pictureBox1.ImageLocation = pathToImage;


        }

        // remove btn
        private void button4_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex > -1)  // we must choose which item remove
            {

                int selectedItemToRemove = listBox1.SelectedIndex;
                int idCarToRemove = displayedCarsInList[selectedItemToRemove];

                // we need to overwrite file with reservations

                string[] lines = File.ReadAllLines(reservationsPath);

                // we clear content of file

                System.IO.File.WriteAllText(reservationsPath, string.Empty);

                foreach (var line in lines)
                {
                    string[] cols = line.Split(';');

                    if(Int32.Parse(cols[0]).Equals(idCarToRemove) && cols[1].Equals(startForm.username) && cols[2].Equals(displayedData[selectedItemToRemove]) )
                    {
                        continue; // we skip iteration
                    }

                    using (StreamWriter sw = File.AppendText(reservationsPath))
                    {
                        //Console.WriteLine(dateReserved);

                        sw.WriteLine(line);  // we rewrite lines apart from that which we want to remove

                    }

                }

                // we need to remove from lists

                displayedData.RemoveAt(selectedItemToRemove);
                displayedCarsInList.RemoveAt(selectedItemToRemove);


                // remmove elements from  listbox

                listBox1.Items.RemoveAt(selectedItemToRemove);

                // we invoke load event to refresh list 

                //this.Form4_Load(this, null); 


            }
           

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            if(dateTimePicker1.Value.Date < DateTime.Now.Date)
            {
                label3.Text = "Wybrano dzień z przeszłości!";
                label3.Visible = true;
                chooseDayFromPast = true;
            }
           else
            {
                chooseDayFromPast = false;
            }


        }
    }

   
    
}
