using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VOD
    {
        public static int AddDailyVOD(Com.DailyVOD mDailyVOD)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.DailyVODs.Add(mDailyVOD);
                    ent.SaveChanges();

                    return mDailyVOD.DVID;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.AddDailyVOD, "", -100, e.Message);
                return -100;
            }
        }



        public static int AddVOD(Com.VOD mVOD)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.VODs.Add(mVOD);
                    ent.SaveChanges();

                    return mVOD.VID;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.AddVOD, "", -100, e.Message);
                Log.DoLog(Com.Common.Action.AddVOD, "", -100, e.InnerException.Message);
                return -100;
            }
        }

        public static int AddMovementTraining(Com.MovementTraining mMovementTraining)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.MovementTrainings.Add(mMovementTraining);
                    ent.SaveChanges();

                    return mMovementTraining.MTID;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.AddMovementTraining, "", -100, e.Message);
                return -100;
            }
        }
        public static int AddMovementTrainingDetail(Com.MovementTrainingDetail mMovementTrainingDetail)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.MovementTrainingDetails.Add(mMovementTrainingDetail);
                    ent.SaveChanges();

                    return mMovementTrainingDetail.MTDID;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.AddMovementTrainingDetail, "", -100, e.Message);
                return -100;
            }
        }
        public static Com.MovementTraining GetMovementTraining(string Part, string SubPart, string MoveName)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.MovementTrainings.Where(M => M.Part == Part && M.SubPart == SubPart && M.Movement == MoveName).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetMovementTraining, " ", -100, e.Message);
                return null;
            }
        }
        public static Com.MovementTrainingDetail GetMovementTrainingDetailByID(int MTDID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.MovementTrainingDetails.Where(M => M.MTDID == MTDID).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetMovementTraining, " ", -100, e.Message);
                return null;
            }
        }
        public static Com.VOD GetVOD(int VID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.VODs.Where(M => M.VID == VID).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetVOD, " ", -100, e.Message);
                return null;
            }
        }
        public static List<Com.MiniVOD> GetAllPreMadeVOD()
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.VODs.Where(M => M.IsPreMade == true).Select( M =>new Com.MiniVOD() { 
                        Info = M.Info,
                        Name = M.Name,
                        VID = M.VID,
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetAllPreMadeVOD, " ", -100, e.Message);
                return null;
            }
        }
        public static Com.VOD GetVODByName(string VODName)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.VODs.Where(M => M.Name == VODName).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetVODByName, " ", -100, e.Message);
                return null;
            }
        }


        public static List<Com.DailyVOD> GetAllDailyVODs()
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.DailyVODs.ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetAllDailyVODs, " ", -100, e.Message);
                return null;
            }
        }

        public static List<Com.DailyVOD> GetDailyVODs(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.DailyVODs.Where(M => M.Date < endDate && M.Date > startDate).ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetDailyVODs, " ", -100, e.Message);
                return null;
            }
        }
        public static List<Com.MovementTraining> GetAllMovementTraining()
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.MovementTrainings.ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetAllMovementTraining, " ", -100, e.Message);
                return null;
            }
        }

        public static List<Com.MovementTrainingDetail> GetAllMovementTrainingDetailByID(int MTID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.MovementTrainingDetails.Where(M => M.MTID == MTID).ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetAllMovementTrainingDetailByID, " ", -100, e.Message);
                return null;
            }
        }

        public static bool UpdateMovementTraining(Com.MovementTraining mMovementTraining)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.MovementTrainings.Attach(mMovementTraining);
                    var Entry = ent.Entry(mMovementTraining);
                    Entry.Property(ex => ex.Context).IsModified = true;
                    Entry.Property(ex => ex.VideoAddress).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.UpdateMovementTraining, mMovementTraining.MTID.ToString(), -100, e.Message);
                return false;
            }
        }
        public static bool UpdateVOD(Com.VOD mVOD)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.VODs.Attach(mVOD);
                    var Entry = ent.Entry(mVOD);
                    Entry.Property(ex => ex.Round).IsModified = true;
                    Entry.Property(ex => ex.Info).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.UpdateVOD, mVOD.VID.ToString(), -100, e.Message);
                return false;
            }
        }

        public static bool DeleteVOD(int VID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    Com.VOD mVOD = new Com.VOD () { VID = VID };
                    ent.VODs.Attach(mVOD);
                    ent.VODs.Remove(mVOD);
                    ent.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.DeleteVOD, VID.ToString(), -100, e.Message);
                return false;
            }
        }

        public static bool DeleteDailyVOD(int DVID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    Com.DailyVOD mDailyVOD = new Com.DailyVOD() { DVID = DVID };
                    ent.DailyVODs.Attach(mDailyVOD);
                    ent.DailyVODs.Remove(mDailyVOD);
                    ent.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.DeleteVOD, DVID.ToString(), -100, e.Message);
                return false;
            }
        }
        public static bool UpdateMovementTrainingContext(Com.MovementTrainingDetail mMovementTrainingDetail)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.MovementTrainingDetails.Attach(mMovementTrainingDetail);
                    var Entry = ent.Entry(mMovementTrainingDetail);
                    Entry.Property(ex => ex.ContextDetail).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.UpdateMovementTrainingContext, mMovementTrainingDetail.MTDID.ToString(), -100, e.Message);
                return false;
            }
        }
        public static bool UpdateMovementTrainingImgAddress(Com.MovementTrainingDetail mMovementTrainingDetail)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.MovementTrainingDetails.Attach(mMovementTrainingDetail);
                    var Entry = ent.Entry(mMovementTrainingDetail);
                    Entry.Property(ex => ex.ImgName).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.UpdateMovementTrainingImgAddress, mMovementTrainingDetail.MTDID.ToString(), -100, e.Message);
                return false;
            }
        }


        public static List<Com.Product> GetAllProduct()
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Products.ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetAllProduct, " ", -100, e.Message);
                return null;
            }
        }
    }
}
