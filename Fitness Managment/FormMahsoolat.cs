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
        //string BaseAddress = "https://www.hasma.ir/";
        string BaseAddress = "http://193.105.234.83/";

        List<Com.Product> AllBookProducts;
        List<Com.Product> AllDoreProducts;
        List<Com.Teacher> AllTeachers;
        public FormMahsoolat()
        {
            InitializeComponent();
            AllBookProducts = new List<Com.Product>();
            try
            {
                imageList1.ImageSize = new Size(256, 256);
                listView1.View = View.LargeIcon;
                listView1.Alignment = ListViewAlignment.Top;
                listView1.LargeImageList = this.imageList1;
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);

            }
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
            int ImgCount = Int32.Parse(SelectedProduct.Img);
            checkBox2.Checked = SelectedProduct.Available;
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
            for (int i = 0; i < ImgCount; i++)
            {
                try
                {

                    System.Net.WebRequest request = System.Net.WebRequest.Create(BaseAddress + "FitnessResource/Product/" + SelectedProduct.PID.ToString() + "/" + ImgCount + ".jpg");
                    System.Net.WebResponse response = request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    publicBitmapBookSelected = new Bitmap(responseStream);
                    imageList1.Images.Add(publicBitmapBookSelected);
                }
                catch
                {

                }
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
                        System.Net.WebRequest request = System.Net.WebRequest.Create(BaseAddress + "FitnessResource/Product/" + BookItem.PID.ToString() + "/0.jpg");
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

        public async Task<string> PostToServerBookProduct(Com.Product mPproduct)
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
        public async Task<string> PostToServerDoreProduct(Com.Product mPproduct)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {

                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(mPproduct));
                        form.Add(contentBody, "Object");


                        ImageConverter imgConverter = new ImageConverter();
                        var imgBytes = (System.Byte[])imgConverter.ConvertTo(pictureBox2.Image, Type.GetType("System.Byte[]"));
                        var fileContent = new ByteArrayContent(imgBytes);
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        form.Add(fileContent, "File", ".jpg");


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
                    Available = checkBox2.Checked,
                    CatID = 1,
                    Description = richTextBox1.Text,
                    Discount = Int32.Parse(textBox14.Text),
                    Img = "",
                    Name = textBoxName.Text,
                    Price = Int32.Parse(textBox13.Text),
                    specifications = JsonConvert.SerializeObject(spec)
                };


                var xx = await PostToServerBookProduct(newProduct);
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
                Available = checkBox2.Checked,
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

        private void button6_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxSarFasl);
            selectedItems = listBoxSarFasl.SelectedItems;

            if (listBoxSarFasl.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBoxSarFasl.Items.Remove(selectedItems[i]);
            }
            else
                MessageBox.Show("خطا");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBoxSarFasl.Items.Add(textBoxSarfasl.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBoxAsatid.Items.Add(comboBoxTeacher.SelectedItem);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxAsatid);
            selectedItems = listBoxAsatid.SelectedItems;

            if (listBoxAsatid.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBoxAsatid.Items.Remove(selectedItems[i]);
            }
            else
                MessageBox.Show("خطا");
        }



        private void tabPage2_Enter(object sender, EventArgs e)
        {
            GetDataANDRefreshGridViewDore();
        }

        async void GetDataANDRefreshGridViewDore()
        {
            try
            {
                var client2 = new HttpClient();
                string content2 = await client2.GetStringAsync(BaseAddress + "fitness/Profile/GetAllTeacher");

                var serializer = new JavaScriptSerializer();
                AllTeachers = serializer.Deserialize<List<Com.Teacher>>(content2);
                foreach (var itemTea in AllTeachers)
                {
                    comboBoxTeacher.Items.Add(itemTea.Name);
                }

                var client = new HttpClient();
                string content = await client.GetStringAsync(BaseAddress + "fitness/Shop/GetAllDore");

                AllDoreProducts = serializer.Deserialize<List<Com.Product>>(content);
                if (AllDoreProducts == null)
                {
                    return;
                }

                dataGridView4.Rows.Clear();

                foreach (var DoreItem in AllDoreProducts)
                {
                    System.Net.WebRequest request = System.Net.WebRequest.Create(BaseAddress + "/FitnessResource/Product/" + DoreItem.PID.ToString() + "/0.jpg");
                    System.Net.WebResponse response = request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    Bitmap bitmapBookItm = new Bitmap(responseStream);

                    dataGridView4.Rows.Add(DoreItem.PID, DoreItem.Name, DoreItem.Name);
                }

                label31.Visible = false;
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
                MessageBox.Show("خطا در اتصال");
            }
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
                    Filter = "Image Files (*.bmp;*.png;*.jpg;*.gif)|*.bmp;*.png;*.jpg;*.gif",
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

        private void button10_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            button11.Enabled = false;

            DataGridViewRow row = dataGridView4.Rows[dataGridView4.CurrentCell.RowIndex];
            string SelectedPIDsrt = row.Cells[0].Value.ToString();
            int SelectedPID = Int32.Parse(SelectedPIDsrt);
            PublicSelectedPID = SelectedPID;

            Com.Product SelectedProduct = AllDoreProducts.Where(W => W.PID == SelectedPID).SingleOrDefault();
            textBox12.Text = SelectedProduct.Name;
            textBox16.Text = SelectedProduct.Price.ToString();
            textBox15.Text = SelectedProduct.Discount.ToString();
            checkBox1.Checked = SelectedProduct.Available;
            richTextBox2.Text = SelectedProduct.Description;

            var serializer = new JavaScriptSerializer();
            Com.SpecDore specDore = serializer.Deserialize<Com.SpecDore>(SelectedProduct.specifications);

            foreach (var itemagenda in specDore.agenda)
                listBoxSarFasl.Items.Add(itemagenda);

            textBox17.Text = specDore.CourseDuration.ToString();
            dateTimePicker2.Value = specDore.EndDate;
            dateTimePicker1.Value = specDore.StartDate;
            comboBoxDoreSatate.SelectedItem = specDore.State;

            foreach (var itemTeacher in specDore.Teachers)
                listBoxAsatid.Items.Add(itemTeacher.Name);

            foreach (var itemQF in specDore.FAQ)
            {
                dataGridView3.Rows.Add(itemQF.Question, itemQF.Answer);
            }
            foreach (var itemEss in specDore.Sessions)
            {
                dataGridView2.Rows.Add(itemEss.Title, itemEss.Date, itemEss.Time);

            }


            System.Net.WebRequest request = System.Net.WebRequest.Create(BaseAddress + "/FitnessResource/Product/" + SelectedProduct.PID.ToString() + "/0.jpg");
            System.Net.WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            pictureBox2.Image = new Bitmap(responseStream);
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            try
            {
                List<Com.FQ> fqs = new List<Com.FQ>();

                foreach (DataGridViewRow itemFQ in dataGridView3.Rows)
                {
                    if (itemFQ.IsNewRow) continue;
                    try
                    {
                        Com.FQ fQ = new Com.FQ()
                        {
                            Answer = itemFQ.Cells[1].Value.ToString(),
                            Question = itemFQ.Cells[0].Value.ToString(),
                        };
                        fqs.Add(fQ);
                    }
                    catch
                    { }

                }

                List<Com.Sess> sesses = new List<Com.Sess>();
                foreach (DataGridViewRow itemFQ in dataGridView2.Rows)
                {
                    if (itemFQ.IsNewRow) continue;
                    try
                    {
                        Com.Sess sess = new Com.Sess()
                        {
                            Date = itemFQ.Cells[1].Value.ToString(),
                            Time = itemFQ.Cells[2].Value.ToString(),
                            Title = itemFQ.Cells[0].Value.ToString(),
                        };
                        sesses.Add(sess);
                    }
                    catch
                    { }
                }

                List<Com.Teacher> teacherssss = new List<Com.Teacher>();

                foreach (var itemTT in listBoxAsatid.Items)
                {
                    var te = AllTeachers.Where(W => W.Name == (string)itemTT).SingleOrDefault();
                    teacherssss.Add(te);
                }


                Com.SpecDore specDore = new Com.SpecDore()
                {
                    agenda = listBoxSarFasl.Items.Cast<String>().ToList(),
                    CourseDuration = Int32.Parse(textBox17.Text),
                    EndDate = dateTimePicker2.Value,
                    StartDate = dateTimePicker1.Value,
                    FAQ = fqs,
                    Sessions = sesses,
                    State = (string)comboBoxDoreSatate.SelectedItem,
                    Teachers = teacherssss
                };

                Com.Product newProduct = new Com.Product()
                {
                    Available = checkBox1.Checked,
                    CatID = 2,
                    Description = richTextBox2.Text,
                    Discount = Int32.Parse(textBox15.Text),
                    Img = "",
                    Name = textBox12.Text,
                    Price = Int32.Parse(textBox16.Text),
                    specifications = JsonConvert.SerializeObject(specDore)
                };

                var xx = await PostToServerDoreProduct(newProduct);
                Console.WriteLine(xx);
                if (xx == "Error")
                {
                    MessageBox.Show("آپلود نشد مشکل در سرور.");
                }
                else
                {
                    MessageBox.Show("آپلود شد.");
                    GetDataANDRefreshGridViewDore();
                }
            }
            catch (Exception eex)
            {
                MessageBox.Show("آپلود نشد مشکل در ورودی ها.");
            }
        }
    }
}