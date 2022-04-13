using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace memory_game
{
    public partial class Form1 : Form
    {

        // class for users in rank

        int selectedLevel = 0;  // default

        public class User
        {
            public string userName;
            public long totalPoints;

            public User(string un,long tp)
            {
                this.userName = un;
                this.totalPoints = tp;
            }

            public override string ToString() 
            {
                return userName + ";" + totalPoints;
            }

        }


        // list for storing best 15 users in our rank

        public List<User> listOfUsers = new List<User>(15);


        // stats
        public int pointsAvailable = 10000;  // when the time is passing this number is decreasing, because it is better to solve in shorter time
        public static int ourPointsTime = 10000;
        public static int numberOfMistakes = 0;


        public bool isLoaded = false;
        public static bool isFinished = false;

        Random random = new Random();

        // example List<string> boardIcons = new List<string>(new string[]{"A","B","C","D","E","F","G","H", "A", "B", "C", "D", "E", "F", "G", "H" });

        List<string> boardIcons = new List<string>();


        static public Label firstClicked = null;
        Label secondClicked = null;


       

        Form gameForm;
        bool isFirstclicked = true;
        static public TableLayoutPanel dynamicTable;    // our table layout on new form with game


        public static Timer timer1;  // this is timer for reverse cards
        Timer timer2;   // this is timer for initial time of displaying cards


        public Form1()
        {
            InitializeComponent();
            
        }

        // main functionality in this application -----------

        private void button1_Click(object sender, EventArgs e)
        {

            // we have to write username, because it is requiered for rank, it cannot be empty
            if(textBox4.Text.Equals("Wpisz nazwę użytkownika") || textBox4.Text.Equals("") || textBox4.Text.Equals(" "))
            {
                MessageBox.Show("Musisz wpisać nazwę użytkownika, ponieważ jest potrzebna do rankingu! " + textBox4.Text, "Komunikat");

            }
            else 
            {

                // here should be if satement to display different boards

                //gameForm = new Form2();
                gameForm = new Form3(this);


                // we add timers for new form



                timer1 = new Timer();
                timer1.Interval = (int)this.numericUpDown2.Value * 1000;   // this is time when our cards are revealed after 2 choosed


                timer2 = new Timer();
                timer2.Interval = (int)this.numericUpDown1.Value * 1000;   // this is time for initially displaying cards




                // we add events dynamically

                timer1.Tick += timer1_Tick;
                timer2.Tick += timer2_Tick;


                // we need to extract int value from a string

                string a = string.Empty;
                if (radioButton1.Checked == true) { a = radioButton1.Text; }
                else if (radioButton2.Checked == true) { a = radioButton2.Text; }
                else { a = radioButton3.Text; }


                string b = string.Empty;
                int val = 0;

                for (int i = 0; i < a.Length; i++)
                {
                    if (Char.IsDigit(a[i]))
                        b += a[i];
                }

                if (b.Length > 0)
                    val = int.Parse(b);
                else
                {
                    this.Close();
                }


                // initializing table properties

                int cols = 8;   // by default we have 8 x rows board
                int rows = val / cols;  // we want to obtain rows number

                boardIcons = generateListWithRandomChars(val / 2);  // we have this arg/2 pairs

                // we generate table

                dynamicTable = new TableLayoutPanel();
                addTableToForm(rows, cols, gameForm, ref dynamicTable);
                addLabelsToTable(rows, cols, ref dynamicTable);


                AddIconsToLabels(Color.Black, ref dynamicTable);


                gameForm.Show();
                this.Hide();


                timer2.Start();  // we start timer with displaying cards originally

                
                
            }
           
        }

        //  ---- ----- - - --
       

        // function to add dynamically tableLayout to form
        public void addTableToForm(int rows,int cols,Form form,ref TableLayoutPanel dynamicTable)
        {
            
            dynamicTable.Location = new System.Drawing.Point(0, 0);
            dynamicTable.Name = "tableLayoutPanel2";
            dynamicTable.TabIndex = 0;
            dynamicTable.Dock = System.Windows.Forms.DockStyle.Fill; 
            dynamicTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;


            dynamicTable.ColumnCount = cols;
            dynamicTable.RowCount = rows;


            float columnSize = (float)100.0 / cols;
            float rowSize = (float)100.0 / rows;

            

            for (int i = 0; i < cols; ++i)
            {
                dynamicTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, columnSize));
            }

            for (int i = 0; i < rows; ++i)
            {
                dynamicTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, rowSize));
            }

            form.Controls.Add(dynamicTable);

            Console.WriteLine((float)columnSize + " " + (float)rowSize);

        }


        public void addLabelsToTable(int rows,int cols,ref TableLayoutPanel tlp)
        {
            for(int i=0;i<rows;++i)
            {
                for(int j=0;j<cols;++j)
                {
                    Label tmp = new Label();
                    tmp.Dock = System.Windows.Forms.DockStyle.Fill;
                    tmp.Font = new System.Drawing.Font("Wingdings", 54F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
                    tmp.Location = new System.Drawing.Point(797, 312);
                    tmp.Cursor = System.Windows.Forms.Cursors.Hand;
                    tmp.Name = "tmp"+j+i;
                    tmp.Size = new System.Drawing.Size(111, 306);
                    tmp.TabIndex = 15;
                    tmp.Text = "i";
                    tmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    tmp.UseCompatibleTextRendering = true;
                    tmp.Click += new System.EventHandler(this.label1_Click);
                    tlp.Controls.Add(tmp, j, i);  // first cols , then rows
                    
                }
            }
        }


        public List<string> generateListWithRandomChars(int howMany)
        {

            List<int> randomList = new List<int>();
            List<string> icons = new List<string>(new string[howMany * 2]);



            for (int i = 0; i < howMany; ++i)
            {
                int letterInt = (int)Math.Round(random.NextDouble() * 57 + 65, 0, MidpointRounding.AwayFromZero); // we generate letters
                char letter = (char)letterInt;

                // check if our letter is unique before adding to list of strings

                while (randomList.Contains(letterInt) || letterInt == 32)
                {
                    letterInt = (int)Math.Round(random.NextDouble() * 60 + 50, 0, MidpointRounding.AwayFromZero);
                    letter = (char)letterInt;
                }

                randomList.Add(letterInt);

                icons[i] = letter.ToString();

            }



            int j = 0;



            for (int i = howMany; i < howMany * 2; i++, j++)
            {
                string tmp = icons[j];
                icons[i] = tmp;  // we adding appropriate pairs

            }


            return icons;
        }


        private void AddIconsToLabels(Color color,ref TableLayoutPanel tbl)  // we pass color
        {
            int i = 0;
            foreach (Control control in tbl.Controls)
            {
                Label iconLabel = control as Label;

                
                if (iconLabel != null && i != boardIcons.Count)
                {
                    int randomNr = random.Next(boardIcons.Count);
                    iconLabel.Text = boardIcons[randomNr];
                    
                    iconLabel.ForeColor = color;  // color of the icon initially
                    boardIcons.RemoveAt(randomNr);   // in order not to duplicate on board when displyaing
                   
                }
            }


        }



        public void ChangeIconsToLabels(Color color)  // we pass color
        {

            foreach (Control control in dynamicTable.Controls)
            {
                Label iconLabel = control as Label;


                if (iconLabel != null)
                {

                    iconLabel.ForeColor = color;  // color of the icon initially

                }
            }


        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(isFirstclicked)
            {
                textBox4.Text = "";
                textBox4.ForeColor = SystemColors.WindowText;
                isFirstclicked = false;
            }
            
            
        }

        // event handler for tiles    --------- 
        

        public void label1_Click(object sender, EventArgs e)
        {
            Label clickedLab = sender as Label;


            // we ignore click when the timmer is running
            

            if (timer1.Enabled == true)
            {
                return;
            }

            if (clickedLab != null)
            {
                // Black
                if (clickedLab.ForeColor == Color.Black) { return; }  // we clicked revealed card yet so we ignore

                if (firstClicked == null)
                {
                    firstClicked = clickedLab;
                    firstClicked.ForeColor = Color.Black; 

                    return;
                }

                secondClicked = clickedLab;
                secondClicked.ForeColor = Color.Black; 


                CheckWhetherItIsWon();


                // verifying whether icons match

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked.Cursor = Cursors.Default;
                    secondClicked.Cursor = Cursors.Default;

                    firstClicked = null;
                    secondClicked = null;
                 
                    return;
                }

                ++numberOfMistakes;  // we increase number of our mistakes

                // now we display two icons, after some time thanks to timer we will hide them

                timer1.Start();

            }
        }

        // function to decide whether this game is won

        private void CheckWhetherItIsWon()
        {

           
            
            
            foreach (Control control in dynamicTable.Controls)
            {
                Label icLab1 = control as Label;

                if (icLab1 != null)
                {

                    if (icLab1.ForeColor == icLab1.BackColor)
                    {
                        return;
                    }
                }
            }
            

            // player won this game  , handling this situation
            isFinished = true;
            Form3.st.Stop();

            // username iputed in form initailly

            string userName = textBox4.Text;

            // we calculate our total points, for time we have higher weigth

            int weightTime = 10;
            int weightMistakes = 5;

            long totalPoints = (weightTime * ourPointsTime) + (weightMistakes * (pointsAvailable - numberOfMistakes * 100));
            Console.WriteLine(totalPoints);

            if( totalPoints < 0 )
            {
                totalPoints = 0;
            }

            // here should be displayed form with rank

            // MessageBox.Show("You won the game", "Congratulations");

            // we update file

            // first crete if it doesnt exist

            string dynamicPath = "rank" + this.selectedLevel + ".txt";  // for particulars levels we have different files

            

            string GuarnteedWritePath = System.Environment.
                             GetFolderPath(
                                 Environment.SpecialFolder.CommonApplicationData
                             );
            string path = Path.Combine(GuarnteedWritePath, dynamicPath);

            Console.WriteLine("Path to file: " + path);

            if (!File.Exists(path))
            {

                using (File.Create(path))
                {
                    Console.WriteLine("Utowrzylem!");
                }

                //Console.WriteLine("Utowrzylem!");

            }


            //we open file and fill objects in list

            bool isSuchUsername = false;
            int indexToUpdate = 0;
            long lastResult = 0;

            string[] lines = File.ReadAllLines(path);
            
            for(int i=0;i<lines.Length;++i)
            {
                string[] tmpValues = lines[i].Split(';');

                if(tmpValues[1].Equals(userName))
                {
                    isSuchUsername = true;
                    indexToUpdate = int.Parse(tmpValues[0]) - 1;  // index
                    lastResult = long.Parse(tmpValues[2]);

                }

                
                listOfUsers.Add(new User(tmpValues[1], long.Parse(tmpValues[2])));

            }


            // we check if we have 15 users in List yet

            if (isSuchUsername)// update when we have yet such a username
            {
                if(totalPoints > lastResult)
                    listOfUsers[indexToUpdate].totalPoints = totalPoints; 
            }
            else if(listOfUsers.Count < 15){ // we check if we have 15 users in List yet
                listOfUsers.Add(new User(userName, totalPoints));
            }
            else
            {
                // firstly we sort our list of user to have the worst result at the end, it provides easy comparison

                listOfUsers.Sort((x, y) => {

                    if (x.totalPoints < y.totalPoints) { return 1; }
                    else if (x.totalPoints > y.totalPoints) { return -1; }

                    return 0;

                });

                // we check if our result is better than the worst because then they will change place in list otherwise nothing happens

                if (totalPoints > listOfUsers[14].totalPoints)
                {
                    listOfUsers[14] = new User(userName, totalPoints);  // replace
                }
            }

            
            

            // we sort the List to have up-to-date rank

            listOfUsers.Sort((x, y) => {

                if(x.totalPoints < y.totalPoints) { return 1; }
                else if(x.totalPoints > y.totalPoints) { return -1; }
                
                return 0;
                
                });

           


            using (StreamWriter writer = new StreamWriter(path)) //// true to append data to the file, but we change all the file, beacuae there can be change totalpoints of users
            {
                for(int i=0;i<listOfUsers.Count;++i)
                {
                    string toWrite = (i + 1) + ";" + listOfUsers[i];  // our text to csv 
                    writer.WriteLine(toWrite);
                }
            }
            
            
            

            Results newForm = new Results(this);  // we open new form with results
            newForm.Show();

            Form3.openForm.Close();


            //Console.WriteLine(path);

              
           

        }



        // timers handlers


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();



            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            Form3.st.Start();
            ChangeIconsToLabels(Color.Khaki);
            isLoaded = true;  // now we hide cards and can play the game
            timerPoints.Enabled = true;
            timerPoints.Start();

        }

        private void timerPoints_Tick(object sender, EventArgs e)
        {
            ourPointsTime -= 100;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedLevel = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedLevel = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.selectedLevel = 2;
        }
    }
}
