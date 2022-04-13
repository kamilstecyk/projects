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
    public partial class Results : Form
    {

        public Form1 previousForm;
        public Results(Form1 form)
        {

            previousForm = form;
            InitializeComponent();

        }

        // we adding users result to the table
        private void Results_Load(object sender, EventArgs e)
        {
            //int j = 0;

            //Console.WriteLine(previousForm.listOfUsers.Count);

           

            Console.WriteLine("result");

            foreach(var tmp in previousForm.listOfUsers)
            {
                Console.WriteLine(tmp);
            }

            foreach (Control control in this.tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                int index = int.Parse(iconLabel.Text) - 1;

                //Console.WriteLine(i);

                if (iconLabel != null &&  index < previousForm.listOfUsers.Count)
                {
                    

                    string user = previousForm.listOfUsers[index].ToString();
                    string[] values = user.Split(';');

                    
                    
                    //Console.WriteLine(values[0] + " " +  values[1]);

                    iconLabel.Text = (index + 1) + ". " + values[0] + " : " + values[1];
                    
                    
                }
                else
                {
                    iconLabel.Text = "";
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();  // we close application
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Show();  // we back to initial page
        }
    }
}
