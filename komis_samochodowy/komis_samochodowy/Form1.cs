using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;


namespace komis_samochodowy
{
    public partial class Form1 : Form
    {
       

        // classes to store information about cars from file 
        public class Car
        {
            public int ID { get; private set; }
            public string MakeOfCar { get; private set; } // property
            public string Model { get;private set; }
            public float Engine { get;private set; }
            public string Colour { get;private set; }

            public string Fuel { get;private set; }


            List<AdditionalEquipment> listOfAdditionalEquipment = new List<AdditionalEquipment>();


            public Car(int id, string moc, string model, float engine, string f, string col)
            {
                this.ID = id;
                this.MakeOfCar = moc;
                this.Model = model;
                this.Engine = engine;
                this.Colour = col;
                this.Fuel = f;
            }

            public string getAllAdditionalEquipment()
            {
                StringBuilder res = new StringBuilder();

                if(listOfAdditionalEquipment.Count > 0)
                {
                    foreach(var el in listOfAdditionalEquipment)
                    {
                        res.Append(el.Equipment + " ");
                    }
                }
                else
                {
                    res.Append("");
                }


                return res.ToString();
            }

            public string[] getAdditionalEqTable()
            {
                int numberOfEq = listOfAdditionalEquipment.Count;
                string[] table = null;  // default

                if(numberOfEq > 0)
                {
                    table = new string[numberOfEq];
                    for(int i=0;i<numberOfEq;++i)
                    {
                        table[i] = listOfAdditionalEquipment[i].Equipment.Trim();
                    }
                }

                return table;

            }

            public void addAdditionalEquipment(string eq)
            {
                listOfAdditionalEquipment.Add(new AdditionalEquipment(eq));
            }


            public override string ToString() 
            {
                

                StringBuilder res = new StringBuilder();

                res.Append(this.ID + ";" + this.MakeOfCar + ";" + this.Model + ";" + this.Engine + ";" + this.Colour + ";" + this.Fuel);

                if(listOfAdditionalEquipment.Count != 0)
                {
                    
                    foreach(var el in listOfAdditionalEquipment)
                    {
                        res.Append(";" + el);
                    }

                }

                return res.ToString();

            }

 


        }

        public List<Car> listOfCars = new List<Car>();



        class AdditionalEquipment   // we create object beacuse in the future we might want to have eg. category of particular equipmeent and additional data
        {
            public string Equipment { get;private set; }

            public AdditionalEquipment(string eq)
            {
                Equipment = eq;
            }

            public override string ToString()
            {
                return Equipment;
            }
        }


        Form2 form2;
        Form3 form3;
        Form4 form4;

        bool isUsernameInputed = false;
        bool firstClick = false;
        public bool noCars = false;


        public string username;


        public Form1()
        {

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isUsernameInputed)
            {
                form2 = new Form2(this);
                this.Hide();
                form2.Show();
                label3.Visible = false;
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isUsernameInputed)
            {
                form3 = new Form3(this);
                this.Hide();
                form3.Show();
                label3.Visible = false;
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isUsernameInputed)
            {
                form4 = new Form4(this);
                this.Hide();
                form4.Show();
                label3.Visible = false;
            }
            else
            {
                label3.Visible = true;
            }
        }



        private void textBox1_Click(object sender, EventArgs e)
        {
            if (!firstClick)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
                firstClick = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != " " && textBox1.Text != "Podaj nazwę użytkownika")
            {
                isUsernameInputed = true;
                username = textBox1.Text;
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            bool fileExist = File.Exists(Form3.sPath);

            if (fileExist)
            {



                var lineCount = File.ReadLines(Form3.sPath).Count();
                Console.WriteLine("Ilosc lini w pliku: " + lineCount);


                if (lineCount == 0)  // we check whtehter file contain content
                {
                    Console.WriteLine("Brak samochodów w komisie!");
                    noCars = true;  // to display info 
                    return;
                }


                noCars = false;

                // we read file line by line and create objects (cars)
                string[] lines = File.ReadAllLines(Form3.sPath);

                for (int i = 0; i < lineCount; ++i)
                {
                    string[] columns = lines[i].Split(';');
                    int numberOfColumns = columns.Length;

                    // it is important that float.Parse() have two obligatory parameters!!!

                    try
                    {

                        Car newCar = new Car(Convert.ToInt32(columns[0]), columns[1], columns[2], float.Parse(columns[3], CultureInfo.InvariantCulture.NumberFormat), columns[4], columns[5]);

                        if (numberOfColumns >= 7)  // this means that we have additional eq to this car
                        {

                            for (int j = 6; j < numberOfColumns; ++j)
                            {
                               
                                    newCar.addAdditionalEquipment(columns[j]);
                                    
                                
                            }

                        }

                        // add car to the list

                        listOfCars.Add(newCar);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Błąd konwersji typu");
                    }



                }
            }
            else
            {
                noCars = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
