using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigratioWeb.DAL.Models;

namespace MigratioWeb.DAL
{
    public class DistrictDataAccess
    {
        public static List<District> GetDistrictsByGovernorate(List<int> idList)
        {
            using (var context = new Context())
            {
                try
                {
                    var result = context.Districts.Where(t => idList.Contains(t.GovernorateID)).ToList();
                    return result;
                }
                catch (Exception)
                {
                    return new List<District>();
                }
            }
        }

    }
}
