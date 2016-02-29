using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigratioWeb.DAL.Models.Mappings
{
    public class DistrictMap : EntityTypeConfiguration<District>
    {
        public DistrictMap()
        {
            this.HasKey(t => t.ID);

            this.Property(t => t.GovernorateID)
                .IsRequired()
                .HasColumnName("GovernorateID");

            this.Property(t => t.Name)
                .HasColumnName("Name");

            this.ToTable("District");
        }
    }
}
