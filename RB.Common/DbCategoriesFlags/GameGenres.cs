using System;

namespace RB.Common.DbCategoriesFlags
{
	[ Flags ]
	public enum GameGenres
	{
		Action = 1,

		FirstPerson = 2,

		ThirdPerson = 4,

		Puzzle = 8,

		Survival = 16,

		Horror = 32,

		Platform = 64,

		Racing = 128,

		Strategy = 256,

		Moba = 512,

		Rpg = 1024,

		Mmo = 2048,

		HackAndSlash = 4096,

		ActionAdventure = 8192,

		Stealth = 16384,

		Fighting = 32768,

		Shooter = 65536,

		OpenWorld = 131072,

		Adventure = 262144,

		Simulation = 524288,

		Tactical = 1048576,

		Soccer = 2097152,

		TurnBased = 4194304,

		Sports = 8388608
	}
}