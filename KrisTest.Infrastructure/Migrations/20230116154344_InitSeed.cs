using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KrisTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "created",
                table: "shopping_carts",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "paid",
                table: "payments",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "shipped",
                table: "orders",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "ordered",
                table: "orders",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "open",
                table: "accounts",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "closed",
                table: "accounts",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "billing_address", "closed", "created_by", "created_date", "is_closed", "modified_by", "modified_date", "open", "uid" },
                values: new object[,]
                {
                    { 1, "Ostavi u prodavnici", new NodaTime.LocalDateTime(1, 1, 1, 0, 0), null, NodaTime.Instant.FromUnixTimeTicks(0L), false, null, null, new NodaTime.LocalDateTime(2000, 12, 20, 22, 30), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, "Bilo gde", new NodaTime.LocalDateTime(1, 1, 1, 0, 0), null, NodaTime.Instant.FromUnixTimeTicks(0L), false, null, null, new NodaTime.LocalDateTime(1, 1, 1, 0, 0), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, "Nije vazno", new NodaTime.LocalDateTime(2022, 1, 16, 1, 30), null, NodaTime.Instant.FromUnixTimeTicks(0L), true, null, null, new NodaTime.LocalDateTime(2002, 1, 1, 21, 20), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "created_by", "created_date", "modified_by", "modified_date", "name", "uid" },
                values: new object[,]
                {
                    { 1, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, "Lopata", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, "Balon", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, "Papir", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 4, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, "Kamen", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 5, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, "Makaze", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "web_users",
                columns: new[] { "id", "created_by", "created_date", "modified_by", "modified_date", "name", "password", "state", "uid" },
                values: new object[,]
                {
                    { 1, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, "UserOne", "IsPassword", 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, "UserTwo", "JopetPassword", 1, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "account_id", "address", "created_by", "created_date", "email", "modified_by", "modified_date", "phone", "uid", "web_user_id" },
                values: new object[,]
                {
                    { 1, 1, "Grobljanska 1, Mala Krsna", null, NodaTime.Instant.FromUnixTimeTicks(0L), "mojmail@mail.com", null, null, "0123456789", new Guid("00000000-0000-0000-0000-000000000000"), 1 },
                    { 2, 2, "Adresa neka, Neko Mesto", null, NodaTime.Instant.FromUnixTimeTicks(0L), "mail.mail@opetmail.com", null, null, "987654321", new Guid("00000000-0000-0000-0000-000000000000"), 0 }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "account_id", "created_by", "created_date", "modified_by", "modified_date", "number", "ordered", "ship_to_address", "shipped", "status", "total", "uid" },
                values: new object[,]
                {
                    { 1, 1, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, "1. order", new NodaTime.LocalDateTime(1, 1, 1, 0, 0), "Ostavi kod komsije", new NodaTime.LocalDateTime(1, 1, 1, 0, 0), 0, 0.0, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, 1, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, "2. order", new NodaTime.LocalDateTime(1, 1, 1, 0, 0), "Ostavi kod drugog komsije", new NodaTime.LocalDateTime(1, 1, 1, 0, 0), 0, 0.0, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "shopping_carts",
                columns: new[] { "id", "account_id", "created", "created_by", "created_date", "modified_by", "modified_date", "uid", "web_user_id" },
                values: new object[,]
                {
                    { 1, 1, new NodaTime.LocalDateTime(2000, 2, 2, 2, 30), null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, new Guid("00000000-0000-0000-0000-000000000000"), 1 },
                    { 2, 3, new NodaTime.LocalDateTime(2012, 8, 21, 1, 0), null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, new Guid("00000000-0000-0000-0000-000000000000"), 2 }
                });

            migrationBuilder.InsertData(
                table: "line_items",
                columns: new[] { "id", "created_by", "created_date", "modified_by", "modified_date", "order_id", "price", "product_id", "quantity", "shopping_cart_id", "uid" },
                values: new object[,]
                {
                    { 1, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, 1, 49.950000000000003, 1, 5, 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, 1, 3.9500000000000002, 2, 10, 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, 2, 0.94999999999999996, 3, 150, 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 4, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, 2, 9.9499999999999993, 4, 6, 2, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 5, null, NodaTime.Instant.FromUnixTimeTicks(0L), null, null, 2, 19.949999999999999, 5, 5, 1, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "id", "account_id", "created_by", "created_date", "details", "modified_by", "modified_date", "order_id", "paid", "total", "uid" },
                values: new object[] { 1, 1, null, NodaTime.Instant.FromUnixTimeTicks(0L), "neke sitnice", null, null, 1, new NodaTime.LocalDateTime(2023, 1, 16, 0, 0), 100.0, new Guid("00000000-0000-0000-0000-000000000000") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "line_items",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "line_items",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "line_items",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "line_items",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "line_items",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "payments",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "shopping_carts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "shopping_carts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "web_users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "web_users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "shopping_carts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "paid",
                table: "payments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "shipped",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ordered",
                table: "orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "open",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "closed",
                table: "accounts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone");
        }
    }
}
