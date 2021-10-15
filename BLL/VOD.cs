using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VOD
    {



        public static List<Com.VOD> GetVODByFilter(int XX)
        {
            try
            {
                using (var ent = DB.Entity)
                {

                    List<Com.VOD> ResList = ent.VODs.Where(a => a.VODModifyTypes.Any(c => c.TID == XX)).ToList();
                    ent.SaveChanges();

                    return ResList;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { Log.DoLog(Com.Common.Action.AddDailyVOD, "", -100, e.Message); }).Start();
                return null;
            }
        }
        public static List<Com.VOD> GetVODByFilter(Com.VODFilterData VODFilterData)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    List<Com.VOD> ResList = ent.VODs
                        .Where(a =>
                        a.Pattern == VODFilterData.Pattern && a.MovmentCount == VODFilterData.MovmentCount && a.TimeDuration == VODFilterData.TimeDuration &&
                        a.Modality == VODFilterData.Modality && a.Place == VODFilterData.Place && a.Body == VODFilterData.Body &&
                        a.Energy == VODFilterData.Energy && a.PublicSkill == VODFilterData.PublicSkill &&
                        a.VODEquipments.Any(c => VODFilterData.Equipments.Contains(c.EID))
                        //&& !a.VODMovments.Any(c => VODFilterData..Contains(c.EID))
                        ).ToList();

                    return ResList;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { Log.DoLog(Com.Common.Action.GetVODByFilter, "", -100, e.Message); }).Start();
                return null;
            }
        }

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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.AddDailyVOD, "", -100, e.Message);
                }).Start();
                return -100;
            }
        }



        public static int AddVOD(Com.VOD mVOD, List<int> ListMV, List<int> ListEQ)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.VODs.Add(mVOD);
                    ent.SaveChanges();

                    List<Com.VODEquipment> vodEquipment = new List<Com.VODEquipment>();
                    List<Com.VODMovment> vodMovment = new List<Com.VODMovment>();

                    foreach (var item in ListEQ)
                        vodEquipment.Add(new Com.VODEquipment() { VID = mVOD.VID, EID = item });

                    foreach (var item in ListMV)
                        vodMovment.Add(new Com.VODMovment() { VID = mVOD.VID, MID = item });

                    ent.VODEquipments.AddRange(vodEquipment);
                    ent.VODMovments.AddRange(vodMovment);

                    ent.SaveChanges();

                    return mVOD.VID;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.AddVOD, "", -100, e.Message);
                }).Start();
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.AddVOD, "Inner", -100, e.InnerException.Message);
                }).Start();
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.AddVOD, "Inner2", -100, e.InnerException.InnerException.Message);
                }).Start();
                return -100;
            }
        }

        public static int AddVODEquipment(Com.VODEquipment vodEquipment)
        {
            try
            {
                using (var ent = DB.Entity)
                {

                    ent.VODEquipments.Add(vodEquipment);
                    ent.SaveChanges();

                    return vodEquipment.VEID;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.AddVODEquipment, "", -100, e.Message);
                }).Start();

                return -100;
            }
        }
        public static int AddVODMovment(Com.VODMovment vodMovment)
        {
            try
            {
                using (var ent = DB.Entity)
                {

                    ent.VODMovments.Add(vodMovment);
                    ent.SaveChanges();

                    return vodMovment.VMID;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.AddVODMovment, "", -100, e.Message);
                }).Start();

                return -100;
            }
        }


        public static bool RemoveMovementTraining(Com.MovementTraining mMovementTraining)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.MovementTrainings.Attach(mMovementTraining);
                    ent.MovementTrainings.Remove(mMovementTraining);
                    ent.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { Log.DoLog(Com.Common.Action.RemoveMovementTraining, "", -100, e.Message); }).Start();
                return false;
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

                    //  new System.Threading.Thread(delegate () { Log.DoLog(Com.Common.Action.AddMovementTraining, " ", mMovementTraining.MTID, ""); }).Start();

                    return mMovementTraining.MTID;
                }
            }
            catch (Exception e)
            {
                //  new System.Threading.Thread(delegate () { Log.DoLog(Com.Common.Action.AddMovementTraining, " ",-100, "ERROR"); }).Start();

                new System.Threading.Thread(delegate () { Log.DoLog(Com.Common.Action.AddMovementTraining, " ", -100, e.Message); }).Start();
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

                    new System.Threading.Thread(delegate () { Log.DoLog(Com.Common.Action.AddMovementTrainingDetail, " ", mMovementTrainingDetail.MTDID, "OK"); }).Start();

                    return mMovementTrainingDetail.MTDID;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {Log.DoLog(Com.Common.Action.AddMovementTrainingDetail, " ", -100, e.Message);}).Start();
                return -100;
            }
        }
        public static Com.MovementTraining GetMovementTraining(string Part, string SubPart, string MoveName)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.MovementTrainings.Where(M => M.Part == Part && M.SubPart == SubPart && M.Movement == MoveName).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetMovementTraining, " ", -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetMovementTraining, " ", -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetVOD, " ", -100, e.Message);
                }).Start();
                return null;
            }
        }
        public static List<Com.MiniVOD> GetAllPreMadeVOD()
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.VODs.Where(M => M.IsPreMade == true).Select(M => new Com.MiniVOD()
                    {
                        Info = M.Info,
                        Name = M.Name,
                        VID = M.VID,
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetAllPreMadeVOD, " ", -100, e.Message);
                }).Start();
                return null;
            }
        }
        public static Com.VOD GetVODByName(string VODName)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.VODs.Where(M => M.Name == VODName).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetVODByName, " ", -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetAllDailyVODs, " ", -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetDailyVODs, " ", -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetAllMovementTraining, " ", -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetAllMovementTrainingDetailByID, " ", -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.UpdateMovementTraining, mMovementTraining.MTID.ToString(), -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.UpdateVOD, mVOD.VID.ToString(), -100, e.Message);
                }).Start();
                return false;
            }
        }

        public static bool DeleteVOD(int VID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    Com.VOD mVOD = new Com.VOD() { VID = VID };
                    ent.VODs.Attach(mVOD);
                    ent.VODs.Remove(mVOD);
                    ent.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.DeleteVOD, VID.ToString(), -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.DeleteVOD, DVID.ToString(), -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.UpdateMovementTrainingContext, mMovementTrainingDetail.MTDID.ToString(), -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.UpdateMovementTrainingImgAddress, mMovementTrainingDetail.MTDID.ToString(), -100, e.Message);
                }).Start();
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
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetAllProduct, " ", -100, e.Message);
                }).Start();
                return null;
            }
        }
    }
}
