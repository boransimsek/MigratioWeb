using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigratioWeb.DAL.Models.ViewModels;

namespace MigratioWeb.DAL
{
    public class PlacesDataAccess
    {
        public static List<GovDistPlaceVM> GetFullPlacesList()
        {
            using (var context = new Context())
            {
                try
                {
                    var result = (from p in context.Places
                                  join d in context.Districts on p.DistrictID equals d.ID
                                  join g in context.Governorates on d.GovernorateID equals g.ID
                                  select new GovDistPlaceVM()
                                  {
                                      Governorate = g,
                                      District = d,
                                      Place = p
                                  }).ToList();
                    return result;
                }
                catch (Exception)
                {
                    return new List<GovDistPlaceVM>();
                }
            }
        }
    }
}
