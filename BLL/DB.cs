using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal static class DB
    {
        public static DAL.FitnessEntities Entity
        {
            get
            {
                var ent = new DAL.FitnessEntities();
                ent.Configuration.ValidateOnSaveEnabled = false;
                ent.Configuration.ProxyCreationEnabled = false;
                return ent;
            }
        }
    }
}
