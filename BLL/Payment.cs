using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class Payment
    {

        public static int AddPay(Com.Pay mPay)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Pays.Add(mPay);
                    ent.SaveChanges();
                    return mPay.PayID;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.AddPay, mPay.BuyID, -100, e.Message);
                return -100;
            }
        }
        public static Com.Pay GetPayByID(int PayID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Pays.Where(z => z.PayID == PayID).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetPayByID, PayID.ToString(), -100, e.Message);
                return null;
            }
        }
        public static Com.Pay GetPayByBuyID(string BuyID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Pays.Where(z => z.BuyID == BuyID).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetPayByBuyID, BuyID, -100, e.Message);
                return null;
            }
        }

        public static bool UpdatePayAfterDargah(Com.Pay mPay)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Pays.Attach(mPay);
                    var Entry = ent.Entry(mPay);
                    Entry.Property(ex => ex.DargahState).IsModified = true;
                    Entry.Property(ex => ex.Token).IsModified = true;
                    Entry.Property(ex => ex.TrackingNumber).IsModified = true;
                    Entry.Property(ex => ex.ReferenceNumber).IsModified = true;
                    Entry.Property(ex => ex.EndMoment).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.UpdateProduct, mPay.BuyID, -100, e.Message);
                return false;
            }
        }
        public static bool UpdatePayAfterConfirm(Com.Pay mPay)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Pays.Attach(mPay);
                    var Entry = ent.Entry(mPay);
                    Entry.Property(ex => ex.IsReverse).IsModified = true;
                    Entry.Property(ex => ex.FinalState).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.UpdatePayAfterConfirm, mPay.BuyID, -100, e.Message);
                return false;
            }
        }
    }
}
