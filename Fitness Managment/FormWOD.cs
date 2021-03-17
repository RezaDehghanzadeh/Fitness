using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Managment
{
    public partial class FormWOD : Form
    {
        private const int V = -1;
        EvolvedVOD evolvedVOD;

        // string BaseAddress = "http://localhost:56271/";
        string BaseAddress = "https://www.hasma.ir/";
        //string BaseAddress = "http://193.105.234.83:80/";

        public FormWOD()
        {
            InitializeComponent();
            evolvedVOD = new EvolvedVOD();
            evolvedVOD.movs = new List<Mov>();
        }

        private void FormWOD_Load(object sender, EventArgs e)
        {


        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Enabled = true;
            string[] installsVazneBardari = new string[] { "هالتر", "دمبل", "کتل بل", "مدیسن بال" };
            string[] installsZhimnastik = new string[] { "میله و دارحلقه", "با وزن بدن", "با تجهیزات" };
            string[] installsKardio = new string[] { "کاردیو" };
            string[] installsParvareshAndam = new string[] { "سرشانه", "سینه", "پشت", "بازو و ساعد", "ران و ساق" };
            string[] installsTRX = new string[] { "بالاتنه", "پایین تنه" };
            string[] installsKesheshi = new string[] { "بالاتنه", "پایین تنه" };

            comboBox6.Items.Clear();
            comboBox6.Text = "Select";
            comboBox5.Text = "Select";

            switch (comboBox4.SelectedItem)
            {
                case "وزنه برداری":
                    comboBox6.Items.AddRange(installsVazneBardari);
                    break;
                case "ژیمناستیک":
                    comboBox6.Items.AddRange(installsZhimnastik);
                    break;
                case "کاردیو":
                    comboBox6.Items.AddRange(installsKardio);
                    break;
                case "پرورش اندام":
                    comboBox6.Items.AddRange(installsParvareshAndam);
                    break;
                case "کششی":
                    comboBox6.Items.AddRange(installsKesheshi);
                    break;
                case "تی آر ایکس":
                    comboBox6.Items.AddRange(installsTRX);
                    break;
                default:
                    // code block
                    break;
            }

        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
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

            comboBox5.Enabled = true;

            comboBox5.Items.Clear();
            comboBox5.Text = "Select";

            switch (comboBox6.SelectedItem)
            {
                case "هالتر":
                    comboBox5.Items.AddRange(Halter);
                    break;
                case "دمبل":
                    comboBox5.Items.AddRange(Dumbbell);
                    break;
                case "کتل بل":
                    comboBox5.Items.AddRange(Kettlebell);
                    break;
                case "مدیسن بال":
                    comboBox5.Items.AddRange(Medicineball);
                    break;
                case "میله و دارحلقه":
                    comboBox5.Items.AddRange(BarAndring);
                    break;
                case "با وزن بدن":
                    comboBox5.Items.AddRange(BodyWeight);
                    break;
                case "با تجهیزات":
                    comboBox5.Items.AddRange(Equipmentbeased);
                    break;
                case "کاردیو":
                    comboBox5.Items.AddRange(Metcan);
                    break;
                case "سرشانه":
                    comboBox5.Items.AddRange(Shoulder);
                    break;
                case "سینه":
                    comboBox5.Items.AddRange(Chest);
                    break;
                case "پشت":
                    comboBox5.Items.AddRange(Back);
                    break;
                case "بازو و ساعد":
                    comboBox5.Items.AddRange(Arm);
                    break;
                case "ران و ساق":
                    comboBox5.Items.AddRange(Leg);
                    break;
                case "بالاتنه":
                    if ((string)comboBox4.SelectedItem == "تی آر ایکس")
                        comboBox5.Items.AddRange(Upperbody);
                    else
                        comboBox5.Items.AddRange(new string[] { });
                    break;
                case "پایین تنه":
                    if ((string)comboBox4.SelectedItem == "تی آر ایکس")
                        comboBox5.Items.AddRange(Lowerbody);
                    else
                        comboBox5.Items.AddRange(new string[] { });
                    break;

                default:
                    // code block
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox3.CheckedItems.Count > 0)
            {
                this.listBox3.Items.Clear();
                foreach (string item in this.checkedListBox3.CheckedItems)
                {
                    this.listBox3.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox3.Items.Count; i++)
                {
                    this.checkedListBox3.SetItemChecked(i, false);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox1.CheckedItems.Count > 0)
            {
                this.listBox1.Items.Clear();
                foreach (string item in this.checkedListBox1.CheckedItems)
                {
                    this.listBox1.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    this.checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox6.CheckedItems.Count > 0)
            {
                this.listBox6.Items.Clear();
                foreach (string item in this.checkedListBox6.CheckedItems)
                {
                    this.listBox6.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox6.Items.Count; i++)
                {
                    this.checkedListBox6.SetItemChecked(i, false);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox2.CheckedItems.Count > 0)
            {
                this.listBox2.Items.Clear();
                foreach (string item in this.checkedListBox2.CheckedItems)
                {
                    this.listBox2.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
                {
                    this.checkedListBox2.SetItemChecked(i, false);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox5.CheckedItems.Count > 0)
            {
                this.listBox5.Items.Clear();
                foreach (string item in this.checkedListBox5.CheckedItems)
                {
                    this.listBox5.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox5.Items.Count; i++)
                {
                    this.checkedListBox5.SetItemChecked(i, false);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox4.CheckedItems.Count > 0)
            {
                this.listBox4.Items.Clear();
                foreach (string item in this.checkedListBox4.CheckedItems)
                {
                    this.listBox4.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    this.checkedListBox4.SetItemChecked(i, false);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Round round = new Round();

            try
            {
                round.RX = new RoundDetail()
                {
                    AddToTotalRep = textBox10.Text != "" ? float.Parse(textBox10.Text) : V,
                    AddToTotalTime = textBox8.Text != "" ? float.Parse(textBox8.Text) : V,
                    AMRAP = textBox1.Text != "" ? float.Parse(textBox1.Text) : V,
                    CapTime = textBox3.Text != "" ? float.Parse(textBox3.Text) : V,
                    FTRound = textBoxTadil.Text != "" ? float.Parse(textBoxTadil.Text) : V,
                    RestBetMov = textBox5.Text != "" ? float.Parse(textBox5.Text) : V,
                    RestBetRep = textBox6.Text != "" ? float.Parse(textBox6.Text) : V,
                    RestBetSet = textBox4.Text != "" ? float.Parse(textBox4.Text) : V,
                    TimeEvery = textBox12.Text != "" ? float.Parse(textBox12.Text) : V,
                    TimeFor = textBox11.Text != "" ? float.Parse(textBox11.Text) : V,
                    TimeRest = textBox13.Text != "" ? float.Parse(textBox13.Text) : V,
                    TRound = textBox7.Text != "" ? float.Parse(textBox7.Text) : V,
                    TSet = textBox2.Text != "" ? float.Parse(textBox2.Text) : V,
                    TWork = textBox9.Text != "" ? float.Parse(textBox9.Text) : V,
                    R1 = textBox14.Text != "" ? float.Parse(textBox14.Text) : V,
                    R2 = textBox15.Text != "" ? float.Parse(textBox15.Text) : V,
                    R3 = textBox17.Text != "" ? float.Parse(textBox17.Text) : V,
                    R4 = textBox16.Text != "" ? float.Parse(textBox16.Text) : V,
                    R5 = textBox21.Text != "" ? float.Parse(textBox21.Text) : V,
                    R6 = textBox19.Text != "" ? float.Parse(textBox19.Text) : V,
                    R7 = textBox20.Text != "" ? float.Parse(textBox20.Text) : V,
                    R8 = textBox18.Text != "" ? float.Parse(textBox18.Text) : V,
                    R9 = textBox29.Text != "" ? float.Parse(textBox29.Text) : V,
                    R10 = textBox25.Text != "" ? float.Parse(textBox25.Text) : V,
                    R11 = textBox27.Text != "" ? float.Parse(textBox27.Text) : V,
                    R12 = textBox23.Text != "" ? float.Parse(textBox23.Text) : V,
                    R13 = textBox28.Text != "" ? float.Parse(textBox28.Text) : V,
                    R14 = textBox24.Text != "" ? float.Parse(textBox24.Text) : V,
                    R15 = textBox26.Text != "" ? float.Parse(textBox26.Text) : V,
                    R16 = textBox22.Text != "" ? float.Parse(textBox22.Text) : V,
                    R17 = textBox33.Text != "" ? float.Parse(textBox33.Text) : V,
                    R18 = textBox31.Text != "" ? float.Parse(textBox31.Text) : V,
                    R19 = textBox32.Text != "" ? float.Parse(textBox32.Text) : V,
                    R20 = textBox30.Text != "" ? float.Parse(textBox30.Text) : V,
                };
            }
            catch
            {
                MessageBox.Show("Error in Input RX section.");
                return;
            }
            try
            {
                round.R2 = new RoundDetail()
                {
                    AddToTotalRep = textBox56.Text != "" ? float.Parse(textBox56.Text) : V,
                    AddToTotalTime = textBox58.Text != "" ? float.Parse(textBox58.Text) : V,
                    AMRAP = textBox63.Text != "" ? float.Parse(textBox63.Text) : V,
                    CapTime = textBox65.Text != "" ? float.Parse(textBox65.Text) : V,
                    FTRound = textBox55.Text != "" ? float.Parse(textBox55.Text) : V,
                    RestBetMov = textBox59.Text != "" ? float.Parse(textBox59.Text) : V,
                    RestBetRep = textBox57.Text != "" ? float.Parse(textBox57.Text) : V,
                    RestBetSet = textBox61.Text != "" ? float.Parse(textBox61.Text) : V,
                    TimeEvery = textBox60.Text != "" ? float.Parse(textBox60.Text) : V,
                    TimeFor = textBox62.Text != "" ? float.Parse(textBox62.Text) : V,
                    TimeRest = textBox54.Text != "" ? float.Parse(textBox54.Text) : V,
                    TRound = textBox64.Text != "" ? float.Parse(textBox64.Text) : V,
                    TSet = textBox67.Text != "" ? float.Parse(textBox67.Text) : V,
                    TWork = textBox66.Text != "" ? float.Parse(textBox66.Text) : V,
                    R1 = textBox53.Text != "" ? float.Parse(textBox53.Text) : V,
                    R2 = textBox45.Text != "" ? float.Parse(textBox45.Text) : V,
                    R3 = textBox49.Text != "" ? float.Parse(textBox49.Text) : V,
                    R4 = textBox41.Text != "" ? float.Parse(textBox41.Text) : V,
                    R5 = textBox51.Text != "" ? float.Parse(textBox51.Text) : V,
                    R6 = textBox43.Text != "" ? float.Parse(textBox43.Text) : V,
                    R7 = textBox47.Text != "" ? float.Parse(textBox47.Text) : V,
                    R8 = textBox39.Text != "" ? float.Parse(textBox39.Text) : V,
                    R9 = textBox52.Text != "" ? float.Parse(textBox52.Text) : V,
                    R10 = textBox44.Text != "" ? float.Parse(textBox44.Text) : V,
                    R11 = textBox48.Text != "" ? float.Parse(textBox48.Text) : V,
                    R12 = textBox40.Text != "" ? float.Parse(textBox40.Text) : V,
                    R13 = textBox50.Text != "" ? float.Parse(textBox50.Text) : V,
                    R14 = textBox42.Text != "" ? float.Parse(textBox42.Text) : V,
                    R15 = textBox46.Text != "" ? float.Parse(textBox46.Text) : V,
                    R16 = textBox38.Text != "" ? float.Parse(textBox38.Text) : V,
                    R17 = textBox37.Text != "" ? float.Parse(textBox37.Text) : V,
                    R18 = textBox35.Text != "" ? float.Parse(textBox35.Text) : V,
                    R19 = textBox36.Text != "" ? float.Parse(textBox36.Text) : V,
                    R20 = textBox34.Text != "" ? float.Parse(textBox34.Text) : V,
                };
            }
            catch
            {
                MessageBox.Show("Error in Input R2 section.");
                return;
            }

            try
            {
                round.R3 = new RoundDetail()
                {
                    AddToTotalRep = textBox90.Text != "" ? float.Parse(textBox90.Text) : V,
                    AddToTotalTime = textBox92.Text != "" ? float.Parse(textBox92.Text) : V,
                    AMRAP = textBox97.Text != "" ? float.Parse(textBox97.Text) : V,
                    CapTime = textBox99.Text != "" ? float.Parse(textBox99.Text) : V,
                    FTRound = textBox89.Text != "" ? float.Parse(textBox89.Text) : V,
                    RestBetMov = textBox93.Text != "" ? float.Parse(textBox93.Text) : V,
                    RestBetRep = textBox91.Text != "" ? float.Parse(textBox91.Text) : V,
                    RestBetSet = textBox95.Text != "" ? float.Parse(textBox95.Text) : V,
                    TimeEvery = textBox94.Text != "" ? float.Parse(textBox94.Text) : V,
                    TimeFor = textBox96.Text != "" ? float.Parse(textBox96.Text) : V,
                    TimeRest = textBox88.Text != "" ? float.Parse(textBox88.Text) : V,
                    TRound = textBox98.Text != "" ? float.Parse(textBox98.Text) : V,
                    TSet = textBox101.Text != "" ? float.Parse(textBox101.Text) : V,
                    TWork = textBox100.Text != "" ? float.Parse(textBox100.Text) : V,
                    R1 = textBox87.Text != "" ? float.Parse(textBox87.Text) : V,
                    R2 = textBox79.Text != "" ? float.Parse(textBox79.Text) : V,
                    R3 = textBox83.Text != "" ? float.Parse(textBox83.Text) : V,
                    R4 = textBox75.Text != "" ? float.Parse(textBox75.Text) : V,
                    R5 = textBox85.Text != "" ? float.Parse(textBox85.Text) : V,
                    R6 = textBox77.Text != "" ? float.Parse(textBox77.Text) : V,
                    R7 = textBox81.Text != "" ? float.Parse(textBox81.Text) : V,
                    R8 = textBox73.Text != "" ? float.Parse(textBox73.Text) : V,
                    R9 = textBox86.Text != "" ? float.Parse(textBox86.Text) : V,
                    R10 = textBox78.Text != "" ? float.Parse(textBox78.Text) : V,
                    R11 = textBox82.Text != "" ? float.Parse(textBox82.Text) : V,
                    R12 = textBox74.Text != "" ? float.Parse(textBox74.Text) : V,
                    R13 = textBox84.Text != "" ? float.Parse(textBox84.Text) : V,
                    R14 = textBox76.Text != "" ? float.Parse(textBox76.Text) : V,
                    R15 = textBox80.Text != "" ? float.Parse(textBox80.Text) : V,
                    R16 = textBox72.Text != "" ? float.Parse(textBox72.Text) : V,
                    R17 = textBox71.Text != "" ? float.Parse(textBox71.Text) : V,
                    R18 = textBox69.Text != "" ? float.Parse(textBox69.Text) : V,
                    R19 = textBox70.Text != "" ? float.Parse(textBox70.Text) : V,
                    R20 = textBox68.Text != "" ? float.Parse(textBox68.Text) : V,
                };
            }
            catch
            {
                MessageBox.Show("Error in Input R2 section.");
                return;
            }

        }
        private void button9_Click(object sender, EventArgs e)
        {
            Mov mov = new Mov();
            mov.KWeightScaled1 = textBox119.Text != "" ? float.Parse(textBox119.Text) : V;
            mov.MovementType = (string)comboBox10.SelectedItem;
            try
            {
                mov.RX = new MovDetail()
                {
                    DistanceMale = textBox109.Text != "" ? float.Parse(textBox109.Text) : V,
                    HeightFeMale = textBox106.Text != "" ? float.Parse(textBox106.Text) : V,
                    HeightMale = textBox107.Text != "" ? float.Parse(textBox107.Text) : V,
                    Movement = (string)comboBox3.SelectedItem,
                    MRest = textBox114.Text != "" ? float.Parse(textBox114.Text) : V,
                    MRestBetSet = textBox116.Text != "" ? float.Parse(textBox116.Text) : V,
                    MRound = textBox113.Text != "" ? float.Parse(textBox113.Text) : V,
                    MSet = textBox114.Text != "" ? float.Parse(textBox114.Text) : V,
                    MWork = textBox112.Text != "" ? float.Parse(textBox112.Text) : V,
                    Part = (string)comboBox1.SelectedItem,
                    Rep = textBox103.Text != "" ? float.Parse(textBox103.Text) : V,
                    RestBet = textBox117.Text != "" ? float.Parse(textBox117.Text) : V,
                    SubPart = (string)comboBox2.SelectedItem,
                    TimeFeMale = textBox110.Text != "" ? float.Parse(textBox110.Text) : V,
                    TimeMale = textBox111.Text != "" ? float.Parse(textBox111.Text) : V,
                    WeightFeMale = textBox105.Text != "" ? float.Parse(textBox105.Text) : V,
                    WeightMale = textBox104.Text != "" ? float.Parse(textBox104.Text) : V,
                    Call = textBox115.Text != "" ? float.Parse(textBox115.Text) : V,
                    DistanceFeMale = textBox108.Text != "" ? float.Parse(textBox108.Text) : V,
                };
            }
            catch (Exception er)
            {
                MessageBox.Show("irad dar vorood Data RX " + er.Message);
                return;

            }

            try
            {

                var DistanceMale = textBox132.Text != "" ? float.Parse(textBox132.Text) : V;
                var HeightFeMale = textBox131.Text != "" ? float.Parse(textBox131.Text) : V;
                var HeightMale = textBox134.Text != "" ? float.Parse(textBox134.Text) : V;
                var Movement = (string)comboBox5.SelectedItem;
                var MRest = textBox126.Text != "" ? float.Parse(textBox126.Text) : V;
                var MRestBetSet = textBox123.Text != "" ? float.Parse(textBox123.Text) : V;
                var MRound = textBox125.Text != "" ? float.Parse(textBox113.Text) : V;
                var MSet = textBox137.Text != "" ? float.Parse(textBox137.Text) : V;
                var MWork = textBox127.Text != "" ? float.Parse(textBox127.Text) : V;
                var Part = (string)comboBox4.SelectedItem;
                var Rep = textBox136.Text != "" ? float.Parse(textBox136.Text) : V;
                var RestBet = textBox122.Text != "" ? float.Parse(textBox122.Text) : V;
                var SubPart = (string)comboBox6.SelectedItem;
                var TimeFeMale = textBox128.Text != "" ? float.Parse(textBox128.Text) : V;
                var TimeMale = textBox129.Text != "" ? float.Parse(textBox129.Text) : V;
                var WeightFeMale = textBox133.Text != "" ? float.Parse(textBox133.Text) : V;
                var WeightMale = textBox135.Text != "" ? float.Parse(textBox135.Text) : V;
                var Call = textBox124.Text != "" ? float.Parse(textBox124.Text) : V;
                var DistanceFeMale = textBox130.Text != "" ? float.Parse(textBox130.Text) : V;

                mov.S2 = new MovDetail()
                {
                    DistanceMale = textBox132.Text != "" ? float.Parse(textBox132.Text) : V,
                    HeightFeMale = textBox131.Text != "" ? float.Parse(textBox131.Text) : V,
                    HeightMale = textBox134.Text != "" ? float.Parse(textBox134.Text) : V,
                    Movement = (string)comboBox5.SelectedItem,
                    MRest = textBox126.Text != "" ? float.Parse(textBox126.Text) : V,
                    MRestBetSet = textBox123.Text != "" ? float.Parse(textBox123.Text) : V,
                    MRound = textBox125.Text != "" ? float.Parse(textBox113.Text) : V,
                    MSet = textBox137.Text != "" ? float.Parse(textBox137.Text) : V,
                    MWork = textBox127.Text != "" ? float.Parse(textBox127.Text) : V,
                    Part = (string)comboBox4.SelectedItem,
                    Rep = textBox136.Text != "" ? float.Parse(textBox136.Text) : V,
                    RestBet = textBox122.Text != "" ? float.Parse(textBox122.Text) : V,
                    SubPart = (string)comboBox6.SelectedItem,
                    TimeFeMale = textBox128.Text != "" ? float.Parse(textBox128.Text) : V,
                    TimeMale = textBox129.Text != "" ? float.Parse(textBox129.Text) : V,
                    WeightFeMale = textBox133.Text != "" ? float.Parse(textBox133.Text) : V,
                    WeightMale = textBox135.Text != "" ? float.Parse(textBox135.Text) : V,
                    Call = textBox124.Text != "" ? float.Parse(textBox124.Text) : V,
                    DistanceFeMale = textBox130.Text != "" ? float.Parse(textBox130.Text) : V,
                };
            }
            catch (Exception er)
            {
                MessageBox.Show("irad dar vorood Data S2 " + er.Message);
                return;

            }

            try
            {
                mov.S3 = new MovDetail()
                {
                    DistanceMale = textBox150.Text != "" ? float.Parse(textBox150.Text) : V,
                    HeightFeMale = textBox149.Text != "" ? float.Parse(textBox149.Text) : V,
                    HeightMale = textBox152.Text != "" ? float.Parse(textBox152.Text) : V,
                    Movement = (string)comboBox8.SelectedItem,
                    MRest = textBox144.Text != "" ? float.Parse(textBox144.Text) : V,
                    MRestBetSet = textBox141.Text != "" ? float.Parse(textBox141.Text) : V,
                    MRound = textBox143.Text != "" ? float.Parse(textBox143.Text) : V,
                    MSet = textBox155.Text != "" ? float.Parse(textBox155.Text) : V,
                    MWork = textBox145.Text != "" ? float.Parse(textBox145.Text) : V,
                    Part = (string)comboBox7.SelectedItem,
                    Rep = textBox154.Text != "" ? float.Parse(textBox154.Text) : V,
                    RestBet = textBox140.Text != "" ? float.Parse(textBox140.Text) : V,
                    SubPart = (string)comboBox9.SelectedItem,
                    TimeFeMale = textBox146.Text != "" ? float.Parse(textBox146.Text) : V,
                    TimeMale = textBox147.Text != "" ? float.Parse(textBox147.Text) : V,
                    WeightFeMale = textBox151.Text != "" ? float.Parse(textBox151.Text) : V,
                    WeightMale = textBox153.Text != "" ? float.Parse(textBox153.Text) : V,
                    Call = textBox142.Text != "" ? float.Parse(textBox142.Text) : V,
                    DistanceFeMale = textBox148.Text != "" ? float.Parse(textBox148.Text) : V,
                };
            }
            catch (Exception er)
            {
                MessageBox.Show("irad dar vorood Data S3 " + er.Message);
                return;
            }


            evolvedVOD.movs.Add(mov);

            var strVOD = JsonConvert.SerializeObject(mov);
            richTextBoxGigaVOD.Text = richTextBoxGigaVOD.Text + strVOD + "\n" + "---------------" + "\n";
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
                    if ((string)comboBox1.SelectedItem == "تی آر ایکس")
                        comboBox3.Items.AddRange(Upperbody);
                    else
                        comboBox3.Items.AddRange(new string[] { });
                    break;
                case "پایین تنه":
                    if ((string)comboBox1.SelectedItem == "تی آر ایکس")
                        comboBox3.Items.AddRange(Lowerbody);
                    else
                        comboBox3.Items.AddRange(new string[] { });
                    break;

                default:
                    // code block
                    break;
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Enabled = true;
            string[] installsVazneBardari = new string[] { "هالتر", "دمبل", "کتل بل", "مدیسن بال" };
            string[] installsZhimnastik = new string[] { "میله و دارحلقه", "با وزن بدن", "با تجهیزات" };
            string[] installsKardio = new string[] { "کاردیو" };
            string[] installsParvareshAndam = new string[] { "سرشانه", "سینه", "پشت", "بازو و ساعد", "ران و ساق" };
            string[] installsTRX = new string[] { "بالاتنه", "پایین تنه" };
            string[] installsKesheshi = new string[] { "بالاتنه", "پایین تنه" };

            comboBox9.Items.Clear();
            comboBox9.Text = "Select";
            comboBox8.Text = "Select";

            switch (comboBox7.SelectedItem)
            {
                case "وزنه برداری":
                    comboBox9.Items.AddRange(installsVazneBardari);
                    break;
                case "ژیمناستیک":
                    comboBox9.Items.AddRange(installsZhimnastik);
                    break;
                case "کاردیو":
                    comboBox9.Items.AddRange(installsKardio);
                    break;
                case "پرورش اندام":
                    comboBox9.Items.AddRange(installsParvareshAndam);
                    break;
                case "کششی":
                    comboBox9.Items.AddRange(installsKesheshi);
                    break;
                case "تی آر ایکس":
                    comboBox9.Items.AddRange(installsTRX);
                    break;
                default:
                    // code block
                    break;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
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

            comboBox8.Enabled = true;

            comboBox8.Items.Clear();
            comboBox8.Text = "Select";

            switch (comboBox9.SelectedItem)
            {
                case "هالتر":
                    comboBox8.Items.AddRange(Halter);
                    break;
                case "دمبل":
                    comboBox8.Items.AddRange(Dumbbell);
                    break;
                case "کتل بل":
                    comboBox8.Items.AddRange(Kettlebell);
                    break;
                case "مدیسن بال":
                    comboBox8.Items.AddRange(Medicineball);
                    break;
                case "میله و دارحلقه":
                    comboBox8.Items.AddRange(BarAndring);
                    break;
                case "با وزن بدن":
                    comboBox8.Items.AddRange(BodyWeight);
                    break;
                case "با تجهیزات":
                    comboBox8.Items.AddRange(Equipmentbeased);
                    break;
                case "کاردیو":
                    comboBox8.Items.AddRange(Metcan);
                    break;
                case "سرشانه":
                    comboBox8.Items.AddRange(Shoulder);
                    break;
                case "سینه":
                    comboBox8.Items.AddRange(Chest);
                    break;
                case "پشت":
                    comboBox8.Items.AddRange(Back);
                    break;
                case "بازو و ساعد":
                    comboBox8.Items.AddRange(Arm);
                    break;
                case "ران و ساق":
                    comboBox8.Items.AddRange(Leg);
                    break;
                case "بالاتنه":
                    if ((string)comboBox7.SelectedItem == "تی آر ایکس")
                        comboBox8.Items.AddRange(Upperbody);
                    else
                        comboBox8.Items.AddRange(new string[] { });
                    break;
                case "پایین تنه":
                    if ((string)comboBox7.SelectedItem == "تی آر ایکس")
                        comboBox8.Items.AddRange(Lowerbody);
                    else
                        comboBox8.Items.AddRange(new string[] { });
                    break;

                default:
                    // code block
                    break;
            }
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            evolvedVOD.infoVOD = new InfoVOD()
            {
                Description = richTextBoxDesc.Text,
                EditType = listBox3.Items.Cast<String>().ToList(),
                EnergyPath = listBox2.Items.Cast<String>().ToList(),
                ManualProgram = richTextBox1.Text,
                NameAndFamilyName = textBoxTime.Text,
                VODName = textBoxName.Text,
                Pattern = listBox1.Items.Cast<String>().ToList(),
                PublicSkill = listBox5.Items.Cast<String>().ToList(),
                Special = listBoxSUBody.Items.Cast<String>().ToList(),
                Time = listBox4.Items.Cast<String>().ToList(),
                Type = listBox6.Items.Cast<String>().ToList(),
            };

            try
            {

                evolvedVOD.round = new Round();
                evolvedVOD.round.RX = new RoundDetail()
                {
                    AddToTotalRep = textBox10.Text != "" ? float.Parse(textBox10.Text) : V,
                    AddToTotalTime = textBox8.Text != "" ? float.Parse(textBox8.Text) : V,
                    AMRAP = textBox1.Text != "" ? float.Parse(textBox1.Text) : V,
                    CapTime = textBox3.Text != "" ? float.Parse(textBox3.Text) : V,
                    FTRound = textBoxTadil.Text != "" ? float.Parse(textBoxTadil.Text) : V,
                    RestBetMov = textBox5.Text != "" ? float.Parse(textBox5.Text) : V,
                    RestBetRep = textBox6.Text != "" ? float.Parse(textBox6.Text) : V,
                    RestBetSet = textBox4.Text != "" ? float.Parse(textBox4.Text) : V,
                    TimeEvery = textBox12.Text != "" ? float.Parse(textBox12.Text) : V,
                    TimeFor = textBox11.Text != "" ? float.Parse(textBox11.Text) : V,
                    TimeRest = textBox13.Text != "" ? float.Parse(textBox13.Text) : V,
                    TRound = textBox7.Text != "" ? float.Parse(textBox7.Text) : V,
                    TSet = textBox2.Text != "" ? float.Parse(textBox2.Text) : V,
                    TWork = textBox9.Text != "" ? float.Parse(textBox9.Text) : V,
                    R1 = textBox14.Text != "" ? float.Parse(textBox14.Text) : V,
                    R2 = textBox15.Text != "" ? float.Parse(textBox15.Text) : V,
                    R3 = textBox17.Text != "" ? float.Parse(textBox17.Text) : V,
                    R4 = textBox16.Text != "" ? float.Parse(textBox16.Text) : V,
                    R5 = textBox21.Text != "" ? float.Parse(textBox21.Text) : V,
                    R6 = textBox19.Text != "" ? float.Parse(textBox19.Text) : V,
                    R7 = textBox20.Text != "" ? float.Parse(textBox20.Text) : V,
                    R8 = textBox18.Text != "" ? float.Parse(textBox18.Text) : V,
                    R9 = textBox29.Text != "" ? float.Parse(textBox29.Text) : V,
                    R10 = textBox25.Text != "" ? float.Parse(textBox25.Text) : V,
                    R11 = textBox27.Text != "" ? float.Parse(textBox27.Text) : V,
                    R12 = textBox23.Text != "" ? float.Parse(textBox23.Text) : V,
                    R13 = textBox28.Text != "" ? float.Parse(textBox28.Text) : V,
                    R14 = textBox24.Text != "" ? float.Parse(textBox24.Text) : V,
                    R15 = textBox26.Text != "" ? float.Parse(textBox26.Text) : V,
                    R16 = textBox22.Text != "" ? float.Parse(textBox22.Text) : V,
                    R17 = textBox33.Text != "" ? float.Parse(textBox33.Text) : V,
                    R18 = textBox31.Text != "" ? float.Parse(textBox31.Text) : V,
                    R19 = textBox32.Text != "" ? float.Parse(textBox32.Text) : V,
                    R20 = textBox30.Text != "" ? float.Parse(textBox30.Text) : V,
                };
            }
            catch (Exception e3)
            {
                MessageBox.Show("Error in Input RX section.");
                MessageBox.Show(e3.Message);
                return;
            }
            try
            {
                evolvedVOD.round.R2 = new RoundDetail()
                {
                    AddToTotalRep = textBox56.Text != "" ? float.Parse(textBox56.Text) : V,
                    AddToTotalTime = textBox58.Text != "" ? float.Parse(textBox58.Text) : V,
                    AMRAP = textBox63.Text != "" ? float.Parse(textBox63.Text) : V,
                    CapTime = textBox65.Text != "" ? float.Parse(textBox65.Text) : V,
                    FTRound = textBox55.Text != "" ? float.Parse(textBox55.Text) : V,
                    RestBetMov = textBox59.Text != "" ? float.Parse(textBox59.Text) : V,
                    RestBetRep = textBox57.Text != "" ? float.Parse(textBox57.Text) : V,
                    RestBetSet = textBox61.Text != "" ? float.Parse(textBox61.Text) : V,
                    TimeEvery = textBox60.Text != "" ? float.Parse(textBox60.Text) : V,
                    TimeFor = textBox62.Text != "" ? float.Parse(textBox62.Text) : V,
                    TimeRest = textBox54.Text != "" ? float.Parse(textBox54.Text) : V,
                    TRound = textBox64.Text != "" ? float.Parse(textBox64.Text) : V,
                    TSet = textBox67.Text != "" ? float.Parse(textBox67.Text) : V,
                    TWork = textBox66.Text != "" ? float.Parse(textBox66.Text) : V,
                    R1 = textBox53.Text != "" ? float.Parse(textBox53.Text) : V,
                    R2 = textBox45.Text != "" ? float.Parse(textBox45.Text) : V,
                    R3 = textBox49.Text != "" ? float.Parse(textBox49.Text) : V,
                    R4 = textBox41.Text != "" ? float.Parse(textBox41.Text) : V,
                    R5 = textBox51.Text != "" ? float.Parse(textBox51.Text) : V,
                    R6 = textBox43.Text != "" ? float.Parse(textBox43.Text) : V,
                    R7 = textBox47.Text != "" ? float.Parse(textBox47.Text) : V,
                    R8 = textBox39.Text != "" ? float.Parse(textBox39.Text) : V,
                    R9 = textBox52.Text != "" ? float.Parse(textBox52.Text) : V,
                    R10 = textBox44.Text != "" ? float.Parse(textBox44.Text) : V,
                    R11 = textBox48.Text != "" ? float.Parse(textBox48.Text) : V,
                    R12 = textBox40.Text != "" ? float.Parse(textBox40.Text) : V,
                    R13 = textBox50.Text != "" ? float.Parse(textBox50.Text) : V,
                    R14 = textBox42.Text != "" ? float.Parse(textBox42.Text) : V,
                    R15 = textBox46.Text != "" ? float.Parse(textBox46.Text) : V,
                    R16 = textBox38.Text != "" ? float.Parse(textBox38.Text) : V,
                    R17 = textBox37.Text != "" ? float.Parse(textBox37.Text) : V,
                    R18 = textBox35.Text != "" ? float.Parse(textBox35.Text) : V,
                    R19 = textBox36.Text != "" ? float.Parse(textBox36.Text) : V,
                    R20 = textBox34.Text != "" ? float.Parse(textBox34.Text) : V,
                };
            }
            catch
            {
                MessageBox.Show("Error in Input R2 section.");
                return;
            }

            try
            {
                evolvedVOD.round.R3 = new RoundDetail()
                {
                    AddToTotalRep = textBox90.Text != "" ? float.Parse(textBox90.Text) : V,
                    AddToTotalTime = textBox92.Text != "" ? float.Parse(textBox92.Text) : V,
                    AMRAP = textBox97.Text != "" ? float.Parse(textBox97.Text) : V,
                    CapTime = textBox99.Text != "" ? float.Parse(textBox99.Text) : V,
                    FTRound = textBox89.Text != "" ? float.Parse(textBox89.Text) : V,
                    RestBetMov = textBox93.Text != "" ? float.Parse(textBox93.Text) : V,
                    RestBetRep = textBox91.Text != "" ? float.Parse(textBox91.Text) : V,
                    RestBetSet = textBox95.Text != "" ? float.Parse(textBox95.Text) : V,
                    TimeEvery = textBox94.Text != "" ? float.Parse(textBox94.Text) : V,
                    TimeFor = textBox96.Text != "" ? float.Parse(textBox96.Text) : V,
                    TimeRest = textBox88.Text != "" ? float.Parse(textBox88.Text) : V,
                    TRound = textBox98.Text != "" ? float.Parse(textBox98.Text) : V,
                    TSet = textBox101.Text != "" ? float.Parse(textBox101.Text) : V,
                    TWork = textBox100.Text != "" ? float.Parse(textBox100.Text) : V,
                    R1 = textBox87.Text != "" ? float.Parse(textBox87.Text) : V,
                    R2 = textBox79.Text != "" ? float.Parse(textBox79.Text) : V,
                    R3 = textBox83.Text != "" ? float.Parse(textBox83.Text) : V,
                    R4 = textBox75.Text != "" ? float.Parse(textBox75.Text) : V,
                    R5 = textBox85.Text != "" ? float.Parse(textBox85.Text) : V,
                    R6 = textBox77.Text != "" ? float.Parse(textBox77.Text) : V,
                    R7 = textBox81.Text != "" ? float.Parse(textBox81.Text) : V,
                    R8 = textBox73.Text != "" ? float.Parse(textBox73.Text) : V,
                    R9 = textBox86.Text != "" ? float.Parse(textBox86.Text) : V,
                    R10 = textBox78.Text != "" ? float.Parse(textBox78.Text) : V,
                    R11 = textBox82.Text != "" ? float.Parse(textBox82.Text) : V,
                    R12 = textBox74.Text != "" ? float.Parse(textBox74.Text) : V,
                    R13 = textBox84.Text != "" ? float.Parse(textBox84.Text) : V,
                    R14 = textBox76.Text != "" ? float.Parse(textBox76.Text) : V,
                    R15 = textBox80.Text != "" ? float.Parse(textBox80.Text) : V,
                    R16 = textBox72.Text != "" ? float.Parse(textBox72.Text) : V,
                    R17 = textBox71.Text != "" ? float.Parse(textBox71.Text) : V,
                    R18 = textBox69.Text != "" ? float.Parse(textBox69.Text) : V,
                    R19 = textBox70.Text != "" ? float.Parse(textBox70.Text) : V,
                    R20 = textBox68.Text != "" ? float.Parse(textBox68.Text) : V,
                };
            }
            catch
            {
                MessageBox.Show("Error in Input R2 section.");
                return;
            }


            Com.VOD mVOD = new Com.VOD()
            {
                Info = JsonConvert.SerializeObject(evolvedVOD.infoVOD),
                Movment = JsonConvert.SerializeObject(evolvedVOD.movs),
                Round = JsonConvert.SerializeObject(evolvedVOD.round),
                DesignerName = textBoxTime.Text,
                DesignerUID = 0,
                Moment = DateTime.Now,
                Name = textBoxName.Text,
                IsPreMade = true
            };

            string resStr = await PostToServerVOD(mVOD);
            int ResInt = Int32.Parse(resStr);
            if (ResInt > 0)
            {
                MessageBox.Show("با موفقیت ارسال شد");
            }
            else
            {
                MessageBox.Show("ظاهرا با مشکل به وجود آمده");
            }
        }

        public async Task<string> PostToServerVOD(Com.VOD mVOD)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {
                        StringContent contentBody = new StringContent(JsonConvert.SerializeObject(mVOD));
                        form.Add(contentBody, "Object");

                        ImageConverter imgConverter = new ImageConverter();
                        var imgBytes = (System.Byte[])imgConverter.ConvertTo(pictureBoxImg.Image, Type.GetType("System.Byte[]"));
                        var fileContent = new ByteArrayContent(imgBytes);
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        form.Add(fileContent, "File", ".gif");

                        HttpResponseMessage response = await httpClient.PostAsync(BaseAddress + "fitness/VOD/PostVOD", form);

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
                return "-199";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                InfoVOD infoVOD = new InfoVOD()
                {
                    Description = richTextBoxDesc.Text,
                    EditType = listBox3.Items.Cast<String>().ToList(),
                    EnergyPath = listBox2.Items.Cast<String>().ToList(),
                    ManualProgram = richTextBox1.Text,
                    NameAndFamilyName = textBoxTime.Text,
                    Pattern = listBox1.Items.Cast<String>().ToList(),
                    PublicSkill = listBox5.Items.Cast<String>().ToList(),
                    Special = listBoxSUBody.Items.Cast<String>().ToList(),
                    Time = listBox4.Items.Cast<String>().ToList(),
                    Type = listBox6.Items.Cast<String>().ToList(),
                    VODName = textBoxName.Text,
                };
            }
            catch
            {
                MessageBox.Show("irad dar Inputs");
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
                    pictureBoxImg.Image = new Bitmap(openFileDialog1.FileName);
                }

            }
            catch (Exception eee)
            {
                Console.WriteLine(eee.Message);
            }
        }

        private void FormWOD_FormClosed(object sender, FormClosedEventArgs e)
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

        private void textBoxTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }

    public class InfoVOD
    {
        public string VODName { get; set; }
        public string NameAndFamilyName { get; set; }
        public string Description { get; set; }
        public string ManualProgram { get; set; }
        public List<string> EditType { get; set; }
        public List<string> Special { get; set; }
        public List<string> Pattern { get; set; }
        public List<string> Type { get; set; }
        public List<string> EnergyPath { get; set; }
        public List<string> PublicSkill { get; set; }
        public List<string> Time { get; set; }
    }
    public class Round
    {
        public RoundDetail RX { get; set; }
        public RoundDetail R2 { get; set; }
        public RoundDetail R3 { get; set; }
    }
    public class RoundDetail
    {
        public float FTRound { get; set; }
        public float AMRAP { get; set; }
        public float TSet { get; set; }
        public float CapTime { get; set; }
        public float TRound { get; set; }
        public float TWork { get; set; }
        public float TimeRest { get; set; }
        public float TimeEvery { get; set; }
        public float TimeFor { get; set; }
        public float RestBetMov { get; set; }
        public float RestBetSet { get; set; }
        public float RestBetRep { get; set; }
        public float AddToTotalTime { get; set; }
        public float AddToTotalRep { get; set; }
        public float R1 { get; set; }
        public float R2 { get; set; }
        public float R3 { get; set; }
        public float R4 { get; set; }
        public float R5 { get; set; }
        public float R6 { get; set; }
        public float R7 { get; set; }
        public float R8 { get; set; }
        public float R9 { get; set; }
        public float R10 { get; set; }
        public float R11 { get; set; }
        public float R12 { get; set; }
        public float R13 { get; set; }
        public float R14 { get; set; }
        public float R15 { get; set; }
        public float R16 { get; set; }
        public float R17 { get; set; }
        public float R18 { get; set; }
        public float R19 { get; set; }
        public float R20 { get; set; }
    }
    public class Mov
    {
        public string MovementType { get; set; }
        public float KWeightScaled1 { get; set; }
        public MovDetail RX { get; set; }
        public MovDetail S2 { get; set; }
        public MovDetail S3 { get; set; }
    }
    public class MovDetail
    {
        public string Part { get; set; }
        public string SubPart { get; set; }
        public string Movement { get; set; }
        public float WeightMale { get; set; }
        public float WeightFeMale { get; set; }
        public float HeightMale { get; set; }
        public float HeightFeMale { get; set; }
        public float DistanceMale { get; set; }
        public float DistanceFeMale { get; set; }
        public float TimeMale { get; set; }
        public float TimeFeMale { get; set; }
        public float MWork { get; set; }
        public float MRest { get; set; }
        public float MRound { get; set; }
        public float Call { get; set; }
        public float MRestBetSet { get; set; }
        public float RestBet { get; set; }
        public float MSet { get; set; }
        public float Rep { get; set; }
    }

    public class EvolvedVOD
    {
        public InfoVOD infoVOD { get; set; }
        public Round round { get; set; }
        public List<Mov> movs { get; set; }
    }
}
