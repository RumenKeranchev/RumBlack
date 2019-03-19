using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Games;
using RB.Data.DbModels.Store;

namespace RB.Data.Configurations.Game_Configurations
{
	public class GameConfiguration : IEntityTypeConfiguration< Game >
	{
		public void Configure( EntityTypeBuilder< Game > builder )
		{
			builder.Property( g => g.Price ).HasColumnType( "decimal(5,2)" );

			builder
				.HasOne( g => g.Developer )
				.WithMany( d => d.Games )
				.HasForeignKey( g => g.DeveloperId );

			builder
				.HasOne( g => g.Stock )
				.WithOne( s => s.Game )
				.HasForeignKey< GameStock >( g => g.GameId );

			builder
				.HasOne( g => g.SystemRequirements )
				.WithOne( gsr => gsr.Game )
				.HasForeignKey< GameSystemRequirements >( gsr => gsr.GameId );
		}
	}
}