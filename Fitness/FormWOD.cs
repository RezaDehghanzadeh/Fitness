//using Newtonsoft.Json;
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
                    AddToTotalRep = float.Parse(textBox10.Text),
                    AddToTotalTime = float.Parse(textBox8.Text),
                    AMRAP = float.Parse(textBox1.Text),
                    CapTime = float.Parse(textBox3.Text),
                    FTRound = float.Parse(textBoxTadil.Text),
                    RestBetMov = float.Parse(textBox5.Text),
                    RestBetRep = float.Parse(textBox6.Text),
                    RestBetSet = float.Parse(textBox4.Text),
                    TimeEvery = float.Parse(textBox12.Text),
                    TimeFor = float.Parse(textBox11.Text),
                    TimeRest = float.Parse(textBox13.Text),
                    TRound = float.Parse(textBox7.Text),
                    TSet = float.Parse(textBox2.Text),
                    TWork = float.Parse(textBox9.Text),
                    R1 = float.Parse(textBox14.Text),
                    R2 = float.Parse(textBox15.Text),
                    R3 = float.Parse(textBox17.Text),
                    R4 = float.Parse(textBox16.Text),
                    R5 = float.Parse(textBox21.Text),
                    R6 = float.Parse(textBox19.Text),
                    R7 = float.Parse(textBox20.Text),
                    R8 = float.Parse(textBox18.Text),
                    R9 = float.Parse(textBox29.Text),
                    R10 = float.Parse(textBox25.Text),
                    R11 = float.Parse(textBox27.Text),
                    R12 = float.Parse(textBox23.Text),
                    R13 = float.Parse(textBox28.Text),
                    R14 = float.Parse(textBox24.Text),
                    R15 = float.Parse(textBox26.Text),
                    R16 = float.Parse(textBox22.Text),
                    R17 = float.Parse(textBox33.Text),
                    R18 = float.Parse(textBox31.Text),
                    R19 = float.Parse(textBox32.Text),
                    R20 = float.Parse(textBox30.Text),
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
                    AddToTotalRep = float.Parse(textBox56.Text),
                    AddToTotalTime = float.Parse(textBox58.Text),
                    AMRAP = float.Parse(textBox63.Text),
                    CapTime = float.Parse(textBox65.Text),
                    FTRound = float.Parse(textBox55.Text),
                    RestBetMov = float.Parse(textBox59.Text),
                    RestBetRep = float.Parse(textBox57.Text),
                    RestBetSet = float.Parse(textBox61.Text),
                    TimeEvery = float.Parse(textBox60.Text),
                    TimeFor = float.Parse(textBox62.Text),
                    TimeRest = float.Parse(textBox54.Text),
                    TRound = float.Parse(textBox64.Text),
                    TSet = float.Parse(textBox67.Text),
                    TWork = float.Parse(textBox66.Text),
                    R1 = float.Parse(textBox53.Text),
                    R2 = float.Parse(textBox45.Text),
                    R3 = float.Parse(textBox49.Text),
                    R4 = float.Parse(textBox41.Text),
                    R5 = float.Parse(textBox51.Text),
                    R6 = float.Parse(textBox43.Text),
                    R7 = float.Parse(textBox47.Text),
                    R8 = float.Parse(textBox39.Text),
                    R9 = float.Parse(textBox52.Text),
                    R10 = float.Parse(textBox44.Text),
                    R11 = float.Parse(textBox48.Text),
                    R12 = float.Parse(textBox40.Text),
                    R13 = float.Parse(textBox50.Text),
                    R14 = float.Parse(textBox42.Text),
                    R15 = float.Parse(textBox46.Text),
                    R16 = float.Parse(textBox38.Text),
                    R17 = float.Parse(textBox37.Text),
                    R18 = float.Parse(textBox35.Text),
                    R19 = float.Parse(textBox36.Text),
                    R20 = float.Parse(textBox34.Text),
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
                    AddToTotalRep = float.Parse(textBox90.Text),
                    AddToTotalTime = float.Parse(textBox92.Text),
                    AMRAP = float.Parse(textBox97.Text),
                    CapTime = float.Parse(textBox99.Text),
                    FTRound = float.Parse(textBox89.Text),
                    RestBetMov = float.Parse(textBox93.Text),
                    RestBetRep = float.Parse(textBox91.Text),
                    RestBetSet = float.Parse(textBox95.Text),
                    TimeEvery = float.Parse(textBox94.Text),
                    TimeFor = float.Parse(textBox96.Text),
                    TimeRest = float.Parse(textBox88.Text),
                    TRound = float.Parse(textBox98.Text),
                    TSet = float.Parse(textBox101.Text),
                    TWork = float.Parse(textBox100.Text),
                    R1 = float.Parse(textBox87.Text),
                    R2 = float.Parse(textBox79.Text),
                    R3 = float.Parse(textBox83.Text),
                    R4 = float.Parse(textBox75.Text),
                    R5 = float.Parse(textBox85.Text),
                    R6 = float.Parse(textBox77.Text),
                    R7 = float.Parse(textBox81.Text),
                    R8 = float.Parse(textBox73.Text),
                    R9 = float.Parse(textBox86.Text),
                    R10 = float.Parse(textBox78.Text),
                    R11 = float.Parse(textBox82.Text),
                    R12 = float.Parse(textBox74.Text),
                    R13 = float.Parse(textBox84.Text),
                    R14 = float.Parse(textBox76.Text),
                    R15 = float.Parse(textBox80.Text),
                    R16 = float.Parse(textBox72.Text),
                    R17 = float.Parse(textBox71.Text),
                    R18 = float.Parse(textBox69.Text),
                    R19 = float.Parse(textBox70.Text),
                    R20 = float.Parse(textBox68.Text),
                };
            }
            catch
            {
                MessageBox.Show("Error in Input R2 section.");
                return;
            }
          //  var stringRound = JsonConvert.SerializeObject(round);
          //  richTextBoxGigaVOD.Text = richTextBoxGigaVOD.Text + stringRound;
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
        public string KWeightScaled1 { get; set; }
        public MovDetail RX { get; set; }
        public MovDetail R2 { get; set; }
        public MovDetail R3 { get; set; }
    }
    public class MovBI
    {
        public string KWeightScaled1 { get; set; }
        public MovDetail RX { get; set; }
        public MovDetail R2 { get; set; }
        public MovDetail R3 { get; set; }
    }
    public class MovBO
    {
        public string KWeightScaled1 { get; set; }
        public MovDetail RX { get; set; }
        public MovDetail R2 { get; set; }
        public MovDetail R3 { get; set; }
    }
    public class MovOD
    {
        public string KWeightScaled1 { get; set; }
        public MovDetail RX { get; set; }
        public MovDetail R2 { get; set; }
        public MovDetail R3 { get; set; }
    }
    public class MovEV
    {
        public string KWeightScaled1 { get; set; }
        public MovDetail RX { get; set; }
        public MovDetail R2 { get; set; }
        public MovDetail R3 { get; set; }
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
}
