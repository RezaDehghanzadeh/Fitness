using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Fitness_Managment
{
    public partial class FormDailyVOD : Form
    {
       // string BaseAddress = "http://localhost:56271/";
        //string BaseAddress = "https://www.hasma.ir/";
        string BaseAddress = "http://193.105.234.83/";

        public FormDailyVOD()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex];
            string SelectedTIDsrt = row.Cells[0].Value.ToString();
            // int SelectedTID = Int32.Parse(SelectedTIDsrt);

            var client2 = new HttpClient();
            string content2 = await client2.GetStringAsync(BaseAddress + "fitness/VOD/DeleteDailyVOD?DVID=" + SelectedTIDsrt);

            dataGridView2.Rows.Clear();

            var client3 = new HttpClient();
            string content3 = await client2.GetStringAsync(BaseAddress + "fitness/VOD/GetAllDailyVOD");

            var serializer = new JavaScriptSerializer();
            var AlldailyVOD = serializer.Deserialize<List<Com.DailyVOD>>(content3);

            foreach (var itemDV in AlldailyVOD)
            {
                dataGridView2.Rows.Add(itemDV.VID, itemDV.VODName, itemDV.Date.ToString());
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
            string SelectedVIDsrt = row.Cells[0].Value.ToString();
            int SelectedVID = Int32.Parse(SelectedVIDsrt);
            string SelectedVIDNamesrt = row.Cells[1].Value.ToString();

            Com.DailyVOD dailyVOD = new Com.DailyVOD()
            {
                Date = dateTimePicker1.Value.Date,
                VID = SelectedVID,
                VODName = SelectedVIDNamesrt
            };

            var strRes = await PostToServerDailyVOD(dailyVOD);
        }
        public async Task<string> PostToServerDailyVOD(Com.DailyVOD mDailyVOD)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {
                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(mDailyVOD));
                        form.Add(contentBody, "Object");

                        HttpResponseMessage response = await httpClient.PostAsync(BaseAddress + "fitness/VOD/PostDailyVOD", form);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("انجام شد");
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
        private async void tabPage1_Enter(object sender, EventArgs e)
        {
            var client2 = new HttpClient();
            string content2 = await client2.GetStringAsync(BaseAddress + "fitness/VOD/GetPreMadeVOD");

            var serializer = new JavaScriptSerializer();
            var miniVODs = serializer.Deserialize<List<Com.MiniVOD>>(content2);
            dataGridView1.Rows.Clear();
            foreach (var itemV in miniVODs)
            {
                dataGridView1.Rows.Add(itemV.VID, itemV.Name, itemV.Info);
            }
        }

        private async void tabPage2_Enter(object sender, EventArgs e)
        {
            var client2 = new HttpClient();
            string content2 = await client2.GetStringAsync(BaseAddress + "fitness/VOD/GetAllDailyVOD");

            var serializer = new JavaScriptSerializer();
            var AlldailyVOD = serializer.Deserialize<List<Com.DailyVOD>>(content2);
            dataGridView2.Rows.Clear();

            foreach (var itemDV in AlldailyVOD)
            {
                dataGridView2.Rows.Add(itemDV.VID, itemDV.VODName, itemDV.Date.ToString());
            }
        }

        private void FormDailyVOD_FormClosed(object sender, FormClosedEventArgs e)
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
