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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace COMPX223_23A_D2
{
    public partial class NewClass : Form
    {
        public NewClass()
        {
            InitializeComponent();

            String courseQuery = "SELECT CourseID FROM Course";
            SQL.editComboBoxItems(comboBoxCourse, courseQuery);
        }

        /// <summary>
        /// Insert new class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertClassButton_Click(object sender, EventArgs e)
        {
            //Get Input
            String location = textBoxLocation.Text.Trim();
            String start = textBoxStart.Text.Trim();
            String end = textBoxEnd.Text.Trim();
            String id = comboBoxCourse.SelectedItem.ToString();
            String instructor = comboBoxInstructor.SelectedItem.ToString();

            //Check if input is valid
            if (!String.IsNullOrEmpty(location) && !String.IsNullOrEmpty(start) && (id != "") && (instructor != ""))
            {
                try
                {
                    //Execute query
                    SQL.executeQuery("INSERT INTO Class (location, startTime, endTime, CourseID) VALUES ('" + location + "', '" + start + "', '" + end + "', '" + id + "')");

                    //Get class ID
                    SQL.selectQuery("Select count(*) From Class");
                    SQL.read.Read();
                    int classid = int.Parse(SQL.read[0].ToString());
                       
                    // Insert new teaches
                    SQL.executeQuery("INSERT INTO Teaches (iEmail, ClassID) VALUES ('" + instructor + "', "  + classid +")");

                    MessageBox.Show("Created Successfully");

                }
                catch(Exception ex)
                {
                    //Show error message 
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill out all fields");
            }

        }

        /// <summary>
        /// Returns to menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            Close();
        }

        /// <summary>
        /// Closes application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Go to new class data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void classDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            ClassData classd = new ClassData();
            classd.ShowDialog();
            Close();
        }

        /// <summary>
        /// Clear text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxLocation.Clear();
            textBoxStart.Clear();
            textBoxEnd.Clear();
            comboBoxCourse.ResetText();
            comboBoxInstructor.ResetText();
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

        /// <summary>
        /// Changes instructor based on course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //Get course selected
            String course = comboBoxCourse.SelectedItem.ToString();

            //Created Queary from course
            String query = "SELECT iEmail FROM Qualified Where CourseID = '" + course + "'";

            //Change combo box
            SQL.editComboBoxItems(comboBoxInstructor, query);
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
