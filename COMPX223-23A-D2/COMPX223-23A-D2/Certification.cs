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

namespace COMPX223_23A_D2
{
    public partial class Certification : Form
    {
        public Certification()
        {
            InitializeComponent();
            String studentQuery = "SELECT email from Customer";
            String classQuery = "SELECT ClassID from Class";
            SQL.editComboBoxItems(comboBoxStudent, studentQuery);
            SQL.editComboBoxItems(comboBoxClass, classQuery);
        }

        /// <summary>
        /// Opens new form, closes the previous
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
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Opens new form, closes the previous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void classDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            ClassData form = new ClassData();
            form.ShowDialog();
            Close();
        }

        /// <summary>
        /// Opens new form, closes the previous
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

        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void buttonMark_Click(object sender, EventArgs e)
        {
            String studEmail = comboBoxStudent.SelectedItem.ToString();
            int classID = int.Parse(comboBoxClass.SelectedItem.ToString());

            try
            {
                int mark = int.Parse(textBoxMark.Text.Trim());

                if ( 0 > mark || mark > 100)
                {
                    MessageBox.Show("Error, mark out of range");
                    return;
                }

                // Insert new attends
                SQL.executeQuery("INSERT INTO Attends (cEmail, ClassID, mark) VALUES ('" + studEmail + "', " + classID + ", " + mark + ")");

                MessageBox.Show("Created Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            String fname = textBoxFName.Text.Trim();
            String lname = textBoxLName.Text.Trim();
            String email = textBoxEmail.Text.Trim();   
            String phone = textBoxPhone.Text.Trim();

            try
            {
                String query = "INSERT INTO Customer (email, fname, sname, phone) VALUES ('" + email + "', '" + fname + "', '" + lname + "', '" + phone + "')";
                SQL.executeQuery(query);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message);}
        }
    }
}
