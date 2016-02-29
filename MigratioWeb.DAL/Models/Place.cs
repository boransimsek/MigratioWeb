using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigratioWeb.DAL.Models
{
    public class Place
    {
        public int ID { get; set; }
        public int DistrictID { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }
}
