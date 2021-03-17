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
    public partial class FormAmoozesh : Form
    {
        //string BaseAddress = "http://localhost:56271/";
        string BaseAddress = "https://www.hasma.ir/";
        //string BaseAddress = "http://193.105.234.83:80/";

        public FormAmoozesh()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            string[] installsVazneBardari = new string[] { "هالتر", "دمبل", "کتل بل", "مدیسن بال" };
            string[] installsZhimnastik = new string[] { "میله و دارحلقه", "با وزن بدن", "با تجهیزات" };
            string[] installsKardio = new string[] { "کاردیو" };
            string[] installsParvareshAndam = new string[] { "سرشانه", "سینه", "پشت", "بازو و ساعد", "ران و ساق" };
            string[] installsTRX = new string[] { "بالاتنه", "پایین تنه" };
            string[] installsKesheshi = new string[] { "بالاتنه", "پایین تنه" };

            comboBox2.Items.Clear();
            comboBox2.Text = "Select";
            comboBox3.Text = "Select";

            switch (comboBox1.SelectedItem)
            {
                case "وزنه برداری":
                    comboBox2.Items.AddRange(installsVazneBardari);
                    break;
                case "ژیمناستیک":
                    comboBox2.Items.AddRange(installsZhimnastik);
                    break;
                case "کاردیو":
                    comboBox2.Items.AddRange(installsKardio);
                    break;
                case "پرورش اندام":
                    comboBox2.Items.AddRange(installsParvareshAndam);
                    break;
                case "کششی":
                    comboBox2.Items.AddRange(installsKesheshi);
                    break;
                case "تی آر ایکس":
                    comboBox2.Items.AddRange(installsTRX);
                    break;
                default:
                    // code block
                    break;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string[] Halter = new string[] {
               "Shoulder press",
               "Push press",
               "Push Jerk",
               "SplitJerk",
               "Snatch Balance",
               "Sots Press",
               "Thruster",
               "Back Squat",
               "Front Squat",
               "Overhead squat",
               "Zercher Squat",
               "Bulgarian Split Squat",
               "Deadlift",
               "Sumo Deadlift",
               "Snatch Deadlift",
               "Sumo Deadlift High Pull",
               "Back Rack Lunge",
               "Front Rack Lunge",
               "Overhead Lunge",
               "Zercher Lunge",
               "SideLunge",
               "Back Rack Walking Lunge",
               "Front Rack Walking Lunge",
               "Overhead Walking Lunge",
               "Zercher Walking Lunge",
               "Squat Snatch",
               "Power Snatch",
               "Hang Snatch",
               "Power Hang Snatch",
               "High Hang Snatch",
               "Power High Hang Snatch",
               "Tall Snatch",
               "Power Tall Snatch",
               "Muscle Snatch",
               "Hang Muscle Snatch",
               "French Snatch",
               "Squat Clean",
               "Power Clean",
               "Hang Clean",
               "Power Hang Clean",
               "High Hang Clean",
               "Power High Hang Clean",
               "Tall Clean",
               "Power Tall Clean",
               "Muscle Clean",
               "Clean & Push Jerk",
               "Power Clean & Push Jerk ",
               "Clean & Split Jerk",
               "Power Clean & Split Jerk ",
               "Hang Clean & Push Jerk",
               "Hang Power Clean & Push Jerk ",
               "Hang Clean & Split Jerk",
               "Hang Power Clean & Split Jerk ",
               "Muscle Clean & Push Jerk",
               "Muscle Clean & Split Jerk",
               "Cluster",
               "Floor Press",
               "Good Morning",
               "Burgener Warm Up"
            };

            string[] Dumbbell = new string[] {
    "DB Shoulder press",
    "DB Push press",
    "DB Push Jerk",
    "DB SplitJerk",
    "DB Snatch Balance",
    "DB Thruster",
    "DB Squat",
    "DB Front Squat",
    "DB Overhead squat",
    "Doual DB Overhead squat",
    "DB Goblet Squat",
    "DB Deadlift",
    "DB Sumo Deadlift",
    "DB Sumo Deadlift High Pull",
    "DB Lunge",
    "DB Front Rack Lunge",
    "DB Overhead Lunge",
    "DB Walking Lunge",
    "DB Front Rack Walking Lunge",
    "DB Overhead Walking Lunge",
    "DB Squat Snatch",
    "DB Power Snatch",
    "DB Hang Snatch",
    "DB Power Hang Snatch",
    "DB High Hang Snatch",
    "DB Power High Hang Snatch",
    "DB Muscle Snatch",
    "DB Hang Muscle Snatch",
    "Alternating DB Snatch",
    "AlternatingDBHangMuscleSnatch",
    "DB Squat Clean",
    "DB Power Clean",
    "DB Hang Clean",
    "DB Power Hang Clean",
    "DB High Hang Clean",
    "DB Power High Hang Clean",
    "DB Muscle Clean",
    "DB Hang Muscle Clean",
    "DB Clean & Push Jerk",
    "DB Power Clean & Push Jerk ",
    "DB Power Clean & Split Jerk ",
    "DB Hang Clean & Push Jerk",
    "DB Hang Power Clean & Push Jerk ",
    "DB Hang Clean & Split Jerk",
    "DB Hang Power Clean & Split Jerk ",
    "DB High Hang Clean & Push Jerk",
    "DB High Hang Power Clean & Push Jerk ",
    "DB High Hang Clean & Split Jerk",
    "DB High Hang Power Clean & Split Jerk ",
    "DB Muscle Clean & Push Jerk",
    "DB Muscle Clean & Split Jerk",
    "DB Hang Muscle Clean & Push Jerk",
    "DB Hang Muscle Clean & Split Jerk",
    "DB Cluster",
    "DB Hang Cluster",
    "DB Swing (USA)",
    "DB Swing (RUS)",
    "DB Turkish Get Up",
    "DB Farmer Carry",
    "DB Floor Press",
    "DB Burpee",
    "DB Farmer Carry",
            };
            string[] Kettlebell = new string[] {
    "KB Squat",
    "KB Front Squat",
    "KB Overhead squat",
    "KB Goblet Squat",
    "KB Deadlift",
    "KB Sumo Deadlift",
    "KB Sumo Deadlift High Pull",
    "KB Single Leg Deadlift",
    "Double KB Deadlift",
    "KB Lunge",
    "KB Front Rack Lunge",
    "KB Overhead Lunge",
    "KB Walking Lunge",
    "KB Front Rack Walking Lunge",
    "KB Overhead Walking Lunge",
    "KB Snatch",
    "KB Clean",
    "KB Swing (USA)",
    "KB Swing (RUS)",
    "One Arm KB Swing (USA)",
    "One Arm KB Swing (RUS)",
    "KB Turkish Get Up",
    "KB Farmer Carry",
            };


            string[] Medicineball = new string[] {
        "MB Squat",
        "MB Deadlift",
        "MB Snatch",
        "MB Clean",
        "Wall Ball Shot",
        "Ball Slam"
        };
            string[] BarAndring = new string[] {
    "Ring swing",
    "Kip swing",
    "Ring pull up",
    "Chin to bar",
    "Chest to bar",
    "Close grip chin pull up",
    "Bar mucle up",
    "Ring muscle up",
    "Inverted row",
    "Ring row",
    "Toes to bar",
    "Rise the knee",
    "L-sit/hold",
    "Ring dip",
    "Wind shield wipers bar",
    "Tuck front",
    "Tucked back lever",
            };

            string[] BodyWeight = new string[] {
  "Air squat",
  "Pistol squat",
  "Squat jump",
  "Burpee",
  "Bar facing burpee",
  "Burpee box jump over",
  "Push up",
  "Hand release push up",
  "Diamond push up",
  "Superman push up",
  "Wall walk",
  "Handstand walk",
  "Hand stand push up",
  "Dip",
  "Bear crowl",
  "Hollow rock",
  "Superman",
  "Mountain climber",
  "Plank",
  "Side plank",
  "L-sit hold",
  "Crunch",
  "V sit",
  "V- sit up",
  "Horizontal jump",
            };

            string[] Equipmentbeased = new string[] {
     "Box jump",
     "One leg jump",
     "Pike press",
    "Pike push up",
    "Burpee box jump over",
    "Rope climb (standard)",
    "Leg less climb",
    "Lying to stand",
    "Abmat sit up",
    "GHD sit up",
    "GHD hip extension",
    "GHD back extension",
    "GHD hip and back extension"
                };

            string[] Metcan = new string[] {
  "Run",
  "Air run",
  "Incline run",
  "Single under",
  "Double under",
  "Row",
  "Biking",
  "Skiing",
  "Stair climber machine",
  "Elliptical",
  "Jumping jack"
            };

            string[] Shoulder = new string[] {
    "پرس سرشانه",
    "پرس سرشانه از پشت",
    " پرس سرشانه دمبل",
    " پرس سرشانه دمبل نشسته",
    "پرس سرشانه چرخشی",
    "پرس سرشانه چرخشی نشسته",
    "پرس سرشانه نشسته",
    "پرس سرشانه ازپشت نشسته",
    "نشر از جلو متناوب",
    "نشر از جلو غیر متناوب",
    "نشر از جلو سیم کش",
    "نشر از جانب",
    "نشر از جانب زاویه جلو",
    "نشر از جانب زاویه پشت",
    "نشر از جانب چکشی",
    "نشر از جلو هالتر",
    "نشر از جلو غیر متناوب",
    "نشر خم دمبل ایستاده",
    "نشر خم دمبل نشسته",
    "نشر خم سیم کش",
    "نشر از جلو هالتر خوابیده",
    "فیس پول",
    "نشر خم روی میز شیبدار",
            };

            string[] Chest = new string[] {
    "پرس سینه هالتر",
    "پرس سینه هالتر دست جمع",
    "پرس سینه هالتر دست باز",
    "پرس سینه هالتر درازکش",
    "پرس سینه دمبل",
    "پرس سینه دمبل درازکش",
    "قفسه سینه دمبل",
    "پرس بالا سینه هالتر",
    "پرس بالا سینه هالتر دست باز",
    "پرس بالا سینه دمبل",
    "قفسه بالا سینه دمبل",
    "پرس زیر سینه هالتر",
    "پرس زیر سینه دمبل",
    "قفسه زیر سینه دمبل",
    "فلای دستگاه",
    "پول اور هالتر",
    "پول اور هالتر دست جمع",
    "پول اور هالتر ایستاده",
    "پول اور دمبل",
    "پول اور دمبل ایستاده",
            };

            string[] Back = new string[] {
    "لت از جلو",
    "لت دست معکوس",
    "لت از پشت",
    "زیر بغل قایقی",
    "زیر بغل تک دمبل",
    "زیر بغل هالتر خم",
    "Barbell Row",
    "زیر بغل جفت دمبل",
    "تی بار هالتر",
            };

            string[] Arm = new string[] {
    "جلو بازو هالتر ایستاده",
    "جلو بازو هالتر ایستاده دست جمع",
    "جلو بازو هالتر نشسته",
    "جلو بازو هالتر نشسته دست جمع",
    "جلو بازو هالتر نشسته دست جمع تمرکزی",
    "جلو بازو هالتر خوابیده",
    "جلو بازو هالتر خوابیده دست جمع",
    "جلو بازو هالتر میز شیبدار",
    "جلو بازو هالتر دست جمع میز شیبدار",
    "جلو بازو دمبل ایستاده",
    "جلو بازو دمبل جفت چکشی",
    "جلو بازو دمبل نشسته تناوبی",
    "جلو بازو تک دمبل نشسته",
    "جلو بازو دمبل میز شیبدار",
    "جلو بازو دمبل تناوبی میز شیبدار",
    "جلو بازو سیم کش",
    "پشت بازو هالتر پرسی",
    "پشت بازو هالتر ایستاده",
    "پشت بازو هالتر نشسته",
    "پشت بازو هالتر خوابیده",
    "پشت بازو هالتر خوابیده دست جمع",
    "BarbellTricepsLying(kickback)",
    "پشت بازو تک دمبل ایستاده",
    "پشت بازو دمبل خوابیده",
    "پشت بازو سیم کش",
    "پشت بازو جفت دمبل نشسته",
    " کیک بک جفت دمبل نشسته",
    "ساعد هالتر از پشت ایستاده",
    "ساعد هالتر نشسته",
    "ساعد هالتر نشسته دست معکوس",
    "ساعد دمبل نشسته",
    "ساعد دمبل نشسته دست معکوس",
            };

            string[] Leg = new string[] {
    "اسکات از پشت",
    "اسکات از پشت پا باز",
    "نیم اسکات از پشت",
    "هاگ اسکات هالتر",
    "اسکات بلغاری",
    "اسکات بلغاری با دمبل",
    "استپ آپ با دمبل",
    "هیپ تراست با هالتر",
    "لانچ با هالتر",
    "لانچ با هالتر همراه با قدم زدن",
    "جلو پا ماشین",
    "هاگ اسکات ماشین",
    "پرس پا ماشین",
    "پشت پا خوابیده ماشین",
    "ددلیفت",
    "ددلیفت رومانیایی",
    "سومو ددلیفت",
    "ساق پا دمبل ایستاده",
    "ساق پا هالتر نشسته",
    "ساق پا جفت دمبل نشسته",
            };

            string[] Upperbody = new string[] {
    "TRX atomic pike",
    "TRX burpee",
    "TRXbodysaw",
    "TRX pike",
    "TRX plank",
    "TRX side plank",
    "TRX spiderman push-up",
    "TRX side plank (single leg)",
    "TRX side plank (single leg to knee tuck)",
    "TRX overhead back extension",
    "TRX inverted row",
    "TRX resisted torso rotation",
    "TRX row series",
    "TRX chest press",
    "TRX clock press",
    "TRX low row to chest press",
    "TRX pull-up",
    "TRX sprinter start",
    "TRX half kneeling roll out",
    "TRX deltoid fly to T fly",
    "TRX triceps press",
    "TRX power pull",
    "TRX biceps curp",
    "TRX mountain climber",
    "TRX incling plank",
    "TRX incline press",
    "TRX plank press",
    "TRX chest fly",
    "TRX hinge",
    "TRX bic FPS curl (single arm)",
    "TRX pull press",
    "TRX hip throw",
    "TRX hinge (single arm)",
    "TRX split fly",
    "TRX inverted row",
    "TRX wall sides (stand facing)",
    "TRX hinge (wide stance)",
    "TRX long torso stretch",
    "TRX half kneeling roll out",
    "TRX cossack",
    "TRX hinge (single arm) to push-up",
    "TRX low row to biceps curl to Y fly",
            };

            string[] Lowerbody = new string[] {
    "TRX hamstring burner",
    "TRXhipabduction",
    "TRXhippress",
    "TRX hip press (single leg)",
    "TRX hamstringcurl",
    "TRX lunge",
    "TRX lunge (1 hand down)",
    "TRX squat",
    "TRX side lunge",
    "TRX squat row",
    "TRX squat row (single arm)",
    "TRX squat Y fly",
    "TRX squat (single leg)",
    "TRX abduction lunge",
    "TRX overhead squat",
    "TRX sprinter start",
    "TRX squat (single leg) to closing balance lunge",
    "TRX forward lunge with hip flexor stretch",
    "TRX split squat (W/ M deltoid fly)",
    "TRX split squat (W/ T deltoid fly)",
    "TRX split squat (W/ Y deltoid fly)",
    "TRX hip hinge (single leg)",
            };

            comboBox3.Enabled = true;

            comboBox3.Items.Clear();
            comboBox3.Text = "Select";

            switch (comboBox2.SelectedItem)
            {
                case "هالتر":
                    comboBox3.Items.AddRange(Halter);
                    break;
                case "دمبل":
                    comboBox3.Items.AddRange(Dumbbell);
                    break;
                case "کتل بل":
                    comboBox3.Items.AddRange(Kettlebell);
                    break;
                case "مدیسن بال":
                    comboBox3.Items.AddRange(Medicineball);
                    break;
                case "میله و دارحلقه":
                    comboBox3.Items.AddRange(BarAndring);
                    break;
                case "با وزن بدن":
                    comboBox3.Items.AddRange(BodyWeight);
                    break;
                case "با تجهیزات":
                    comboBox3.Items.AddRange(Equipmentbeased);
                    break;
                case "کاردیو":
                    comboBox3.Items.AddRange(Metcan);
                    break;
                case "سرشانه":
                    comboBox3.Items.AddRange(Shoulder);
                    break;
                case "سینه":
                    comboBox3.Items.AddRange(Chest);
                    break;
                case "پشت":
                    comboBox3.Items.AddRange(Back);
                    break;
                case "بازو و ساعد":
                    comboBox3.Items.AddRange(Arm);
                    break;
                case "ران و ساق":
                    comboBox3.Items.AddRange(Leg);
                    break;
                case "بالاتنه":
                    if (comboBox1.SelectedItem == "تی آر ایکس")
                        comboBox3.Items.AddRange(Upperbody);
                    else
                        comboBox3.Items.AddRange(new string[] { });
                    break;
                case "پایین تنه":
                    if (comboBox1.SelectedItem == "تی آر ایکس")
                        comboBox3.Items.AddRange(Lowerbody);
                    else
                        comboBox3.Items.AddRange(new string[] { });
                    break;

                default:
                    // code block
                    break;
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
                    Filter = "Image Files (*.bmp;*.png;*.jpg;*.gif)|*.bmp;*.png;*.jpg;*.gif",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = openFileDialog1.FileName;
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    publicText1 = openFileDialog1.FileName;

                    button4.Enabled = true;
                }

                DataGridViewColumn column = dataGridView1.Columns[1];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ((DataGridViewImageColumn)dataGridView1.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                //dataGridView1.Rows[1].Height = 100;
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }

        string publicText1 = "";
        string publicText2 = "";
        string publicText3 = "";

        private void button2_Click(object sender, EventArgs e)
        {
            if (publicText1 == "" && publicText2 == "" && publicText3 == "")
            {
                MessageBox.Show("عکسی انتخاب نکردید ولی ادامه میدیم");
                //                return;

                dataGridView1.Rows.Add(richTextBox1.Text, null, null, null, textBox2.Text, textBox3.Text, textBox4.Text);
            }
            else if (publicText2 == "" && publicText3 == "")
            {
                dataGridView1.Rows.Add(richTextBox1.Text, new Bitmap(publicText1), null, null, textBox2.Text, textBox3.Text, textBox4.Text);
            }
            else if (publicText3 == "")
            {
                dataGridView1.Rows.Add(richTextBox1.Text, new Bitmap(publicText1), new Bitmap(publicText2), null, textBox2.Text, textBox3.Text, textBox4.Text);
            }
            else
            {
                dataGridView1.Rows.Add(richTextBox1.Text, new Bitmap(publicText1), new Bitmap(publicText2), new Bitmap(publicText3), textBox2.Text, textBox3.Text, textBox4.Text);
            }
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            richTextBox1.Text = "";
            publicText1 = "";
            publicText2 = "";
            publicText3 = "";
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private async void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();

            var content = await client.GetStringAsync(BaseAddress + "fitness/VOD/GetMovement?Part=" + comboBox1.SelectedItem + "&SubPart=" + comboBox2.SelectedItem + "&MoveName=" + comboBox3.SelectedItem);

            //Console.WriteLine(content);
            label7.Visible = false;
            label6.Visible = false;

            if (content == "false")
            {
                label7.Visible = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
            }
            else
            {
                label6.Visible = true;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;

            }
        }

        public async Task<string> PostToServerMovementDetail(string filePath1, string filePath2, string filePath3, Com.MovementTrainingDetail movementTrainingDetail)
        {
            try
            {
                // string filePath = "C:/Users/mehrs/Downloads/Telegram Desktop/4-10-6.png";

                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {


                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(movementTrainingDetail));
                        if (filePath1 != null && filePath1 != "")
                        {
                            form.Add(contentBody, "Object");
                            var fs = File.OpenRead(filePath1);
                            var streamContent = new StreamContent(fs);
                            var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync());
                            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                            form.Add(fileContent, "File", Path.GetExtension(filePath1));

                            if (filePath2 != null && filePath2 != "")
                            {
                                var fs2 = File.OpenRead(filePath2);
                                var streamContent2 = new StreamContent(fs2);
                                var fileContent2 = new ByteArrayContent(await streamContent2.ReadAsByteArrayAsync());
                                fileContent2.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                                form.Add(fileContent2, "File", Path.GetExtension(filePath2));

                                if (filePath3 != null && filePath3 != "")
                                {
                                    var fs3 = File.OpenRead(filePath3);
                                    var streamContent3 = new StreamContent(fs3);
                                    var fileContent3 = new ByteArrayContent(await streamContent3.ReadAsByteArrayAsync());
                                    fileContent3.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                                    form.Add(fileContent3, "File", Path.GetExtension(filePath3));
                                }
                            }
                        }
                        HttpResponseMessage response = await httpClient.PostAsync(BaseAddress + "fitness/VOD/PostMovementDetail", form);
                        string ResStr = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("PostMovementDetail : " + ResStr);
                        return ResStr;
                    }
                }
            }
            catch (Exception eeee)
            {
                Console.WriteLine(eeee.Message);
                MessageBox.Show(eeee.Message);
                return "-1000";
            }
        }

        public async void PostUpdateImgMovementDetail(string filePath1, string filePath2, string filePath3, Com.MovementTrainingDetail movementTrainingDetail)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {
                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(movementTrainingDetail));
                        form.Add(contentBody, "Object");

                        var fs = File.OpenRead(filePath1);
                        var streamContent = new StreamContent(fs);
                        var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync());
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        form.Add(fileContent, "File", Path.GetExtension(filePath1));

                        if (filePath2 != null && filePath2 != "")
                        {
                            var fs2 = File.OpenRead(filePath2);
                            var streamContent2 = new StreamContent(fs2);
                            var fileContent2 = new ByteArrayContent(await streamContent2.ReadAsByteArrayAsync());
                            fileContent2.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                            form.Add(fileContent2, "File", Path.GetExtension(filePath2));

                            if (filePath3 != null && filePath3 != "")
                            {
                                var fs3 = File.OpenRead(filePath3);
                                var streamContent3 = new StreamContent(fs3);
                                var fileContent3 = new ByteArrayContent(await streamContent3.ReadAsByteArrayAsync());
                                fileContent3.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                                form.Add(fileContent3, "File", Path.GetExtension(filePath3));
                            }
                        }

                        HttpResponseMessage response = await httpClient.PostAsync(BaseAddress + "fitness/VOD/PostUpdateImgMovementDetail", form);
                    }
                }
            }
            catch (Exception eeee)
            {
                Console.WriteLine(eeee.Message);
                MessageBox.Show("مشکل در ارسال پست");
                MessageBox.Show(eeee.Message);
            }
        }
        //public async void PostToServerMovementDetail(string filePath1, string filePath2, string filePath3, Com.MovementTrainingDetail movementTrainingDetail)
        //{
        //    try
        //    {
        //        // string filePath = "C:/Users/mehrs/Downloads/Telegram Desktop/4-10-6.png";

        //        using (var httpClient = new HttpClient())
        //        {
        //            using (var form = new MultipartFormDataContent())
        //            {
        //                using (var fs = File.OpenRead(filePath))
        //                {
        //                    using (var streamContent = new StreamContent(fs))
        //                    {
        //                        using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
        //                        {
        //                            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

        //                            // movementTrainingDetail = new Com.MovementTrainingDetail() { ContextDetail = "adcasdac", ImgNumber = 2, MTID = 2 };
        //                            StringContent contentBody = new StringContent(JsonConvert.SerializeObject(movementTrainingDetail));
        //                            form.Add(contentBody, "Object");

        //                            // "file" parameter name should be the same as the server side input parameter name
        //                            form.Add(fileContent, "File", Path.GetExtension(filePath));

        //                            HttpResponseMessage response = await httpClient.PostAsync(BaseAddress+"fitness/VOD/PostMovementDetail", form);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception eeee)
        //    {
        //        Console.WriteLine(eeee.Message);
        //    }
        //}

        public async Task<string> PostToServerMovement(Com.MovementTraining movementTraining)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {
                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(movementTraining));
                        form.Add(contentBody, "Object");


                        ImageConverter imgConverter = new ImageConverter();
                        var imgBytes = (System.Byte[])imgConverter.ConvertTo(pictureBox7.Image, Type.GetType("System.Byte[]"));
                        var fileContent = new ByteArrayContent(imgBytes);
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        form.Add(fileContent, "File", ".gif");

                        HttpResponseMessage response = await httpClient.PostAsync(BaseAddress + "fitness/VOD/PostMovement", form);

                        string ResStr = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(ResStr);
                        return ResStr;
                    }
                }
            }
            catch (Exception eeee)
            {
                Console.WriteLine(eeee.Message);
                MessageBox.Show("احتملا حجم عکس زیاد است");
                return "err";
            }
        }
        public async Task<string> PostUpdateMovementTrainingContext(Com.MovementTrainingDetail movementTrainingDetail)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {
                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(movementTrainingDetail));
                        form.Add(contentBody, "Object");

                        HttpResponseMessage response = await httpClient.PostAsync(BaseAddress + "fitness/VOD/PostUpdateMovementTrainingContext", form);

                        string ResStr = await response.Content.ReadAsStringAsync();
                        return ResStr;
                    }
                }
            }
            catch (Exception eeee)
            {
                Console.WriteLine(eeee.Message);
                return "err";
            }
        }
        public async Task<string> PostUpdateMovement(Com.MovementTraining movementTraining)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {
                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(movementTraining));
                        form.Add(contentBody, "Object");

                        HttpResponseMessage response = await httpClient.PostAsync(BaseAddress + "fitness/VOD/UpdateMovement", form);

                        string ResStr = await response.Content.ReadAsStringAsync();
                        return ResStr;
                    }
                }
            }
            catch (Exception eeee)
            {
                Console.WriteLine(eeee.Message);
                return "err";
            }
        }



        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Com.MovFilter movFilter;
                try
                {
                    movFilter = new Com.MovFilter()
                    {
                        Envoritment = listBoxEnvoritment.Items.Cast<String>().ToList(),
                        Equipment = listBoxEquipment.Items.Cast<String>().ToList(),
                        MDbody = listBoxMDBody.Items.Cast<String>().ToList(),
                        MMbody = listBoxMMBody.Items.Cast<String>().ToList(),
                        Modality = listBoxModality.Items.Cast<String>().ToList(),
                        MUbody = listBoxMUBody.Items.Cast<String>().ToList(),
                        SDbody = listBoxSDBody.Items.Cast<String>().ToList(),
                        Skill = listBoxSkill.Items.Cast<String>().ToList(),
                        SMbody = listBoxSMBody.Items.Cast<String>().ToList(),
                        SUbody = listBoxSUBody.Items.Cast<String>().ToList(),
                        Time = float.Parse(textBoxTime.Text),
                        Vazn = float.Parse(textBoxVazn.Text),
                        Zarib = float.Parse(textBoxTadil.Text),
                        PayeshMard = float.Parse(textBoxPayeshMard.Text),
                        PayeshZan = float.Parse(textBoxPayeshZan.Text),
                        ZaribSakhti = float.Parse(textBoxZaribSakhti.Text)
                    };
                }
                catch (Exception)
                {
                    MessageBox.Show("ایراد در ورودی ها");
                    return;
                }

                Com.MovementTraining movementTraining = new Com.MovementTraining()
                {
                    Context = richTextBox2.Text,
                    VideoAddress = textBox1.Text,
                    Part = (string)comboBox1.SelectedItem,
                    SubPart = (string)comboBox2.SelectedItem,
                    Movement = (string)comboBox3.SelectedItem,
                    Filter = JsonConvert.SerializeObject(movFilter)
                };

                string cc = await PostToServerMovement(movementTraining);

                if (cc == "err")
                {
                    MessageBox.Show("مشکلی در ارسال وجود دارد");
                    return;
                }

                int MTIDnew = Int32.Parse(cc);

                if (MTIDnew < 0)
                {
                    MessageBox.Show("مشکلی در ارسال وجود دارد");
                    return;
                }


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    {
                        Com.MovementTrainingDetail movementTrainingDetail = new Com.MovementTrainingDetail()
                        {
                            ContextDetail = row.Cells[0].Value.ToString(),
                            ImgName = "",
                            MTID = MTIDnew
                        };
                        string bb = await PostToServerMovementDetail(row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), movementTrainingDetail);

                        int MTDIDnew = Int32.Parse(bb);

                        if (MTDIDnew < 0)
                        {
                            MessageBox.Show("مشکلی در ارسال جزییات حرکت وجود دارد ولی  اطلاعات حرکت در دیتابیس ذخیره شده است");
                            return;
                        }

                    }
                }

                MessageBox.Show("آپلود به درستی انجام شد.");

                dataGridView1.Rows.Clear();
                richTextBox2.Text = "";
                textBox1.Text = "";
                label7.Visible = false;
                label6.Visible = false;

                listBoxEnvoritment.Items.Clear();
                listBoxEquipment.Items.Clear();
                listBoxMDBody.Items.Clear();
                listBoxMMBody.Items.Clear();
                listBoxModality.Items.Clear();
                listBoxMUBody.Items.Clear();
                listBoxSDBody.Items.Clear();
                listBoxSkill.Items.Clear();
                listBoxSMBody.Items.Clear();
                listBoxSUBody.Items.Clear();
                textBoxTime.Text = "";
                textBoxVazn.Text = "";
                textBoxTadil.Text = "";
                textBoxPayeshMard.Text = "";
                textBoxPayeshZan.Text = "";
                pictureBox7.Image = null;

            }
            catch (Exception ee)
            {
                MessageBox.Show("مشکلی در ارسال دارد.");
                MessageBox.Show(ee.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog2 = new OpenFileDialog
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

                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    textBox3.Text = openFileDialog2.FileName;
                    pictureBox2.Image = new Bitmap(openFileDialog2.FileName);
                    publicText2 = openFileDialog2.FileName;
                    button5.Enabled = true;

                }

                DataGridViewColumn column = dataGridView1.Columns[2];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ((DataGridViewImageColumn)dataGridView1.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                //dataGridView1.Rows[1].Height = 100;
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog3 = new OpenFileDialog
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

                if (openFileDialog3.ShowDialog() == DialogResult.OK)
                {
                    textBox4.Text = openFileDialog3.FileName;
                    pictureBox3.Image = new Bitmap(openFileDialog3.FileName);
                    publicText3 = openFileDialog3.FileName;
                }

                DataGridViewColumn column = dataGridView1.Columns[3];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ((DataGridViewImageColumn)dataGridView1.Columns[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                //dataGridView1.Rows[1].Height = 100;
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }


        List<Com.MovementTraining> MovementObjectTabPage2;
        private async void tabPage2_Enter(object sender, EventArgs e)
        {
            Fillrefresh();
        }


        async void Fillrefresh()
        {
            try
            {
                var client = new HttpClient();

                string content = await client.GetStringAsync(BaseAddress + "fitness/VOD/GetAllMovementTraining");

                //  var jsonString = await filesReadToProvider.Contents[0].ReadAsStringAsync();
                var serializer = new JavaScriptSerializer();
                MovementObjectTabPage2 = serializer.Deserialize<List<Com.MovementTraining>>(content);

                comboBox4.DataSource = MovementObjectTabPage2.Select(A => A.Part).Distinct().ToList();
                label12.Visible = false;
                groupBox3.Enabled = true;

                Console.WriteLine(content);
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
                MessageBox.Show("خطا در اتصال");
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox5.DataSource = MovementObjectTabPage2.Where(M => M.Part == comboBox4.SelectedItem.ToString()).Select(A => A.SubPart).Distinct().ToList();
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox6.DataSource = MovementObjectTabPage2.Where(M => M.Part == comboBox4.SelectedItem.ToString() && M.SubPart == comboBox5.SelectedItem.ToString()).Select(A => A.Movement).ToList();
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var MovTemp = MovementObjectTabPage2.Where(M => M.Part == comboBox4.SelectedItem.ToString() && M.SubPart == comboBox5.SelectedItem.ToString() && M.Movement == comboBox6.SelectedItem.ToString()).FirstOrDefault();
                richTextBox3.Text = MovTemp.Context;
                textBox5.Text = MovTemp.VideoAddress;
                label13.Text = MovTemp.MTID.ToString();

                MovementInput movementInput = new MovementInput() { MoveName = MovTemp.Movement, Part = MovTemp.Part, SubPart = MovTemp.SubPart };
                var resAllMovDetials = PostgetAllMovDetailsInfo(movementInput).Result;

                dataGridView2.Rows.Clear();

                if (resAllMovDetials.MovementTrainingDetails == null)
                {
                    MessageBox.Show("با اینکه در دیتابیس ثبت شده ولی خالی است، اسم و نوع و ... بررسی شود بعدا.");
                    return;
                }

                foreach (var itemMovDet in resAllMovDetials.MovementTrainingDetails)
                {
                    var ImgNameSplited = itemMovDet.ImgName.Split(',');
                    int ImgNameCount = ImgNameSplited.Count();

                    if (ImgNameCount == 1)
                    {
                        if (ImgNameSplited[0] == "")
                            break;
                        try
                        {
                            System.Net.WebRequest request = System.Net.WebRequest.Create(
                                "https://www.hasma.ir/FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[0]);
                            System.Net.WebResponse response = request.GetResponse();
                            Stream responseStream = response.GetResponseStream();
                            Bitmap bitmapMov = new Bitmap(responseStream);

                            dataGridView2.Rows.Add(itemMovDet.MTDID, itemMovDet.ContextDetail, bitmapMov, null, null);

                            DataGridViewColumn column = dataGridView2.Columns[2];
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            ((DataGridViewImageColumn)dataGridView2.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        }
                        catch
                        {
                            dataGridView2.Rows.Add(itemMovDet.MTDID, itemMovDet.ContextDetail, null, null, null);
                            MessageBox.Show("خطا در بارگذاری عکس");
                        }
                    }
                    else if (ImgNameCount == 2)
                    {
                        try
                        {
                            System.Net.WebRequest request = System.Net.WebRequest.Create(
                                "https://www.hasma.ir/FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[0]);
                            System.Net.WebResponse response = request.GetResponse();
                            Stream responseStream = response.GetResponseStream();
                            Bitmap bitmapMov = new Bitmap(responseStream);

                            System.Net.WebRequest request2 = System.Net.WebRequest.Create(
                                "https://www.hasma.ir/FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[1]);
                            System.Net.WebResponse response2 = request2.GetResponse();
                            Stream responseStream2 = response2.GetResponseStream();
                            Bitmap bitmapMov2 = new Bitmap(responseStream2);

                            dataGridView2.Rows.Add(itemMovDet.MTDID, itemMovDet.ContextDetail, bitmapMov, bitmapMov2, null);

                            DataGridViewColumn column = dataGridView2.Columns[2];
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            ((DataGridViewImageColumn)dataGridView2.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                            DataGridViewColumn column3 = dataGridView2.Columns[3];
                            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            ((DataGridViewImageColumn)dataGridView2.Columns[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        }
                        catch
                        {
                            dataGridView2.Rows.Add(itemMovDet.MTDID, itemMovDet.ContextDetail, null, null, null);
                            MessageBox.Show("خطا در بارگذاری عکس");
                        }
                    }
                    else if (ImgNameCount == 3)
                    {
                        try
                        {
                            System.Net.WebRequest request = System.Net.WebRequest.Create(
                                "https://www.hasma.ir/FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[0]);
                            System.Net.WebResponse response = request.GetResponse();
                            Stream responseStream = response.GetResponseStream();
                            Bitmap bitmapMov = new Bitmap(responseStream);

                            System.Net.WebRequest request2 = System.Net.WebRequest.Create(
                                "https://www.hasma.ir/FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[1]);
                            System.Net.WebResponse response2 = request2.GetResponse();
                            Stream responseStream2 = response2.GetResponseStream();
                            Bitmap bitmapMov2 = new Bitmap(responseStream2);

                            System.Net.WebRequest request3 = System.Net.WebRequest.Create(
                                "https://www.hasma.ir/FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[2]);
                            System.Net.WebResponse response3 = request3.GetResponse();
                            Stream responseStream3 = response3.GetResponseStream();
                            Bitmap bitmapMov3 = new Bitmap(responseStream3);

                            dataGridView2.Rows.Add(itemMovDet.MTDID, itemMovDet.ContextDetail, bitmapMov, bitmapMov2, bitmapMov3);

                            DataGridViewColumn column = dataGridView2.Columns[2];
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            ((DataGridViewImageColumn)dataGridView2.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                            DataGridViewColumn column3 = dataGridView2.Columns[3];
                            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            ((DataGridViewImageColumn)dataGridView2.Columns[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                            DataGridViewColumn column4 = dataGridView2.Columns[4];
                            column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            ((DataGridViewImageColumn)dataGridView2.Columns[4]).ImageLayout = DataGridViewImageCellLayout.Stretch;

                        }
                        catch (Exception ee)
                        {
                            dataGridView2.Rows.Add(itemMovDet.MTDID, itemMovDet.ContextDetail, null, null, null);

                            MessageBox.Show("خطا در بارگذاری عکس ها");
                            Console.WriteLine(ee.Message);
                        }
                    }
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                MessageBox.Show("ارور دارد ولی شما ادامه بدهید");
            }
        }

        public async Task<MegaMovement> PostgetAllMovDetailsInfo(MovementInput requestObj)
        {
            // Initialization.  
            MegaMovement responseObj = new MegaMovement();

            // Posting.  
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriString: BaseAddress);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ContentObj = JsonConvert.SerializeObject(requestObj);
                HttpResponseMessage response = new HttpResponseMessage();

                response = await client.PostAsJsonAsync("fitness/VOD/GetMegaMovementTraining", requestObj).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    responseObj = JsonConvert.DeserializeObject<MegaMovement>(result);
                }
            }

            return responseObj;
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            Com.MovementTraining movementTraining = new Com.MovementTraining()
            {
                MTID = Int32.Parse(label13.Text),
                Context = richTextBox3.Text,
                VideoAddress = textBox5.Text,
            };
            string cc = await PostUpdateMovement(movementTraining);
            if (cc == "err")
            {
                MessageBox.Show("خطااااا");
            }
            else
            {
                MessageBox.Show("آپدیت شد");
            }

        }


        int UpdatedMTID = 0;
        int UpdatedMTDID = 0;
        private async void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int cc = dataGridView2.CurrentCell.RowIndex;

                DataGridViewRow row = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex];
                string SelectedMTDID = row.Cells[0].Value.ToString();
                UpdatedMTID = Int32.Parse(label13.Text);
                UpdatedMTDID = Int32.Parse(SelectedMTDID);

                string RequestURI = BaseAddress + "fitness/VOD/DeleteImg?MTID=" + label13.Text + "&MTDID=" + SelectedMTDID;
                var client = new HttpClient();
                string content = await client.GetStringAsync(RequestURI);

                var serializer = new JavaScriptSerializer();
                bool ResDelete = serializer.Deserialize<bool>(content);
                if (ResDelete)
                {
                    dataGridView2.Visible = false;
                    button7.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;

                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    textBox8.Visible = true;
                    button8.Visible = true;
                    button9.Visible = true;
                    button10.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    button11.Visible = true;
                }
                else
                {
                    MessageBox.Show("خطا در اتصال");
                }
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
                MessageBox.Show("خطا در اتصال");
            }
        }

        string publicTxtUpdate1 = "";
        string publicTxtUpdate2 = "";
        string publicTxtUpdate3 = "";

        private void button8_Click(object sender, EventArgs e)
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
                    textBox6.Text = openFileDialog1.FileName;
                    pictureBox4.Image = new Bitmap(openFileDialog1.FileName);
                    publicTxtUpdate1 = openFileDialog1.FileName;
                    button9.Enabled = true;

                    DataGridViewColumn column = dataGridView2.Columns[2];
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    ((DataGridViewImageColumn)dataGridView1.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                }
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
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
                    textBox7.Text = openFileDialog1.FileName;
                    pictureBox5.Image = new Bitmap(openFileDialog1.FileName);
                    publicTxtUpdate2 = openFileDialog1.FileName;
                    button10.Enabled = true;

                    DataGridViewColumn column = dataGridView2.Columns[3];
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    ((DataGridViewImageColumn)dataGridView1.Columns[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                }
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
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
                    textBox8.Text = openFileDialog1.FileName;
                    pictureBox6.Image = new Bitmap(openFileDialog1.FileName);
                    publicTxtUpdate3 = openFileDialog1.FileName;

                    DataGridViewColumn column = dataGridView2.Columns[3];
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    ((DataGridViewImageColumn)dataGridView1.Columns[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                }
            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Com.MovementTrainingDetail movementTrainingDetail = new Com.MovementTrainingDetail()
            {
                ImgName = "",
                MTID = UpdatedMTID,
                MTDID = UpdatedMTDID
            };

            PostUpdateImgMovementDetail(publicTxtUpdate1, publicTxtUpdate2, publicTxtUpdate3, movementTrainingDetail);

            MessageBox.Show("آپلود شد.");

            dataGridView2.Visible = true;
            button7.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;

            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            button11.Visible = false;

            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;

            Fillrefresh();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex];
            string SelectedMTDID = row.Cells[0].Value.ToString();
            int UpdatedMTIDContext = Int32.Parse(label13.Text);
            int UpdatedMTDIDContext = Int32.Parse(SelectedMTDID);

            Com.MovementTrainingDetail movementTrainingDetail = new Com.MovementTrainingDetail()
            {
                MTID = UpdatedMTIDContext,
                MTDID = UpdatedMTDIDContext,
                ContextDetail = richTextBox4.Text
            };

            PostUpdateMovementTrainingContext(movementTrainingDetail);

            MessageBox.Show("تغییرات اعمال شد");

            Fillrefresh();
        }

        private void FormAmoozesh_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Management

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
                //this.Hide();
            }
            catch (Exception ee)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (this.checkedListBoxUpperBody.CheckedItems.Count > 0)
            {
                this.listBoxSUBody.Items.Clear();
                foreach (string item in this.checkedListBoxUpperBody.CheckedItems)
                {
                    this.listBoxSUBody.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBoxUpperBody.Items.Count; i++)
                {
                    this.checkedListBoxUpperBody.SetItemChecked(i, false);
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox1.CheckedItems.Count > 0)
            {
                this.listBoxMUBody.Items.Clear();
                foreach (string item in this.checkedListBox1.CheckedItems)
                {
                    this.listBoxMUBody.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    this.checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox2.CheckedItems.Count > 0)
            {
                this.listBoxSMBody.Items.Clear();
                foreach (string item in this.checkedListBox2.CheckedItems)
                {
                    this.listBoxSMBody.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
                {
                    this.checkedListBox2.SetItemChecked(i, false);
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox3.CheckedItems.Count > 0)
            {
                this.listBoxMMBody.Items.Clear();
                foreach (string item in this.checkedListBox3.CheckedItems)
                {
                    this.listBoxMMBody.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox3.Items.Count; i++)
                {
                    this.checkedListBox3.SetItemChecked(i, false);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox4.CheckedItems.Count > 0)
            {
                this.listBoxSDBody.Items.Clear();
                foreach (string item in this.checkedListBox4.CheckedItems)
                {
                    this.listBoxSDBody.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox4.Items.Count; i++)
                {
                    this.checkedListBox4.SetItemChecked(i, false);
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox5.CheckedItems.Count > 0)
            {
                this.listBoxMDBody.Items.Clear();
                foreach (string item in this.checkedListBox5.CheckedItems)
                {
                    this.listBoxMDBody.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox5.Items.Count; i++)
                {
                    this.checkedListBox5.SetItemChecked(i, false);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox6.CheckedItems.Count > 0)
            {
                this.listBoxModality.Items.Clear();
                foreach (string item in this.checkedListBox6.CheckedItems)
                {
                    this.listBoxModality.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox6.Items.Count; i++)
                {
                    this.checkedListBox6.SetItemChecked(i, false);
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox7.CheckedItems.Count > 0)
            {
                this.listBoxEnvoritment.Items.Clear();
                foreach (string item in this.checkedListBox7.CheckedItems)
                {
                    this.listBoxEnvoritment.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox7.Items.Count; i++)
                {
                    this.checkedListBox7.SetItemChecked(i, false);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox8.CheckedItems.Count > 0)
            {
                this.listBoxSkill.Items.Clear();
                foreach (string item in this.checkedListBox8.CheckedItems)
                {
                    this.listBoxSkill.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox8.Items.Count; i++)
                {
                    this.checkedListBox8.SetItemChecked(i, false);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox9.CheckedItems.Count > 0)
            {
                this.listBoxEquipment.Items.Clear();
                foreach (string item in this.checkedListBox9.CheckedItems)
                {
                    this.listBoxEquipment.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox9.Items.Count; i++)
                {
                    this.checkedListBox9.SetItemChecked(i, false);
                }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Browse Text Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "gif",
                    Filter = "Image Files (*.gif)|*.gif",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox7.Image = new Bitmap(openFileDialog1.FileName);
                }

            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }
    }

    public class MegaMovement
    {
        public Com.MovementTraining MovementTraining { get; set; }
        public List<Com.MovementTrainingDetail> MovementTrainingDetails { get; set; }
        public bool HasError { get; set; }
    }
    public class MovementInput
    {
        public string Part { get; set; }
        public string SubPart { get; set; }
        public string MoveName { get; set; }
    }

    public class MovFilter
    {
        public List<string> MUbody { get; set; }
        public List<string> SUbody { get; set; }
        public List<string> MMbody { get; set; }
        public List<string> SMbody { get; set; }
        public List<string> MDbody { get; set; }
        public List<string> SDbody { get; set; }
        public List<string> Modality { get; set; }
        public List<string> Envoritment { get; set; }
        public List<string> Skill { get; set; }
        public List<string> Equipment { get; set; }
        public List<string> Vazn { get; set; }
        public List<string> Zarib { get; set; }
        public List<string> Time { get; set; }
    }
}
