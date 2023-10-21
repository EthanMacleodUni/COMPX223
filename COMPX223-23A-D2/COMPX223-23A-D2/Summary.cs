using INTRO_USERS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPX223_23A_D2
{
    public partial class Summary : Form
    {
        public Summary()
        {
            InitializeComponent();
            String courseQuery = "Select CourseID from Course";
            SQL.editComboBoxItems(comboBoxCourse, courseQuery);
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSumm_Click(object sender, EventArgs e)
        {
            //Get course
            String course = comboBoxCourse.SelectedItem.ToString();

            //Set up queries
            String numClassesQuery = "select count(*) from Class where CourseID = '" + course + "'";
            String numStudentsQuery = "select count(DISTINCT(cEmail)) From Attends join Class on Attends.ClassID = Class.ClassID Where Class.CourseID = '" + course + "'";
            String avgQuery = "SELECT CAST(ROUND(AVG(mark),2) as numeric(19,2)) from Attends join Class on Attends.ClassID = Class.ClassID WHERE CourseID = '" + course + "'";
            String dayQuery = "Select TOP 1 DATENAME(WEEKDAY, startTime) as 'day' From Class where CourseID = '" + course + "' GROUP BY DATENAME(WEEKDAY, startTime) ORDER BY 'day' DESC";

            try
            {
                //Execute query
                SQL.selectQuery(numClassesQuery);

                //Reset listbox
                listBoxSummary.Items.Clear();

                listBoxSummary.Items.Add("Showing summary results for '" + course + "' :");
                listBoxSummary.Items.Add("-----------------------------------------------");

                //Check if anything is returned
                if (SQL.read.HasRows)
                {
                    SQL.read.Read();
                    String numClasses = SQL.read[0].ToString();
                    listBoxSummary.Items.Add("There are " + numClasses + " classes run for course " + course + ".");

                }

                //Add empty line
                listBoxSummary.Items.Add("");

                //Execute query
                SQL.selectQuery(numStudentsQuery);

                //Check if anything is returned
                if (SQL.read.HasRows)
                {
                    SQL.read.Read();
                    String numStudents = SQL.read[0].ToString();
                    listBoxSummary.Items.Add("This course has been attended by " + numStudents + " students");

                }

                //Add empty line
                listBoxSummary.Items.Add("");

                //Execute query
                SQL.selectQuery(avgQuery);

                //Check if anything is returned
                if (SQL.read.HasRows)
                {
                    SQL.read.Read();
                    String avgMark = SQL.read[0].ToString();
                    listBoxSummary.Items.Add("The average mark for " + course + " to 2 decimal places is " + avgMark);

                }

                //Add empty line
                listBoxSummary.Items.Add("");

                //Execute query
                SQL.selectQuery(dayQuery);

                //Check if anything is returned
                if (SQL.read.HasRows)
                {
                    SQL.read.Read();
                    String dayOfWeek = SQL.read[0].ToString();
                    listBoxSummary.Items.Add("Most classes for " + course + " occured on " + dayOfWeek);

                }


            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Clears listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxSummary.Items.Clear();
        }

        /// <summary>
        /// Quits application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Opens class data
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
        /// Opens Certification Form
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
    }
}
