using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace memory_game
{
    public partial class Form3 : Form
    {
        // static variable to close this form in another form

        static public Form3 openForm; 


       public static Stopwatch st = new Stopwatch();

        public bool isSuspend = false;

       
        public Form1 hiddenForm;
        public Form3(Form1 form)
        {
            hiddenForm = form;
            InitializeComponent();
        }


        public Timer getTimer1()
        {
            return timer1;
        }

        public Timer getTimer2()
        {
            return timer2;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Form1.isFinished)
            {
                string message = "Jesteś pewny, że chcesz zamknąc aplikację? Wynik nie zostanie zapisany!";
                string title = "Zamknięcie okna";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);


                if (result == DialogResult.Yes)
                {

                    System.Environment.Exit(0);

                }// we close application
                else
                {
                    e.Cancel = true;  // we cancel closing form
                }
            }
            
        }

        private void zmieńCzasOdkryciaKartToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form inputBox = new InputMSGWindow(hiddenForm, Form1.timer1.Interval);  // static
            inputBox.ShowDialog();   // we cannot touch form under this
                
        }

        private void zatrzymajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // we can stop only if our cards are hidden ( anycard is revealed )

            // if the firstclicked have sth this means that either we have 1 one card revealed or 2 

            if(Form1.firstClicked == null && hiddenForm.isLoaded == true)
            {
                isSuspend = !isSuspend;

                 // remove event listeners from label , app imitates to be frozen, we have to also stop counting time from start
                
                    foreach (Control control in Form1.dynamicTable.Controls)
                    {
                        Label iconLabel = control as Label;


                        if (iconLabel != null && isSuspend == true)
                        {

                            iconLabel.Click -= hiddenForm.label1_Click;

                        }
                        else if(iconLabel != null && isSuspend == false)
                        {
                        iconLabel.Click += hiddenForm.label1_Click;
                    }
                    }
                

                    if(isSuspend == true)
                    {
                        //sw.Stop();  // we stop measurig time of game
                        timer3.Stop();
                        st.Stop();
                        hiddenForm.timerPoints.Stop();
                        MessageBoxButtons msgBtn = MessageBoxButtons.OK;
                        MessageBoxIcon msgIcon = MessageBoxIcon.Information;
                        string msg = "Zatrzymano grę, naciśnij przycisk jeszcze raz, aby wznowić!";
                        MessageBox.Show(msg, "Zatrzymanie", msgBtn, msgIcon);
                        zatrzymajToolStripMenuItem.Text = "Wznów";
                    }else
                    {
                        timer3.Start();
                        st.Start();
                        hiddenForm.timerPoints.Start();
                        //sw.Start();  // we reasume measuring time of the game
                        zatrzymajToolStripMenuItem.Text = "Zatrzymaj";
                    }
                    
                
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            timer3.Start();

            openForm = this;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
           if(hiddenForm.isLoaded == true)
            {
                TimeSpan elapsed = st.Elapsed; /// get elapsed time current
                label1.Text = string.Format("{0:00}:{1:00}", elapsed.Minutes,elapsed.Seconds);
            }
            
            if(Form1.isFinished == true)
            {
                timer3.Stop();
                
            }
        }
    }
}
