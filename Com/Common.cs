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
            AddTeacher,
            AddMovementTraining,
            AddMovementTrainingDetail,
            AddPay,
            AddOrder,
            AddVOD,
            AddComment,
            UpdateUser,
            UpdateUserCode,
            UpdateOrderPayStatus,
            UpdateOrderDeliverStatus,
            UpdateUserAfterLogin,
            UpdateUserInfo,
            UpdateTeacher,
            SignUpUser,
            ActiveUser,
            GetUser,
            GetMovementTraining,
            GetMovementTrainingByFilter,
            GetUserByTellNumber,
            GetTeacherByID,
            GetPayByID,
            GetPayByBuyID,
            GetAllOrders,
            GetLastUserInfo,
            GetVOD,
            GetVODByName,
            GetCommentByPID,
            GetDailyVODs,
            Logon,
            Login,
            SendSMS,
            PostMovementTraining,
            GetAllMovementTrainingDetailByID,
            GetAllMovementTraining,
            GetAllPreMadeVOD,
            UpdateMovementDetailContent,
            UpdatePayAfterConfirm,
            UpdateVOD,
            UpdateMovement,
            PostMovementDetail,
            PostUpdateMovementTrainingContext,
            PostProduct,
            PostUpdateProduct,
            PostMovement,
            PostVOD,
            PostComment,
            PostUpdateTeacher,
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
            GetAllTeacher,
            GetAllUserVOD,
            GetAllProduct,
            GetAllBookProduct,
            GetAllDoreProduct,
            GetAllUserMessage,
            addUserMessage,
            AddDailyVOD,
            GetProductByID,
            GetProductByCatID,
            GetProductByIDs,
            GetCategories,
            DeleteImg,
            DeleteVOD,
            DeleteComment,
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
        public string Ostan { get; set; }
    }
    public class MiniUser
    {
        public int UID { get; set; }
        public string TellNumber { get; set; }
        public string Email { get; set; }
        public int Credit { get; set; }
        public System.DateTime JoinDate { get; set; }
        public System.DateTime LastLogin { get; set; }
        public int RewardState { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string NickName { get; set; }
        public string CodeMeli { get; set; }
        public string Address { get; set; }
        public string CodePosti { get; set; }
        public string City { get; set; }
        public string Ostan { get; set; }
    }
    public class UserInfo
    {
        public int UID { get; set; }
        public string TellNumber { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }

        public string CodeMeli { get; set; }
        public string Address { get; set; }
        public string CodePosti { get; set; }
        public string City { get; set; }
        public string Ostan { get; set; }
    }
    public class ResLastUserInfo
    {
        public MiniUser MiniUser { get; set; }
        public List<Com.UserBought> userBought { get; set; }
        public List<Com.UserMessage> userMessage { get; set; }
    }


    public class SpecDore
    {
        public string State { get; set; } // Normal, ComingSoon, Expire , TamdidShode
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseDuration { get; set; }
        public List<Com.Teacher> Teachers { get; set; }
        public List<Sess> Sessions { get; set; }
        public List<string> agenda { get; set; }
        public List<FQ> FAQ { get; set; }
    }

    public class FQ
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    public class Sess
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }

    public class MiniVOD
    {
        public int VID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

    }


}