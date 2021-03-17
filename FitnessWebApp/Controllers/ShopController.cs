using Newtonsoft.Json;
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
    public class ShopController : ApiController
    {
        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<IHttpActionResult> PostComment()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.Comment mComment = new Com.Comment();

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        mComment = serializer.Deserialize<Com.Comment>(jsonString);

                        int ResAdd = BLL.Feedback.AddComment(mComment);
                        //TODO: Add to product rate.
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
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostComment, "", -400, ee.Message); }).Start();
                return BadRequest();
            }
        }

        [AcceptVerbs("Get")]
        [Authorize]
        public List<Com.Comment> GetCommentOfPID(int PID)
        {
            return BLL.Feedback.GetCommentByPID(PID);
        }


        [AcceptVerbs("Get")]
        [Authorize]
        public List<Com.Category> GetCategories()
        {
            return BLL.Product.GetCategories();
        }


        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public List<Com.Product> GetProductByCatID(int CatID)
        {
            return BLL.Product.GetProductByCatID(CatID);
        }
        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public List<Com.Product> GetAllProduct()
        {
            return BLL.Product.GetAllProduct();
        }

        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public List<Com.Product> GetProductByIDs([FromUri] List<int> PIDs)
        {
            return BLL.Product.GetProductByIDs(PIDs);
        }
        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public List<Com.Product> GetAllBook()
        {
            return BLL.Product.GetAllBookProduct();
        }
        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public List<Com.Product> GetAllDore()
        {
            return BLL.Product.GetAllDoreProduct();
        }
        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public List<Com.Product> GetAllProductByCategory(int CatID)
        {
            return BLL.Product.GetProductByCatID(CatID);
        }

        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public Com.Product GetProductByID(int PID)
        {
            return BLL.Product.GetProductByID(PID);
        }

        [AcceptVerbs("Post")]
        [AllowAnonymous]
        public int AddProduct([FromBody] Com.Product product)
        {
            return BLL.Product.AddProduct(product);
        }

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<IHttpActionResult> PostProduct()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.Product mProduct = new Com.Product();

                int MainPID = 0;
                int Imgcount = 0;

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        mProduct = serializer.Deserialize<Com.Product>(jsonString);

                        int ResAdd = BLL.Product.AddProduct(mProduct);
                        if (ResAdd < 0)
                        {
                            return BadRequest();
                        }
                        MainPID = ResAdd;
                    }
                    else if (itemContent.Headers.ContentDisposition.Name == "File")
                    {
                        var fileBytes = await itemContent.ReadAsByteArrayAsync();
                        string HeaderType = itemContent.Headers.ContentDisposition.FileName;

                        string NameNewFile = System.Web.Hosting.HostingEnvironment.MapPath("~/FitnessResource/Product/" + MainPID);

                        if (!Directory.Exists(NameNewFile))
                            Directory.CreateDirectory(NameNewFile);

                        NameNewFile = NameNewFile + "/" + Imgcount.ToString() + HeaderType;

                        File.WriteAllBytes(NameNewFile, fileBytes);
                        Imgcount++;

                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                Com.Product mProductUpdate = new Com.Product();
                mProductUpdate.PID = MainPID;
                mProductUpdate.Img = (Imgcount - 1).ToString();

                BLL.Product.UpdateProductImgNumber(mProductUpdate);

                return Ok();
            }
            catch (Exception ee)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostProduct, "", -400, ee.Message); }).Start();
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<IHttpActionResult> PostUpdateProduct()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                Com.Product mProduct = new Com.Product();

                int Imgcount = 0;

                foreach (var itemContent in filesReadToProvider.Contents)
                {
                    if (itemContent.Headers.ContentDisposition.Name == "Object")
                    {
                        var jsonString = await itemContent.ReadAsStringAsync();
                        var serializer = new JavaScriptSerializer();
                        mProduct = serializer.Deserialize<Com.Product>(jsonString);

                        if (!BLL.Product.UpdateProduct(mProduct))
                        {
                            return BadRequest();
                        }
                    }
                    else if (itemContent.Headers.ContentDisposition.Name == "File")
                    {
                        string rootFolder = @"C:\inetpub\wwwroot\FitnessResource\Product\" + mProduct.PID;

                        if (!Directory.Exists(rootFolder))
                            Directory.CreateDirectory(rootFolder);

                        string[] files = Directory.GetFiles(rootFolder);
                        foreach (var file in files)
                        {
                            File.Delete(file);
                        }

                        var fileBytes = await itemContent.ReadAsByteArrayAsync();
                        string HeaderType = itemContent.Headers.ContentDisposition.FileName;

                        string NameNewFile = System.Web.Hosting.HostingEnvironment.MapPath("~/FitnessResource/Product/" + mProduct.PID);

                        if (!Directory.Exists(NameNewFile))
                            Directory.CreateDirectory(NameNewFile);

                        NameNewFile = NameNewFile + "/" + Imgcount.ToString() + HeaderType;

                        File.WriteAllBytes(NameNewFile, fileBytes);

                        Imgcount++;


                        mProduct.Img = Imgcount.ToString();

                        BLL.Product.UpdateProductImgNumber(mProduct);
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
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.PostUpdateProduct, "", -400, ee.Message); }).Start();
                return BadRequest();
            }
        }

        [AcceptVerbs("Get")]
        [AllowAnonymous]
        public Com.Pay GetPayResult(int PayID)
        {
            return BLL.Payment.GetPayByID(PayID);
        }
        [AcceptVerbs("Post")]
        [AllowAnonymous]
        public IHttpActionResult CallBackPayResult(HttpRequestMessage request)
        {
            try
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.CallBackPayResult, "", 0, "STAART"); }).Start();

                var form = request.Content.ReadAsFormDataAsync().Result;
                Com.PayEndResult payEndResult = new Com.PayEndResult();

                payEndResult.ErrorCode = form["ErrorCode"];
                payEndResult.BuyID = form["BuyID"];
                payEndResult.ErrorDescription = form["ErrorDescription"];
                payEndResult.ReferenceNumber = form["ReferenceNumber"];
                payEndResult.State = Int32.Parse(form["State"]);
                payEndResult.Token = form["Token"];
                payEndResult.TrackingNumber = form["TrackingNumber"];

                Com.PayVerifiedData payVerifiedData = new Com.PayVerifiedData();

                var pay = BLL.Payment.GetPayByBuyID(payEndResult.BuyID);
                if (pay == null)
                {
                    Com.PayVerifiedData mPayVerifiedDataTmp = new Com.PayVerifiedData()
                    {
                        ForceReverse = true,
                        Token = payEndResult.Token
                    };
                    var resTmp = PayConfirm(mPayVerifiedDataTmp);
                    //chio to Db updte konam Akhe !

                    new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.CallBackPayResult, payEndResult.BuyID, 2, "Bad END"); }).Start();
                    // return Redirect("https://www.hasma.ir/payment/failed");
                    return Redirect("wodex://purchase");

                }
                else
                {
                    pay.ReferenceNumber = payEndResult.ReferenceNumber;
                    pay.DargahState = payEndResult.State;
                    pay.Token = payEndResult.Token;
                    pay.TrackingNumber = payEndResult.TrackingNumber;
                    pay.EndMoment = DateTime.Now;

                    BLL.Payment.UpdatePayAfterDargah(pay);
                }

                Com.PayVerifiedData mPayVerifiedData = new Com.PayVerifiedData()
                {
                    ForceReverse = false,
                    Token = pay.Token,
                    TrackingNumber = pay.TrackingNumber,
                    State = pay.DargahState ?? 0,
                    ReferenceNumber = pay.ReferenceNumber,
                    Amount = pay.Amount,
                    BuyID = pay.BuyID
                };
                var resFinal = PayConfirm(mPayVerifiedData);

                if (resFinal.Status == 1)
                {
                    pay.FinalState = resFinal.Status;
                    pay.IsReverse = false;
                    BLL.Payment.UpdatePayAfterConfirm(pay);
                }
                else
                {
                    pay.FinalState = resFinal.Status;
                    pay.IsReverse = true;
                    BLL.Payment.UpdatePayAfterConfirm(pay);
                }

                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.CallBackPayResult, payEndResult.BuyID, 1, "Happy END"); }).Start();
                //  return Redirect("https://www.hasma.ir/payment/Success/" + payEndResult.TrackingNumber);
                return Redirect("wodex://purchase");
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.CallBackPayResult, "payEndResult", -100, e.Message); }).Start();
                //return Redirect("https://www.hasma.ir/payment/failed");
                return Redirect("wodex://purchase");
            }
        }

        [AllowAnonymous]
        [AcceptVerbs("Post")]
        public async Task<Com.BuyResult> Buy()
        {
            Com.BuyResult buyResult = new Com.BuyResult();
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    buyResult.HasError = true;
                    buyResult.StateDesc = "Exception dade: UnsupportedMediaType";
                    return buyResult;
                }


                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();

                if (filesReadToProvider.Contents[0].Headers.ContentDisposition.Name == "Object" || filesReadToProvider.Contents[0].Headers.ContentDisposition.Name == "\"Object\"")
                {
                    var jsonString = await filesReadToProvider.Contents[0].ReadAsStringAsync();
                    var serializer = new JavaScriptSerializer();
                    Com.MiddlePayment mMiddlePayment = serializer.Deserialize<Com.MiddlePayment>(jsonString);


                    double SumPrice = 0;
                    foreach (var itemPro in mMiddlePayment.productInfos)
                    {
                        var pr = BLL.Product.GetProductByID(itemPro.PID);
                        if (pr == null)
                        {
                            buyResult.HasError = true;
                            buyResult.StateDesc = "product nistesh";
                            return buyResult;
                        }
                        SumPrice = SumPrice + (pr.Discount * itemPro.Count);
                    }


                    Com.Order order = new Com.Order()
                    {
                        IsDelivered = false,
                        OrderTime = DateTime.Now,
                        PayStatus = false,
                        ProductsInfo = JsonConvert.SerializeObject(mMiddlePayment.productInfos),
                        ReciverInfo = JsonConvert.SerializeObject(mMiddlePayment.MiliUser),
                        UID = mMiddlePayment.MiliUser.UID,

                    };
                    int OIDRes = BLL.Salement.AddOrder(order);
                    if (OIDRes < 0)
                    {
                        buyResult.HasError = true;
                        buyResult.StateDesc = "Etela'at Kharid dar DB Save nashode";
                        return buyResult;
                    }

                    string BuyID = "70000332" + DateTime.Now.ToString("MMddyyyyhmms");


                    Com.PayResultRequested payResultRequested = PayStart(10000, BuyID);
                    if (payResultRequested.Result > 0)
                    {

                        Com.Pay newPay = new Com.Pay()
                        {
                            Amount = 10000,//MablagheGhabelePardakht
                            BuyID = BuyID,
                            StartMoment = DateTime.Now,
                            UID = mMiddlePayment.MiliUser.UID,
                            OID = OIDRes
                        };
                        int resDB = BLL.Payment.AddPay(newPay);
                        if (resDB < 0)
                        {
                            buyResult.HasError = true;
                            buyResult.StateDesc = "Etela'at pardakht dar DB Save nashode";
                            return buyResult;
                        }

                        buyResult.PayID = resDB;
                        buyResult.MablagheKoleKharid = (long)SumPrice;
                        buyResult.HasError = false;
                        buyResult.LinkPardakht = "http://www.poolban.ir/V2PayGate/Pool/StartPayRedirectww/" + payResultRequested.Result;
                        buyResult.StateDesc = "OK Successsssss hoooraaa";
                    }
                    else
                    {
                        buyResult.MablagheKoleKharid = (long)SumPrice;
                        buyResult.HasError = true;
                        buyResult.StateDesc = "irad dar dargahe pardakht";
                    }

                    return buyResult;
                }
                else
                {
                    buyResult.HasError = true;
                    buyResult.StateDesc = "eshtbahi dar ersal Post pish amade";
                    return buyResult;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { BLL.Log.DoLog(Com.Common.Action.Buy, "", -100, e.Message); }).Start();
                buyResult.HasError = true;
                buyResult.StateDesc = "Exception dade: " + e.Message;
                return buyResult;
            }
        }


        public Com.PayResultRequested PayStart(int Amount, string BuyID)
        {

            Com.PayStart mPayStart = new Com.PayStart()
            {
                Amount = Amount,
                BuyID = BuyID,
                CallBackURl = "http://193.105.234.83/fintness/Shop/CallBackPayResult",
                Language = "fa",
                TerminalNumber = "70000332"
            };

            var webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json;charset=utf-8";
            var rawMessage = JsonConvert.SerializeObject(mPayStart);

            rawMessage = webClient.UploadString("http://www.poolban.ir/payGate/pay/SendCustomerToIPG", rawMessage);

            var Result = JsonConvert.DeserializeObject<Com.PayResultRequested>(rawMessage);

            return Result;
        }

        public Com.PayFinalResult PayConfirm(Com.PayVerifiedData mPayVerifiedData)
        {

            var webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json;charset=utf-8";
            var rawMessage = JsonConvert.SerializeObject(mPayVerifiedData);

            rawMessage = webClient.UploadString("http://www.poolban.ir/PayGate/pay/VerifiedCustomerForIPG", rawMessage);

            var Result = JsonConvert.DeserializeObject<Com.PayFinalResult>(rawMessage);

            return Result;
        }


    }
}
