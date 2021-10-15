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
        //string BaseAddress = "https://www.hasma.ir/";
        //string BaseAddress = "http://193.105.234.83:80/";
        string BaseAddress = "http://193.105.234.83/";
        public FormAmoozesh()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            string[] installsVazneBardari = new string[] { "هالتر", "دمبل", "کتل بل", "تجهیزات" };
            string[] installsZhimnastik = new string[] { "میله و دارحلقه", "وزن بدن" };
            string[] installsKardio = new string[] { "کاردیو" };
            string[] installsParvareshAndam = new string[] { "سرشانه", "سینه", "پشت", "بازو و ساعد", "ران و ساق", "میان تنه" };
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
                case "کش مقاومتی":
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
"Shoulder Press",
"Push Press",
"Push Jerk",
"Split Jerk",
"Snatch Balance",
"Sots Press",
"Thruster",
"Back Squat",
"Front Squat",
"Overhead Squat",
"Zercher Squat",
"Bulgarian Split Squat",
"Deadlift",
"Romanian Deadlift",
"Deficit Deadlift",
"Sumo Deadlift",
"Snatch Deadlift",
"Sumo Deadlift High Pull",
"Back Rack Lunge",
"Front Rack Lunge",
"Overhead Lunge",
"Zercher Lunge",
"Back Rack Walking Lunge",
"Front Rack Walking Lunge",
"Overhead Walking Lunge",
"Zercher Walking Lunge",
"Bench Press",
"Good Morning",
"Ground to Shoulder",
"Shoulder to Overhead",
"Ground to Overhead",
"Snatch Pull",
"Snatch",
"Squat Snatch",
"Power Snatch",
"Hang Snatch",
"Hang Squat Snatch",
"Hang Power Snatch",
"High Hang Snatch",
"High Hang Squat Snatch",
"High Hang Power Snatch",
"Tall Snatch",
"Tall Squat Snatch",
"Tall Power Snatch",
"Muscle Snatch",
"Hang Muscle Snatch",
"Tall Muscle Snatch",
"Split Snatch",
"Hang Split Snatch",
"Tall Split Snatch",
"Clean Pull",
"Clean",
"Squat Clean",
"Power Clean",
"Hang Clean",
"Hang Squat Clean",
"Hang Power Clean",
"High Hang Clean",
"High Hang Squat Clean",
"High Hang  Power Clean",
"Tall Clean",
"Tall Squat Clean",
"Tall Power Clean",
"Muscle Clean",
"Hang Muscle Clean",
"Tall Muscle Clean",
"Split Clean",
"Hang Split Clean",
"Tall Split Clean",
"Clean & Jerk",
"Squat Clean & Push Jerk",
"Power clean & Push Jerk",
"Squat Clean & Split Jerk",
"Power Clean & Split Jerk",
"Hang Clean & Jerk",
"Hang Squat Clean & Push Jerk",
"Hang Power Clean & Push Jerk",
"Hang Squat Clean & Split Jerk",
"Hang Power Clean & Split Jerk",
"Tall Clean & Jerk",
"Tall Squat Clean & Push Jerk",
"Tall Power Clean & Push Jerk",
"Tall Squat Clean & Split Jerk",
"Tall Power Clean & Split Jerk",
"Muscle Clean & Push Jerk",
"Muscle Clean & Split Jerk",
"Cluster",
"Hang Cluster",
"Burgener Warm-up",
"Farmer Carry",
"Yoke Carry"
            };

            string[] Dumbbell = new string[] {
"DB Shoulder Press",
"Single arm DB Shoulder Press",
"DB Push Press",
"Single arm DB Push Press",
"DB Push Jerk",
"Single arm DB Push Jerk",
"DB Split Jerk",
"Single arm DB Split Jerk",
"DB Thruster",
"Single arm DB Thruster",
"DB Squat",
"DB Front Squat",
"DB Overhead Squat",
"Double arm DB Overhead Squat",
"Single arm DB Overhead Squat",
"Right arm DB Overhead Squat",
"Left arm DB Overhead Squat",
"DB Goblet Squat",
"DB Deadlift",
"DB Sumo Deadlift",
"DB Sumo Deadlift High Pull",
"DB Lunge",
"DB Front Rack Lunge",
"DB Overhead Lunge",
"Single arm DB Overhead Lunge",
"Right arm DB Overhead Lunge",
"Left arm DB Overhead Lunge",
"DB Walking Lunge",
"DB Front Rack Walking Lunge",
"DB Overhead Walking Lunge",
"Single arm DB Overhead Walking Lunge",
"Right arm DB Overhead Walking Lunge",
"Left arm DB Overhead Walking Lunge",
"DB Swing",
"DB Swing (USA)",
"DB Swing (RUS)",
"DB Ground to Shoulder",
"DB Shoulder to Overhead",
"DB Ground to Overhead",
"DB Snatch",
"DB Squat Snatch",
"DB Power Snatch",
"DB Hang Snatch",
"DB Hang Squat Snatch",
"DB Hang Power Snatch",
"DB High Hang Snatch",
"DB High Hang Squat Snatch",
"DB High Hang Power Snatch",
"DB Tall Snatch",
"DB Tall Squat Snatch",
"DB Tall Power Snatch",
"DB Muscle Snatch",
"DB Hang Muscle Snatch",
"DB Tall Muscle Snatch",
"Alternating DB Snatch",
"Alternating DB Squat Snatch",
"Alternating DB Power Snatch",
"Alternating DB Hang Snatch",
"Alternating DB Hang Squat Snatch",
"Alternating DB Hang Power Snatch",
"Alternating DB High Hang Snatch",
"Alternating DB High Hang Squat Snatch",
"Alternating DB High Hang Power Snatch",
"Alternating DB Tall Snatch",
"Alternating DB Tall Squat Snatch",
"Alternating DB Tall Power Snatch",
"Alternating DB Muscle Snatch",
"DB Clean",
"DB Squat Clean",
"DB Power Clean",
"DB Hang Clean",
"DB Hang Squat Clean",
"DB Hang Power Clean",
"DB High Hang Clean",
"DB High Hang Squat Clean",
"DB High Hang Power Clean",
"DB Tall Clean",
"DB Tall Squat Clean",
"DB Tall Power Clean",
"DB Muscle Clean",
"DB Hang Muscle Clean",
"DB Tall Muscle Clean",
"Single arm DB Clean",
"Right arm DB Clean",
"Left arm DB Clean",
"Single arm DB Squat Clean",
"Right arm DB Squat Clean",
"Left arm DB Squat Clean",
"Single arm DB Power Clean",
"Right arm DB Power Clean",
"Left arm DB Power Clean",
"Single arm DB Hang Squat Clean",
"Right arm DB Hang Squat Clean",
"Left arm DB Hang Squat Clean",
"Single arm DB Hang Power Clean",
"Right arm DB Hang Power Clean",
"Left arm DB Hang Power Clean",
"Alternating DB Clean",
"Alternating DB Squat Clean",
"Alternating DB Power Clean",
"Alternating DB Hang Clean",
"Alternating DB Hang Squat Clean",
"Alternating DB Hang Power Clean",
"Alternating DB High Hang Clean",
"Alternating DB High Hang Squat Clean",
"Alternating DB High Hang Power Clean",
"Alternating DB Tall Clean",
"Alternating DB Tall Squat Clean",
"Alternating DB Tall Power Clean",
"Alternating DB Muscle Clean",
"DB Clean & Jerk",
"DB Squat Clean & Push Jerk",
"DB Power Clean & Push Jerk",
"DB Squat Clean & Split Jerk",
"DB Power Clean & Split Jerk",
"DB Hang Clean & Jerk",
"DB Hang Squat Clean & Push Jerk",
"DB Hang Power Clean & Push Jerk",
"DB Hang Squat Clean & Split Jerk",
"DB Hang Power Clean & Split Jerk",
"DB High Hang Clean & Jerk",
"DB High Hang Squat Clean & Push Jerk",
"DB High Hang Power Clean & Push Jerk",
"DB High Hang Squat Clean & Split Jerk",
"DB High Hang Power Clean & Split Jerk",
"DB Muscle Clean & Push Jerk",
"DB Muscle Clean & Split Jerk",
"DB Hang Muscle Clean & Push Jerk",
"DB Hang Muscle Clean & Split Jerk",
"DB Cluster",
"DB Hang Cluster",
"Devil Press",
"Single Arm DB Clean & jerk",
"Single Arm DB Squat Clean & Push jerk",
"Single Arm DB Power Clean & Push jerk",
"Single Arm DB Hang Squat Clean & Push jerk",
"Single Arm DB Hang Power Clean & Push jerk",
"Single Arm DB High Hang Squat Clean & Push jerk",
"Single Arm DB High Hang Power Clean & Push jerk",
"DB Burpee",
"DB Farmer Carry",
"DB Turkish Get up",
"Right arm DB Turkish Get up",
"Left arm DB Turkish Get up"
            };
            string[] Kettlebell = new string[] {
"KB Shoulder Press",
"Single arm KB Shoulder Press",
"KB Push Press",
"Single arm KB Push Press",
"KB Push Jerk",
"Single arm KB Push Jerk",
"KB Thruster",
"Single arm KB Thruster",
"KB Squat",
"KB Front Squat",
"KB Overhead Squat",
"Single arm KB Overhead Squat",
"Right arm KB Overhead Squat",
"Left arm KB Overhead Squat",
"KB Goblet Squat",
"KB Deadlift",
"KB Sumo Deadlift",
"KB Sumo Deadlift High Pull",
"KB Single Leg Deadlift",
"Double KB Single-Leg Deadlift",
"KB Lunge",
"KB Front Rack Lunge",
"KB Overhead Lunge",
"KB Walking Lunge",
"KB Front Rack Walking Lunge",
"KB Overhead Walking Lunge",
"KB Swing",
"KB Swing (USA)",
"KB Swing (RUS)",
"Single arm KB Swing (USA)",
"Single arm KB Swing (RUS)",
"KB Ground to Shoulder",
"KB Shoulder to Overhead",
"KB Ground to Overhead",
"KB Snatch",
"KB Squat Snatch",
"KB Power Snatch",
"KB Hang Snatch",
"KB Hang Squat Snatch",
"KB Hang Power Snatch",
"KB Tall Snatch",
"KB Tall Squat Snatch",
"KB Tall Power Snatch",
"KB Muscle Snatch",
"KB Hang Muscle Snatch",
"KB Tall Muscle Snatch",
"Alternating KB Snatch",
"Alternating KB Squat Snatch",
"Alternating KB Power Snatch",
"Alternating KB Hang Snatch",
"Alternating KB Hang Squat Snatch",
"Alternating KB Hang Power Snatch",
"Alternating KB Tall Snatch",
"Alternating KB Tall Squat Snatch",
"Alternating KB Tall Power Snatch",
"Alternating KB Muscle Snatch",
"KB Clean",
"KB Squat Clean",
"KB Power Clean",
"KB Hang Clean",
"KB Hang Squat Clean",
"KB Hang Power Clean",
"KB Tall Clean",
"KB Tall Squat Clean",
"KB Tall Power Clean",
"KB Muscle Clean",
"KB Hang Muscle Clean",
"KB Tall Muscle Clean",
"Single arm KB Clean",
"Right arm KB Clean",
"Left arm KB Clean",
"Alternating KB Clean",
"Alternating KB Squat Clean",
"Alternating KB Power Clean",
"Alternating KB Hang Clean",
"Alternating KB Hang Squat Clean",
"Alternating KB Hang Power Clean",
"Alternating KB Tall Clean",
"Alternating KB Tall Squat Clean",
"Alternating KB Tall Power Clean",
"Alternating KB Muscle Clean",
"KB Clean & Jerk",
"KB Squat Clean & Jerk",
"KB Power Clean & Jerk",
"KB Farmer Carry",
"KB Step up",
"KB Turkish Get up",
"Right arm KB Turkish Get up",
"Right arm KB Turkish Get up",

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
"Inverted Row",
"Dip",
"Bar Dip",
"Strict Bar Dip",
"Kipping Bar Dip",
"Kip Swing",
"Resistance Band Assisted Pull up",
"Box Assisted Pull up",
"Pull up",
"Strict Pull up",
"Kipping Pull up",
"Bar Pull up",
"Strict Bar Pull up",
"Kipping Bar Pull up",
"Supinated Grip Pull up",
"L Pull up",
"Close Grip Pull up",
"Chin to Bar Pull up",
"Chest to Bar Pull up",
"Strict Chest to Bar Pull up",
"Kipping Chest to Bar Pull up",
"Butterfly Pull up",
"Burpee Pull up",
"Muscle up",
"Bar Muscle up",
"Strict Bar Muscle up",
"Kipping Bar Muscle up",
"Glide Kip",
"Pull Over",
"Knees Raise",
"Knees to Elbows",
"Strict Knees to Elbows",
"Kipping Knees to Elbows",
"Toes to Bar",
"Strict Toes to Bar",
"Kipping Toes to Bar",
"Hanging L Sit",
"Windshield Wipers Bar",
"Tuck Front Lever",
"Tuck Back Lever",
"Ring Row",
"Ring Push up",
"Ring Dip",
"Strict Ring Dip",
"Kiping Ring Dip",
"Ring Swing",
"Box Assisted Ring Pull-up",
"Ring Pull up",
"Strict Ring Pull up",
"Kipping Ring Pull up",
"Chest to Ring Pull up",
"Strict Chest to Ring Pull up",
"Kipping Chest to Ring Pull up",
"Ring Muscle up",
"Strict Ring Muscle up",
"Kipping Ring Muscle up",
"Toes to Rings",
"Strict Toes to Rings",
"Kipping Toes to Rings",
"L Sit on Rings",
"Forward Roll from Support",
"Backward Roll to Support",
"Skin the Cat",

            };

            string[] BodyWeight = new string[] {
"Air Squat",
"Narrow Stance Air Squat",
"Pistol squat",
"Alternating Pistol squat",
"Single Leg Squat",
"Alternating Single Leg Squat",
"Jumping Squat",
"Lunge",
"Jumping lunge",
"Shoulder Tap",
"Modified Push up",
"Push up",
"Hand Release Push up",
"Knuckle Pus up",
"Biceps Push up",
"Triceps Push up",
"Diamond Push up",
"Split Push up",
"Wide Push up",
"Russian Push up",
"Superman Push up",
"Spiderman Push up",
"Toe Touch Push up",
"Inchworm Push up",
"Clapping Push up",
"Chest Slap Push up",
"Pike Press",
"Pike Push up",
"Nordic Hamstring Curl",
"Burpee",
"Burpee Over the Bar",
"Bar Facing Burpee",
"Burpee Box Jump Over",
"Burpee Broad Jump",
"Burpee Over Rower",
"Burpee Over Object",
"Belushi Burpee",
"Burpee Jack",
"Inverted Burpee",
"Wall Walk",
"Handstand Hold",
"Freestanding Handstand Hold",
"L Sit to Shoulder Stand",
"Straddle Press to Handstand",
"Handstand Walk",
"Handstand Push up",
"Strict Handstand Push up",
"Kipping Handstand Push up",
"Chest to Wall Handstand Push up",
"Deficit Handstand Push up",
"Strict Deficit Handstand Push up",
"Kipping Deficit Handstand Push up",
"Parallette Handstand Push up",
"Freestanding Handstand Push up",
"Shoot Through",
"Bear Crawl",
"Crab Walk",
"Mountain Climber",
"Box Step up",
"Box jump",
"Single Leg Box jump",
"Broad jump",
"Plank",
"Up & Down Plank",
"Sit up",
"Crunch",
"Butterfly Sit-up",
"Hollow Hold",
"Hollow Rock",
"V Sit",
"V Up",
"Candlestick",
"L sit Hold",
"L Sit Leg Lift",
"Evil Wheel",
"Sit up to Stand up",
"Abmat Sit up",
"GHD Sit up",
"GHD Hip Extension",
"GHD Back Extension",
"GHD Hip & Back Extension",
"Glute Ham Raise",
"Rope Climb",
"Modified Rope Climb",
"Lying to Stand Rope Climb",
"Rope Climb (Standard)",
"Rope Climb (Wrapping)",
"Rope Climb (Basket)",
"Leg Less Rope Climb",
"L Sit Rope Climb",
"Pegboard Accent",
"SLIPS"
            };

            string[] Equipmentbeased = new string[] {
"D Ball Bearhug Hold",
"D Ball Squat",
"MB Squat",
"MB Lunge",
"MB Lunge Rotation",
"MB Deadlift",
"MB Push up",
"MB Rolling Push up",
"MB Sit up",
"MB Russian Twist",
"Lateral Ball Toss",
"Leg lever to Ball",
"MB Sit up to Stand up",
"MB Snatch",
"MB Clean",
"MB Ground to Shoulder",
"MB Shoulder to Overhead",
"MB Ground to Overhead",
"Wall Ball Shot",
"Slam Ball",
"MB Over the Shoulder",
"SB Bearhug Hold",
"SB Squat",
"SB Deadlift",
"SB Clean",
"SB Ground to Shoulder",
"SB Shoulder to Overhead",
"SB Ground to Overhead",
"SB Farmer Carry",
"SB Over the Shoulder",
"SB Throw",
"SB Overhead Toss",
"Sled Drag",
"Sled Pull",
"Sled Reverse Pull",
"Arm over arm Sled Pull",
"Sled Push",
"Tire Front Squat",
"Tire Deadlift",
"Tire Farmer Deadlift",
"Tire Leg Press",
"Tire Chest Press",
"Tire Jump",
"Tire Decline Push-up",
"Tire Incline Push-up",
"Tire Shoulder Push-up",
"Sledge Hammer",
"Right arm Sledge Hammer",
"Left arm Sledge Hammer",
"Tire Flip",
"Tire Drag",
"Tire Pull",
"Tire Reverse Pull",
"Tire Push",
"Tire Farmer Carry",
"Tire Overhead Toss",
"BR Alternating waves",
"BR Up & Down waves",
"BR Side to Side waves",
"BR In & Out waves",
"BR Slam",
"BR Jump Slam",
"BR Side Slam",
"BR Inside Circle",
"BR Outside Circle",
"BR Hold Squat Wave",
"BR Active Squat waves",
"BR Alternating Side Lunge waves",
"BR Alternating Reverse Lunge waves",
"BR Jumping Alternating Lunge",
"BR Grappler Toss",
"BR Drum Solo waves",
"BR Ultimate Warrior Rope Shake",
"BR Shuffle waves",
"BR Hop waves",
"BR Upper Cut",
"BR Split Snatch waves",
"BR Figure 8 waves",
"BR Jumping Jack waves",
"BR Split Jack waves",
"BR Diagonal Chop",
"BR Plank waves",
"BR Side Plank Slam",
"BR Russian Twist waves",
"BR Lateral Hop+Slam",
"BR Seated waves",
"BR Kneeling waves",
"BR Kneeling to Standing waves",
"BR Standing Trunk Rotation",
"BR Alternating Standing Press",
"BR Kneeling Press",
"BR Front Raise",
"BR Rear Delt Raise",
"BR Foot Fire Alternating waves",
"BR Band Resistance Alternating waves"

                };

            string[] Metcan = new string[] {
"Run",
"Air run",
"Treadmill",
"Backward Run",
"Incline Run",
"Sprint",
"Shuttle Sprint",
"Bike",
"BikeErg",
"AirBike",
"Airdyne",
"Echo Bike",
"Row",
"SkiErg",
"Stair Climber Machine",
"Elliptical",
"Swim",
"Single Under",
"Double Under",
"Triple Under",
"Jump",
"But Kick",
"High Knees",
"Hop Heel Click",
"Toe Tap Hop",
"Jumping Jack",
"Jumping Ts",
"Split Jack",
"Press Jack",
"Twist Jack",
"Seal Jack",
"Crossover Jack",
"Star Jump",
"Tuck Jump",
"Standing Knees to Elbows",
"Squat Step up"

            };

            string[] Shoulder = new string[] {
"Shoulder Press Machine",
"Standing Shoulder Press",
"Seated Shoulder Press",
"Behind the Neck Press",
"Seated Behind the Neck  Press",
"Dumbbell Shoulder Press",
"Seated Dumbbell Shoulder Press",
"Arnold Press",
"Seated Arnold Press",
"Machine Reverse Fly",
"Barbell Front Raise",
"Barbell Rear Delt Raise (Prone)",
"Dumbbell Front Raise",
"Alternating Dumbbell Front Raise",
"Cable Front Raise",
"Single arm Cable Front Raise",
"Lateral Raise Machine",
"Lateral Raise",
"Lateral Raise (Front Angle)",
"Lateral Raise (Back Angle)",
"Hammer Grip Lateral Raise",
"Cable Lateral Raise",
"Single arm Cable Lateral Raise (Front Angle)",
"Single arm Cable Lateral Raise (Back Angle)",
"Cable Rear Delt Fly",
"Cable Internal Rotation",
"Cable External Rotation",
"Standing Bent over Dumbbell Lateral Raise",
"Seated Bent over Dumbbell Lateral Raise",
"Incline Bent over Lateral Raise",
"Bent over Cable Lateral Raise",
"Single arm Cable Reverse Fly",
"Trap raise",
"Face pull",
"Barbell Shrug",
"Barbell Shrug (Front Angle)",
"Barbell Shrug (Back Angle)",
"Dumbbell Shrug",
"Dumbbell Shrug (Front Angle)",
"Dumbbell Shrug (Back Angle)",
"Cable Shrug",
"Barbell High Pull",
"Wide Grip Barbell High Pull",
"Close Grip Barbell High Pull",
"Dumbbell High Pull",
"Cable High Pull"
            };

            string[] Chest = new string[] {
"Chest Press Machine",
"Barbell Bench Press",
"Close Grip Bench Press",
"Wide Grip Bench Press",
"Floor Press",
"Dumbbell Bench Press",
"Neutral Grip Dumbbell Bench Press",
"Lying Fly",
"Dumbbell Floor Press",
"Neutral Grip Dumbbell Floor Press",
"Floor Lying Fly",
"Cable Crossover",
"Incline Chest Press Machine",
"Incline Barbell Bench Press",
"Wide Grip Incline Bench Press",
"Incline Dumbbell Bench Press",
"Neutral Grip Incline Dumbbell Bench Press",
"Incline Cable Chest Press",
"Incline Fly",
"Incline Cable Fly",
"Fly Machine",
"Decline Barbell Bench Press",
"Wide Grip Decline Bench Press",
"Decline Dumbbell Bench Press",
"Neutral Grip Decline Dumbbell Bench Press",
"Decline Cable Chest Press",
"Decline Fly",
"Decline Cable Fly",
"Barbell Pull over",
"Close Grip Barbell Pull over",
"Dumbbell Pull over",
"Chest Dip",

            };

            string[] Back = new string[] {
"Seated Pull down Machine",
"Lat Pull Down",
"Behind the Neck Lat Pull Down",
"Close Grip Lat Pull Down",
"Wide Grip Lat Pull Down",
"Reverse Grip Lat Pull Down",
"Straight arm Lat Pull Down",
"Rope Straight arm Pull Down",
"Cable Row",
"Wide Grip Cable Row",
"Underhand Grip Cable Row",
"Barbell Row",
"Incline Bench Barbell Row",
"Reverse Grip Incline Bench Barbell Row",
"Dumbbell Row",
"Incline Bench Dumbbell Row",
"Single arm Dumbbell Row",
"T Bar Machine",
"T Bar Row",
"H Machine Row",
"Single arm H Machine Row",
"Good Morning",
"Pull up",
"Wide Grip Pull up"

            };

            string[] MiddleBody = new string[]
            {
"Crunch Machine",
"Sit up",
"Crunch",
"Alternating Crunch",
"MB Sit up",
"Heel Touch",
"Russian Twist",
"MB Russian Twist",
"BR Russian Twist Wave",
"Lateral Ball Toss",
"Butterfly Sit up",
"Bicycle Crunch",
"Standing Knees to Elbows",
"Flutter Kick",
"Scissor Kick",
"Decline Sit up",
"Hollow Hold",
"Hollow Rock",
"V Sit",
"V Up",
"Leg Lever",
"Candlestick",
"Leg lever to Ball",
"Vertical Leg Raise",
"Vertical Knees Raise",
"Hanging Knees Raise",
"Hanging Leg Raise",
"L sit Hold",
"L Sit Leg Lift",
"Hanging L Sit",
"Windshield Wipers Bar",
"Evil Wheel",
"Sit up to Stand up",
"MB Sit up to Stand up",
"RB Core Twist",
"RB Pallof Hold",
"Plank",
"PPT Plank",
"Wide Plank",
"Extended Plank",
"Side to Side Plank",
"Plank With Opposite Reach",
"Side Plank",
"Side Plank Knee Tuck",
"Reverse Plank",
"Up Down Plank",
"Plank Press",
"Hip Bridge",
"Side Hip Bridge",
"RB Hip Bridge",
"RB Single Leg Hip Bridge",
"Mountain Climber",
"RB Good Morning",
"Superman",
"Hyperextension"

            };

            string[] Arm = new string[] {
"Biceps Curl Machine",
"Single arm Biceps Curl Machine",
"Standing Barbell Curl",
"Close Grip Standing Barbell Curl",
"Wide Grip Standing Barbell Curl",
"Seated Barbell Curl",
"Close Grip Seated Barbell Curl",
"Close Grip Seated Concentration Barbell Curl",
"Incline Barbell Curl",
"Close Grip Incline Barbell Curl",
"Prone Barbell Curl",
"Close Grip Prone BarbellCurl",
"Standing EZ Bar curl",
"EZ Bar Preacher Curl",
"Standing Dumbbell Curl",
"Standing Alternating Dumbbell Curl",
"Standing Hammer Curl",
"Standing Alternating Hammer Curl",
"Seated Alternating Dumbbell Curl",
"Concentration Dumbbell Curl",
"Zottman Curl",
"Incline Dumbbell Curl",
"Alternaing Incline Dumbbell Curl",
"Dumbbell Preacher Curl",
"Cable Biceps Curl",
"Close Grip Cable Biceps Curl",
"Single Arm Cable Curl",
"Seated Cable Curl",
"Standing High Pulley Cable Curl",
"Standing Single arm High Pulley Cable Curl",
"Triceps Press Machine",
"Barbell Triceps Press",
"Standing Barbell Triceps Press",
"Seated Barbell Triceps Press",
"Prone Barbell Triceps Press",
"Close Grip Prone Barbell Triceps Press",
"Barbell Triceps Lying (KickBack)",
"Seated single Dumbbell Triceps Extension",
"Standing Overhead Dumbbell Triceps",
"Seated Single Dumbbell Triceps Extension",
"Seated Dumbbell Triceps Extension",
"Double ArmTriceps KickBack",
"Seated Double Arm Triceps KickBack",
"Prone Dumbbell Triceps Press",
"Push Down",
"Single arm Cable Triceps Extension",
"Reverse Grip Triceps Extension",
"Rope Triceps Extension",
"Lying Triceps Extension",
"Bench Dip",
"Reverse Grip Barbell Curl",
"Standing Dumbbell Reverse Curl",
"Standing Wrist Curl Behind Back",
"Seated Barbell Wrist Curl",
"Reverse Grip Seated Barbell Wrist Curl",
"Seated Dumbbell Wrist Curl",
"Reverse Grip Seated Dumbbell Wrist Curl",

            };

            string[] Leg = new string[] {
"Seated Leg Extension",
"Seated Single Leg Extension",
"Back Squat",
"Hack Squat",
"Barbell Hack Squat",
"Bulgarian Split Squat",
"Dumbbell Squat",
"Pile Squat",
"Dumbbell Bulgarian Split Squat",
"Barbell Lunge",
"Walking Barbell Lunge",
"Dumbbell Lunge",
"Walking Dumbbell Lunge",
"Side Lunge",
"Leg Press Machine",
"Lying Leg Curl Machine",
"Single Leg Curl Machine",
"Seated Leg Curl Machine",
"Dumbbell Hamstring Curl on Bench",
"Dumbbell Hamstring Curl on Floor",
"Adductor Machine",
"Abductor Machine",
"Deadlift",
"Romanian Deadlift",
"Sumo Deadlift",
"Glute KickBack Machine",
"Hip Thrust",
"Barbell Step up",
"Dumbbell Step up",
"Standing Calf Raise Machine",
"Seated Calf Raise Machine",
"Rocking Standing Calf Raise",
"Seated Barbell Calf Raise",
"Standing Dumbbell Calf Raise",
"Seated Dumbbell Calf Raise",
"Calf Raise Machine",
"Hack Calf Raise",
"Calf Raise on Leg Press Machine"
            };

            string[] Upperbody = new string[] {
"TRX Chest Press",
"TRX Clock Press",
"TRX Chest Fly",
"TRX Split Fly",
"TRX T Fly",
"TRX Y Fly",
"TRX Y Fly to T Fly",
"TRX Power Pull",
"TRX Triceps Press",
"TRX Biceps Curl",
"TRX Bic FPS Curl (Single Arm)",
"TRX Plank",
"TRX Body Saw",
"TRX Side Plank",
"TRX Side Plank (Single Leg)",
"TRX Side Plank (Single Leg to Knee Tuck)",
"TRX Up Down Plank",
"TRX Plank Press",
"TRX Push up",
"TRX Spiderman Push-up",
"TRX Pike",
"TRX Atomic Pike",
"TRX Mountain Climber",
"TRX Burpee",
"TRX Row",
"TRX Inverted Row",
"TRX Single arm Inverted Row",
"TRX Torso Rotation",
"TRX Hip Throw",
"TRX Pull up",
"TRX Overhead Back Extension",
"TRX Long Torso Stretch",

            };

            string[] Lowerbody = new string[] {
"TRX Hip Abduction",
"TRX Hip Bridge",
"TRX Hamstring Curl",
"TRX Hamstring Runner",
"TRX Squat",
"TRX Squat Jump",
"TRX Squat Y Fly",
"TRX Overhead Squat",
"TRX Single Leg Squat",
"TRX Squat Row (Single arm/leg)",
"TRX Split Squat (W/Y Deltoid Fly)",
"TRX Split Squat (W/T Deltoid Fly)",
"TRX Split Squat (W/M Deltoid Fly)",
"TRX Hip Hinge (Single Leg)",
"TRX Cossack Stretch",
"TRX Lunge",
"TRX Lunge (One Hand Down)",
"TRX Side Lunge",
"TRX Abducted Lunge",
"TRX Single Leg Squat to Crossing Balance Lunge",
"TRX Forward Lunge with Hip Flexor Stretch",
"TRX Sprinter Start"
            };
            string[] UpperbodyKeshResistance = new string[] {
"RB Push up",
"RB Chest Press",
"RB Chest Fly",
"RB Chest Crossover",
"RB Butterfly",
"RB Shoulder Press",
"RB Front Raise",
"RB Alternating Front Raise",
"RB Lateral Raise",
"RB Alternating Lateral Raise",
"RB Hammer Grip Lateral Raise",
"RB Reverse Fly",
"RB Lower Reverse Fly",
"RB Upright Raise",
"RB Shrug",
"RB Bent Deltoid",
"RB Archer",
"RB Upper Back Row",
"RB Overhead Pull Down",
"RB Seated Row",
"RB Biceps Curl",
"RB Alternating Biceps Curl",
"RB Hammer Grip Curl",
"RB Alternating Hammer Grip Curl",
"RB Concentration Curl",
"RB Triceps Overhead Press",
"RB Triceps Side Press",
"RB Triceps Pull",
"RB Triceps Kickback",
"RB Good Morning",
"RB Core Twist",
"RB Pallof Hold"
            };

            string[] LowerbodyKeshResistance = new string[] {
"RB Squat",
"RB Front Squat",
"RB Lunge",
"RB Front Lunge",
"RB Outer Thigh Raise",
"RB Donkey Kick",
"RB Leg KickBack",
"RB Leg Press",
"RB Adduction",
"RB Abduction",
"RB Hip Bridge",
"RB Single Leg Hip Bridge",
"RB Hamstring Curl"
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
                case "وزن بدن":
                    comboBox3.Items.AddRange(BodyWeight);
                    break;
                case "تجهیزات":
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
                case "میان تنه":
                    comboBox3.Items.AddRange(MiddleBody);
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
                        comboBox3.Items.AddRange(UpperbodyKeshResistance);
                    break;
                case "پایین تنه":
                    if (comboBox1.SelectedItem == "تی آر ایکس")
                        comboBox3.Items.AddRange(Lowerbody);
                    else
                        comboBox3.Items.AddRange(LowerbodyKeshResistance);
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

        int publicMTID = 0;
        private async void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = new HttpClient();

            var content = await client.GetStringAsync(BaseAddress + "fitness/VOD/GetMovement?Part=" + comboBox1.SelectedItem + "&SubPart=" + comboBox2.SelectedItem + "&MoveName=" + comboBox3.SelectedItem);

            //Console.WriteLine(content);
            label7.Visible = false;
            label6.Visible = false;
            button31.Visible = false;

            if (content == "0")
            {
                label7.Visible = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                button31.Visible = false;

            }
            else
            {
                label6.Visible = true;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                button31.Visible = true;
                publicMTID = Int32.Parse(content);
            }
        }

        public async Task<string> PostToServerMovementDetail(string filePath1, string filePath2, string filePath3, Com.MovementTrainingDetail movementTrainingDetail)
        {
            try
            {
                // string filePath = "C:/Users/mehrs/Downloads/Telegram Desktop/4-10-6.png";

                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMinutes(30);

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

                        Uri myUri = new Uri(BaseAddress + "fitness/VOD/PostMovement", UriKind.Absolute);

                        HttpResponseMessage response = await httpClient.PostAsync(myUri, form);

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
                        ZaribSakhti = float.Parse(textBoxZaribSakhti.Text),
                        ZaribTaAdol = float.Parse(textBox9.Text),
                        ShowStatus = (string)comboBox7.SelectedItem,
                        vaznNormalZhimnastik = float.Parse(textBox10.Text),
                        WhichType = listBoxType.Items.Cast<String>().FirstOrDefault(),
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

                MessageBox.Show("تبریک!!! قسمت اول آپلود انجام شد، حالا ادامه میدیم");

                int iMehr = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
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
                        MessageBox.Show(" حرکت شماره  "+ iMehr + "دچار مشکل شده ولی ادامه میدیم تا ببینیم چی میشه");
                        // MessageBox.Show("مشکلی در ارسال جزییات حرکت وجود دارد ولی  اطلاعات حرکت در دیتابیس ذخیره شده است");
                        // return;
                    }
                    iMehr++;
                }

                MessageBox.Show("آپلود به درستی انجام شد.");

                dataGridView1.Rows.Clear();
                richTextBox2.Text = "";
                textBox1.Text = "";
                label7.Visible = false;
                label6.Visible = false;
                button31.Visible = false;

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
                                BaseAddress + "FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[0]);
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
                               BaseAddress + "/FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[0]);
                            System.Net.WebResponse response = request.GetResponse();
                            Stream responseStream = response.GetResponseStream();
                            Bitmap bitmapMov = new Bitmap(responseStream);

                            System.Net.WebRequest request2 = System.Net.WebRequest.Create(
                               BaseAddress + "/FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[1]);
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
                                BaseAddress + "FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[0]);
                            System.Net.WebResponse response = request.GetResponse();
                            Stream responseStream = response.GetResponseStream();
                            Bitmap bitmapMov = new Bitmap(responseStream);

                            System.Net.WebRequest request2 = System.Net.WebRequest.Create(
                               BaseAddress + "FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[1]);
                            System.Net.WebResponse response2 = request2.GetResponse();
                            Stream responseStream2 = response2.GetResponseStream();
                            Bitmap bitmapMov2 = new Bitmap(responseStream2);

                            System.Net.WebRequest request3 = System.Net.WebRequest.Create(
                               BaseAddress + "FitnessResource/Movement/" + itemMovDet.MTID.ToString() + "/" + itemMovDet.MTDID.ToString() + "/" + ImgNameSplited[2]);
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

        private void button24_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox10.CheckedItems.Count > 0)
            {
                this.listBoxType.Items.Clear();
                foreach (string item in this.checkedListBox10.CheckedItems)
                {
                    this.listBoxType.Items.Add(item.ToString());
                }
                for (int i = 0; i < this.checkedListBox10.Items.Count; i++)
                {
                    this.checkedListBox10.SetItemChecked(i, false);
                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBoxUpperBody.Items.Count; i++)
            {
                this.checkedListBoxUpperBody.SetItemChecked(i, true);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
            {
                this.checkedListBox2.SetItemChecked(i, true);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox3.Items.Count; i++)
            {
                this.checkedListBox3.SetItemChecked(i, true);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox4.Items.Count; i++)
            {
                this.checkedListBox4.SetItemChecked(i, true);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox5.Items.Count; i++)
            {
                this.checkedListBox5.SetItemChecked(i, true);
            }
        }

        private async void button31_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync(BaseAddress + "fitness/VOD/RemoveMovement?MTID=" + publicMTID);
            Console.WriteLine(content);
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
