using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigratioWeb.DAL.Models;

namespace MigratioWeb.DAL
{
    public class TestDataAccess
    {
        public static int GetGovernorateCount()
        {
            using (var context = new Context())
            {
                try
                {
                    return context.Governorates.Count();
                }
                catch (Exception exc)
                {
                    return -1;
                }
            }
        }

        public static List<Place> GetPlaces()
        {
            using (var context = new Context())
            {
                try
                {
                    return context.Places.ToList();
                }
                catch (Exception exc)
                {
                    return new List<Place>();
                }
            }
        }
    }
}
