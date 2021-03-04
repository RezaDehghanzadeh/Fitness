using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Salement
    {
        public static int AddOrder(Com.Order mOrder)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Orders.Add(mOrder);
                    ent.SaveChanges();
                    return mOrder.OID;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.AddOrder, "AddOrder", -100, e.Message);
                return -100;
            }
        }

        public static List<Com.Order> GetAllOrders()
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Orders.ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetAllOrders, "GetAll", -100, e.Message);
                return null;
            }
        }


        public static bool UpdateOrderPayStatus(Com.Order mOrder)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Orders.Attach(mOrder);
                    var Entry = ent.Entry(mOrder);
                    Entry.Property(ex => ex.PayStatus).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.UpdateOrderPayStatus, mOrder.OID.ToString(), -100, e.Message);
                return false;
            }
        }
        public static bool UpdateOrderDeliverStatus(Com.Order mOrder)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Orders.Attach(mOrder);
                    var Entry = ent.Entry(mOrder);
                    Entry.Property(ex => ex.PayStatus).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.UpdateOrderDeliverStatus, mOrder.OID.ToString(), -100, e.Message);
                return false;
            }
        }

    }
}
