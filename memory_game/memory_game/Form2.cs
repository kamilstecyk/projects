using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memory_game
{
    public partial class Form2 : Form
    {

        Random random = new Random();

        // example List<string> boardIcons = new List<string>(new string[]{"A","B","C","D","E","F","G","H", "A", "B", "C", "D", "E", "F", "G", "H" });

        List<string> boardIcons = new List<string>();


        Label firstClicked = null;
        Label secondClicked = null;

        
        public Form2()
        {
            InitializeComponent();
            
            boardIcons = generateListWithRandomChars(8);  // we have this arg/2 pairs


            foreach (var ic in boardIcons)
            {
                Console.Write(ic);

            }

            AddIconsToLabels(Color.Black);

            timer2.Start();    // after some time we will hide cards

        }



        public List<string> generateListWithRandomChars(int howMany)
        {
            
            List<int> randomList = new List<int>();   
            List<string> icons = new List<string>(new string[howMany*2]);

          

            for(int i=0;i<howMany;++i)
            {
                int letterInt = (int)Math.Round(random.NextDouble() * 57 + 65, 0, MidpointRounding.AwayFromZero); // we generate letters
                char letter = (char)letterInt;

                // check if our letter is unique before adding to list of strings
                
                while(randomList.Contains(letterInt) || letterInt == 32)
                {
                    letterInt = (int)Math.Round(random.NextDouble() * 60 + 50, 0, MidpointRounding.AwayFromZero);
                    letter = (char)letterInt;
                }
                
                randomList.Add(letterInt);

                icons[i] = letter.ToString();
              
            }

           

            int j = 0;

            

            for(int i=howMany;i<howMany*2;i++,j++)
            {
                string tmp = icons[j];
                icons[i] = tmp;  // we adding appropriate pairs
               
            }

                 
            return icons;
        }


        private void AddIconsToLabels(Color color)  // we pass color
        {
            int i = 0;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                // iconLabel != null &&
                if (iconLabel != null && i !=boardIcons.Count)
                {
                    int randomNr = random.Next(boardIcons.Count);
                    iconLabel.Text = boardIcons[randomNr];
                    //iconLabel.Text = boardIcons[i];
                    //++i;
                    iconLabel.ForeColor = color;  // color of the icon initially
                    boardIcons.RemoveAt(randomNr);   // in order not to duplicate on board when displyaing
                    //Console.WriteLine(i);
                }
            }
          
            
        }

        private void ChangeIconsToLabels(Color color)  // we pass color
        {
           
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                
                if (iconLabel != null )
                {
              
                    iconLabel.ForeColor = color;  // color of the icon initially
                    
                }
            }


        }


        private void label1_Click(object sender, EventArgs e)
        {
            Label clickedLab = sender as Label;


            // we ignore click when the timmer is running

            if(timer1.Enabled == true)
            {
                return;
            }

            if(clickedLab != null)
            {
                // Black
                if(clickedLab.ForeColor == Color.Black) { return; }  // we clicked revealed card yet so we ignore

                if(firstClicked == null)
                {
                    firstClicked = clickedLab;
                    firstClicked.ForeColor = Color.Black; // Black

                    return;
                }

                secondClicked = clickedLab;
                secondClicked.ForeColor = Color.Black; // Black


                CheckWhetherItIsWon();


                // verifying whether icons match

                if(firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }


                // now we display two icons, after some time thanks to timer we will hide them

                timer1.Start();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckWhetherItIsWon()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label icLab1 = control as Label;

                if(icLab1 != null)
                {
                    
                    if(icLab1.ForeColor == icLab1.BackColor)
                    {
                        return;
                    }
                }
            }


            // player won this game

            MessageBox.Show("You won the game", "Congratulations");
            
            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            ChangeIconsToLabels(Color.Khaki);

        }
    }
}
