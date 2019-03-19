using System;

namespace RB.Common.DbCategoriesFlags
{
	[ Flags ]
	public enum MusicGenres
	{
		HipHop = 1,

		Edm = 2,

		Rock = 4,

		Reggae = 8,

		Pop = 16,

		Blues = 32,

		Folk = 64,

		Country = 128,

		HeavyMetal = 256,

		Swing = 512,

		Dubstep = 1024,

		House = 2048
	}
}