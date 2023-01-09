using KrisTest.Domain.Common;
using KrisTest.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Infrastructure.Data
{
	public class KrisTestContext : DbContext
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public KrisTestContext(DbContextOptions<KrisTestContext> options, IHttpContextAccessor httpContextAccessor)
			: base(options)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public DbSet<Product> Products { get; set; }

		public DbSet<LineItem> LineItems { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<Payment> Payments { get; set; }

		public DbSet<Account> Accounts { get; set; }

		public DbSet<ShoppingCart> ShoppingCarts { get; set; }

		public DbSet<WebUser> WebUsers { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(builder);
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			var modifiedEntries = ChangeTracker.Entries()
				.Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));
			var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
			var currentUser = !string.IsNullOrEmpty(userId) ? userId : "Unknown";

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
