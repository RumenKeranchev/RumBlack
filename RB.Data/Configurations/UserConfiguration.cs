using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RB.Data.DbModels.Social;
using RB.Data.DbModels.Store;

namespace RB.Data.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration< User >
	{
		public void Configure( EntityTypeBuilder< User > builder )
		{
			builder
				.HasOne( u => u.Cart )
				.WithOne( c => c.User )
				.HasForeignKey< ShoppingCart >( c => c.UserId );
		}
	}
}