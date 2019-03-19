using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RB.Services.Games.Interfaces;
using RB.Services.Store.Interfaces.Games;
using RB.Services.Store.Models.Games;
using RB.WebApp.Models;

namespace RB.WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IGameService service;

		private readonly IGameShoppingCartService gameShoppingCartService;

		public HomeController( IGameService service, IGameShoppingCartService gameShoppingCartService )
		{
			this.service = service;
			this.gameShoppingCartService = gameShoppingCartService;
		}

		public async Task< IActionResult > Index()
		{
//			var res = await this.gameShoppingCartService.ChangeQuantity( new Add_ServiceModel()
//			{
//				GameId = 2,
//				UserId = "6b2fc175-23a5-4013-8d29-61f490850163",
//				Quantity = 10
//			} );

			return this.View();
		}

		public IActionResult Privacy()
		{
			return this.View();
		}

		[ ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true ) ]
		public IActionResult Error()
		{
			return this.View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier } );
		}
	}
}