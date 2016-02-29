using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigratioWeb.DAL.Models.Mappings
{
    public class PlaceMap : EntityTypeConfiguration<Place>
    {
        public PlaceMap()
        {
            this.HasKey(t => t.ID);
            this.Property(t => t.DistrictID)
                .IsRequired()
                .HasColumnName("DistrictID");

            this.Property(t => t.Name)
                .HasColumnName("Name");

            this.Property(t => t.Latitude)
                .HasColumnName("Latitude");

            this.Property(t => t.Longitude)
                .HasColumnName("Longitude");

            this.ToTable("Place");

        }
    }
}
