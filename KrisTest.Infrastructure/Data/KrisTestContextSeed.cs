using KrisTest.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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
	internal class KrisTestContextSeed
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			KrisTestContext context = applicationBuilder.ApplicationServices.CreateScope()
				.ServiceProvider.GetService<KrisTestContext>();

			context.AddRange
			(
				new Product { Name = "Lopata" },
				new Product { Name = "Balon" },
				new Product { Name = "Papir" },
				new Product { Name = "Kamen" },
				new Product { Name = "Makaze" }
			);

			context.AddRange
			(
				new Customer { Address = "Grobljanska 1, Mala Krsna", Phone = "0123456789", Email = "mojmail@mail.com", },
				new Customer { Address = "Adresa neka, Neko Mesto", Phone = "987654321", Email = "mail.mail@opetmail.com" }
			);

			context.AddRange
			(
				new LineItem { Quantity = 5, Price = 49.95 },
				new LineItem { Quantity = 10, Price = 3.95 },
				new LineItem { Quantity = 150, Price = 0.95 },
				new LineItem { Quantity = 6, Price = 9.95 },
				new LineItem { Quantity = 5, Price = 19.95 }
			);


			context.AddRange
				(
					new Account { BillingAddress = "Ostavi u prodavnici", IsClosed = false, Open = new DateTime(2000, 20, 12) },
					new Account { BillingAddress = "Bilo gde", IsClosed = false },
					new Account { BillingAddress = "Nije vazno", IsClosed = true, Open = new DateTime(2002, 01, 01) }
				);



			context.AddRange
				(
					new Payment { Paid = DateTime.Today, Total = 100.00, Details = "neke sitnice" }
				);



			context.AddRange
				(
					new Order { Number = "1. order", ShipToAddress = "Ostavi kod komsije" },
					new Order { Number = "2. order" }
				);

		}
	}
}
