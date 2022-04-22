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
using System.Text.RegularExpressions;

namespace komis_samochodowy
{
    public partial class Form3 : Form
    {
        Form1 previousForm;

        public static string temp = AppDomain.CurrentDomain.BaseDirectory;
        public static string  sPath = Path.Combine(temp, "cars.txt");

        string fileToUpload;
        int idOfThecar;
        bool idLoaded = true;   // change to false;

        bool cancelClose = false;
        public Form3(Form1 form)
        {
            previousForm = form;
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.ForeColor = Color.Black;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox4.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // we need to write regexp to validate data

            // we will be adding this car to db which is the file cars.txt

            //string temp = AppDomain.CurrentDomain.BaseDirectory;
            //string sPath = Path.Combine(temp, "cars.txt");



            bool fileExist = File.Exists(sPath);

            if (fileExist)
            {
                Console.WriteLine("File " + sPath + " exists.");
            }
            else
            {
                using (File.Create(sPath)) ;
                Console.WriteLine("File " + sPath +  " does not exist.");
            }



            // we need to firsly open a file and check what is the last index of car and then we increment, all cars have their unique id's

            var lineCount = File.ReadLines(sPath).Count();
            


            if (lineCount == 0)  // we check whtehter file contain content
            {
                idOfThecar = 0;
            }
            else
            {

                idOfThecar = lineCount; // we start enumarate ids' from 0

            }


            // last id loaded
            idLoaded = true;



            // there will be basic valdation and we will write to file 

            bool isError = false;
            StringBuilder errMsg = new StringBuilder();

            // regex for validation float (engine)
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");


            if (textBox1.Text == "" || textBox2.Text == "" || textBox2.Text == "" || textBox2.Text == "" )
            {
                errMsg.Append("Pola do wpisania nie mogą być puste!");
                isError = true;
            }

            if(textBox1.Text == "Marka" || textBox2.Text == "Model" || textBox3.Text == "Silnik" || textBox4.Text == "Kolor")
            {
                errMsg.Append("Musisz wpisać swoje wartośći w pola!");
                isError = true;
            }


            if(comboBox1.Text == "Rodzaj paliwa")
            {
                errMsg.Append("\nWybierz rodzaj paliwa!");
                isError = true;
            }


            if(fileToUpload == null)
            {
                errMsg.Append("\nNie przesłano zdjęcia!");
                isError = true;
            }

            if(!regex.IsMatch(textBox3.Text))
            {
                errMsg.Append("\nNiepoprawny format dla silnika!");
                isError = true;
            }


            if(isError)
            {
                label4.Visible = true;
                label4.Text = errMsg.ToString();
            }
            else
            {
                label4.Visible = false;
                label4.Text = "";
            }





            // handling adding of cars to db ( as a file)

            if(!isError)   // everything with inputed data is fine and we uploaded photo
            {

                // we save in file data 

                string data;  // this is a string which contain data to add


                // data include: 
                // id;username;makeOfCar;model;fuel;engine;colour; additional data (( like air-conditioning ) etc. after 7 index of table in line )

                StringBuilder additionalData = new StringBuilder();

                bool first = true;
                int howMany = checkedListBox1.CheckedItems.Count;

                int i = 1;
                foreach(var li in checkedListBox1.CheckedItems)
                {
                    if (first && howMany != 1)
                    { 
                        additionalData.Append(li.ToString().Trim() + ";");
                        first = false;
                    }
                    else if( i >= howMany)  // last 
                    {
                        additionalData.Append(li.ToString().Trim());
                    }
                    else
                        additionalData.Append(li.ToString().Trim() + ";");

                    ++i;

                }

                //Console.WriteLine(additionalData.ToString());
                //data = idOfThecar + ";" + previousForm.username + ";" + textBox1.Text.ToUpper() + ";" + textBox2.Text.ToUpper() + ";" + comboBox1.SelectedItem.ToString().ToUpper() + ";" + textBox3.Text + ";" + textBox4.Text.ToUpper();
                data = idOfThecar +  ";" + textBox1.Text.ToUpper() + ";" + textBox2.Text.ToUpper() + ";" + textBox3.Text + ";" + comboBox1.SelectedItem.ToString().ToUpper() + ";" + textBox4.Text.ToUpper();

                if(additionalData.Length != 0)
                {
                    data += ";" + additionalData.ToString();
                }

               // Console.WriteLine("Do zapisu: " + data);

                using (StreamWriter sw = File.AppendText(sPath))
                {
                    sw.WriteLine(data);
                    Console.WriteLine("Zapisano do pliku " + sPath);
                }

                // adding photo to the folder

                // we will be naming it by id of the car  

                // @ make that the string doesn t recognize escape characters like /" it is "

                File.Copy(fileToUpload, Path.Combine(@"C:\Users\user\source\repos\komis_samochodowy\komis_samochodowy\images\", idOfThecar.ToString() + Path.GetExtension(fileToUpload)), true);   // we copy choosed photo to folder in our project
                Console.WriteLine("Zapisano plik do folder");

                previousForm.Form1_Load(sender,e);
                this.Hide();

                Form6 successForm = new Form6(previousForm, this);
                successForm.Show();



            }
           




        }

        // choosing photo of the car
        private void button2_Click(object sender, EventArgs e)
        {
            if (idLoaded)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";


                if (open.ShowDialog() == DialogResult.OK)
                {
                    fileToUpload = open.FileName;
                    pictureBox1.Image = new Bitmap(open.FileName);   // we open choosed photo in picture box

               
                }
            }
            else
            {
                Console.WriteLine("Nie wczytano jeszcze id");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            cancelClose = true;
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!cancelClose)
                Environment.Exit(0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 4)
            {
                //textBox3.Visible = false;
                textBox3.Enabled = false;
                textBox3.Text = "0.0";  // battery electric vehicle
            }
            else if(comboBox1.SelectedIndex == 3)
            {
                // textBox3.Visible = false;
                textBox3.Enabled = false;
                textBox3.Text = "0.0";  // HYBRID electric vehicle
            }
            else  // default 
            {
                //textBox3.Visible = true;
                textBox3.Enabled = true;
                textBox3.Text = "Silnik";
            }
        }
    }
}
