using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitnessWebApp.Controllers
{
    public class AuthorizationController : ApiController
    {
        [AcceptVerbs("Get")]
        public Com.LogonResult Logon(string TellNumber)
        {
            try
            {
                Com.User mUser = BLL.User.GetUserByTellNumber(TellNumber);
                if (mUser == null)
                {
                    mUser = new Com.User()
                    {
                        TellNumber = TellNumber,
                        LastLogin = DateTime.Now,
                        Active = false,
                        Credit = 500,
                        JoinDate = DateTime.Now,
                        RewardState = 0,
                        ActiveCode = "12345"// CreateRandomCode()
                    };

                    mUser.UID = BLL.User.AddUser(mUser);
                    if (mUser.UID < 0)
                    {
                        return new Com.LogonResult() { IsNew = true, HasError = true, NickName = "", UserID = mUser.UID };
                    }
                    else
                    {
                       // new System.Threading.Thread(delegate () { SendActivationCodeViaSMS(TellNumber, mUser.ActiveCode); }).Start();
                        return new Com.LogonResult() { IsNew = true, HasError = false, NickName = "", UserID = mUser.UID };
                    }
                }
                else
                {
                    string NewActiveCode = "123456";// CreateRandomCode();
                    if (TellNumber == "989123456789")//mehr
                    {
                        NewActiveCode = "12345";
                    }
                    mUser.ActiveCode = NewActiveCode;
                    bool Res = BLL.User.UpdateUserCode(mUser);
                    //new System.Threading.Thread(delegate () { SendActivationCodeViaSMS(TellNumber, NewActiveCode); }).Start();
                    return new Com.LogonResult() { IsNew = false, HasError = false, NickName = mUser.NickName, UserID = mUser.UID };
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.Logon, TellNumber, -200, e.Message); }).Start();
                return new Com.LogonResult() { IsNew = false, HasError = true, NickName = e.Message, UserID = 0 };
            }
        }

        //////////////////////////////////////////////////
        /// Help API For Controler       /////////////////
        //////////////////////////////////////////////////

        string CreateRandomCode()
        {
            string[] SplitChars = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            Random random = new Random();
            string RandomPCode = string.Empty;
            for (int i = 0; i <= 4; i++)
            {
                RandomPCode += SplitChars[random.Next(1, SplitChars.Length)];
            }

            return RandomPCode;
        }

        bool SendActivationCodeViaSMS(string TellNumber, string RndNumber)
        {
            try
            {
                Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi("6E41717A4D532F556962626E7149466679445A6D4B413D3D");
                var result = api.VerifyLookup(TellNumber, RndNumber, "GoftemanActivationCode");

                return true;
            }
            catch (Kavenegar.Exceptions.ApiException)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.SendSMS, TellNumber, 0, "Return Not 200"); }).Start();
                return false;
            }
            catch (Kavenegar.Exceptions.HttpException)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.SendSMS, TellNumber, 0, "Not Connected"); }).Start();
                return false;
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.SendSMS, TellNumber, 0, e.Message); }).Start();
                return false;
            }
        }
    }
}
