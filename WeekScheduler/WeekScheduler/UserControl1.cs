using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeekScheduler
{
    public partial class WeekScheduler: UserControl
    {

        static TableLayoutPanel schedulerTable = null;
        private int rowsCount = 48;
        private int colsCount = 7;
        Color defualtColor = Color.Green;
        Color markedCellColor = Color.Red;

        // categories

        private Color defaultColorOfTask = Color.Wheat;

        List<string> categoriesOfTasks = new List<string>() { "Household chore", "Job", "Hobby", "Very important" };
        List<Color> colorsOfTasks = new List<Color>() { Color.BurlyWood, Color.Brown, Color.Yellow, Color.Tomato };

        Label[,] tableOfPanels = null;
        bool[,] tableOfClicked = null;  // contain true on the indices of panels that were clicked

        Label lastClicked = null;
       // List<Panel> clickedPanels = new List<Panel>();

        Dictionary<IndicesOfPanel,Label> clickedPanels = new Dictionary<IndicesOfPanel,Label >();   // arbitrary for handling clicked panels in the table

        bool wasAddedTask = false;

        private class IndicesOfPanel
        {
            public int rowIndex;
            public int colIndex;

            public IndicesOfPanel(int rI,int cI)
            {
                rowIndex = rI;
                colIndex = cI;
            }
        }



        public WeekScheduler()
        {
            InitializeComponent();


            schedulerTable = createSchedulerTable(1000,530,7,48);

            // we fill combobox

            foreach(var category in categoriesOfTasks)
            {
                comboBox1.Items.Add(category);
            }

        }




        private TableLayoutPanel createSchedulerTable(int width,int height,int cols,int rows)
        {
            int columnCount = cols + 1;  // one for description of time
            int rowCount = rows + 1;  // one row for days of week


            // size of tableLayout

           // int width = 992;
           // int height = 521;

            // we create our dynamic tableLayout for tasks

            TableLayoutPanel dynamicTableLayoutPanel = new TableLayoutPanel();

            dynamicTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            dynamicTableLayoutPanel.Name = "dynamicTableLayout";
            dynamicTableLayoutPanel.Size = new System.Drawing.Size(width, height);
            dynamicTableLayoutPanel.TabIndex = 0;
            dynamicTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            dynamicTableLayoutPanel.Dock = DockStyle.Fill;
            dynamicTableLayoutPanel.BackColor = defualtColor;
            dynamicTableLayoutPanel.AutoScroll = true;
            dynamicTableLayoutPanel.MaximumSize = new System.Drawing.Size(width, height);


            dynamicTableLayoutPanel.ColumnCount = columnCount;
            dynamicTableLayoutPanel.RowCount = rowCount;


            float sizeOfColCell = width / columnCount - 6;
            float sizeOfRowCell = height / (rowCount / 2);


            for (int i = 0; i < columnCount; ++i)
            {
                dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, sizeOfColCell));
            }

            for (int i = 0; i < rowCount; ++i)
            {
                dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, sizeOfRowCell));
            }

            // we add labels with days


            string[] days = new string[] { "Today", "Tomorrow", "After Tomorrow", "4 day", "5 day", "6 day", "7 day" };


            for (int i = 0; i < 7; ++i)
            {
                Label dayLabel = new Label();
                dayLabel.Size = new Size((int)sizeOfColCell, (int)sizeOfRowCell);
                dayLabel.TextAlign = ContentAlignment.MiddleCenter;
                dayLabel.Text = days[i];
                dayLabel.Font = new Font(dayLabel.Font, FontStyle.Bold);

                dynamicTableLayoutPanel.Controls.Add(dayLabel, i + 1, 0);

            }

            // we add labels with time , we have 30 minutes slotes of time 

            int hour = 0;
            int minute = 0;

            for (int i = 0; i < 48; ++i)
            {

                Label timeLabel = new Label();
                timeLabel.Size = new Size((int)sizeOfColCell, (int)sizeOfRowCell);
                timeLabel.TextAlign = ContentAlignment.MiddleCenter;


                if (i % 2 == 0)
                {

                    timeLabel.Text = buildTime(hour, minute);
                    minute += 30;
                }

                if (i % 2 != 0)
                {
                    timeLabel.Text = buildTime(hour, minute);
                    minute = 0;
                    ++hour;
                }


                dynamicTableLayoutPanel.Controls.Add(timeLabel, 0, i + 1);


            }



            this.Controls.Add(dynamicTableLayoutPanel);


            // we add panels to table and assign events handlers

            tableOfPanels = new Label[rowCount - 1,columnCount -1];


            // we create table of clicked/ not clicked panels

            tableOfClicked = new bool[rowCount - 1, columnCount - 1];


            for (int i=1;i<8;++i)
            {
                for(int j=1;j<49;j++)
                {
                    // panel on the particular cell in table

                    Label panelToAdd = new Label() { Size = new Size((int)sizeOfColCell, (int)sizeOfRowCell),Name = (j-1) + ":" + (i-1),Cursor = Cursors.Hand };
                    panelToAdd.Click += new EventHandler(panelClickHandler);
                    panelToAdd.TextAlign = ContentAlignment.MiddleCenter;
                    panelToAdd.FlatStyle = FlatStyle.Popup;

                    tableOfPanels[j-1,i - 1] = panelToAdd;

                    // tableOfClicked[j - 1, i - 1] = false;   // we default set not clicked panels when app starts
                    cleanAllCellsInTableOfBools();

                    dynamicTableLayoutPanel.Controls.Add(panelToAdd, i, j);
                   
                }
            }

        

            return dynamicTableLayoutPanel;
            
        }




        private static string buildTime(int hour,int minutes)
        {

            if(minutes == 0)
            {
                return hour + ":00";
            }

            return hour + ":" + minutes;
        }



        private string getTimeOfStartTask(int rowIndex, int cols)
        {

            string resultTime = null;  // hour of start and after ';' days from today

            int hour = 0;
            int minute = 0;

            for (int i = 0; i < 48; ++i)
            {

                if (i % 2 == 0)
                {

                    resultTime = buildTime(hour, minute) + ";" + cols;
                    minute += 30;
                }

                if (i % 2 != 0)
                {
                    resultTime = buildTime(hour, minute) + ";" + cols;
                    minute = 0;
                    ++hour;
                }


                if (i == rowIndex)
                {
                    break;
                }

            }

            return resultTime;

        }


        private void cleanAllCellsInTableOfBools()
        {
            for (int i = 0; i < rowsCount; ++i)
            {
                for (int j = 0; j < colsCount; ++j)
                {

                    if (tableOfClicked[i, j] == true)
                    {
                        tableOfPanels[i, j].BackColor = defualtColor; // we restore default setttings
                    }

                    tableOfClicked[i, j] = false;
                }
            }
        }


        private void clean2DtableOfBools()  // clean only clicked
        {
            
            foreach(var entry in clickedPanels)
            {
                entry.Value.BackColor = defualtColor;
                tableOfClicked[entry.Key.rowIndex, entry.Key.colIndex] = false;
            }

        }


        void panelClickHandler(object sender, EventArgs e)
        {

            Label triggeredPanel = (Label)sender;


            string[] rowAndColumnOfPanel = triggeredPanel.Name.ToString().Split(':');

            int rowIndex = int.Parse(rowAndColumnOfPanel[0]);
            int colIndex = int.Parse(rowAndColumnOfPanel[1]);

            Console.WriteLine("Clicked: " + rowIndex + " ; " + colIndex);

            if (lastClicked != null)  // we should merge in one day up or down particular cell
            {
                Console.WriteLine(rowIndex - 1 + " ; " + colIndex);


                if (rowIndex == (rowsCount - 1))  // last cell
                {


                    if (lastClicked != tableOfPanels[rowIndex - 1, colIndex])
                    {
                        clean2DtableOfBools();
                        showMessageBox("Invalid operation!");
                        lastClicked = null;
                        clickedPanels.Clear();
                        return;
                    }
                   
                        
                    lastClicked = triggeredPanel;
                    clickedPanels.Add( new IndicesOfPanel(rowIndex,colIndex), lastClicked);
                    
                }



                else if (rowIndex == 0)  // first cell
                {

                    if (lastClicked != tableOfPanels[rowIndex + 1, colIndex])
                    {
                        clean2DtableOfBools();
                        showMessageBox("Invalid operation!");
                        lastClicked = null;
                        clickedPanels.Clear();
                        return;
                    }

                    lastClicked = triggeredPanel;
                    clickedPanels.Add(new IndicesOfPanel(rowIndex, colIndex),lastClicked);


                }

                else if ((lastClicked != tableOfPanels[rowIndex - 1, colIndex] && lastClicked != tableOfPanels[rowIndex + 1, colIndex]) || (tableOfClicked[rowIndex - 1, colIndex] == true && tableOfClicked[rowIndex + 1, colIndex] == true))
                {
                    clean2DtableOfBools();
                    showMessageBox("Invalid operation!");
                    lastClicked = null;
                    clickedPanels.Clear();
                    return;
                }





                lastClicked = triggeredPanel;
                clickedPanels.Add(new IndicesOfPanel(rowIndex, colIndex), lastClicked);

            }



            tableOfClicked[rowIndex, colIndex] = true;
            triggeredPanel.BackColor = markedCellColor;
            lastClicked = triggeredPanel;
            clickedPanels.Add(new IndicesOfPanel(rowIndex, colIndex), lastClicked);


        }

        private static void showMessageBox(string message)
        {
            string caption = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(clickedPanels.Count > 0 )
            {
                displayAddTaskPanel();
            }
            else
            {
                showMessageBox("You must choose cell times to add task!");
            }
        }

        private void displayAddTaskPanel()
        {
            addTaskPanel.Visible = true;
            addTaskPanel.Enabled = true;
            schedulerTable.Enabled = false;
            button1.Enabled = false;


            // we reset combobox
            comboBox1.SelectedIndex = -1;

            // we reset textbox
            textBox1.Text = "";

        }

        private void hideAddTaskPanel()
        {
            addTaskPanel.Visible = false;
            addTaskPanel.Enabled = false;
            schedulerTable.Enabled = true;
            button1.Enabled = true;

            // we clear clicked earlier panels

            if (!wasAddedTask)
            {
                clean2DtableOfBools();
            }
          

            lastClicked = null;
            clickedPanels.Clear();
            wasAddedTask = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            hideAddTaskPanel();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                SelectedTaskColor.BackColor = colorsOfTasks[comboBox1.SelectedIndex];
            }
            else
            {
                SelectedTaskColor.BackColor = Color.Transparent;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            
            // we set choosed color for choosed panels and give them task description


            if(comboBox1.SelectedIndex != -1 && textBox1.Text.Length != 0)
            {
                wasAddedTask = true;

                foreach(var choosedPanel in clickedPanels.Values)
                {
                    choosedPanel.BackColor = SelectedTaskColor.BackColor;
                    choosedPanel.Enabled = false;
                    choosedPanel.Text = textBox1.Text;

                    int indexRowStartTask = clickedPanels.ElementAt(0).Key.rowIndex;
                    int indexColStartTask = clickedPanels.ElementAt(0).Key.colIndex;

                    Console.WriteLine(getTimeOfStartTask(indexRowStartTask, indexColStartTask) + " ; start task time");
                }


                hideAddTaskPanel();

            }
            else
            {
                showMessageBox("You must change category of task and add description of it!");
            }

        }


       

    }
}
