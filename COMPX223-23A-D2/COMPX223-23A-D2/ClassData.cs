using INTRO_USERS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPX223_23A_D2
{
    public partial class ClassData : Form
    {
        public ClassData()
        {
            InitializeComponent();
        }

        private void buttonGetClasses_Click(object sender, EventArgs e)
        {   
            //get combo box value
            int comboValue = comboBoxFilter.SelectedIndex;

            //Initialise "Where" statement
            String qadd = "";

            //Change the value of the "Where" statement based on combobox value
            if(comboValue == 1){ qadd = " WHERE Class.endTime < GETDATE()"; }
            else if(comboValue == 2) { qadd = " WHERE Class.startTime < GETDATE() AND Class.endtime > GETDATE()"; }
            else if (comboValue == 3) { qadd = " WHERE Class.startTime > GETDATE()"; }
               
            // Create query
            String query = "Select Course.name, Instructor.fname, Instructor.sname, Class.location, Class.startTime, Class.endTime \r\nFROM Class join Teaches on Class.ClassID = Teaches.ClassID join Instructor on Teaches.iEmail = Instructor.email join Course on Course.CourseID = Class.CourseID";
            
            //Add where statement to query
            query += qadd;
               
            //Execute query
            SQL.selectQuery(query);

            //Reset listbox
            listBoxClassData.Items.Clear();
               
            //Check if anything is returned
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {   
                    //Get Values
                    String course = SQL.read[0].ToString();
                    String fname = SQL.read[1].ToString();
                    String lname = SQL.read[2].ToString();
                    String location = SQL.read[3].ToString();
                    String startTime = SQL.read[4].ToString();
                    String endTime = SQL.read[5].ToString();

                    //display each of the rows in a nice way
                    listBoxClassData.Items.Add("Course: " + course
                     + ", Instructor: " + fname + " " + lname
                     + ", Location: " + location
                     + ", Start Time: " + startTime
                     + ", EndTime: " + endTime
                     );
                }
            }
            else
            {
                MessageBox.Show("No data found");
            }
        }

        /// <summary>
        /// Delete listbox items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxClassData.Items.Clear();
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Opens the "Menu" Form 
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Opens the new class form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            NewClass form = new NewClass();
            form.ShowDialog();
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
