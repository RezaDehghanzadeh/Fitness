using Com;
using BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace FitnessWebApp.Controllers
{
    [Authorize]
    public class VODController : ApiController
    {
        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public bool IsVODNameRepeated(string VODName)
        {
            var vod = BLL.VOD.GetVODByName(VODName);
            if (vod == null)
                return false;
            else
                return false;
        }

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<SearchInfoResult> SearchVODAsync()
        {
            try
            {
                SearchInfoResult searchInfoResult = new SearchInfoResult();
                if (!Request.Content.IsMimeMultipartContent())
                {
                    searchInfoResult.HasError = true;
                    searchInfoResult.DescError = "Exception dade: UnsupportedMediaType";
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.GetMegaMovementTraining, "Mov", -100, "Exception dade: UnsupportedMediaType"); });
                    return searchInfoResult;
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();

                VODFilterData VODFilterData = new VODFilterData();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object" || itemContent.Headers.ContentDisposition.Name == "\"Object\"")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        VODFilterData = serializer.Deserialize<VODFilterData>(jsonString);



                        var Res = BLL.VOD.GetVODByFilter(VODFilterData);
                        if (Res != null)
                        {
                            searchInfoResult.HasError = false;
                            searchInfoResult.VODs = Res;
                            return searchInfoResult;
                        }
                        else
                        {
                            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.GetMegaMovementTraining, "Mov", -100, ""); });
                            searchInfoResult.HasError = true;
                            searchInfoResult.DescError = "az halghe biroon oomad toosh hich chizi naboode";
                            return searchInfoResult;
                        }
                    }
                }

                searchInfoResult.HasError = true;
                searchInfoResult.DescError = "az halghe biroon oomad toosh hich chizi naboode";
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.GetMegaMovementTraining, "Mov", -100, "az halghe biroon oomad toosh hich chizi naboode"); });
                return searchInfoResult;
            }
            catch (Exception e)
            {
                SearchInfoResult searchInfoResult = new SearchInfoResult();
                searchInfoResult.HasError = true;
                searchInfoResult.DescError = e.Message;
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.GetMegaMovementTraining, "Mov", -100, e.Message); });
                return searchInfoResult;
            }
        }

        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public bool DeleteVOD(int VID)
        {
            return BLL.VOD.DeleteVOD(VID);
        }

        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public bool DeleteDailyVOD(int DVID)
        {
            return BLL.VOD.DeleteDailyVOD(DVID);
        }



        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public bool DeleteImg(int MTID, int MTDID)
        {
            try
            {
                Com.MovementTrainingDetail movementTrainingDetail = new Com.MovementTrainingDetail() { MTDID = MTDID, MTID = MTID, ImgName = "" };
                var ResMovement = BLL.VOD.UpdateMovementTrainingImgAddress(movementTrainingDetail);
                if (!ResMovement)
                {
                    return false;
                }
                else
                {
                    string rootFolder = @"C:\inetpub\wwwroot\FitnessResource\Movement\" + MTID.ToString() + @"\" + MTDID.ToString();
                    string[] files = Directory.GetFiles(rootFolder);
                    foreach (var file in files)
                    {
                        File.Delete(file);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                BLL.Log.DoLog(Com.Common.Action.DeleteImg, " ", -100, e.Message);
                return false;
            }
        }


        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public List<Com.MovementTraining> GetAllMovementTraining()
        {
            return BLL.VOD.GetAllMovementTraining();
        }

        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public List<Com.MiniVOD> GetPreMadeVOD()
        {
            return BLL.VOD.GetAllPreMadeVOD();
        }
        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public List<Com.DailyVOD> GetAllDailyVOD()
        {
            return BLL.VOD.GetAllDailyVODs();
        }

        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public List<Com.DailyVOD> GetDailyVOD(DateTime Start, DateTime End)
        {
            return BLL.VOD.GetDailyVODs(Start, End);
        }

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<MegaMovement> GetMegaMovementTrainingAsync()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    MegaMovement megaMovementRes = new MegaMovement();
                    megaMovementRes.HasError = true;
                    megaMovementRes.DescError = "Exception dade: UnsupportedMediaType";
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.GetMegaMovementTraining, "Mov", -100, "Exception dade: UnsupportedMediaType"); });
                    return megaMovementRes;
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();

                MovementInput movementInput = new MovementInput();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object" || itemContent.Headers.ContentDisposition.Name == "\"Object\"")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        movementInput = serializer.Deserialize<MovementInput>(jsonString);

                        MegaMovement megaMovement = new MegaMovement();
                        megaMovement.MovementTraining = new MovementTraining();
                        megaMovement.MovementTrainingDetails = new List<MovementTrainingDetail>();

                        var ResMovement = BLL.VOD.GetMovementTraining(movementInput.Part, movementInput.SubPart, movementInput.MoveName);
                        if (ResMovement != null)
                        {
                            megaMovement.MovementTraining = ResMovement;
                            var AllMovDetialRes = BLL.VOD.GetAllMovementTrainingDetailByID(ResMovement.MTID);
                            if (AllMovDetialRes != null)
                            {
                                megaMovement.MovementTrainingDetails = AllMovDetialRes;
                            }

                            return megaMovement;
                        }
                        else
                        {
                            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.GetMegaMovementTraining, "Mov", -100, "Null : " + movementInput.MoveName + " " + movementInput.Part + " " + movementInput.SubPart); });
                            megaMovement.HasError = true;
                            megaMovement.DescError = "az halghe biroon oomad toosh hich chizi naboode";
                            return megaMovement;
                        }
                    }
                }
                MegaMovement megaMovementResError = new MegaMovement();
                megaMovementResError.HasError = true;
                megaMovementResError.DescError = "az halghe biroon oomad toosh hich chizi naboode";
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.GetMegaMovementTraining, "Mov", -100, "az halghe biroon oomad toosh hich chizi naboode"); });
                return megaMovementResError;
            }
            catch (Exception e)
            {
                MegaMovement megaMovement = new MegaMovement();
                megaMovement.HasError = true;
                megaMovement.DescError = e.Message;
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.GetMegaMovementTraining, "Mov", -100, e.Message); });
                return megaMovement;
            }
        }

        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public int GetMovement(string Part, string SubPart, string MoveName)
        {
            var ResMovement = BLL.VOD.GetMovementTraining(Part, SubPart, MoveName);
            if (ResMovement == null)
            {
                return 0;
            }
            else
            {
                return ResMovement.MTID;
            }
        }
        //RemoveMovementTraining
        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public bool RemoveMovement(int MTID)
        {
            Com.MovementTraining mMovementTraining = new Com.MovementTraining()
            {
                MTID = MTID
            };

            return BLL.VOD.RemoveMovementTraining(mMovementTraining);
        }

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<bool> UpdateMovement()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return false;
                }
                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.MovementTraining MovementObject = new Com.MovementTraining();

                if (filesReadToProvider.Contents[0].Headers.ContentDisposition.Name == "Object")
                {
                    var jsonString = await filesReadToProvider.Contents[0].ReadAsStringAsync();
                    var serializer = new JavaScriptSerializer();
                    MovementObject = serializer.Deserialize<Com.MovementTraining>(jsonString);

                    return BLL.VOD.UpdateMovementTraining(MovementObject);
                }
                return false;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.UpdateMovement, "", -400, ee.Message); }).Start();
                return true;
            }
        }
        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<bool> UpdateMovementDetailContent()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return false;
                }
                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.MovementTrainingDetail MovementDetailObject = new Com.MovementTrainingDetail();

                if (filesReadToProvider.Contents[0].Headers.ContentDisposition.Name == "Object")
                {
                    var jsonString = await filesReadToProvider.Contents[0].ReadAsStringAsync();
                    var serializer = new JavaScriptSerializer();
                    MovementDetailObject = serializer.Deserialize<Com.MovementTrainingDetail>(jsonString);

                    return BLL.VOD.UpdateMovementTrainingContext(MovementDetailObject);
                }
                return false;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.UpdateMovementDetailContent, "", -400, ee.Message); }).Start();
                return true;
            }
        }
        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<bool> PostUpdateMovementTrainingContext()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return false;
                }
                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.MovementTrainingDetail movementTrainingDetail = new Com.MovementTrainingDetail();

                if (filesReadToProvider.Contents[0].Headers.ContentDisposition.Name == "Object")
                {
                    var jsonString = await filesReadToProvider.Contents[0].ReadAsStringAsync();
                    var serializer = new JavaScriptSerializer();
                    movementTrainingDetail = serializer.Deserialize<Com.MovementTrainingDetail>(jsonString);

                    return BLL.VOD.UpdateMovementTrainingContext(movementTrainingDetail);
                }
                return false;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostUpdateMovementTrainingContext, "", -400, ee.Message); }).Start();
                return false;
            }
        }

        [AllowAnonymous]
        [AcceptVerbs("Get")]
        public List<UserVOD> GetDailyUserVOD(int UID, DateTime date)
        {
            var tmpUVOD = BLL.User.GetUserVODByTime(UID, date);

            return tmpUVOD;

        }

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<int> PostWodexScore()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -101, "MimeMultipartContent"); }).Start();
                    return -101;
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                ScoreData mVOD = new ScoreData();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object" || itemContent.Headers.ContentDisposition.Name == "\"Object\"")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostVOD, "Json Khales", 21, jsonString); }).Start();

                        var serializer = new JavaScriptSerializer();
                        mVOD = serializer.Deserialize<ScoreData>(jsonString);

                        Random rnd = new Random();
                        int RND = rnd.Next(50, 150);
                     
                        return RND;
                    }
                    else
                    {
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -106, "Ye Chize ezafi too req boode"); }).Start();
                        return -106;
                    }
                }
                return -104;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -105, ee.Message); }).Start();
                return -105;
            }
        }


        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<EquationsOutput> PostEquationsVOD()
        {
            EquationsOutput equationsOutput = new EquationsOutput();
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -101, "MimeMultipartContent"); }).Start();
                    equationsOutput.Status = -101;
                    return equationsOutput;
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                ManualVOD mVOD = new ManualVOD();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object" || itemContent.Headers.ContentDisposition.Name == "\"Object\"")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostVOD, "Json Khales", 21, jsonString); }).Start();

                        var serializer = new JavaScriptSerializer();
                        mVOD = serializer.Deserialize<ManualVOD>(jsonString);

                        Random rnd = new Random();
                        int RND = rnd.Next(50, 150);
                        equationsOutput.WodexScore = RND;
                        RND = rnd.Next(110, 450);
                        equationsOutput.TotalTime = RND;
                        RND = rnd.Next(0, 2);
                        List<string> tmpGPP = new List<string>() { "قدرت", "استقامت عضلانی", "استقامت قلبی عروقی" };
                        equationsOutput.GPP = tmpGPP[RND];
                        RND = rnd.Next(0, 2);
                        List<string> tmpEnergyPathway = new List<string>() { "فسفاژن", "اسید لاکتیک", "هوازی" };
                        equationsOutput.EnergyPathway = tmpEnergyPathway[RND];
                        RND = rnd.Next(0, 3);
                        List<int> tmpSmartScaled = new List<int>() { 100, 75, 50, 25 };
                        equationsOutput.SmartScaled = tmpSmartScaled[RND];
                        equationsOutput.Status = 0;

                        return equationsOutput;
                    }
                    else
                    {
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -106, "Ye Chize ezafi too req boode"); }).Start();
                        equationsOutput.Status = -106;
                        return equationsOutput;
                    }
                }
                equationsOutput.Status = -104;
                return equationsOutput;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -105, ee.Message); }).Start();
                equationsOutput.Status = -105;
                return equationsOutput;
            }
        }
        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<int> PostManualVOD()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -101, "MimeMultipartContent"); }).Start();
                    return -101;
                }

                int NewVID = 0;
                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.ManualVOD mVOD = new Com.ManualVOD();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object" || itemContent.Headers.ContentDisposition.Name == "\"Object\"")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostVOD, "Json Khales", 21, jsonString); }).Start();

                        var serializer = new JavaScriptSerializer();
                        mVOD = serializer.Deserialize<Com.ManualVOD>(jsonString);

                        var tmpVOD = BLL.VOD.GetVODByName(mVOD.Name);
                        if (tmpVOD != null)
                        {
                            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -103, "Name is repeated"); }).Start();
                            return -103;
                        }

                        List<int> tmpNullList = new List<int>();

                        Com.VOD NewVOD = new Com.VOD()
                        {
                            Body = -1,
                            DesignerName = mVOD.UID.ToString(),
                            DesignerUID = mVOD.UID,
                            Energy = -1,
                            Info = "Empty",
                            IsPreMade = false,
                            Modality = 1,
                            Moment = DateTime.Now,
                            Movment = "Empty",
                            Name = mVOD.Name,
                            MovmentCount = -1,
                            Pattern = -1,
                            Place = -1,
                            PublicSkill = -1,
                            Round = "Empty",
                            TimeDuration = -1
                        };

                        int ResAdd = BLL.VOD.AddVOD(NewVOD, tmpNullList, tmpNullList);
                        if (ResAdd < 0)
                        {
                            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -108, "moshkel dar Add VOD"); }).Start();
                            return -108;
                        }

                        //01/01/2021
                        DateTime dateTime = DateTime.Parse(mVOD.StartTime);

                        UserVOD userVOD = new UserVOD()
                        {
                            Date = dateTime.Date,
                            Duration = 0,
                            ItemVOD = "",
                            PureContent = jsonString,
                            UID = mVOD.UID,
                            VID = ResAdd,
                            TypeVODID = 0,
                            TypeVODStr = ""
                        };

                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostVOD, "UID", userVOD.UID, ""); }).Start();
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostVOD, "Json Khales", 1, jsonString); }).Start();


                        int UVID = BLL.User.addUserVOD(userVOD);
                        if (UVID > 0)
                        {
                            return 1;

                        }
                        else
                        {
                            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -107, "Save nashode"); }).Start();
                            return -107;
                        }
                    }
                    else
                    {
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -106, "Ye Chize ezafi too req boode"); }).Start();
                        return -106;
                    }
                }
                return -104;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostManualVOD, "", -400, ee.Message); }).Start();
                return -105;
            }
        }

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<int> PostVOD()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostVOD, "", -101, "MimeMultipartContent"); }).Start();
                    return -101;
                }

                int NewVID = 0;
                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.VOD mVOD = new Com.VOD();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object" || itemContent.Headers.ContentDisposition.Name == "\"Object\"")
                    {

                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        mVOD = serializer.Deserialize<Com.VOD>(jsonString);

                        var tmpVOD = BLL.VOD.GetVODByName(mVOD.Name);
                        if (tmpVOD != null)
                        {
                            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostVOD, "", -103, "Name is repeated"); }).Start();
                            return -103;
                        }

                        var listMov = serializer.Deserialize<List<Com.Mov>>(mVOD.Movment);

                        List<int> ListEQ = new List<int>();
                        List<int> ListMV = new List<int>();

                        foreach (var itemMov in listMov)
                        {
                            var tmpMov = BLL.VOD.GetMovementTraining(itemMov.RX.Part, itemMov.RX.SubPart, itemMov.RX.Movement);
                            var tmpMovFilter = serializer.Deserialize<Com.MovFilter>(tmpMov.Context);

                            ListMV.Add(tmpMov.MTID);
                            foreach (var itemEQ in tmpMovFilter.Equipment)
                            {
                                switch (itemEQ)
                                {
                                    case "Body weight":
                                        ListEQ.Add(1);
                                        break;
                                    case "Barbell":
                                        ListEQ.Add(2);
                                        break;
                                    case "Dumbbells":
                                        ListEQ.Add(3);
                                        break;
                                    case "Kettlebell":
                                        ListEQ.Add(4);
                                        break;
                                    case "Medicine Ball":
                                        ListEQ.Add(5);
                                        break;
                                    case "Pull-Up Bar":
                                        ListEQ.Add(6);
                                        break;
                                    case "Rings":
                                        ListEQ.Add(7);
                                        break;
                                    case "Jump Rope":
                                        ListEQ.Add(8);
                                        break;
                                    case "Box":
                                        ListEQ.Add(9);
                                        break;
                                    case "Rower":
                                        ListEQ.Add(10);
                                        break;
                                    case "AirBike":
                                        ListEQ.Add(11);
                                        break;
                                    case "BikeErg":
                                        ListEQ.Add(12);
                                        break;
                                    case "Running area":
                                        ListEQ.Add(13);
                                        break;
                                    case "AirRunner":
                                        ListEQ.Add(14);
                                        break;
                                    case "Treadmill":
                                        ListEQ.Add(15);
                                        break;
                                    case "SkiErg":
                                        ListEQ.Add(16);
                                        break;
                                    case "SandBag":
                                        ListEQ.Add(17);
                                        break;
                                    case "Dip Bar":
                                        ListEQ.Add(18);
                                        break;
                                    case "Rope":
                                        ListEQ.Add(19);
                                        break;
                                    case "Sled":
                                        ListEQ.Add(20);
                                        break;
                                    case "GHD":
                                        ListEQ.Add(21);
                                        break;
                                    case "Abmat":
                                        ListEQ.Add(22);
                                        break;
                                    case "PVC":
                                        ListEQ.Add(23);
                                        break;
                                    case "TRX":
                                        ListEQ.Add(24);
                                        break;
                                    case "Resistance Band":
                                        ListEQ.Add(25);
                                        break;
                                    default:
                                        // code block
                                        break;
                                }
                            }


                        }

                        ListEQ = ListEQ.Distinct().ToList();
                        ListMV = ListMV.Distinct().ToList();

                        int ResAdd = BLL.VOD.AddVOD(mVOD, ListMV, ListEQ);
                        if (ResAdd < 0)
                        {
                            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostVOD, "", -102, "cant Add to DB"); }).Start();
                            return -102;
                        }
                        else
                        {
                            NewVID = ResAdd;
                        }
                    }
                    else if (itemContent.Headers.ContentDisposition.Name == "File")
                    {
                        var fileBytes = await itemContent.ReadAsByteArrayAsync();
                        string HeaderType = itemContent.Headers.ContentDisposition.FileName;

                        string NameNewFile = System.Web.Hosting.HostingEnvironment.MapPath("~/FitnessResource/VOD/" + NewVID);

                        if (!Directory.Exists(NameNewFile))
                            Directory.CreateDirectory(NameNewFile);

                        NameNewFile = NameNewFile + "/Img" + HeaderType;

                        File.WriteAllBytes(NameNewFile, fileBytes);

                        return NewVID;
                    }
                    else
                    {
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostVOD, "", -106, "Ye Chize ezafi too req boode"); }).Start();
                        return -106;
                    }
                }
                return -104;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostVOD, "", -400, ee.Message); }).Start();
                return -105;
            }
        }
        //[AllowAnonymous]
        //[AcceptVerbs("Post")]
        //public async Task<int> PostHandMadeVOD()
        //{
        //    try
        //    {
        //        if (!Request.Content.IsMimeMultipartContent())
        //        {
        //            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostHandMadeVOD, "", -101, "MimeMultipartContent"); }).Start();
        //            return -101;
        //        }

        //        var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
        //        Com.VOD mVOD = new Com.VOD();
        //        VODHandMade tmpVODHandMade = new VODHandMade();

        //        foreach (var itemContent in filesReadToProvider.Contents)
        //        {
        //            if (itemContent.Headers.ContentDisposition.Name == "Object" || itemContent.Headers.ContentDisposition.Name == "\"Object\"")
        //            {

        //                var jsonString = await itemContent.ReadAsStringAsync();
        //                var serializer = new JavaScriptSerializer();

        //                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostHandMadeVOD, "", 1, jsonString); }).Start();

        //                tmpVODHandMade = serializer.Deserialize<VODHandMade>(jsonString);

        //                mVOD.DesignerName = "tmpVODHandMade.DesignerName";
        //                mVOD.DesignerUID = tmpVODHandMade.DesignerUID;
        //                mVOD.Info = tmpVODHandMade.Info ?? "Khali";
        //                mVOD.IsPreMade = false;
        //                mVOD.Moment = DateTime.Now;
        //                mVOD.Movment = tmpVODHandMade.Movment ?? "Khali";
        //                mVOD.Name = tmpVODHandMade.Name ?? "Khali";
        //                mVOD.Round = tmpVODHandMade.Round ?? "Khali";

        //                var tmpVOD = BLL.VOD.GetVODByName(mVOD.Name);
        //                if (tmpVOD != null)
        //                {
        //                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostHandMadeVOD, "", -103, "Name is repeated"); }).Start();
        //                    return -103;
        //                }

        //                int ResAdd = BLL.VOD.AddVOD(mVOD);
        //                if (ResAdd < 0)
        //                {
        //                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostHandMadeVOD, "", -102, "cant Add to DB"); }).Start();
        //                    return -102;
        //                }
        //                else
        //                {
        //                    return ResAdd;
        //                }
        //            }
        //            else
        //            {
        //                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostHandMadeVOD, "", -106, "Ye Chize ezafi too req boode"); }).Start();
        //                return -106;
        //            }
        //        }
        //        return -104;
        //    }
        //    catch (Exception ee)
        //    {
        //        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostHandMadeVOD, "", -400, ee.Message); }).Start();
        //        return -105;
        //    }
        //}
        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<int> PostMovement()
        {
            try
            {
            //    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", 0, "start 1"); }).Start();

                if (!Request.Content.IsMimeMultipartContent())
                {
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", -101, "MimeMultipartContent"); }).Start();
                    return -101;
                }

                int MTID = 0;
                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.MovementTraining MovementObject = new Com.MovementTraining();
             //   new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", 0, "start 2"); }).Start();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object")
                    {
                    //    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", 0, "start 3"); }).Start();

                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        MovementObject = serializer.Deserialize<Com.MovementTraining>(jsonString);
                       
                  //      new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "pro", 0, MovementObject.Context); }).Start();

                        
                        int ResAdd = BLL.VOD.AddMovementTraining(MovementObject);
                        if (ResAdd < 0)
                        {
                            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", -102, "cant Add to DB"); }).Start();
                            return -102;
                        }
                        else
                        {
                            MTID = ResAdd;
                        }
                    }
                    else if (itemContent.Headers.ContentDisposition.Name == "File")
                    {
                        var fileBytes = await itemContent.ReadAsByteArrayAsync();
                        string HeaderType = itemContent.Headers.ContentDisposition.FileName;

                        string NameNewFile = System.Web.Hosting.HostingEnvironment.MapPath("~/FitnessResource/Movement/" + MTID);

                        if (!Directory.Exists(NameNewFile))
                            Directory.CreateDirectory(NameNewFile);

                        NameNewFile = NameNewFile + "/GifImg" + HeaderType;

                        File.WriteAllBytes(NameNewFile, fileBytes);

                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", 0 , "Added to DB"); }).Start();

                        return MTID;
                    }
                    else
                    {
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", -106, "Ye Chize ezafi too req boode"); }).Start();
                        return -106;
                    }
                }
                return -104;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", -400, ee.Message); }).Start();
                return -105;
            }
        }

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<int> PostMovementDetail()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, " ", -101, "MimeMultipartContent"); }).Start();

                    return -201;
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.MovementTrainingDetail MovementObject = new Com.MovementTrainingDetail();

                int MainMTDID = 0;
                int MainMTID = 0;
                int ImgCount = 0;
                string ImgAddress = "";

                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, " ", 1, filesReadToProvider.Contents.Count().ToString()); }).Start();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        MovementObject = serializer.Deserialize<Com.MovementTrainingDetail>(jsonString);

                        int ResAdd = BLL.VOD.AddMovementTrainingDetail(MovementObject);
                        if (ResAdd < 0)
                        {
                            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, " ", -202, "Chize dg-i toosh boode too request"); }).Start();
                            return -202;
                        }
                        MainMTDID = ResAdd;
                        MainMTID = MovementObject.MTID;
                    }
                    else if (itemContent.Headers.ContentDisposition.Name == "File")
                    {
                        var fileBytes = await itemContent.ReadAsByteArrayAsync();
                        string HeaderType = itemContent.Headers.ContentDisposition.FileName;

                        string NameNewFile = System.Web.Hosting.HostingEnvironment.MapPath("~/FitnessResource/Movement/" + MainMTID + "/" + MainMTDID);

                        if (!Directory.Exists(NameNewFile))
                            Directory.CreateDirectory(NameNewFile);

                        NameNewFile = NameNewFile + "/" + ImgCount + HeaderType;

                        File.WriteAllBytes(NameNewFile, fileBytes);

                        if (ImgCount > 0)
                            ImgAddress = ImgAddress + ",";

                        ImgAddress = ImgAddress + ImgCount + HeaderType;
                        ImgCount++;

                    }
                    else
                    { 
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, " ", -203, "Chize dg-i toosh boode too request"); }).Start();
                        return -203;
                    }
                }

                MovementObject.ImgName = ImgAddress;
                BLL.VOD.UpdateMovementTrainingImgAddress(MovementObject);

                 new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, " ", 1, "OK"); }).Start();

                return 1;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, " ", -200, ee.Message); }).Start();
                return -200;
            }
        }
        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<IHttpActionResult> PostUpdateImgMovementDetail()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.MovementTrainingDetail MovementObject = new Com.MovementTrainingDetail();

                int MainMTDID = 0;
                int MainMTID = 0;
                int ImgCount = 0;
                string ImgAddress = "";

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        MovementObject = serializer.Deserialize<Com.MovementTrainingDetail>(jsonString);

                        var ResAdd = BLL.VOD.GetMovementTrainingDetailByID(MovementObject.MTDID);
                        if (ResAdd == null)
                        {
                            return BadRequest();
                        }
                        MainMTDID = MovementObject.MTDID;
                        MainMTID = MovementObject.MTID;
                    }
                    else if (itemContent.Headers.ContentDisposition.Name == "File")
                    {
                        var fileBytes = await itemContent.ReadAsByteArrayAsync();
                        string HeaderType = itemContent.Headers.ContentDisposition.FileName;

                        string NameNewFile = System.Web.Hosting.HostingEnvironment.MapPath("~/FitnessResource/Movement/" + MainMTID + "/" + MainMTDID);

                        if (!Directory.Exists(NameNewFile))
                            Directory.CreateDirectory(NameNewFile);

                        NameNewFile = NameNewFile + "/" + ImgCount + HeaderType;

                        File.WriteAllBytes(NameNewFile, fileBytes);

                        if (ImgCount > 0)
                            ImgAddress = ImgAddress + ",";

                        ImgAddress = ImgAddress + ImgCount + HeaderType;
                        ImgCount++;

                    }
                    else
                    {
                        return BadRequest();
                    }
                }

                MovementObject.ImgName = ImgAddress;
                BLL.VOD.UpdateMovementTrainingImgAddress(MovementObject);

                return Ok();
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, "", -400, ee.Message); }).Start();
                return BadRequest();
            }
        }
        //[AllowAnonymous]
        //[AcceptVerbs("Post")]
        //public HttpResponseMessage PostMovementTraining()
        //{
        //    //[FromBody] 
        //    Com.MovementTrainingDetail movementTrainingDetail = new Com.MovementTrainingDetail();
        //    Dictionary<string, object> dict = new Dictionary<string, object>();
        //    try
        //    {
        //        var httpRequest = HttpContext.Current.Request;

        //        foreach (string file in httpRequest.Files)
        //        {
        //            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

        //            var postedFile = httpRequest.Files[file];
        //            if (postedFile != null && postedFile.ContentLength > 0)
        //            {
        //                int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

        //                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png" };
        //                var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
        //                var extension = ext.ToLower();
        //                if (!AllowedFileExtensions.Contains(extension))
        //                {
        //                    var message = string.Format("Please Upload image of type .jpg or .png");
        //                    dict.Add("error", message);
        //                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
        //                }
        //                else if (postedFile.ContentLength > MaxContentLength)
        //                {
        //                    var message = string.Format("Please Upload a file upto 1 mb.");
        //                    dict.Add("error", message);
        //                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
        //                }
        //                else
        //                {

        //                    int ResAddMove = BLL.VOD.AddMovementTrainingDetail(movementTrainingDetail);
        //                    if (ResAddMove < 0)
        //                    {
        //                        var message = string.Format("cant add to DB.");
        //                        dict.Add("error", message);
        //                        return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
        //                    }

        //                    var folderPath = System.Web.Hosting.HostingEnvironment.MapPath("~/images/MovementTraining/" + movementTrainingDetail.MTID + "/" + ResAddMove + "/");
        //                    if (!Directory.Exists(folderPath))
        //                        Directory.CreateDirectory(folderPath);

        //                    string Cur1 = folderPath + "1.jpg";
        //                    string Cur2 = folderPath + "2.jpg";
        //                    string Cur3 = folderPath + "3.jpg";
        //                    string Cur4 = folderPath + "4.jpg";

        //                    if (!File.Exists(Cur1))
        //                    {
        //                        postedFile.SaveAs(Cur1);
        //                    }
        //                    else if (!File.Exists(Cur2))
        //                    {
        //                        postedFile.SaveAs(Cur2);
        //                    }
        //                    else if (!File.Exists(Cur3))
        //                    {
        //                        postedFile.SaveAs(Cur3);
        //                    }
        //                    else if (!File.Exists(Cur4))
        //                    {
        //                        postedFile.SaveAs(Cur4);
        //                    }
        //                    else
        //                    {
        //                        var message = string.Format("already there is 4 images");
        //                        dict.Add("error", message);
        //                        return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
        //                    }
        //                }
        //            }

        //            var message1 = string.Format("Image Updated Successfully.");
        //            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementTraining, movementTrainingDetail.MTID.ToString(), 0, null); }).Start();
        //            return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
        //        }
        //        var res = string.Format("Please Upload a image.");
        //        dict.Add("error", res);
        //        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementTraining, movementTrainingDetail.MTID.ToString(), -100, res); }).Start();

        //        return Request.CreateResponse(HttpStatusCode.NotFound, dict);
        //    }
        //    catch (Exception ex)
        //    {
        //        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementTraining, movementTrainingDetail.MTID.ToString(), -200, ex.Message + " Inner: " + ex.InnerException); }).Start();
        //        dict.Add("error", ex.Message);
        //        return Request.CreateResponse(HttpStatusCode.NotFound, dict);
        //    }
        //}

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<IHttpActionResult> PostDailyVOD()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.DailyVOD dailyVOD = new Com.DailyVOD();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        dailyVOD = serializer.Deserialize<Com.DailyVOD>(jsonString);

                        int ResAdd = BLL.VOD.AddDailyVOD(dailyVOD);
                        if (ResAdd < 0)
                        {
                            return BadRequest();
                        }
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
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostDailyVOD, "", -400, ee.Message); }).Start();
                return BadRequest();
            }
        }



        //weight      
        //Rep         
        //Time        
        //Cardio(rep) 
        //Cardio(dis) 

        /////////////////////////////////////////////////////////////
        ///////////////////////////Equations/////////////////////////
        /////////////////////////////////////////////////////////////
        public EquationsGPPOutput DoEquationGPP(EquationsInput equationsInput, MovementInput movementInput, UserPr userPr)
        {
            EquationsGPPOutput equationsGPPOutput = new EquationsGPPOutput();

            var serializer = new JavaScriptSerializer();
            var tmpMov = BLL.VOD.GetMovementTraining(movementInput.Part, movementInput.SubPart, movementInput.MoveName);
            var tmpMovFilter = serializer.Deserialize<Com.MovFilter>(tmpMov.Context);

            try
            {
                if (equationsInput.Pattern == VODPattern.AHAP)
                {

                }
                else
                {

                }
                return equationsGPPOutput;

            }
            catch (Exception e)
            {
                equationsGPPOutput.VODMaharatBadani = VODMaharatBadani.None;
                equationsGPPOutput.Error = true;
                equationsGPPOutput.Desc = e.Message;
                return equationsGPPOutput;
            }

        }


        public EquationsEnergyPathwayOutput DoEquationEnergyPathway(EquationsInput equationsInput, MovementInput movementInput, UserPr userPr)
        {
            EquationsEnergyPathwayOutput equationsEnergyPathwayOutput = new EquationsEnergyPathwayOutput();

            var serializer = new JavaScriptSerializer();
            var tmpMov = BLL.VOD.GetMovementTraining(movementInput.Part, movementInput.SubPart, movementInput.MoveName);
            var tmpMovFilter = serializer.Deserialize<Com.MovFilter>(tmpMov.Context);

            try
            {
                if (equationsInput.Pattern == VODPattern.ForTime || equationsInput.Pattern == VODPattern.AMRAP ||
                    equationsInput.Pattern == VODPattern.EMOM || equationsInput.Pattern == VODPattern.Tabata ||
                    equationsInput.Pattern == VODPattern.ForCompletion)
                {
                    Random random = new Random();
                    int Resrnd = random.Next(50, 100);

                    if (Resrnd <= 50)
                    {
                        equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Phosphagen;
                    }
                    else if (50 < Resrnd && Resrnd < 300)
                    {
                        equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.LacticAcid;
                    }
                    else
                    {
                        equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Aerobic;
                    }
                }

                else if (equationsInput.Pattern == VODPattern.AHAP)
                {
                    if (tmpMovFilter.WhichType == "weight" || tmpMovFilter.WhichType == "Rep" || tmpMovFilter.WhichType == "Time" || tmpMovFilter.WhichType == "Cardio(rep)")
                    {
                        if (equationsInput.Nrep != 0)
                        {
                            if (equationsInput.Nrep < 5)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Phosphagen;
                            }
                            else if (equationsInput.Nrep < 5 && equationsInput.Nrep < 35)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.LacticAcid;

                            }
                            else// (35 < equationsInput.Nrep )
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Aerobic;
                            }
                        }
                        else if (equationsInput.Dis != 0)
                        {
                            if (equationsInput.Dis < 5)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Phosphagen;
                            }
                            else if (equationsInput.Dis < 5 && equationsInput.Dis < 35)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.LacticAcid;

                            }
                            else// (35 < equationsInput.Dis )
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Aerobic;
                            }
                        }
                        else if (equationsInput.T != 0)
                        {
                            float tmpT = equationsInput.T / tmpMovFilter.Time;
                            if (tmpT < 5)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Phosphagen;

                            }
                            else if (5 < tmpT && tmpT < 35)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.LacticAcid;

                            }
                            else  //35 < tmpT
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Aerobic;
                            }

                        }
                        else
                        {
                            equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.None;
                            equationsEnergyPathwayOutput.Error = true;
                        }
                    }
                    else if (tmpMovFilter.WhichType == "Cardio(dis)")
                    {
                        if (equationsInput.Dis != 0)
                        {
                            if (equationsInput.Dis <= 100)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Phosphagen;

                            }
                            else if (100 < equationsInput.Dis && equationsInput.Dis <= 300)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.LacticAcid;
                            }
                            else
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Aerobic;
                            }
                        }
                        else if (equationsInput.T != 0)
                        {
                            if (equationsInput.T <= 100)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Phosphagen;

                            }
                            else if (100 < equationsInput.T && equationsInput.T <= 300)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.LacticAcid;
                            }
                            else
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Aerobic;
                            }
                        }
                        else if (equationsInput.Nrep != 0)
                        {
                            if (equationsInput.Nrep <= 100)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Phosphagen;

                            }
                            else if (100 < equationsInput.Nrep && equationsInput.Nrep <= 300)
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.LacticAcid;
                            }
                            else
                            {
                                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.Aerobic;
                            }
                        }
                        else
                        {
                            equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.None;
                            equationsEnergyPathwayOutput.Error = true;
                        }
                    }
                    else
                    {
                        equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.None;
                        equationsEnergyPathwayOutput.Error = true;
                    }
                }
                else
                {
                    equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.None;
                    equationsEnergyPathwayOutput.Error = true;
                }


                return equationsEnergyPathwayOutput;
            }
            catch (Exception e)
            {
                equationsEnergyPathwayOutput.VODenrgy = VODEnrgy.None;
                equationsEnergyPathwayOutput.Error = true;
                equationsEnergyPathwayOutput.Desc = e.Message;
                return equationsEnergyPathwayOutput;
            }
        }

        public EquationsTotalTimeOutput DoEquationTotalTime(EquationsInput equationsInput, MovementInput movementInput, UserPr userPr)
        {
            EquationsTotalTimeOutput equationsOutputOutput = new EquationsTotalTimeOutput();
            equationsOutputOutput.Error = false;
            equationsOutputOutput.Desc = "";

            try
            {

                var serializer = new JavaScriptSerializer();
                var tmpMov = BLL.VOD.GetMovementTraining(movementInput.Part, movementInput.SubPart, movementInput.MoveName);
                var tmpMovFilter = serializer.Deserialize<Com.MovFilter>(tmpMov.Context);

                if (equationsInput.Pattern == VODPattern.AMRAP)
                {
                    equationsOutputOutput.Time = (equationsInput.Nset * equationsInput.T) + (equationsInput.T_BetRest * (equationsInput.Nset - 1));
                }
                else if (equationsInput.Pattern == VODPattern.ForTime)
                {
                    float MainParam = 0;
                    if (equationsInput.EditionType != VODEditType.Like211519)
                    {

                        if (tmpMovFilter.WhichType == "Cardio(dis)")
                        {
                            if (equationsInput.Nrep != 0 && equationsInput.T != 0 && equationsInput.Dis != 0)
                            {
                                MainParam = equationsInput.T;
                            }
                            else if (equationsInput.Nrep != 0 && equationsInput.Dis != 0)
                            {
                                MainParam = equationsInput.Dis / 10.0f;
                            }
                            else
                            {
                                equationsOutputOutput.Error = true;
                                equationsOutputOutput.Desc = "همه اش صفره";

                                return equationsOutputOutput;
                            }
                        }
                        else
                        {
                            if (equationsInput.Nrep != 0 && equationsInput.T != 0 && equationsInput.Dis != 0)
                            {
                                MainParam = equationsInput.T;
                            }
                            else if (equationsInput.Nrep != 0 && equationsInput.Dis != 0)
                            {
                                MainParam = equationsInput.Nrep;
                            }
                            else if (equationsInput.Dis != 0)
                            {
                                MainParam = equationsInput.Dis;
                            }
                            else
                            {
                                equationsOutputOutput.Error = true;
                                equationsOutputOutput.Desc = "همه اش صفره";

                                return equationsOutputOutput;
                            }
                        }

                    }
                    else // if (equationsInput.EditionType != VODEditType.Like211519)
                    {
                        if (tmpMovFilter.WhichType == "Cardio(dis)")
                        {
                            if (equationsInput.Nrep != 0 && equationsInput.T != 0 && equationsInput.Dis != 0)
                            {
                                MainParam = equationsInput.T;
                            }
                            else if (equationsInput.Nrep != 0 && equationsInput.Dis != 0)
                            {
                                MainParam = equationsInput.Dis / 10.0f;
                            }
                            else
                            {
                                equationsOutputOutput.Error = true;
                                equationsOutputOutput.Desc = "همه اش صفره";

                                return equationsOutputOutput;
                            }
                        }
                        else
                        {
                            if (equationsInput.Nrep != 0 && equationsInput.T != 0 && equationsInput.Dis != 0)
                            {
                                MainParam = equationsInput.T;
                            }
                            else if (equationsInput.Nrep != 0 && equationsInput.Dis != 0)
                            {
                                MainParam = equationsInput.Nrep;
                            }
                            else if (equationsInput.Dis != 0)
                            {
                                MainParam = equationsInput.Dis;
                            }
                            else
                            {
                                equationsOutputOutput.Error = true;
                                equationsOutputOutput.Desc = "همه اش صفره";

                                return equationsOutputOutput;
                            }
                        }
                    }

                    Random random = new Random();
                    int Resrnd = random.Next(50, 100);
                    equationsOutputOutput.Time = Resrnd;

                }
                else if (equationsInput.Pattern == VODPattern.EMOM)
                {
                    equationsOutputOutput.Time = equationsInput.T;
                }
                else if (equationsInput.Pattern == VODPattern.ForCompletion || equationsInput.Pattern == VODPattern.AHAP)
                {
                    Random random = new Random();
                    int Resrnd = random.Next(50, 100);
                    equationsOutputOutput.Time = Resrnd;
                }
                else if (equationsInput.Pattern == VODPattern.Tabata)
                {
                    if (equationsInput.EditionType == VODEditType.EStandard)
                    {
                        Random random = new Random();
                        int Resrnd = random.Next(50, 100);
                        equationsOutputOutput.Time = Resrnd;
                    }
                    else// if (equationsInput.EditionType == VODEditType.alter)
                    {
                        Random random = new Random();
                        int Resrnd = random.Next(50, 100);
                        equationsOutputOutput.Time = Resrnd;
                    }
                }
                else
                {
                    equationsOutputOutput.Error = true;
                }

            }
            catch (Exception e)
            {
                equationsOutputOutput.Error = true;
                equationsOutputOutput.Desc = e.Message;
            }
            return equationsOutputOutput;
        }

        public EquationsSmartScaledOutput DoEquationSmartScaled(EquationsInput equationsInput, MovementInput movementInput, UserPr userPr)
        {
            EquationsSmartScaledOutput equationsOutputOutput = new EquationsSmartScaledOutput();
            equationsOutputOutput.Error = false;
            equationsOutputOutput.Desc = "";

            try
            {
                //weight            Pr          Count   
                //Rep               W           Time    
                //Time              T           Distance
                //Cardio(rep)       Dis         Weight  
                //Cardio(dis)       Nrep 

                var serializer = new JavaScriptSerializer();
                var tmpMov = BLL.VOD.GetMovementTraining(movementInput.Part, movementInput.SubPart, movementInput.MoveName);
                var tmpMovFilter = serializer.Deserialize<Com.MovFilter>(tmpMov.Context);

                if (equationsInput.Pattern != VODPattern.Tabata)
                {
                    if (tmpMovFilter.WhichType == "Rep" || tmpMovFilter.WhichType == "Cardio(rep)")
                    {
                        if (equationsInput.W >= 0)
                            equationsOutputOutput.Weight = equationsInput.W / 2;

                        if (equationsInput.Pr == 0)
                            equationsInput.Pr = tmpMovFilter.ZaribTaAdol * userPr.pr_pull_up;

                        equationsOutputOutput.Rep = (equationsInput.Pr * tmpMovFilter.Time * equationsInput.Nrep) / (60 + (equationsInput.Pr * tmpMovFilter.ZaribTaAdol));
                        equationsOutputOutput.Distance = (equationsInput.Pr * tmpMovFilter.Time * equationsInput.Dis) / (60 + (equationsInput.Pr * tmpMovFilter.ZaribTaAdol));
                        equationsOutputOutput.Time = (equationsInput.Pr * tmpMovFilter.Time * equationsInput.T) / (60 + (equationsInput.Pr * tmpMovFilter.ZaribTaAdol));

                    }
                    else if (tmpMovFilter.WhichType == "Time")
                    {
                        if (equationsInput.W >= 0)
                            equationsOutputOutput.Weight = equationsInput.W / 2;

                        if (equationsInput.Pr == 0)
                            equationsInput.Pr = tmpMovFilter.ZaribTaAdol * userPr.pr_pull_up * tmpMovFilter.Time;


                        equationsOutputOutput.Time = (equationsInput.Pr * equationsInput.T) / (60 + (equationsInput.Pr * tmpMovFilter.ZaribTaAdol / tmpMovFilter.Time));
                        equationsOutputOutput.Rep = (equationsInput.Pr * equationsInput.Nrep) / (60 + (equationsInput.Pr * tmpMovFilter.ZaribTaAdol / tmpMovFilter.Time));
                        equationsOutputOutput.Distance = (equationsInput.Pr * equationsInput.Dis) / (60 + (equationsInput.Pr * tmpMovFilter.ZaribTaAdol / tmpMovFilter.Time));

                    }
                    else if (tmpMovFilter.WhichType == "Cardio(dis)")
                    {
                        if (equationsInput.W >= 0)
                            equationsOutputOutput.Weight = equationsInput.W / 2;

                        if (equationsInput.Pr == 0)
                            equationsInput.Pr = tmpMovFilter.ZaribTaAdol * userPr.pr_400m_run;

                        equationsOutputOutput.Distance = (400 * equationsInput.Dis * tmpMovFilter.Time) / (equationsInput.Pr + (tmpMovFilter.ZaribTaAdol * 400));


                    }
                    else if (tmpMovFilter.WhichType == "weight" && equationsInput.Pattern != VODPattern.AHAP)
                    {
                        if (equationsInput.Pr == 0)
                            equationsInput.Pr = tmpMovFilter.ZaribTaAdol * userPr.pr_squat;

                        if (equationsInput.W <= (equationsInput.Pr * 3.0f) / 10.0f)
                        {
                            equationsInput.Pr = equationsInput.Pr / 2.0f;
                        }
                        else if ((equationsInput.Pr * 3.0f) / 10.0f < equationsInput.W && equationsInput.W <= (equationsInput.Pr * 5.0f) / 10.0f)
                        {
                            equationsInput.Pr = equationsInput.Pr * 3.0f / 4.0f;

                        }
                        //else if((equationsInput.Pr * 5.0f) / 10.0f < equationsInput.W && equationsInput.W <= equationsInput.Pr)
                        //{

                        //}
                        else
                        {
                            //hich kari nemikonim
                        }



                        if (1 <= equationsInput.Nrep && equationsInput.Nrep < 14)
                        {
                            equationsOutputOutput.Weight = equationsInput.Pr * (1.0278f - (equationsInput.Nrep * 0.0278f));
                        }
                        else if (14 <= equationsInput.Nrep && equationsInput.Nrep < 20)
                        {
                            equationsOutputOutput.Weight = equationsInput.Pr * (65.0f + (14.0f - equationsInput.Nrep)) / 100.0f;
                        }
                        else if (20 <= equationsInput.Nrep && equationsInput.Nrep < 26)
                        {
                            equationsOutputOutput.Weight = equationsInput.Pr * (59.25f + ((20.0f - equationsInput.Nrep) * 3.0f / 4.0f)) / 100.0f;
                        }
                        else if (26 <= equationsInput.Nrep && equationsInput.Nrep < 31)
                        {
                            equationsOutputOutput.Weight = equationsInput.Pr * (55.0f + ((26.0f - equationsInput.Nrep) / 2.0f)) / 100.0f;

                        }
                        else if (31 <= equationsInput.Nrep && equationsInput.Nrep < 36)
                        {
                            equationsOutputOutput.Weight = equationsInput.Pr * (52.75f + ((31.0f - equationsInput.Nrep) / 4.0f)) / 100.0f;

                        }
                        else if (36 <= equationsInput.Nrep && equationsInput.Nrep < 51)
                        {
                            equationsOutputOutput.Weight = equationsInput.Pr * (51.6f + ((36.0f - equationsInput.Nrep) * 15.0f / 100.0f)) / 100.0f;

                        }
                        else if (51 <= equationsInput.Nrep && equationsInput.Nrep < 201)
                        {
                            equationsOutputOutput.Weight = equationsInput.Pr * (49.4f + ((51.0f - equationsInput.Nrep) / 10.0f)) / 100.0f;

                        }
                        else if (201 <= equationsInput.Nrep && equationsInput.Nrep < 502)
                        {
                            equationsOutputOutput.Weight = equationsInput.Pr * (34.45f + ((201.0f - equationsInput.Nrep) / 20.0f)) / 100.0f;

                        }
                        else if (502 <= equationsInput.Nrep && equationsInput.Nrep < 1281)
                        {
                            equationsOutputOutput.Weight = equationsInput.Pr * (19.47f + ((502.0f - equationsInput.Nrep) / 400.0f)) / 100.0f;

                        }
                        else
                        {
                            equationsOutputOutput.Weight = equationsInput.Pr * 17.5f / 100.0f;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                equationsOutputOutput.Error = true;
                equationsOutputOutput.Desc = e.Message;
            }
            return equationsOutputOutput;
        }
    }


    public class MovementInput
    {
        public string Part { get; set; }
        public string SubPart { get; set; }
        public string MoveName { get; set; }
    }

    public class MegaMovement
    {
        public Com.MovementTraining MovementTraining { get; set; }
        public List<Com.MovementTrainingDetail> MovementTrainingDetails { get; set; }
        public bool HasError { get; set; }
        public string DescError { get; set; }
    }

    public class UserPr
    {
        public float pr_pull_up { get; set; }
        public float pr_400m_run { get; set; }
        public float pr_squat { get; set; }
    }



}
