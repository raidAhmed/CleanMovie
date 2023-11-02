using CleanMovie.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure.EntityConfiguration
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Movie").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"BankAccount").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cost).HasColumnName(@"TradeRecord").HasColumnType("int").IsRequired().HasMaxLength(100);
         }
    }
}
