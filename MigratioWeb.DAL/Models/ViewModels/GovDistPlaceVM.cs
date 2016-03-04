using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigratioWeb.DAL.Models.ViewModels
{
    public class GovDistPlaceVM
    {
        public Governorate Governorate { get; set; }
        public District District { get; set; }
        public Place Place { get; set; }
    }
}
