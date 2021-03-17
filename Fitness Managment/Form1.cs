using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Managment
{
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            try
            {
                FormMahsoolat FormMahsoolat = (FormMahsoolat)Application.OpenForms["FormMahsoolat"];
                if (FormMahsoolat != null)
                {
                    //frmLogin.Visible = true; Uncomment this line if form still not get visible.
                    FormMahsoolat.Show();
                }
                else
                {
                    FormMahsoolat = new FormMahsoolat();
                    FormMahsoolat.Show();
                }
                this.Hide();
            }
            catch (Exception ee)
            {

            }
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هنوز تکمیل نشده");
        }

        private void buttonPrivateVOD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هنوز تکمیل نشده");
        }

        private void buttonAmoozesh_Click(object sender, EventArgs e)
        {
            try
            {
                FormAmoozesh Formamoozesh = (FormAmoozesh)Application.OpenForms["FormAmoozesh"];
                if (Formamoozesh != null)
                {
                    //frmLogin.Visible = true; Uncomment this line if form still not get visible.
                    Formamoozesh.Show();
                }
                else
                {
                    Formamoozesh = new FormAmoozesh();
                    Formamoozesh.Show();
                }
                this.Hide();
            }
            catch(Exception ee)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormWOD Formawod = (FormWOD)Application.OpenForms["FormWOD"];
            if (Formawod != null)
            {
                //frmLogin.Visible = true; Uncomment this line if form still not get visible.
                Formawod.Show();
            }
            else
            {
                Formawod = new FormWOD();
                Formawod.Show();
            }
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOstad Formawod = (FormOstad)Application.OpenForms["FormOstad"];
            if (Formawod != null)
            {
                //frmLogin.Visible = true; Uncomment this line if form still not get visible.
                Formawod.Show();
            }
            else
            {
                Formawod = new FormOstad();
                Formawod.Show();
            }
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDailyVOD Formawod = (FormDailyVOD)Application.OpenForms["FormDailyVOD"];
            if (Formawod != null)
            {
                //frmLogin.Visible = true; Uncomment this line if form still not get visible.
                Formawod.Show();
            }
            else
            {
                Formawod = new FormDailyVOD();
                Formawod.Show();
            }
            this.Hide();
        }
    }
}
