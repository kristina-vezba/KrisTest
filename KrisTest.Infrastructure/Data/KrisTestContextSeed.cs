using KrisTest.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Operations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal;
using System.Reflection.Emit;

namespace KrisTest.Infrastructure.Data
{
	public class KrisTestContextSeed 
	{
		public static void Seed(ModelBuilder builder)
		{
			Product p1 = new Product { Id = 1, Name = "Lopata" };
			Product p2 = new Product { Id = 2, Name = "Balon" };
			Product p3 = new Product { Id = 3, Name = "Papir" };
			Product p4 = new Product { Id = 4, Name = "Kamen" };
			Product p5 = new Product { Id = 5, Name = "Makaze" };

			builder.Entity<Product>()
				.HasData(p1, p2, p3, p4, p5);
			//context.Products.AddRange(p1, p2, p3, p4, p5);

			Account a1 = new Account
			{
				Id = 1, BillingAddress = "Ostavi u prodavnici", IsClosed = false,
				Open = new LocalDateTime(2000, 12, 20, 22, 30, 00)
			};
			Account a2 = new Account { Id = 2, BillingAddress = "Bilo gde", IsClosed = false };

			Account a3 = new Account
			{
				Id = 3, BillingAddress = "Nije vazno", IsClosed = true,
				Open = new LocalDateTime(2002, 01, 01, 21, 20, 00), Closed = new LocalDateTime(2022, 01, 16, 01, 30, 00),
			};

			builder.Entity<Account>()
				.HasData(a1, a2, a3);

			Order o1 = new Order { Id = 1, Number = "1. order", ShipToAddress = "Ostavi kod komsije", AccountId = a1.Id };
			Order o2 = new Order { Id = 2, Number = "2. order", AccountId = a1.Id, ShipToAddress = "Ostavi kod drugog komsije" };

			builder.Entity<Order>()
				.HasData(o1, o2);
			//context.Orders.AddRange(o1, o2);

			WebUser wu1 = new WebUser
				{ Id = 1, Name = "UserOne", Password = "IsPassword", State = Domain.Enums.UserState.Active };

			WebUser wu2 = new WebUser
				{ Id = 2, Name = "UserTwo", Password = "JopetPassword", State = Domain.Enums.UserState.Active };

			builder.Entity<WebUser>()
				.HasData(wu1, wu2);
			//context.WebUsers.AddRange(wu1);

			ShoppingCart sc1 = new ShoppingCart
				{ Id = 1, WebUserId = wu1.Id, AccountId = a1.Id, Created = new LocalDateTime(2000, 02, 02, 02, 30, 00) };

			ShoppingCart sc2 = new ShoppingCart
				{ Id = 2, WebUserId = wu2.Id, AccountId = a3.Id, Created = new LocalDateTime(2012, 08, 21, 01, 00, 00) };

			builder.Entity<ShoppingCart>()
				.HasData(sc1, sc2);
			//context.ShoppingCarts.AddRange(sc1, sc2);

			LineItem li1 = new LineItem
				{ Id = 1, Quantity = 5, Price = 49.95, ProductId = p1.Id, OrderId = o1.Id, ShoppingCartId = sc1.Id };

			LineItem li2 = new LineItem
				{ Id = 2, Quantity = 10, Price = 3.95, ProductId = p2.Id, OrderId = o1.Id, ShoppingCartId = sc2.Id };

			LineItem li3 = new LineItem
				{ Id = 3, Quantity = 150, Price = 0.95, ProductId = p3.Id, OrderId = o2.Id, ShoppingCartId = sc1.Id };

			LineItem li4 = new LineItem
				{ Id = 4, Quantity = 6, Price = 9.95, ProductId = p4.Id, OrderId = o2.Id, ShoppingCartId = sc2.Id };

			LineItem li5 = new LineItem
				{ Id = 5, Quantity = 5, Price = 19.95, ProductId = p5.Id, OrderId = o2.Id, ShoppingCartId = sc1.Id };

			builder.Entity<LineItem>()
				.HasData(li1, li2, li3, li4, li5);
			//context.LineItems.AddRange(li1, li2, li3, li4, li5);

			Customer cust1 = new Customer
			{
				Id = 1, Address = "Grobljanska 1, Mala Krsna", Phone = "0123456789",
				Email = "mojmail@mail.com", AccountId = a1.Id, WebUserId= wu1.Id
			};

			Customer cust2 = new Customer
			{
				Id = 2, Address = "Adresa neka, Neko Mesto", Phone = "987654321",
				Email = "mail.mail@opetmail.com", AccountId = a2.Id
			};

			builder.Entity<Customer>()
				.HasData(cust1, cust2);
			//context.Customers.AddRange(cust1, cust2);

			Payment pay1 = new Payment
				{ Id = 1, Paid = new LocalDateTime(2023, 01, 16, 00, 00, 00), Total = 100.00, Details = "neke sitnice", AccountId = a1.Id, OrderId = o1.Id };

			builder.Entity<Payment>()
				.HasData(pay1);
			//context.Payments.AddRange(pay1);
		}
	}
}