﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RB.Data;
using RB.Data.DbModels.Social;
using RB.WebApp.Extensions;

namespace RB.WebApp
{
	public class Startup
	{
		public Startup( IConfiguration configuration )
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices( IServiceCollection services )
		{
			services.Configure< CookiePolicyOptions >( options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			} );

			services.AddDbContext< RumBlackDbContext>( options =>
				options.UseSqlServer(
					this.Configuration.GetConnectionString( "DefaultConnection" ) ) );

			services.AddDefaultIdentity< User >( options =>
				{
					options.Password.RequiredLength = 4;
					options.Password.RequireDigit = false;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireUppercase = false;
					//TODO: revert password requirements
				} )
				.AddEntityFrameworkStores< RumBlackDbContext >()
				.AddDefaultUI()
				.AddDefaultTokenProviders();

			services.AddMvc(
					options => { options.Filters.Add( new AutoValidateAntiforgeryTokenAttribute() ); } )
				.SetCompatibilityVersion( CompatibilityVersion.Version_2_2 )
				.AddRazorPagesOptions( options =>
				{
					options.AllowAreas = true;
					options.Conventions.AuthorizeAreaFolder( "Identity", "/Account/Manage" );
					options.Conventions.AuthorizeAreaPage( "Identity", "/Account/Logout" );
				} );

			services.ConfigureApplicationCookie( options =>
			{
				options.LoginPath = $"/Identity/Account/Login";
				options.LogoutPath = $"/Identity/Account/Logout";
				options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
			} );

			services.Configure< RouteOptions >( options => options.LowercaseUrls = true );

			services.AddAutoMapper();

			services.AddDomainServices();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure( IApplicationBuilder app, IHostingEnvironment env )
		{
			if ( env.IsDevelopment() )
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler( "/Home/Error" );
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc( routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}" );
			} );
		}
	}
}