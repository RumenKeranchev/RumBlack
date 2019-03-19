using System;

namespace RB.Common.DbCategoriesFlags
{
	[ Flags ]
	public enum MoviesGenres
	{
		Thriller = 1,

		Romance = 2,

		Comedy = 4,

		Horror = 8,

		Action = 16,

		Drama = 32,

		Adventure = 64,

		Documentary = 128,

		Western = 256,

		Animation = 512,

		Noir = 1024,

		Fantasy = 2048,

		Mystery = 4096
	}
}