using KrisTest.Domain.Common;
using KrisTest.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NodaTime;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Internal;

namespace KrisTest.Infrastructure.Data
{
	public class KrisTestContext : DbContext
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IConfiguration _configuration;

		public KrisTestContext()  
		{
			
		}

		public KrisTestContext(DbContextOptions<KrisTestContext> options, IHttpContextAccessor httpContextAccessor)
			: base(options)
		{
			_httpContextAccessor = httpContextAccessor;
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
		}

		public DbSet<Product> Products { get; set; }

		public DbSet<LineItem> LineItems { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<Payment> Payments { get; set; }

		public DbSet<Account> Accounts { get; set; }

		public DbSet<ShoppingCart> ShoppingCarts { get; set; }

		public DbSet<WebUser> WebUsers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseNpgsql("Server=localhost;Username=postgres;Password=postgre;database=KrisTest;Integrated Security=True;",
								options =>
								{
									options.UseNodaTime();
									AssemblyName assemblyName = typeof(KrisTestContext).Assembly.GetName();
									options.MigrationsAssembly(assemblyName.Name);
								})
							.EnableSensitiveDataLogging()
							.UseSnakeCaseNamingConvention();
			}

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{	
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			KrisTestContextSeed.Seed(builder);
			base.OnModelCreating(builder);
	
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			var modifiedEntries = ChangeTracker.Entries()
				.Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

			var currentUser = string.Empty;

			if (_httpContextAccessor.HttpContext != null)
			{
				 currentUser = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
			}

			else
			{
				 currentUser = "Anonymous";
			}

			foreach (var entry in modifiedEntries)
			{
				var entity = entry.Entity as BaseEntity;

				if (entity != null)
				{
					if (entry.State == EntityState.Added)
					{
						entity.CreatedDate = Instant.MaxValue;
						entity.CreatedBy = currentUser;
					}

					entity.ModifiedDate = Instant.MaxValue;
					entity.ModifiedBy = currentUser;
				}
			}
			return base.SaveChanges(acceptAllChangesOnSuccess);
		}
	}
}
