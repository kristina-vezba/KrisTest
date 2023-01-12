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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NodaTime;

namespace KrisTest.Infrastructure.Data
{
	public class KrisTestContext : IdentityDbContext
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IConfiguration _configuration;

		public KrisTestContext(DbContextOptions<KrisTestContext> options, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
			: base(options)
		{
			_httpContextAccessor = httpContextAccessor;
			this._configuration = configuration;
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
				optionsBuilder.UseNpgsql(this._configuration.GetConnectionString("KrisTestContextConnection"),
								options =>
								{
									//options.UseNodaTime();
									AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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

			base.OnModelCreating(builder);
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			var modifiedEntries = ChangeTracker.Entries()
				.Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

			var currentUser = " ";

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
						entity.CreatedDate = DateTime.UtcNow;
						entity.CreatedBy = currentUser;
					}

					entity.ModifiedDate = DateTime.UtcNow;
					entity.ModifiedBy = currentUser;
				}
			}
			return base.SaveChanges(acceptAllChangesOnSuccess);
		}
	}
}
