using KrisTest.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account = KrisTest.Domain.Entities.Account;
using Customer = KrisTest.Domain.Entities.Customer;
using LineItem = KrisTest.Domain.Entities.LineItem;
using Product = KrisTest.Domain.Entities.Product;

namespace KrisTest.Infrastructure.Data
{
	public static class KrisTestContextSeed
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			KrisTestContext context = applicationBuilder.ApplicationServices.CreateScope()
				.ServiceProvider.GetService<KrisTestContext>();


			Product p1 = new Product { Id = 1, Name = "Lopata" };
			Product p2 = new Product { Id = 2, Name = "Balon" };
			Product p3 = new Product { Id = 3, Name = "Papir" };
			Product p4 = new Product { Id = 4, Name = "Kamen" };
			Product p5 = new Product { Id = 5, Name = "Makaze" };

			context.Products.AddRange(p1, p2, p3, p4, p5);

			Account a1 = new Account { Id = 501, BillingAddress = "Ostavi u prodavnici", IsClosed = false,
				Open = new DateTime(2000 - 12 - 20)};
			Account a2 = new Account { Id = 502, BillingAddress = "Bilo gde", IsClosed = false};
			Account a3 = new Account { Id = 503, BillingAddress = "Nije vazno", IsClosed = true,
				Open = new DateTime(2002 - 01 - 01), Closed = DateTime.Now};


			Order o1 = new Order { Id = 201, Number = "1. order", ShipToAddress = "Ostavi kod komsije", Account = a1 };
			Order o2 = new Order { Id = 202, Number = "2. order", Account = a1 };

			context.Orders.AddRange(o1, o2);


			WebUser wu1 = new WebUser { Id = 10000, Name = "UserOne", Password = "IsPassword", State = Domain.Enums.UserState.Active };
			WebUser wu2 = new WebUser { Id = 10001, Name = "UserTwo", Password = "JopetPassword", State = Domain.Enums.UserState.Active };

			context.WebUsers.AddRange(wu1);


			ShoppingCart sc1 = new ShoppingCart { Id = 1001, WebUser = wu1, Account = a1, Created = new DateTime(2000-02-02) };
			ShoppingCart sc2 = new ShoppingCart { Id = 1002, WebUser = wu2, Account = a3, Created = new DateTime(2012-08-21) };

			context.ShoppingCarts.AddRange(sc1, sc2);


			LineItem li1 = new LineItem { Id = 801, Quantity = 5, Price = 49.95, Product = p1, Order = o1, ShoppingCart = sc1 };
			LineItem li2 = new LineItem { Id = 802, Quantity = 10, Price = 3.95, Product = p2, Order = o1, ShoppingCart = sc2 };
			LineItem li3 = new LineItem { Id = 803, Quantity = 150, Price = 0.95, Product = p3, Order = o2, ShoppingCart = sc1 };
			LineItem li4 = new LineItem { Id = 804, Quantity = 6, Price = 9.95, Product = p4, Order = o2, ShoppingCart = sc2 };
			LineItem li5 = new LineItem { Id = 805, Quantity = 5, Price = 19.95, Product = p5, Order = o2, ShoppingCart = sc1 };

			context.LineItems.AddRange(li1, li2, li3, li4, li5);


			Customer cust1 = new Customer { Id = 301, Address = "Grobljanska 1, Mala Krsna", Phone = "0123456789",
				Email = "mojmail@mail.com", Account = a1, WebUser = wu1 };
			Customer cust2 = new Customer { Id = 302, Address = "Adresa neka, Neko Mesto", Phone = "987654321",
				Email = "mail.mail@opetmail.com", Account = a2 };

			context.Customers.AddRange(cust1, cust2);


			Payment pay1 = new Payment { Id = 100000, Paid = DateTime.Today, Total = 100.00, Details = "neke sitnice", Account = a1};

			context.Payments.AddRange(pay1);


			context.SaveChanges();
		}
	}
}
