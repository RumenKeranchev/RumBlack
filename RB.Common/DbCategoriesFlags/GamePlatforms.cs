using System;

namespace RB.Common.DbCategoriesFlags
{
	[ Flags ]
	public enum GamePlatforms
	{
		MicrosoftWindows = 1,

		MacOs = 2,

		PlayStation = 4,

		XboxOne = 8,

		NintendoSwitch = 16,

		Linux = 32,

		Android = 64
	}
}