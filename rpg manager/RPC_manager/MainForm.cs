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
    public partial class MainForm : Form
    {

        static EditPasswordsForm editPassForm = null;
        static RemoveForm removeForm = null;
        static AddForm addForm = null;
        static DisplayForm displayForm = null;
        static EditForm editForm = null;

        static public  MainForm menu = null;


        public MainForm()
        {
            InitializeComponent();
            menu = this;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Form1.logForm != null)
            {
                Form1.logForm.Close();
            }
        }

        // logout
        private void button1_Click(object sender, EventArgs e)
        {
            dbActions.setLoggedUser(-1);
            Form1.logForm.Show();
            new Form1().Show();
            this.Close();
        }

        public void MainForm_Load(object sender, EventArgs e)   // we need to use it outside class
        {
            Console.WriteLine("Load");

            string roleOfLoggedUSer = dbActions.getRoleOfLoggedUser();

            if(roleOfLoggedUSer.Equals("admin"))
            {
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;

                panel6.Visible = true;

                panel1.Location  =  new Point(64,222);
                panel1.Size = new Size(457,154);



            }
            else if(roleOfLoggedUSer.Equals("user"))
            {
                panel6.Visible = false;
            }


            listView1.Items.Clear();

            List<string> top5Characters = dbActionsMainForm.getTop5Characters();

            for (int i=0;i<top5Characters.Count;++i)
            {
                listView1.Items.Add(top5Characters[i]);
               // Console.WriteLine(top5Characters[i]);
            }

            listView2.Items.Clear();

            List<string> newestArtefacts = dbActionsMainForm.getNewestArtefactsCharacters(Decimal.ToInt32(numericUpDown1.Value));

            for(int i=0;i<newestArtefacts.Count;++i)
            {
                listView2.Items.Add(newestArtefacts[i]);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            addForm = new AddForm();
            addForm.Show();
            this.Hide();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            List<string> newestArtefacts = dbActionsMainForm.getNewestArtefactsCharacters(Decimal.ToInt32(numericUpDown1.Value));

            listView2.Items.Clear();  // we firstly clear items which are displayed

            for (int i = 0; i < newestArtefacts.Count; ++i)
            {
                listView2.Items.Add(newestArtefacts[i]);
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {
            displayForm = new DisplayForm();
            displayForm.Show();
            this.Hide();
        }

        //edit
        private void label3_Click(object sender, EventArgs e)
        {
            editForm = new EditForm();
            editForm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            removeForm = new RemoveForm();
            removeForm.Show();

            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            editPassForm = new EditPasswordsForm();
            editPassForm.Show();
            this.Hide();
        }
    }
}
