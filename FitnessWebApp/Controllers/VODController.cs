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
        public bool DeleteVOD(int VID)
        {
            return BLL.VOD.DeleteVOD(VID);
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
        public bool GetMovement(string Part, string SubPart, string MoveName)
        {
            var ResMovement = BLL.VOD.GetMovementTraining(Part, SubPart, MoveName);
            if (ResMovement == null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
                    if (itemContent.Headers.ContentDisposition.Name == "Object")
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

                        int ResAdd = BLL.VOD.AddVOD(mVOD);
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

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<int> PostMovement()
        {
            try
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", 0, "start 1"); }).Start();

                if (!Request.Content.IsMimeMultipartContent())
                {
                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", -101, "MimeMultipartContent"); }).Start();
                    return -101;
                }

                int MTID = 0;
                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.MovementTraining MovementObject = new Com.MovementTraining();
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", 0, "start 2"); }).Start();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object")
                    {
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", 0, "start 3"); }).Start();

                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        MovementObject = serializer.Deserialize<Com.MovementTraining>(jsonString);
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", 0, "start 4"); }).Start();

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

                        //  new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovement, "", -102, "cant Add to DB"); }).Start();

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
                    return -201;
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

                        int ResAdd = BLL.VOD.AddMovementTrainingDetail(MovementObject);
                        if (ResAdd < 0)
                        {
                            new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, "", -202, "Chize dg-i toosh boode too request"); }).Start();
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
                        new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, "", -203, "Chize dg-i toosh boode too request"); }).Start();
                        return -203;
                    }
                }

                MovementObject.ImgName = ImgAddress;
                BLL.VOD.UpdateMovementTrainingImgAddress(MovementObject);

                // new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, "", 1, "OK"); }).Start();

                return 1;
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostMovementDetail, "", -200, ee.Message); }).Start();
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


        // GET: api/VOD
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/VOD/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VOD
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/VOD/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/VOD/5
        public void Delete(int id)
        {
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

}
