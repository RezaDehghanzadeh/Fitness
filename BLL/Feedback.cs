using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Feedback
    {
        public static List<Com.Comment> GetCommentByPID(int PID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Comments.Where(M => M.PID == PID).ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetCommentByPID, " ", -100, e.Message);
                return null;
            }
        }
        public static int AddComment(Com.Comment comment)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Comments.Add(comment);
                    ent.SaveChanges();

                    return comment.ComID;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.AddComment, "", -100, e.Message);
                return -100;
            }
        }

        //public static bool UpdateComment(Com.Comment comment)
        //{
        //    try
        //    {
        //        using (var ent = DB.Entity)
        //        {
        //            ent.Comments.Attach(comment);
        //            var Entry = ent.Entry(comment);
        //            Entry.Property(ex => ex.Round).IsModified = true;
        //            Entry.Property(ex => ex.Info).IsModified = true;
        //            ent.SaveChanges();
        //            return true;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Log.DoLog(Com.Common.Action.UpdateComment, comment.ComID.ToString(), -100, e.Message);
        //        return false;
        //    }
        //}

        public static bool DeleteComment(int ComID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    Com.Comment comment = new Com.Comment() { ComID = ComID };
                    ent.Comments.Attach(comment);
                    ent.Comments.Remove(comment);
                    ent.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.DeleteComment, ComID.ToString(), -100, e.Message);
                return false;
            }
        }
    }
}
