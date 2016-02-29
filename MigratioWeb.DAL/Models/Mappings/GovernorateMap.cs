using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigratioWeb.DAL.Models.Mappings
{
    public class GovernorateMap : EntityTypeConfiguration<Governorate>
    {
        public GovernorateMap()
        {
            this.HasKey(t => t.ID);

            this.Property(t => t.Name)
                .HasColumnName("Name");

            this.ToTable("Governorate");
        }
    }
}
