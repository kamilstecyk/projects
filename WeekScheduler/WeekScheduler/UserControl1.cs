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

        public WeekScheduler()
        {
            InitializeComponent();


            schedulerTable = createSchedulerTable(1000,540,7,48);

           // schedulerTable = dynamicTableLayoutPanel;  // we hook reference to it 
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
            dynamicTableLayoutPanel.BackColor = Color.Green;
            dynamicTableLayoutPanel.AutoScroll = true;
            dynamicTableLayoutPanel.MaximumSize = new System.Drawing.Size(width, height);


            dynamicTableLayoutPanel.ColumnCount = columnCount;
            dynamicTableLayoutPanel.RowCount = rowCount;


            float sizeOfColCell = width / columnCount;
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

    }
}
