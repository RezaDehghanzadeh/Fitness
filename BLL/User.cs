using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class User
    {
        public static Com.User GetLoginByCode(string Tell, string Code)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Users.Where(U => U.ActiveCode == Code && U.TellNumber == Tell).SingleOrDefault();

                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetLoginByCode, Tell, -100, e.Message);
                });
                return null;
            }
        }

        public static List<Com.UserVOD> GetUserVOD(int UID, DateTime date)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.UserVODs.Where(U => U.UID == UID && (U.Date > date.Date.AddDays(-3) || U.Date < date.Date.AddDays(3))).ToList();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetUserVOD, UID.ToString(), -100, e.Message);
                });
                return null;
            }
        }

        public static List<Com.UserBought> GetAllUserBought(int UID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.UserBoughts.Where(U => U.UID == UID).ToList();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetAllUserBought, UID.ToString(), -100, e.Message);
                });
                return null;
            }
        }

        public static List<Com.Teacher> GetAllTeacher()
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Teachers.ToList();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetAllTeacher, "", -100, e.Message);
                });
                return null;
            }
        }
        public static Com.Teacher GetTeacherByID(int TID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Teachers.Where(T => T.TID == TID).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetTeacherByID, "", -100, e.Message);
                });
                return null;
            }
        }
        public static List<Com.UserVOD> GetAllUserVOD(int UID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.UserVODs.Where(U => U.UID == UID).Take(100).ToList();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetAllUserVOD, UID.ToString(), -100, e.Message);
                });
                return null;
            }
        }
        public static List<Com.UserMessage> GetAllUserMessage(int UID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.UserMessages.Where(U => U.UID == UID).Take(100).ToList();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetAllUserMessage, UID.ToString(), -100, e.Message);
                });
                return null;
            }
        }
        public static Com.DailyVOD GetDailyVOD(DateTime date)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.DailyVODs.Where(D => D.Date == date.Date).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetDailyVOD, date.ToString(), -100, e.Message);
                });
                return null;
            }
        }
        public static int addUserVOD(Com.UserVOD userVOD)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.UserVODs.Add(userVOD);
                    ent.SaveChanges();

                    return userVOD.UVID;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.addUserVOD, userVOD.UID.ToString(), -100, e.Message);
                });
                return -100;
            }
        }

        public static int addUserMessage(Com.UserMessage userMessage)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.UserMessages.Add(userMessage);
                    ent.SaveChanges();

                    return userMessage.UMID;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.addUserMessage, userMessage.UID.ToString(), -100, e.Message);
                });
                return -100;
            }
        }

        public static bool UpdateUserVOD(Com.UserVOD mUserVOD)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.UserVODs.Attach(mUserVOD);
                    var Entry = ent.Entry(mUserVOD);
                    Entry.Property(ex => ex.Duration).IsModified = true;
                    Entry.Property(ex => ex.ItemVOD).IsModified = true;
                    Entry.Property(ex => ex.TypeVODStr).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.UpdateUserVOD, mUserVOD.UVID.ToString(), -100, e.Message);
                });
                return false;
            }
        }
        public static bool UpdateUserMessage(Com.UserMessage mUserMessage)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.UserMessages.Attach(mUserMessage);
                    var Entry = ent.Entry(mUserMessage);
                    Entry.Property(ex => ex.Seen).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.UpdateUserVOD, mUserMessage.UMID.ToString(), -100, e.Message);
                });
                return false;
            }
        }
        public static int AddUser(Com.User mUser)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Users.Add(mUser);
                    ent.SaveChanges();

                    return mUser.UID;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.AddUser, mUser.TellNumber, -100, e.Message);
                });
                return -100;
            }
        }
        public static int AddTeacher(Com.Teacher mTeacher)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Teachers.Add(mTeacher);
                    ent.SaveChanges();

                    return mTeacher.TID;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.AddTeacher, "", -100, e.Message);
                });
                return -100;
            }
        }
        public static int AddUserBought(Com.UserBought mUserBought)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.UserBoughts.Add(mUserBought);
                    ent.SaveChanges();

                    return mUserBought.UBID;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.AddUserBought, mUserBought.UID.ToString(), -100, e.Message);
                });
                return -100;
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
                    Log.DoLog(Com.Common.Action.AddUserBought, mDailyVOD.VID.ToString(), -100, e.Message);
                });
                return -100;
            }
        }
        public static Com.User GetUser(int UID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Users.Where(z => z.UID == UID).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate () { Log.DoLog(Com.Common.Action.GetUser, UID.ToString(), -100, e.Message); });
                new System.Threading.Thread(delegate () { Log.DoLog(Com.Common.Action.GetUser, UID.ToString(), -100, e.InnerException.Message); });
                return null;
            }
        }
        public static Com.User GetUserByTellNumber(string TellNumber)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Users.Where(z => z.TellNumber == TellNumber).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.GetUserByTellNumber, TellNumber, -100, e.Message);
                });
                return null;
            }
        }

        public static bool UpdateUserAfterLogin(Com.User mUser)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Users.Attach(mUser);
                    var Entry = ent.Entry(mUser);
                    Entry.Property(ex => ex.Active).IsModified = true;
                    Entry.Property(ex => ex.NickName).IsModified = true;
                    Entry.Property(ex => ex.DeviceID).IsModified = true;
                    Entry.Property(ex => ex.FBToken).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.UpdateUserAfterLogin, mUser.UID.ToString(), -100, e.Message);
                });
                return false;
            }
        }
        public static bool UpdateUserInfo(Com.User mUser)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Users.Attach(mUser);
                    var Entry = ent.Entry(mUser);
                    Entry.Property(ex => ex.CodeMeli).IsModified = true;
                    Entry.Property(ex => ex.Email).IsModified = true;
                    Entry.Property(ex => ex.FamilyName).IsModified = true;
                    Entry.Property(ex => ex.NickName).IsModified = true;
                    Entry.Property(ex => ex.Name).IsModified = true;
                    Entry.Property(ex => ex.Address).IsModified = true;
                    Entry.Property(ex => ex.CodePosti).IsModified = true;
                    Entry.Property(ex => ex.City).IsModified = true;
                    Entry.Property(ex => ex.Ostan).IsModified = true;

                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.UpdateUserInfo, mUser.UID.ToString(), -100, e.Message);
                });
                return false;
            }
        }

        public static bool UpdateUserCode(Com.User mUser)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Users.Attach(mUser);
                    var Entry = ent.Entry(mUser);
                    Entry.Property(ex => ex.ActiveCode).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.UpdateUserCode, mUser.UID.ToString(), -100, e.Message);
                });
                return false;
            }
        }
        public static bool UpdateTeacher(Com.Teacher mTeacher)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Teachers.Attach(mTeacher);
                    var Entry = ent.Entry(mTeacher);
                    Entry.Property(ex => ex.Name).IsModified = true;
                    Entry.Property(ex => ex.ScienceRanking).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                new System.Threading.Thread(delegate ()
                {
                    Log.DoLog(Com.Common.Action.UpdateTeacher, mTeacher.TID.ToString(), -100, e.Message);
                });
                return false;
            }
        }

    }
}
