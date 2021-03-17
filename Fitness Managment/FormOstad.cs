using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Fitness_Managment
{
    public partial class FormOstad : Form
    {
       // string BaseAddress = "http://localhost:56271/";
         string BaseAddress = "https://www.hasma.ir/";

        List<Com.Teacher> AllTeachers;

        public FormOstad()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Browse Text Files",
                    CheckFileExists = true,
                    CheckPathExists = true,
                    DefaultExt = "jpg",
                    Filter = "Image Files (*.jpg;)|*.jpg;",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = new Bitmap(openFileDialog1.FileName);
                }

            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }

        private void FormOstad_Load(object sender, EventArgs e)
        {
            GetDataANDRefreshGridView();
        }

        private void FormOstad_Enter(object sender, EventArgs e)
        {

        }


        async void GetDataANDRefreshGridView()
        {
            try
            {
                var client2 = new HttpClient();
                string content2 = await client2.GetStringAsync(BaseAddress + "fitness/Profile/GetAllTeacher");

                var serializer = new JavaScriptSerializer();
                AllTeachers = serializer.Deserialize<List<Com.Teacher>>(content2);
                int ImgCou = 0;

                dataGridView4.Rows.Clear();
                foreach (var itemTea in AllTeachers)
                {
                    Bitmap bitmapBookItm = null;
                    try
                    {
                        System.Net.WebRequest request = System.Net.WebRequest.Create("https://www.hasma.ir/FitnessResource/Teacher/" + itemTea.TID.ToString() + "/Img.jpg");
                        System.Net.WebResponse response = request.GetResponse();
                        Stream responseStream = response.GetResponseStream();
                        bitmapBookItm = new Bitmap(responseStream);
                    }
                    catch { }
                    dataGridView4.Rows.Add(itemTea.TID, itemTea.Name, bitmapBookItm, itemTea.ScienceRanking);

                    DataGridViewColumn column = dataGridView4.Columns[2];
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    ((DataGridViewImageColumn)dataGridView4.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    dataGridView4.Rows[ImgCou].Height = 100;
                    ImgCou++;
                }


                label19.Visible = false;
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
                MessageBox.Show("خطا در اتصال");
            }
        }

        int PublicSelectedTID = 0;
        private void button10_Click(object sender, EventArgs e)
        {
            button11.Enabled = false;
            button9.Enabled = true;

            DataGridViewRow row = dataGridView4.Rows[dataGridView4.CurrentCell.RowIndex];
            string SelectedTIDsrt = row.Cells[0].Value.ToString();
            int SelectedTID = Int32.Parse(SelectedTIDsrt);
            PublicSelectedTID = SelectedTID;

            Com.Teacher SelectedTeach = AllTeachers.Where(W => W.TID == SelectedTID).SingleOrDefault();

            textBoxName.Text = SelectedTeach.Name.ToString();
            textBoxOnvan.Text = SelectedTeach.ScienceRanking.ToString();
            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create("https://www.hasma.ir/FitnessResource/Teacher/" + SelectedTID.ToString() + "/Img.jpg");
                System.Net.WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                var publicBitmapBookSelected = new Bitmap(responseStream);
                pictureBox2.Image = publicBitmapBookSelected;
            }
            catch { }
        }

        private async void button11_Click(object sender, EventArgs e)
        {

            Com.Teacher mTeacher = new Com.Teacher()
            {
                Name = textBoxName.Text,
                ScienceRanking = textBoxOnvan.Text,
            };
            var strRes = await PostToServerOstad(mTeacher);
            if (strRes == "Ok")
            {

                GetDataANDRefreshGridView();
                button11.Enabled = true;
                button9.Enabled = false;
                textBoxName.Text = "";
                textBoxOnvan.Text = "";
                pictureBox2.Image = null;
            }
        }
        public async Task<string> PostToServerOstad(Com.Teacher mTeacher)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {

                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(mTeacher));
                        form.Add(contentBody, "Object");

                        ImageConverter imgConverter = new ImageConverter();
                        var imgBytes = (System.Byte[])imgConverter.ConvertTo(pictureBox2.Image, Type.GetType("System.Byte[]"));
                        var fileContent = new ByteArrayContent(imgBytes);
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        form.Add(fileContent, "File", ".jpg");

                        HttpResponseMessage response = await httpClient.PostAsync(BaseAddress + "fitness/Profile/PostUpdateTeacher", form);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return "Ok";
                        }
                        else
                        {
                            MessageBox.Show("مشکل در ارسال پست");

                            return "Error";
                        }
                    }
                }
            }
            catch (Exception eeee)
            {
                Console.WriteLine(eeee.Message);
                MessageBox.Show("مشکل در ارسال پست");
                MessageBox.Show(eeee.Message);
                return "Error";

            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            Com.Teacher mTeacher = new Com.Teacher()
            {
                TID = PublicSelectedTID,
                Name = textBoxName.Text,
                ScienceRanking = textBoxOnvan.Text,
            };
            var strRes = await PostToServerOstad(mTeacher);
            if (strRes == "Ok")
            {
                GetDataANDRefreshGridView();
                button11.Enabled = true;
                button9.Enabled = false;
                textBoxName.Text = "";
                textBoxOnvan.Text = "";
                pictureBox2.Image = null;
            }


        }

        private void FormOstad_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Management Management = (Management)Application.OpenForms["Management"];
                if (Management != null)
                {
                    //frmLogin.Visible = true; Uncomment this line if form still not get visible.
                    Management.Show();
                }
                else
                {
                    Management = new Management();
                    Management.Show();
                }
            }
            catch
            {

            }
        }
    }
}
