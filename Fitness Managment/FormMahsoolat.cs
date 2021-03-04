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
    public partial class FormMahsoolat : Form
    {
        //string BaseAddress = "http://localhost:56271/";
        string BaseAddress = "https://www.hasma.ir/";
        List<Com.Product> AllBookProducts;
        public FormMahsoolat()
        {
            InitializeComponent();
            AllBookProducts = new List<Com.Product>();

            imageList1.ImageSize = new Size(80, 80);
            listView1.View = View.LargeIcon;
            listView1.Alignment = ListViewAlignment.Top;
            listView1.LargeImageList = this.imageList1;
        }

        int PublicSelectedPID = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            buttonAddBook.Enabled = false;
            button3.Enabled = true;
            button2.Enabled = true;

            DataGridViewRow row = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
            string SelectedPIDsrt = row.Cells[0].Value.ToString();
            int SelectedPID = Int32.Parse(SelectedPIDsrt);
            PublicSelectedPID = SelectedPID;

            Com.Product SelectedProduct = AllBookProducts.Where(W => W.PID == SelectedPID).SingleOrDefault();

            richTextBox1.Text = SelectedProduct.Description;
            textBoxName.Text = SelectedProduct.Name;
            textBox13.Text = SelectedProduct.Price.ToString();
            textBox14.Text = SelectedProduct.Discount.ToString();

            var serializer = new JavaScriptSerializer();
            SpecObj spec = serializer.Deserialize<SpecObj>(SelectedProduct.specifications);
            textBox1.Text = spec.Nevisande;
            textBox3.Text = spec.GerdAavari;
            textBox2.Text = spec.Nasher;
            textBox5.Text = spec.Mozoo;
            textBox10.Text = spec.Vazn;
            textBox4.Text = spec.NobateChap;
            textBox6.Text = spec.SaleChap;
            textBox7.Text = spec.TedadeSafhe;
            textBox8.Text = spec.Ghat;
            textBox9.Text = spec.Shabok;
            textBox11.Text = spec.MonasebBaraye;
            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create("https://www.hasma.ir/FitnessResource/Product/" + SelectedProduct.PID.ToString() + "/0.jpg");
                System.Net.WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                publicBitmapBookSelected = new Bitmap(responseStream);
                pictureBox1.Image = publicBitmapBookSelected;
            }
            catch
            {

            }
        }
        Bitmap publicBitmapBookSelected = null;
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            GetDataANDRefreshGridView();
        }

        async void GetDataANDRefreshGridView()
        {
            try
            {
                var client = new HttpClient();
                string content = await client.GetStringAsync(BaseAddress + "fitness/Shop/GetAllBook");

                var serializer = new JavaScriptSerializer();
                AllBookProducts = serializer.Deserialize<List<Com.Product>>(content);
                if (AllBookProducts == null)
                {
                    return;
                }
                Console.WriteLine(content);

                int CountImg = 0;

                dataGridView1.Rows.Clear();

                foreach (var BookItem in AllBookProducts)
                {
                    try
                    {
                        System.Net.WebRequest request = System.Net.WebRequest.Create("https://www.hasma.ir/FitnessResource/Product/" + BookItem.PID.ToString() + "/0.jpg");
                        System.Net.WebResponse response = request.GetResponse();
                        Stream responseStream = response.GetResponseStream();
                        Bitmap bitmapBookItm = new Bitmap(responseStream);

                        dataGridView1.Rows.Add(BookItem.PID, BookItem.Name, BookItem.Description,
                            BookItem.specifications, BookItem.Price, BookItem.Discount, bitmapBookItm);


                        DataGridViewColumn column = dataGridView1.Columns[6];
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        ((DataGridViewImageColumn)dataGridView1.Columns[6]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        dataGridView1.Rows[CountImg].Height = 100;

                    }
                    catch
                    {
                        dataGridView1.Rows.Add(BookItem.PID, BookItem.Name, BookItem.Description,
                        BookItem.specifications, BookItem.Price, BookItem.Discount, null);
                    }
                    CountImg++;
                }

                label19.Visible = false;

            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
                MessageBox.Show("خطا در اتصال");
            }
        }

        public async Task<string> PostToServerProduct(Com.Product mPproduct)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {

                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(mPproduct));
                        form.Add(contentBody, "Object");

                        foreach (var ImgItem in imageList1.Images)
                        {
                            ImageConverter imgConverter = new ImageConverter();
                            var imgBytes = (System.Byte[])imgConverter.ConvertTo(ImgItem, Type.GetType("System.Byte[]"));
                            var fileContent = new ByteArrayContent(imgBytes);
                            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                            form.Add(fileContent, "File", ".jpg");
                        }

                        //var fs = File.OpenRead(filePath1);
                        //var streamContent = new StreamContent(fs);
                        //var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync());
                        //fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        //form.Add(fileContent, "File", Path.GetExtension(filePath1));

                        HttpResponseMessage response = await httpClient.PostAsync(BaseAddress + "fitness/Shop/PostProduct", form);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return "Ok";
                        }
                        else
                        {
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

        private async void buttonAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                SpecObj spec = new SpecObj()
                {
                    GerdAavari = textBox3.Text,
                    Ghat = textBox8.Text,
                    MonasebBaraye = textBox11.Text,
                    Mozoo = textBox5.Text,
                    Nasher = textBox2.Text,
                    Nevisande = textBox1.Text,
                    NobateChap = textBox4.Text,
                    SaleChap = textBox6.Text,
                    Shabok = textBox9.Text,
                    TedadeSafhe = textBox7.Text,
                    Vazn = textBox10.Text,
                };

                Com.Product newProduct = new Com.Product()
                {
                    Available = true,
                    CatID = 1,
                    Description = richTextBox1.Text,
                    Discount = Int32.Parse(textBox14.Text),
                    Img = "",
                    Name = textBoxName.Text,
                    Price = Int32.Parse(textBox13.Text),
                    specifications = JsonConvert.SerializeObject(spec)
                };


                var xx = await PostToServerProduct(newProduct);
                Console.WriteLine(xx);
                if (xx == "Error")
                {
                    MessageBox.Show("آپلود نشد مشکل در سرور.");
                }
                else
                {
                    MessageBox.Show("آپلود شد.");
                    GetDataANDRefreshGridView();

                    listView1.Items.Clear();
                    imageList1.Images.Clear();
                    textBox3.Text = "";
                    textBox8.Text = "";
                    textBox11.Text = "";
                    textBox5.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox4.Text = "";
                    textBox6.Text = "";
                    textBox11.Text = "";
                    textBox7.Text = "";
                    textBox10.Text = "";
                    richTextBox1.Text = "";
                    textBox14.Text = "";
                    textBoxName.Text = "";
                    textBox13.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("یه چیزی خرابه");
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    Filter = "Image Files (*.jpg;)|;*.jpg;",
                    FilterIndex = 2,
                    RestoreDirectory = true,
                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    buttonAddBook.Enabled = true;
                }

                imageList1.Images.Add(pictureBox1.Image);

                listView1.Items.Clear();

                for (int j = 0; j < imageList1.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    listView1.Items.Add(item);
                }

                Console.WriteLine(listView1.Items.Count);
                //                DataGridViewColumn column = dataGridView1.Columns[6];
                //              column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //            ((DataGridViewImageColumn)dataGridView1.Columns[6]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                //dataGridView1.Rows[0].Height = 100;
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }

        private void FormMahsoolat_FormClosed(object sender, FormClosedEventArgs e)
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

        public async Task<string> PostToServerUpdateProduct(Com.Product mPproduct)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {
                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(mPproduct));
                        form.Add(contentBody, "Object");

                        foreach (var ImgItem in imageList1.Images)
                        {
                            ImageConverter imgConverter = new ImageConverter();
                            var imgBytes = (System.Byte[])imgConverter.ConvertTo(ImgItem, Type.GetType("System.Byte[]"));
                            var fileContent = new ByteArrayContent(imgBytes);
                            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                            form.Add(fileContent, "File", ".jpg");
                        }

                        //ImageConverter imgConverter = new ImageConverter();
                        //var imgBytes = (System.Byte[])imgConverter.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));
                        //var fileContent = new ByteArrayContent(imgBytes);
                        //fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        //form.Add(fileContent, "File", ".jpg");

                        HttpResponseMessage response = await httpClient.PostAsync(BaseAddress + "fitness/Shop/PostUpdateProduct", form);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return "Ok";
                        }
                        else
                        {
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


        private async void button3_Click(object sender, EventArgs e)
        {
            SpecObj spec = new SpecObj()
            {
                GerdAavari = textBox3.Text,
                Ghat = textBox8.Text,
                MonasebBaraye = textBox11.Text,
                Mozoo = textBox5.Text,
                Nasher = textBox2.Text,
                Nevisande = textBox1.Text,
                NobateChap = textBox4.Text,
                SaleChap = textBox6.Text,
                Shabok = textBox11.Text,
                TedadeSafhe = textBox7.Text,
                Vazn = textBox10.Text,
            };

            Com.Product UpProduct = new Com.Product()
            {
                PID = PublicSelectedPID,
                CatID = 1,
                Available = true,
                Description = richTextBox1.Text,
                Discount = Int32.Parse(textBox14.Text),
                Img = "",
                Name = textBoxName.Text,
                Price = Int32.Parse(textBox13.Text),
                specifications = JsonConvert.SerializeObject(spec)
            };

            var xx = await PostToServerUpdateProduct(UpProduct);
            Console.WriteLine(xx);
            if (xx == "Error")
            {
                MessageBox.Show("آپدیت نشد مشکل در سرور.");
            }
            else
            {
                MessageBox.Show("آپدیت شد.");
                GetDataANDRefreshGridView();

                listView1.Items.Clear();
                imageList1.Images.Clear();
                textBox3.Text = "";
                textBox8.Text = "";
                textBox11.Text = "";
                textBox5.Text = "";
                textBox2.Text = "";
                textBox1.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox11.Text = "";
                textBox7.Text = "";
                textBox10.Text = "";
                richTextBox1.Text = "";
                textBox14.Text = "";
                textBoxName.Text = "";
                textBox13.Text = "";
            }
        }


        public class SpecObj
        {
            public string Nevisande { get; set; }
            public string GerdAavari { get; set; }
            public string Nasher { get; set; }
            public string Mozoo { get; set; }
            public string Vazn { get; set; }
            public string NobateChap { get; set; }
            public string SaleChap { get; set; }
            public string TedadeSafhe { get; set; }
            public string Ghat { get; set; }
            public string Shabok { get; set; }
            public string MonasebBaraye { get; set; }
        }
    }
}