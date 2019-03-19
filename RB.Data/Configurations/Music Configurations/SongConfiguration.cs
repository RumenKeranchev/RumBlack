using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Music;
using RB.Data.DbModels.Store;

namespace RB.Data.Configurations.Music_Configurations
{
	public class SongConfiguration : IEntityTypeConfiguration< Song >
	{
		public void Configure( EntityTypeBuilder< Song > builder )
		{
			builder
				.HasOne( s => s.Stock )
				.WithOne( st => st.Song )
				.HasForeignKey< SongStock >( st => st.SongId );
		}
	}
}