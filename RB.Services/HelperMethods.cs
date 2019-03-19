using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RB.Data;
using RB.Data.DbModels.Games;

namespace RB.Services
{
	public static class HelperMethods
	{
		/// <summary>
		/// Takes a file uploaded from the frontend and converts it to byte[]
		/// </summary>
		/// <param name="file"></param>
		/// <returns>byte[]</returns>
		public static byte[] FileToBytes( IFormFile file )
		{
			byte[] result;

			using ( var fileStream = file.OpenReadStream() )
			using ( var memoryStream = new MemoryStream() )
			{
				fileStream.CopyTo( memoryStream );
				result = memoryStream.ToArray();
			}

			return result;
		}
	}
}