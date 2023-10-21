using INTRO_USERS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace COMPX223_23A_D2
{
    public partial class DayChart : Form
    {
        public DayChart()
        {
            InitializeComponent();


        }

        private void initChart()
        {
            try
            {
                SeriesChartType chartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), "Bar");

                Chart chart = (Chart)this.Controls["chartGraph"];


                chart.Series.Clear();
                chart.Titles.Clear();

                Series series;

                int type = comboBoxClass.SelectedIndex;
                String query;

                if(type == 0)
                {
                    chart.Titles.Add("Students by room");
                    series = new Series("Number of Students");
                    query = "SELECT DISTINCT(location), count(cEmail) from Class join Attends on Class.ClassID = Attends.ClassID GROUP BY location";
                }
                else if(type == 1)
                {
                    chart.Titles.Add("Students by day");
                    series = new Series("Number of Students");
                    query = "SELECT DATENAME(WEEKDAY, startTime), count(cEmail) from Class join Attends on Class.ClassID = Attends.ClassID GROUP BY DATENAME(WEEKDAY, startTime)";
                }
                else
                {
                    chart.Titles.Add("Students by Instructor");
                    series = new Series("Number of Students");
                    query = "SELECT (Instructor.fname + ' ' + Instructor.sname), count(cEmail) from Class join Attends on Class.ClassID = Attends.ClassID join Teaches on Class.ClassID = Teaches.ClassID join Instructor on Instructor.email = Teaches.iEmail GROUP BY (Instructor.fname + ' ' + Instructor.sname)";
                }

                chart.Titles.Add("Class by day");
                chart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                //chart.ChartAreas["ChartArea"].AxisX.Interval = 1;
                //chart.ChartAreas["ChartArea"].AxisX.MajorGrid.LineWidth = 0;
                //chart.ChartAreas["ChartArea"].AxisY.MajorGrid.LineWidth = 0;


                SQL.selectQuery(query);

                series.ChartType = chartType;

                //Check if anything is returned
                if (SQL.read.HasRows)
                {
                    while (SQL.read.Read())
                    {
                        //Get Values
                        String _room = SQL.read[0].ToString();
                        int num = int.Parse(SQL.read[1].ToString());

                        series.Points.AddXY(_room, num);
                    }
                    chart.Series.Add(series);
                }
                else
                {
                    MessageBox.Show("No data found");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            initChart();
        }

        /// <summary>
        /// Clear chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart chart = (Chart)this.Controls["chartGraph"];
            chart.Series.Clear();
            chart.Titles.Clear();
        }

        /// <summary>
        /// Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Open class data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void classDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            ClassData cdata = new ClassData();
            cdata.ShowDialog();
            Close();
        }

        /// <summary>
        /// Opens new class form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            NewClass newclass = new NewClass();
            newclass.ShowDialog();
            Close();
        }

        /// <summary>
        /// Opens the Certification form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void certificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Certification cert = new Certification();
            cert.ShowDialog();
            Close();
        }

        /// <summary>
        /// Opens summary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Summary summ = new Summary();
            summ.ShowDialog();
            Close();
        }
    }
}
