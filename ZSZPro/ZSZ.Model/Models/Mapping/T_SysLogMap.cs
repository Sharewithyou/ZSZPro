using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Models.Mapping
{
    public class T_SysLogMap : EntityTypeConfiguration<T_SysLog>
    {
        public T_SysLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Level)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Logger)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Message)
                .IsRequired();

            this.Property(t => t.Exception)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("T_SysLog");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Level).HasColumnName("Level");
            this.Property(t => t.Logger).HasColumnName("Logger");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.Exception).HasColumnName("Exception");
        }
    }
}
