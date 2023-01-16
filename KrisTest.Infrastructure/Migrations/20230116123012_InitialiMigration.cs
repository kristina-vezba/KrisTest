using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KrisTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialiMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    billingaddress = table.Column<string>(name: "billing_address", type: "text", nullable: false),
                    isclosed = table.Column<bool>(name: "is_closed", type: "boolean", nullable: false),
                    open = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    closed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: true),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: true),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "web_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false),
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: true),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_web_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ordered = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    shipped = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    shiptoaddress = table.Column<string>(name: "ship_to_address", type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false),
                    accountid = table.Column<int>(name: "account_id", type: "integer", nullable: false),
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: true),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_accounts_account_id",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    accountid = table.Column<int>(name: "account_id", type: "integer", nullable: false),
                    webuserid = table.Column<int>(name: "web_user_id", type: "integer", nullable: false),
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: true),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                    table.ForeignKey(
                        name: "fk_customers_accounts_account_id",
                        column: x => x.id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_customers_web_users_web_user_id",
                        column: x => x.id,
                        principalTable: "web_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopping_carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    accountid = table.Column<int>(name: "account_id", type: "integer", nullable: false),
                    webuserid = table.Column<int>(name: "web_user_id", type: "integer", nullable: false),
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: true),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shopping_carts", x => x.id);
                    table.ForeignKey(
                        name: "fk_shopping_carts_accounts_account_id",
                        column: x => x.id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_shopping_carts_web_users_web_user_id",
                        column: x => x.id,
                        principalTable: "web_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    paid = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false),
                    details = table.Column<string>(type: "text", nullable: false),
                    orderid = table.Column<int>(name: "order_id", type: "integer", nullable: false),
                    accountid = table.Column<int>(name: "account_id", type: "integer", nullable: false),
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: true),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.id);
                    table.ForeignKey(
                        name: "fk_payments_accounts_account_id",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_payments_orders_order_id",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "line_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "integer", nullable: false),
                    shoppingcartid = table.Column<int>(name: "shopping_cart_id", type: "integer", nullable: false),
                    orderid = table.Column<int>(name: "order_id", type: "integer", nullable: false),
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: true),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_line_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_line_items_orders_order_id",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_line_items_products_product_id",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_line_items_shopping_carts_shopping_cart_id",
                        column: x => x.shoppingcartid,
                        principalTable: "shopping_carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_line_items_order_id",
                table: "line_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_line_items_product_id",
                table: "line_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_line_items_shopping_cart_id",
                table: "line_items",
                column: "shopping_cart_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_account_id",
                table: "orders",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_account_id",
                table: "payments",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_order_id",
                table: "payments",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "line_items");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "shopping_carts");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "web_users");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
