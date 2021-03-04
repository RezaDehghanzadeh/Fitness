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
    public partial class FormWOD : Form
    {
        public FormWOD()
        {
            InitializeComponent();
        }

        private void FormWOD_Load(object sender, EventArgs e)
        {


        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (this.checkedListBoxUpperBody.CheckedItems.Count > 0)
        //    {
        //        this.listBoxSUBody.Items.Clear();
        //        foreach (string item in this.checkedListBoxUpperBody.CheckedItems)
        //        {
        //            this.listBoxSUBody.Items.Add(item.ToString());
        //        }
        //        for (int i = 0; i < this.checkedListBoxUpperBody.Items.Count; i++)
        //        {
        //            this.checkedListBoxUpperBody.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (this.checkedListBox2.CheckedItems.Count > 0)
        //    {
        //        this.listBoxSMBody.Items.Clear();
        //        foreach (string item in this.checkedListBox2.CheckedItems)
        //        {
        //            this.listBoxSMBody.Items.Add(item.ToString());
        //        }
        //        for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
        //        {
        //            this.checkedListBox2.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    if (this.checkedListBox4.CheckedItems.Count > 0)
        //    {
        //        this.listBoxSDBody.Items.Clear();
        //        foreach (string item in this.checkedListBox4.CheckedItems)
        //        {
        //            this.listBoxSDBody.Items.Add(item.ToString());
        //        }
        //        for (int i = 0; i < this.checkedListBox4.Items.Count; i++)
        //        {
        //            this.checkedListBox4.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if (this.checkedListBox1.CheckedItems.Count > 0)
        //    {
        //        this.listBoxMUBody.Items.Clear();
        //        foreach (string item in this.checkedListBox1.CheckedItems)
        //        {
        //            this.listBoxMUBody.Items.Add(item.ToString());
        //        }
        //        for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
        //        {
        //            this.checkedListBox1.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    if (this.checkedListBox3.CheckedItems.Count > 0)
        //    {
        //        this.listBoxMMBody.Items.Clear();
        //        foreach (string item in this.checkedListBox3.CheckedItems)
        //        {
        //            this.listBoxMMBody.Items.Add(item.ToString());
        //        }
        //        for (int i = 0; i < this.checkedListBox3.Items.Count; i++)
        //        {
        //            this.checkedListBox3.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    if (this.checkedListBox5.CheckedItems.Count > 0)
        //    {
        //        this.listBoxMDBody.Items.Clear();
        //        foreach (string item in this.checkedListBox5.CheckedItems)
        //        {
        //            this.listBoxMDBody.Items.Add(item.ToString());
        //        }
        //        for (int i = 0; i < this.checkedListBox5.Items.Count; i++)
        //        {
        //            this.checkedListBox5.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    if (this.checkedListBox6.CheckedItems.Count > 0)
        //    {
        //        this.listBoxModality.Items.Clear();
        //        foreach (string item in this.checkedListBox6.CheckedItems)
        //        {
        //            this.listBoxModality.Items.Add(item.ToString());
        //        }
        //        for (int i = 0; i < this.checkedListBox6.Items.Count; i++)
        //        {
        //            this.checkedListBox6.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //private void button8_Click(object sender, EventArgs e)
        //{
        //    if (this.checkedListBox7.CheckedItems.Count > 0)
        //    {
        //        this.listBoxEnvoritment.Items.Clear();
        //        foreach (string item in this.checkedListBox7.CheckedItems)
        //        {
        //            this.listBoxEnvoritment.Items.Add(item.ToString());
        //        }
        //        for (int i = 0; i < this.checkedListBox7.Items.Count; i++)
        //        {
        //            this.checkedListBox7.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    if (this.checkedListBox8.CheckedItems.Count > 0)
        //    {
        //        this.listBoxSkill.Items.Clear();
        //        foreach (string item in this.checkedListBox8.CheckedItems)
        //        {
        //            this.listBoxSkill.Items.Add(item.ToString());
        //        }
        //        for (int i = 0; i < this.checkedListBox8.Items.Count; i++)
        //        {
        //            this.checkedListBox8.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    if (this.checkedListBox9.CheckedItems.Count > 0)
        //    {
        //        this.listBoxEquipment.Items.Clear();
        //        foreach (string item in this.checkedListBox9.CheckedItems)
        //        {
        //            this.listBoxEquipment.Items.Add(item.ToString());
        //        }
        //        for (int i = 0; i < this.checkedListBox9.Items.Count; i++)
        //        {
        //            this.checkedListBox9.SetItemChecked(i, false);
        //        }
        //    }
        //}

        //private void buttonImgSelector_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        OpenFileDialog openFileDialog1 = new OpenFileDialog
        //        {
        //            InitialDirectory = @"C:\",
        //            Title = "Browse Text Files",

        //            CheckFileExists = true,
        //            CheckPathExists = true,

        //            DefaultExt = "jpg",
        //            Filter = "Image Files (*.bmp;*.png;*.jpg;*.gif)|*.bmp;*.png;*.jpg;*.gif",
        //            FilterIndex = 2,
        //            RestoreDirectory = true,

        //            ReadOnlyChecked = true,
        //            ShowReadOnly = true
        //        };

        //        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //        {
        //            pictureBoxImg.Image = new Bitmap(openFileDialog1.FileName);

        //            button4.Enabled = true;
        //        }
        //    }
        //    catch (Exception eee)
        //    {
        //        Console.WriteLine(eee.Message);
        //    }
        //}
    }
}
