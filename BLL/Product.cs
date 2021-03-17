using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Product
    {

        public static List<Com.Category> GetCategories()
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Categories.ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetCategories, " ", -100, e.Message);
                return null;
            }
        }

        public static int AddProduct(Com.Product mProduct)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Products.Add(mProduct);
                    ent.SaveChanges();

                    return mProduct.PID;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.AddProduct, "", -100, e.Message);
                return -100;
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
        public static List<Com.Product> GetProductByIDs(List<int> PIDs)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Products.Where(r => PIDs.Contains(r.PID)).ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetProductByIDs, " ", -100, e.Message);
                return null;
            }
        }
        public static List<Com.Product> GetAllBookProduct()
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Products.Where(W => W.CatID == 1).ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetAllBookProduct, " ", -100, e.Message);
                Log.DoLog(Com.Common.Action.GetAllBookProduct, " ", -100, e.InnerException.Message);
                return null;
            }
        }
        public static List<Com.Product> GetAllDoreProduct()
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Products.Where(W => W.CatID == 2).ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetAllDoreProduct, " ", -100, e.Message);
                Log.DoLog(Com.Common.Action.GetAllDoreProduct, " ", -100, e.InnerException.Message);
                return null;
            }
        }
        public static Com.Product GetProductByID(int PID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Products.Where(P => P.PID == PID).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetProductByID, " ", -100, e.Message);
                return null;
            }
        }

        public static List<Com.Product> GetProductByCatID(int CatID)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    return ent.Products.Where(P => P.CatID == CatID).ToList();
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.GetProductByCatID, " ", -100, e.Message);
                return null;
            }
        }


        public static bool UpdateProduct(Com.Product mProduct)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Products.Attach(mProduct);
                    var Entry = ent.Entry(mProduct);
                    Entry.Property(ex => ex.Description).IsModified = true;
                    Entry.Property(ex => ex.Discount).IsModified = true;
                    Entry.Property(ex => ex.Price).IsModified = true;
                    Entry.Property(ex => ex.specifications).IsModified = true;
                    Entry.Property(ex => ex.Name).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.UpdateProduct, mProduct.PID.ToString(), -100, e.Message);
                return false;
            }
        }

        public static bool UpdateProductImgNumber(Com.Product mProduct)
        {
            try
            {
                using (var ent = DB.Entity)
                {
                    ent.Products.Attach(mProduct);
                    var Entry = ent.Entry(mProduct);
                    Entry.Property(ex => ex.Img).IsModified = true;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.DoLog(Com.Common.Action.UpdateProductImgNumber, mProduct.PID.ToString(), -100, e.Message);
                return false;
            }
        }
    }
}
