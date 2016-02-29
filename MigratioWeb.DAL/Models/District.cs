using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigratioWeb.DAL.Models
{
    public class District
    {
        public int ID { get; set; }
        public int GovernorateID { get; set; }
        public string Name { get; set; }
    }
}
