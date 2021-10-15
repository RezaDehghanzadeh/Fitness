using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Web.Script.Serialization;


namespace Fitness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var dad = DateTime.Parse("01/01/2021");

        }

        bool SendMSVahid()
        {
            try
            {
                Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi("6A6B364F786E554E3353725364357359306F4C796362394337355149386F793475756E702B3465386737513D");
                var result = api.VerifyLookup("09393616555", "مهرشاد", "تاریخ", "", "VahidWarning");

                return true;
            }
            catch (Kavenegar.Exceptions.ApiException e)
            {
                Console.WriteLine(e.Message);
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                return false;
            }
            catch (Kavenegar.Exceptions.HttpException e)
            {
                Console.WriteLine(e.Message);

                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }
    }
}
