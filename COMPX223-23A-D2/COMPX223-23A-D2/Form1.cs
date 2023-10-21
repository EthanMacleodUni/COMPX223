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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        /// Opens the Class Data form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            Hide();
            ClassData cdata = new ClassData();
            cdata.ShowDialog();
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
    }
}
