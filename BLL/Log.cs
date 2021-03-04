using Com;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Log
    {
        public static void DoLog(Common.Action act, string UIDorTELL, int Result, string Exception)
        {
            try
            {
                Com.Log mLog = new Com.Log()
                {
                    ActionType = (int)act,
                    Time = DateTime.UtcNow,
                    UIDorTELLNUMBER = UIDorTELL,
                    Result = Result,
                    Exception = Exception
                };
                using (FitnessEntities ent = new FitnessEntities())
                {
                    ent.Logs.Add(mLog);
                    ent.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error On Log: "+e.Message);
            }
        }
    }
}
