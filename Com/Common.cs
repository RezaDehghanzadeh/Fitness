using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com
{
    public class Common
    {
        public enum Action
        {
            AddUser,
            AddProduct,
            AddMovementTraining,
            AddMovementTrainingDetail,
            AddPay,
            AddOrder,
            UpdateUser,
            UpdateUserCode,
            UpdateOrderPayStatus,
            UpdateOrderDeliverStatus,
            SignUpUser,
            ActiveUser,
            GetUser,
            GetMovementTraining,
            GetMovementTrainingByFilter,
            GetUserByTellNumber,
            GetPayByID,
            GetPayByBuyID,
            GetAllOrders,
            Logon,
            Login,
            SendSMS,
            PostMovementTraining,
            GetAllMovementTrainingDetailByID,
            GetAllMovementTraining,
            UpdateMovementDetailContent,
            UpdatePayAfterConfirm,
            PostMovementDetail,
            PostUpdateMovementTrainingContext,
            PostProduct,
            PostUpdateProduct,
            UpdateMovement,
            PostMovement,
            GetLoginByCode,
            GetUserVOD,
            addUserVOD,
            UpdateUserVOD,
            UpdateMovementTraining,
            UpdateMovementTrainingContext,
            UpdateMovementTrainingImgAddress,
            UpdateProduct,
            UpdateProductImgNumber,
            AddUserBought,
            GetDailyVOD,
            GetAllUserBought,
            GetAllUserVOD,
            GetAllProduct,
            GetAllBookProduct,
            GetAllUserMessage,
            addUserMessage,
            AddDailyVOD,
            GetProductByID,
            GetProductByCatID,
            GetCategories,
            DeleteImg,
            GetMegaMovementTraining,
            CallBackPayResult,
            Buy,

        }
    }

    public class LogonResult
    {
        public int UserID { get; set; }
        public bool IsNew { get; set; }
        public string NickName { get; set; }
        public bool HasError { get; set; }
    }
    public class LoginInput
    {
        public int UserID { get; set; }
        public string ActiveCode { get; set; }
        public string DeviceID { get; set; }
        public string FBToken { get; set; }
        public string InviterTellNumber { get; set; }
        public string NickName { get; set; }

    }
    public class LoginResult
    {
        public bool StatusResult { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
        public int ErrorCode { get; set; }
        public string Token { get; set; }
    }

    public class PayStart
    {
        public int Amount { get; set; }
        public string Language { get; set; }
        public string BuyID { get; set; }
        public string TerminalNumber { get; set; }
        public string CallBackURl { get; set; }

    }
    public class PayResultRequested
    {
        public int Result { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorCode { get; set; }
    }

    [Serializable]
    public class PayEndResult
    {
        public int State { get; set; }
        public string BuyID { get; set; }
        public string Token { get; set; }
        public string TrackingNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorCode { get; set; }
    }

    public class PayFinalResult
    {
        public int Status { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorCode { get; set; }
    }

    public class PayVerifiedData
    {
        public long Amount { get; set; }
        public int State { get; set; }
        public string BuyID { get; set; }
        public string Token { get; set; }
        public string TrackingNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public bool ForceReverse { get; set; }
    }

    public class BuyResult
    {
        public long MablagheKoleKharid { get; set; }
        public bool HasError { get; set; }
        public string StateDesc { get; set; }
        public string LinkPardakht { get; set; }
        public int PayID { get; set; }
    }

    public class MiddlePayment
    {
        public List<ProductInfo> productInfos { get; set; }
        public MiliUser MiliUser { get; set; }

    }

    public class ProductInfo
    {
        public int PID { get; set; }
        public int Count { get; set; }
    }

    public class MiliUser
    {
        public int UID { get; set; }
        public string TellNumber { get; set; }
        public string Name { get; set; }
        public string CodeMeli { get; set; }
        public string Address { get; set; }
        public string CodePosti { get; set; }
        public string City { get; set; }
    }
}
