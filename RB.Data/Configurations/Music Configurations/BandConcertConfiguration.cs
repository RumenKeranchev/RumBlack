using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Music;

namespace RB.Data.Configurations.Music_Configurations
{
    public class BandConcertConfiguration : IEntityTypeConfiguration<BandConcert>
    {
        public void Configure( EntityTypeBuilder< BandConcert > builder )
        {
            builder
                .HasKey(bc => new { bc.BandId, bc.ConcertId });

            builder
                .HasOne(b => b.Band)
                .WithMany(bc => bc.Concerts)
                .HasForeignKey(b => b.BandId);

            builder
                .HasOne(c => c.Concert)
                .WithMany(bc => bc.Bands)
                .HasForeignKey(c => c.ConcertId);
        }
    }
}