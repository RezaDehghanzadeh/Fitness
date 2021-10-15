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
            AddVODMovment,
            AddVODEquipment,
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
            GetUserByUsername,
            GetTeacherByID,
            GetPayByID,
            GetPayByBuyID,
            GetAllOrders,
            GetLastUserInfo,
            GetVOD,
            GetVODByName,
            GetCommentByPID,
            GetDailyVODs,
            GetAllDailyVODs,
            GetVODByFilter,
            GetUserVODByTime,
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
            UpdateUserProfilePro,
            PostMovementDetail,
            PostUpdateMovementTrainingContext,
            PostProduct,
            PostUpdateProduct,
            PostMovement,
            PostVOD,
            PostManualVOD,
            PostComment,
            PostDailyVOD,
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
            RemoveMovementTraining
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
        public string Username { get; set; }
        public int Sex { get; set; }
        public double RCBackSquat { get; set; }
        public double RCPullUp { get; set; }
        public double RCRun { get; set; }
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

    public class UserInfoPro
    {
        public int UID { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Sex { get; set; }
        public int ScreenMode { get; set; }
        public float RCBackSquat { get; set; }
        public float RCPullUp { get; set; }
        public float RCRun { get; set; }
        public int Status { get; set; }
    }


    public class ResLastUserInfo
    {
        public MiniUser MiniUser { get; set; }
        public List<Com.UserBought> userBought { get; set; }
        public List<Com.UserMessage> userMessage { get; set; }
    }
    public class ResultUpdateInfoPro
    {
        public bool Error { get; set; }
        public int Res { get; set; }

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

    public partial class VODHandMade
    {
        public string Name { get; set; }
        public string DesignerName { get; set; }
        public int DesignerUID { get; set; }
        public string Info { get; set; }
        public string Round { get; set; }
        public string Movment { get; set; }
    }

    public enum VODEditType
    {
        None,
        Standard,
        Set,
        WithBuyInBuyOut,
        Like211519,
        Alternative,
        OddEven,
        RFT,
        EStandard
    }
    public enum VODPattern
    {
        None,
        AMRAP,
        ForTime,
        EMOM,
        Tabata,
        AHAP,
        ForCompletion///fitness
    }
    public enum VODSpecial
    {
        None,
        CrossFit,
        Gymnastics,
        Bodybuilding,
        OlympicLifting,
        PowerLift,
        Two,
        Swim,
        StrongMan,
        Heat,
    }




    public enum VODModifyTypeEnum
    {
        None,
        Partner,
        WarmUp,
        Open,
        Hero,
        Girls,
        Benchmark,
        BodyBuilding,
        TRX,
    }

    public enum VODEnrgy
    {
        None,
        Phosphagen,//فسفاژن
        LacticAcid,//اسید لاکتیک
        Aerobic,//هوازی
    }

    public enum VODPublicSkill
    {
        None,
        Strength,
        Muscular,
        Cardiovascular
    }

    public enum VODMaharatBadani
    {
        None,
        Power,
        Azolani,
        Ghalbi,
        PowerANDAzolani,
        PowerANDGhalbi,
        AzolaniANDGhalbi,
        PowerANDAzolaniANDGhalbi
    }

    public enum VODTimeDuration
    {
        None,
        Zire5,
        az5ta10,
        az10ta15,
        az15ta20,
        az20ta25,
        az25ta30,
        balaye30
    }



    public class VODFilterData
    {
        public List<int> Equipments { get; set; } //Movment
        public List<int> MovmentNotToBe { get; set; } //Movment
        public int Pattern { get; set; } //Movment
        public int MovmentCount { get; set; }
        public int TimeDuration { get; set; }
        public int Modality { get; set; } ////Movment
        public int Place { get; set; }
        public int Body { get; set; }
        public int Energy { get; set; }
        public int PublicSkill { get; set; }
    }

    public class SearchInfoResult
    {
        public bool HasError { get; set; }
        public List<Com.VOD> VODs { get; set; }
        public string DescError { get; set; }
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
        public string MovementType { get; set; }
        public float KWeightScaled1 { get; set; }
        public MovDetail RX { get; set; }
        public MovDetail S2 { get; set; }
        public MovDetail S3 { get; set; }
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

    public class EvolvedVOD
    {
        public InfoVOD infoVOD { get; set; }
        public Round round { get; set; }
        public List<Mov> movs { get; set; }
    }


    public class EquationsSmartScaledOutput
    {
        public float Rep { get; set; }
        public float Time { get; set; }
        public float Distance { get; set; }
        public float Weight { get; set; }
        public bool Error { get; set; }
        public string Desc { get; set; }
    }
    public class EquationsTotalTimeOutput
    {
        public float Time { get; set; }
        public bool Error { get; set; }
        public string Desc { get; set; }
    }
    public class EquationsEnergyPathwayOutput
    {
        public VODEnrgy VODenrgy { get; set; }
        public bool Error { get; set; }
        public string Desc { get; set; }
    }
    public class EquationsGPPOutput
    {
        public VODMaharatBadani VODMaharatBadani { get; set; }
        public bool Error { get; set; }
        public string Desc { get; set; }
    }

    public class EquationsInput
    {
        public VODEditType EditionType { get; set; }
        public VODPattern Pattern { get; set; }
        public float Pr { get; set; }
        public float W { get; set; }
        public float T { get; set; }
        public float T_BetRest { get; set; }
        public float Dis { get; set; }
        public float Nrep { get; set; }
        public float Nset { get; set; }
    }





    public class UnitMov
    {
        public string id { get; set; }
        public List<Param> Units { get; set; }
    }
    public class Param
    {
        public string Title { get; set; }
        public string id { get; set; }
        public bool Enable { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
        public List<MicroParam> Units { get; set; }
    }

    public class MicroParam
    {
        public string Title { get; set; }
        public string id { get; set; }
        public bool Selected { get; set; }
    }
    public class ScoreData
    {
        int UID { get; set; }
        int VID { get; set; }
        List<int> Trep { get; set; }
        List<int> Nrep { get; set; }
        List<int> Crep { get; set; }

    }

    public class ManualVOD
    {
        public int UID { get; set; }
        public string Name { get; set; }
        public string VODPattern { get; set; }
        public string VODEditType { get; set; }
        public List<ManualMovement> MovmentName { get; set; }
        //param
        public int RoundForTime { get; set; }
        public int Round { get; set; }
        public int Work { get; set; }
        public int TimeCap { get; set; }
        public int minAMRAP { get; set; }
        public int Every { get; set; }
        public int MinOnTheMinFor { get; set; }
        public int RestbetweenSets { get; set; }
        public int Rest { get; set; }
        public List<int> Reps { get; set; }
        public string StartTime { get; set; }
    }

    public class ManualMovement
    {
        public string MovmentName { get; set; }
        public List<zirMajmooe> SeriZirMajmooe { get; set; }
    }

    public class zirMajmooe
    {
        public string ID { get; set; }
        public float Value { get; set; }
        public string UintID { get; set; }
    }

    public class EquationsOutput
    {
        public int WodexScore { get; set; }
        public string GPP { get; set; }
        public string EnergyPathway { get; set; }
        public int SmartScaled { get; set; }
        public int TotalTime { get; set; }
        public int Status { get; set; }
    }

    public class MehrSugest
    {
        public string MovementName { get; set; }
        public string MovementPart { get; set; }
        public string MovementSubpart { get; set; }



        public int Rounds { get; set; }
        public bool RoundsSelected { get; set; }//fekr konam in IsSelected ha ezafe hastan

        public int Work { get; set; }
        public bool WorkSelected { get; set; }

        public int Rest { get; set; }
        public bool RestSelected { get; set; }

        public int Sets { get; set; }
        public bool SetsSelected { get; set; }

        public int Reps { get; set; }
        public int MaxReps { get; set; }
        public bool RepsSelected { get; set; }

        public int Weight { get; set; }
        public string WeightYEKA { get; set; }//KG ? IB???

        public int Distance { get; set; }
        public string DistanceYEKA { get; set; }//m?? feet? cal ? km? yard? mile?

        public int Height { get; set; }
        public string HeightYEKA { get; set; }//cm?? inch? meter ? feet? 

        public int minSec { get; set; }// in bayad tabdil be Saniye beshe, befresti
        public bool minSecSelected { get; set; }
    }
}