using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigratioWeb.DAL.Models;
using MigratioWeb.DAL.Models.ViewModels;

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

        public static List<District> GetDistrictsByGovernorate(int id)
        {
            using (var context = new Context())
            {
                try
                {
                    return context.Districts.Where(t => t.GovernorateID == id).ToList();
                }
                catch (Exception)
                {
                    return new List<District>();
                }
            }
        }
    }
}
