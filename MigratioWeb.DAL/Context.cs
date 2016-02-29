using MigratioWeb.DAL.Models;
using MigratioWeb.DAL.Models.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigratioWeb.DAL
{
    public class Context : DbContext
    {
        public Context() : base(Constants.ConnectionString)
        {
        }

        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GovernorateMap());
            modelBuilder.Configurations.Add(new DistrictMap());
            modelBuilder.Configurations.Add(new PlaceMap());
        }
    }
}
