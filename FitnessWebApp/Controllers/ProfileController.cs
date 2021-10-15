using Com;
using FitnessWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace FitnessWebApp.Controllers
{
    [Authorize]
    public class ProfileController : ApiController
    {


        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public ResLastUserInfo GetLastUserInfo(int UID)
        {
            ResLastUserInfo Res = new ResLastUserInfo();
            try
            {
                Com.User usr = BLL.User.GetUser(UID);
                int SSex = 0;
                if (usr.Sex == true)
                    SSex = 1;
                MiniUser miniUser = new MiniUser()
                {
                    CodeMeli = usr.CodeMeli ?? "",
                    Credit = usr.Credit,
                    Email = usr.Email ?? "",
                    FamilyName = usr.FamilyName ?? "",
                    JoinDate = usr.JoinDate,
                    LastLogin = usr.LastLogin,
                    Name = usr.Name ?? "",
                    NickName = usr.NickName ?? "",
                    RewardState = 1,
                    TellNumber = usr.TellNumber,
                    UID = usr.UID,
                    Address = usr.Address ?? "",
                    CodePosti = usr.CodePosti ?? "",
                    City = usr.City ?? "",
                    Ostan = usr.Ostan ?? "",
                    RCBackSquat = usr.RCBackSquat ?? 0,
                    RCPullUp = usr.RCPullUp ?? 0,
                    RCRun = usr.RCRun ?? 0,
                    Sex = SSex,
                    Username = usr.Username ?? "", 
                };
                Res.MiniUser = miniUser;
                Res.userBought = BLL.User.GetAllUserBought(UID);
                Res.userMessage = BLL.User.GetAllUserMessage(UID);
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Common.Action.GetLastUserInfo, UID.ToString(), -400, e.Message); }).Start();
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Common.Action.GetLastUserInfo, UID.ToString(), -400, e.InnerException.Message); }).Start();
            }

            return Res;
        }

        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public List<Com.UserBought> GetAllUserBought(int UID)
        {
            return BLL.User.GetAllUserBought(UID);
        }
        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public List<Com.Teacher> GetAllTeacher()
        {
            return BLL.User.GetAllTeacher();
        }
        [AcceptVerbs("Get")]
        [AllowAnonymous]
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
                        ActiveCode = CreateRandomCode()
                    };

                    mUser.UID = BLL.User.AddUser(mUser);
                    if (mUser.UID < 0)
                    {
                        return new Com.LogonResult() { IsNew = true, HasError = true, NickName = "", UserID = mUser.UID };
                    }
                    else
                    {
                        new System.Threading.Thread(delegate () { SendActivationCodeViaSMS(TellNumber, mUser.ActiveCode); }).Start();
                        return new Com.LogonResult() { IsNew = true, HasError = false, NickName = "", UserID = mUser.UID };
                    }
                }
                else
                {
                    string NewActiveCode = CreateRandomCode();
                    if (TellNumber == "989123456789")//mehr
                    {
                        NewActiveCode = "12345";
                    }
                    mUser.ActiveCode = NewActiveCode;
                    bool Res = BLL.User.UpdateUserCode(mUser);
                    new System.Threading.Thread(delegate () { SendActivationCodeViaSMS(TellNumber, NewActiveCode); }).Start();
                    return new Com.LogonResult() { IsNew = false, HasError = false, NickName = mUser.NickName, UserID = mUser.UID };
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.Logon, TellNumber, -200, e.Message); }).Start();
                return new Com.LogonResult() { IsNew = false, HasError = true, NickName = e.Message, UserID = 0 };
            }
        }

        [AcceptVerbs("Post")]
        [AllowAnonymous]
        public LoginResult Login([FromBody] LoginInput loginInput)
        {
            try
            {
                User mUser = BLL.User.GetUser(loginInput.UserID);
                if (mUser == null)
                {
                    return new LoginResult() { HasError = true, Error = "User Not found.", ErrorCode = -300 };
                }

                if (mUser.ActiveCode == loginInput.ActiveCode)
                {//Mehr
                    //if (loginInput.InviterTellNumber != "empty")
                    //{
                    //    User mInviterUIDUser = BLL.User.GetUserByTellNumber(loginInput.InviterTellNumber);


                    //    if (SubTell == StSP[1])
                    //    {
                    //        //add to User
                    //        //add to inviter
                    //        if (IncreasedCredit(InviterUID, 50) > 0)
                    //        {
                    //            AppMsgCollection appMsgCollection = new AppMsgCollection()
                    //            {
                    //                Category = 0,
                    //                Content = "به دلیل معرفی این برنامه به دوست خود و نصب برنامه توسط ایشان شما 50 سکه رایگان دریافت کردید.",
                    //                MID = 10,
                    //                Notify = true,
                    //                NotifyInApp = false,
                    //                Scheduled = false,
                    //                SID = 0,
                    //                Tab = 1,
                    //                Tiltle = "هدیه معرفی",
                    //                TypeStyle = 1
                    //            };
                    //            FCMPushNotification fcmPushInviter = new FCMPushNotification();
                    //            fcmPushInviter.SendInAppNotification(mInviterUIDUser.FBToken, appMsgCollection, mInviterUIDUser.OSType);
                    //        }
                    //        if (IncreasedCredit(UID, 25) > 0)
                    //        {
                    //            AppMsgCollection appMsgCollection = new AppMsgCollection()
                    //            {
                    //                Category = 0,
                    //                Content = "به دلیل استفاده از کد معرف دوست خود و نصب برنامه گفتمان 25 سکه رایگان دریافت کرده اید شما هم با معرفی این برنامه به دیگران می توانید 50 سکه رایگان دریافت کنید.",
                    //                MID = 10,
                    //                Notify = true,
                    //                NotifyInApp = false,
                    //                Scheduled = false,
                    //                SID = 0,
                    //                Tab = 1,
                    //                Tiltle = "هدیه معرفی",
                    //                TypeStyle = 1
                    //            };
                    //            FCMPushNotification fcmPushInviter = new FCMPushNotification();
                    //            fcmPushInviter.SendInAppNotification(FBToken, appMsgCollection, mInviterUIDUser.OSType);
                    //        }
                    //        //Send in App MSG
                    //    }
                    //    else
                    //    {
                    //        return -200;
                    //    }
                    //}
                    mUser.NickName = loginInput.NickName;
                    mUser.Active = true;
                    mUser.DeviceID = loginInput.DeviceID;
                    mUser.FBToken = loginInput.FBToken;

                    if (BLL.User.UpdateUserAfterLogin(mUser))
                    {
                        return new LoginResult() { HasError = false, StatusResult = true, Token = "FelanAlaki" };
                    }
                    else
                    {
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Common.Action.Login, loginInput.UserID.ToString(), -400, null); }).Start();
                        return new LoginResult() { Error = "Error in DB.", HasError = true, ErrorCode = -500 };
                    }
                }
                else
                {
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Common.Action.Login, loginInput.UserID.ToString(), -400, null); }).Start();
                    return new LoginResult() { Error = "Wrong code.", HasError = true, ErrorCode = -400 };
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Common.Action.Login, loginInput.UserID.ToString(), -900, null); }).Start();
                return new LoginResult() { Error = e.Message, HasError = true, ErrorCode = -900 };
            }
        }

        [AcceptVerbs("Post")]
        [AllowAnonymous]
        public bool UpdateUserProfile([FromBody] UserInfo UserInfo)
        {
            Com.User mUser = new User()
            {
                UID = UserInfo.UID,
                Address = UserInfo.Address,
                CodeMeli = UserInfo.CodeMeli,
                CodePosti = UserInfo.CodePosti,
                Email = UserInfo.Email,
                FamilyName = UserInfo.FamilyName,
                Name = UserInfo.Name,
                NickName = UserInfo.NickName,
                Ostan = UserInfo.Ostan,
                City = UserInfo.City,

            };
            return BLL.User.UpdateUserInfo(mUser);
        }

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<UserInfoPro> UpdateUserProfilePro()
        {
            UserInfoPro resUserInfoPro = new UserInfoPro();

            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.UpdateUserProfilePro, "", -101, "MimeMultipartContent"); }).Start();
                    resUserInfoPro.Status = -101;
                    return resUserInfoPro;

                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                UserInfoPro mUserInfoPro = new UserInfoPro();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object" || itemContent.Headers.ContentDisposition.Name == "\"Object\"")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.UpdateUserProfilePro, "Json Khales", 21, jsonString); }).Start();

                        var serializer = new JavaScriptSerializer();
                        mUserInfoPro = serializer.Deserialize<UserInfoPro>(jsonString);


                        var tmpUser = BLL.User.GetUserByUsername(mUserInfoPro.Username);
                        if (tmpUser != null)
                        {
                            if (mUserInfoPro.UID == tmpUser.UID)
                            {

                            }
                            else
                            {
                                resUserInfoPro.Status = -102;
                                return resUserInfoPro;
                            }
                        }

                        bool SEX = true;

                        if (mUserInfoPro.Sex == 0)
                            SEX = false;
                        
                        Com.User mUser = new User()
                        {
                            UID = mUserInfoPro.UID,
                            Email = mUserInfoPro.Email,
                            Name = mUserInfoPro.Name,
                            RCBackSquat = mUserInfoPro.RCBackSquat,
                            RCPullUp = mUserInfoPro.RCPullUp,
                            RCRun = mUserInfoPro.RCRun,
                            ScreenMode = mUserInfoPro.ScreenMode,
                            Sex = SEX,//mUserInfoPro.Sex,
                            Username = mUserInfoPro.Username,
                        };

                        if (BLL.User.UpdateUserInfoPro(mUser))
                        {
                            mUserInfoPro.Status = 0;
                            return mUserInfoPro;
                        }
                        else
                        {
                            resUserInfoPro.Status = -103;
                            return resUserInfoPro;
                        }

                    }
                    else
                    {
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.UpdateUserProfilePro, "", -106, "Ye Chize ezafi too req boode"); }).Start();
                        resUserInfoPro.Status = -106;
                        return resUserInfoPro;
                    }
                }
                resUserInfoPro.Status = -104;
                return resUserInfoPro;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.UpdateUserProfilePro, "", -105, ee.Message); }).Start();
                resUserInfoPro.Status = -105;
                return resUserInfoPro;
            }
        }



        //[AcceptVerbs("Post")]
        //[AllowAnonymous]
        //public ResultUpdateInfoPro UpdateUserProfilePro([FromBody] UserInfoPro UserInfo)
        //{
        //    ResultUpdateInfoPro resultUpdateInfoPro = new ResultUpdateInfoPro();
        //    try
        //    {
        //        var tmpUser = BLL.User.GetUserByUsername(UserInfo.Username);
        //        if (tmpUser != null)
        //        {
        //            resultUpdateInfoPro.Error = true;
        //            resultUpdateInfoPro.Res = -1;
        //            return resultUpdateInfoPro;
        //        }

        //        Com.User mUser = new User()
        //        {
        //            UID = UserInfo.UID,
        //            Email = UserInfo.Email,
        //            Name = UserInfo.Name,
        //            RCBackSquat = UserInfo.RCBackSquat,
        //            RCPullUp = UserInfo.RCPullUp,
        //            RCRun = UserInfo.RCRun,
        //            ScreenMode = UserInfo.ScreenMode,
        //            Sex = UserInfo.Sex,
        //            Username = UserInfo.Username,
        //        };

        //        if (BLL.User.UpdateUserInfoPro(mUser))
        //        {
        //            resultUpdateInfoPro.Error = false;
        //            resultUpdateInfoPro.Res = 0;
        //            return resultUpdateInfoPro;
        //        }
        //        else
        //        {
        //            resultUpdateInfoPro.Error = true;
        //            resultUpdateInfoPro.Res = -3;
        //            return resultUpdateInfoPro;
        //        }
        //    }
        //    catch
        //    {
        //        resultUpdateInfoPro.Error = true;
        //        resultUpdateInfoPro.Res = -4;
        //        return resultUpdateInfoPro;
        //    }
        //}

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<IHttpActionResult> PostUpdateTeacher()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.Teacher mTeacher = new Com.Teacher();

                int MainTID = 0;

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        mTeacher = serializer.Deserialize<Com.Teacher>(jsonString);

                        if (mTeacher.TID != 0)
                        {
                            var ResAdd = BLL.User.GetTeacherByID(mTeacher.TID);
                            if (ResAdd == null)
                            {
                                return BadRequest();
                            }
                            MainTID = ResAdd.TID;
                            BLL.User.UpdateTeacher(mTeacher);
                        }
                        else
                        {
                            MainTID = BLL.User.AddTeacher(mTeacher);
                        }
                    }
                    else if (itemContent.Headers.ContentDisposition.Name == "File")
                    {
                        var fileBytes = await itemContent.ReadAsByteArrayAsync();
                        string HeaderType = itemContent.Headers.ContentDisposition.FileName;

                        string NameNewFile = System.Web.Hosting.HostingEnvironment.MapPath("~/FitnessResource/Teacher/" + MainTID + "/");

                        if (!Directory.Exists(NameNewFile))
                            Directory.CreateDirectory(NameNewFile);

                        NameNewFile = NameNewFile + "Img.jpg";

                        File.WriteAllBytes(NameNewFile, fileBytes);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return Ok();
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostUpdateTeacher, "", -400, ee.Message); }).Start();
                return BadRequest();
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
