using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Music;
using RB.Data.DbModels.Store;

namespace RB.Data.Configurations.Music_Configurations
{
	public class AlbumConfiguration : IEntityTypeConfiguration< Album >
	{
		public void Configure( EntityTypeBuilder< Album > builder )
		{
			builder
				.HasOne( a => a.Band )
				.WithMany( b => b.Albums )
				.HasForeignKey( a => a.BandId );

			builder
				.HasMany( a => a.Songs )
				.WithOne( s => s.Album )
				.HasForeignKey( s => s.AlbumId );

			builder
				.HasOne( a => a.Stock )
				.WithOne( s => s.Album )
				.HasForeignKey< AlbumStock >( s => s.AlbumId );
		}
	}
}