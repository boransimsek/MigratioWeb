using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigratioWeb.DAL.Models;

namespace MigratioWeb.DAL
{
    public class GovernorateDataAccess
    {
        public static List<Governorate> GetGovernorates()
        {
            using (var context = new Context())
            {
                try
                {
                    return context.Governorates.ToList();
                }
                catch (Exception)
                {
                    return new List<Governorate>();
                }
            }
        }

    }
}
