using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtPulseAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferName = table.Column<string>(type: "text", nullable: false),
                    OfferDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    SellerId = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProduct_ShoppingCart",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProduct_ShoppingCart", x => new { x.CustomerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CustomerProduct_ShoppingCart_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProduct_ShoppingCart_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferProduct",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferProduct", x => new { x.OfferId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OfferProduct_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Header = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ReviewingCustomerId = table.Column<int>(type: "integer", nullable: false),
                    ReviewedProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_ReviewingCustomerId",
                        column: x => x.ReviewingCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ReviewedProductId",
                        column: x => x.ReviewedProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "address1", "email1", "fname1", "lname1", "pnumber+i" },
                    { 2, "address2", "email2", "fname2", "lname2", "pnumber+i" },
                    { 3, "address3", "email3", "fname3", "lname3", "pnumber+i" },
                    { 4, "address4", "email4", "fname4", "lname4", "pnumber+i" },
                    { 5, "address5", "email5", "fname5", "lname5", "pnumber+i" },
                    { 6, "address6", "email6", "fname6", "lname6", "pnumber+i" },
                    { 7, "address7", "email7", "fname7", "lname7", "pnumber+i" },
                    { 8, "address8", "email8", "fname8", "lname8", "pnumber+i" },
                    { 9, "address9", "email9", "fname9", "lname9", "pnumber+i" },
                    { 10, "address10", "email10", "fname10", "lname10", "pnumber+i" },
                    { 11, "address11", "email11", "fname11", "lname11", "pnumber+i" },
                    { 12, "address12", "email12", "fname12", "lname12", "pnumber+i" },
                    { 13, "address13", "email13", "fname13", "lname13", "pnumber+i" },
                    { 14, "address14", "email14", "fname14", "lname14", "pnumber+i" },
                    { 15, "address15", "email15", "fname15", "lname15", "pnumber+i" },
                    { 16, "address16", "email16", "fname16", "lname16", "pnumber+i" },
                    { 17, "address17", "email17", "fname17", "lname17", "pnumber+i" },
                    { 18, "address18", "email18", "fname18", "lname18", "pnumber+i" },
                    { 19, "address19", "email19", "fname19", "lname19", "pnumber+i" },
                    { 20, "address20", "email20", "fname20", "lname20", "pnumber+i" },
                    { 21, "address21", "email21", "fname21", "lname21", "pnumber+i" },
                    { 22, "address22", "email22", "fname22", "lname22", "pnumber+i" },
                    { 23, "address23", "email23", "fname23", "lname23", "pnumber+i" },
                    { 24, "address24", "email24", "fname24", "lname24", "pnumber+i" },
                    { 25, "address25", "email25", "fname25", "lname25", "pnumber+i" },
                    { 26, "address26", "email26", "fname26", "lname26", "pnumber+i" },
                    { 27, "address27", "email27", "fname27", "lname27", "pnumber+i" },
                    { 28, "address28", "email28", "fname28", "lname28", "pnumber+i" },
                    { 29, "address29", "email29", "fname29", "lname29", "pnumber+i" },
                    { 30, "address30", "email30", "fname30", "lname30", "pnumber+i" },
                    { 31, "address31", "email31", "fname31", "lname31", "pnumber+i" },
                    { 32, "address32", "email32", "fname32", "lname32", "pnumber+i" },
                    { 33, "address33", "email33", "fname33", "lname33", "pnumber+i" },
                    { 34, "address34", "email34", "fname34", "lname34", "pnumber+i" },
                    { 35, "address35", "email35", "fname35", "lname35", "pnumber+i" },
                    { 36, "address36", "email36", "fname36", "lname36", "pnumber+i" },
                    { 37, "address37", "email37", "fname37", "lname37", "pnumber+i" },
                    { 38, "address38", "email38", "fname38", "lname38", "pnumber+i" },
                    { 39, "address39", "email39", "fname39", "lname39", "pnumber+i" },
                    { 40, "address40", "email40", "fname40", "lname40", "pnumber+i" },
                    { 41, "address41", "email41", "fname41", "lname41", "pnumber+i" },
                    { 42, "address42", "email42", "fname42", "lname42", "pnumber+i" },
                    { 43, "address43", "email43", "fname43", "lname43", "pnumber+i" },
                    { 44, "address44", "email44", "fname44", "lname44", "pnumber+i" },
                    { 45, "address45", "email45", "fname45", "lname45", "pnumber+i" },
                    { 46, "address46", "email46", "fname46", "lname46", "pnumber+i" },
                    { 47, "address47", "email47", "fname47", "lname47", "pnumber+i" },
                    { 48, "address48", "email48", "fname48", "lname48", "pnumber+i" },
                    { 49, "address49", "email49", "fname49", "lname49", "pnumber+i" },
                    { 50, "address50", "email50", "fname50", "lname50", "pnumber+i" },
                    { 51, "address51", "email51", "fname51", "lname51", "pnumber+i" },
                    { 52, "address52", "email52", "fname52", "lname52", "pnumber+i" },
                    { 53, "address53", "email53", "fname53", "lname53", "pnumber+i" },
                    { 54, "address54", "email54", "fname54", "lname54", "pnumber+i" },
                    { 55, "address55", "email55", "fname55", "lname55", "pnumber+i" },
                    { 56, "address56", "email56", "fname56", "lname56", "pnumber+i" },
                    { 57, "address57", "email57", "fname57", "lname57", "pnumber+i" },
                    { 58, "address58", "email58", "fname58", "lname58", "pnumber+i" },
                    { 59, "address59", "email59", "fname59", "lname59", "pnumber+i" },
                    { 60, "address60", "email60", "fname60", "lname60", "pnumber+i" },
                    { 61, "address61", "email61", "fname61", "lname61", "pnumber+i" },
                    { 62, "address62", "email62", "fname62", "lname62", "pnumber+i" },
                    { 63, "address63", "email63", "fname63", "lname63", "pnumber+i" },
                    { 64, "address64", "email64", "fname64", "lname64", "pnumber+i" },
                    { 65, "address65", "email65", "fname65", "lname65", "pnumber+i" },
                    { 66, "address66", "email66", "fname66", "lname66", "pnumber+i" },
                    { 67, "address67", "email67", "fname67", "lname67", "pnumber+i" },
                    { 68, "address68", "email68", "fname68", "lname68", "pnumber+i" },
                    { 69, "address69", "email69", "fname69", "lname69", "pnumber+i" },
                    { 70, "address70", "email70", "fname70", "lname70", "pnumber+i" },
                    { 71, "address71", "email71", "fname71", "lname71", "pnumber+i" },
                    { 72, "address72", "email72", "fname72", "lname72", "pnumber+i" },
                    { 73, "address73", "email73", "fname73", "lname73", "pnumber+i" },
                    { 74, "address74", "email74", "fname74", "lname74", "pnumber+i" },
                    { 75, "address75", "email75", "fname75", "lname75", "pnumber+i" },
                    { 76, "address76", "email76", "fname76", "lname76", "pnumber+i" },
                    { 77, "address77", "email77", "fname77", "lname77", "pnumber+i" },
                    { 78, "address78", "email78", "fname78", "lname78", "pnumber+i" },
                    { 79, "address79", "email79", "fname79", "lname79", "pnumber+i" },
                    { 80, "address80", "email80", "fname80", "lname80", "pnumber+i" },
                    { 81, "address81", "email81", "fname81", "lname81", "pnumber+i" },
                    { 82, "address82", "email82", "fname82", "lname82", "pnumber+i" },
                    { 83, "address83", "email83", "fname83", "lname83", "pnumber+i" },
                    { 84, "address84", "email84", "fname84", "lname84", "pnumber+i" },
                    { 85, "address85", "email85", "fname85", "lname85", "pnumber+i" },
                    { 86, "address86", "email86", "fname86", "lname86", "pnumber+i" },
                    { 87, "address87", "email87", "fname87", "lname87", "pnumber+i" },
                    { 88, "address88", "email88", "fname88", "lname88", "pnumber+i" },
                    { 89, "address89", "email89", "fname89", "lname89", "pnumber+i" },
                    { 90, "address90", "email90", "fname90", "lname90", "pnumber+i" },
                    { 91, "address91", "email91", "fname91", "lname91", "pnumber+i" },
                    { 92, "address92", "email92", "fname92", "lname92", "pnumber+i" },
                    { 93, "address93", "email93", "fname93", "lname93", "pnumber+i" },
                    { 94, "address94", "email94", "fname94", "lname94", "pnumber+i" },
                    { 95, "address95", "email95", "fname95", "lname95", "pnumber+i" },
                    { 96, "address96", "email96", "fname96", "lname96", "pnumber+i" },
                    { 97, "address97", "email97", "fname97", "lname97", "pnumber+i" },
                    { 98, "address98", "email98", "fname98", "lname98", "pnumber+i" },
                    { 99, "address99", "email99", "fname99", "lname99", "pnumber+i" },
                    { 100, "address100", "email100", "fname100", "lname100", "pnumber+i" }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "address1", "email1", "fname1", "lname1", "pnumber1" },
                    { 2, "address2", "email2", "fname2", "lname2", "pnumber2" },
                    { 3, "address3", "email3", "fname3", "lname3", "pnumber3" },
                    { 4, "address4", "email4", "fname4", "lname4", "pnumber4" },
                    { 5, "address5", "email5", "fname5", "lname5", "pnumber5" },
                    { 6, "address6", "email6", "fname6", "lname6", "pnumber6" },
                    { 7, "address7", "email7", "fname7", "lname7", "pnumber7" },
                    { 8, "address8", "email8", "fname8", "lname8", "pnumber8" },
                    { 9, "address9", "email9", "fname9", "lname9", "pnumber9" },
                    { 10, "address10", "email10", "fname10", "lname10", "pnumber10" },
                    { 11, "address11", "email11", "fname11", "lname11", "pnumber11" },
                    { 12, "address12", "email12", "fname12", "lname12", "pnumber12" },
                    { 13, "address13", "email13", "fname13", "lname13", "pnumber13" },
                    { 14, "address14", "email14", "fname14", "lname14", "pnumber14" },
                    { 15, "address15", "email15", "fname15", "lname15", "pnumber15" },
                    { 16, "address16", "email16", "fname16", "lname16", "pnumber16" },
                    { 17, "address17", "email17", "fname17", "lname17", "pnumber17" },
                    { 18, "address18", "email18", "fname18", "lname18", "pnumber18" },
                    { 19, "address19", "email19", "fname19", "lname19", "pnumber19" },
                    { 20, "address20", "email20", "fname20", "lname20", "pnumber20" },
                    { 21, "address21", "email21", "fname21", "lname21", "pnumber21" },
                    { 22, "address22", "email22", "fname22", "lname22", "pnumber22" },
                    { 23, "address23", "email23", "fname23", "lname23", "pnumber23" },
                    { 24, "address24", "email24", "fname24", "lname24", "pnumber24" },
                    { 25, "address25", "email25", "fname25", "lname25", "pnumber25" },
                    { 26, "address26", "email26", "fname26", "lname26", "pnumber26" },
                    { 27, "address27", "email27", "fname27", "lname27", "pnumber27" },
                    { 28, "address28", "email28", "fname28", "lname28", "pnumber28" },
                    { 29, "address29", "email29", "fname29", "lname29", "pnumber29" },
                    { 30, "address30", "email30", "fname30", "lname30", "pnumber30" },
                    { 31, "address31", "email31", "fname31", "lname31", "pnumber31" },
                    { 32, "address32", "email32", "fname32", "lname32", "pnumber32" },
                    { 33, "address33", "email33", "fname33", "lname33", "pnumber33" },
                    { 34, "address34", "email34", "fname34", "lname34", "pnumber34" },
                    { 35, "address35", "email35", "fname35", "lname35", "pnumber35" },
                    { 36, "address36", "email36", "fname36", "lname36", "pnumber36" },
                    { 37, "address37", "email37", "fname37", "lname37", "pnumber37" },
                    { 38, "address38", "email38", "fname38", "lname38", "pnumber38" },
                    { 39, "address39", "email39", "fname39", "lname39", "pnumber39" },
                    { 40, "address40", "email40", "fname40", "lname40", "pnumber40" },
                    { 41, "address41", "email41", "fname41", "lname41", "pnumber41" },
                    { 42, "address42", "email42", "fname42", "lname42", "pnumber42" },
                    { 43, "address43", "email43", "fname43", "lname43", "pnumber43" },
                    { 44, "address44", "email44", "fname44", "lname44", "pnumber44" },
                    { 45, "address45", "email45", "fname45", "lname45", "pnumber45" },
                    { 46, "address46", "email46", "fname46", "lname46", "pnumber46" },
                    { 47, "address47", "email47", "fname47", "lname47", "pnumber47" },
                    { 48, "address48", "email48", "fname48", "lname48", "pnumber48" },
                    { 49, "address49", "email49", "fname49", "lname49", "pnumber49" },
                    { 50, "address50", "email50", "fname50", "lname50", "pnumber50" },
                    { 51, "address51", "email51", "fname51", "lname51", "pnumber51" },
                    { 52, "address52", "email52", "fname52", "lname52", "pnumber52" },
                    { 53, "address53", "email53", "fname53", "lname53", "pnumber53" },
                    { 54, "address54", "email54", "fname54", "lname54", "pnumber54" },
                    { 55, "address55", "email55", "fname55", "lname55", "pnumber55" },
                    { 56, "address56", "email56", "fname56", "lname56", "pnumber56" },
                    { 57, "address57", "email57", "fname57", "lname57", "pnumber57" },
                    { 58, "address58", "email58", "fname58", "lname58", "pnumber58" },
                    { 59, "address59", "email59", "fname59", "lname59", "pnumber59" },
                    { 60, "address60", "email60", "fname60", "lname60", "pnumber60" },
                    { 61, "address61", "email61", "fname61", "lname61", "pnumber61" },
                    { 62, "address62", "email62", "fname62", "lname62", "pnumber62" },
                    { 63, "address63", "email63", "fname63", "lname63", "pnumber63" },
                    { 64, "address64", "email64", "fname64", "lname64", "pnumber64" },
                    { 65, "address65", "email65", "fname65", "lname65", "pnumber65" },
                    { 66, "address66", "email66", "fname66", "lname66", "pnumber66" },
                    { 67, "address67", "email67", "fname67", "lname67", "pnumber67" },
                    { 68, "address68", "email68", "fname68", "lname68", "pnumber68" },
                    { 69, "address69", "email69", "fname69", "lname69", "pnumber69" },
                    { 70, "address70", "email70", "fname70", "lname70", "pnumber70" },
                    { 71, "address71", "email71", "fname71", "lname71", "pnumber71" },
                    { 72, "address72", "email72", "fname72", "lname72", "pnumber72" },
                    { 73, "address73", "email73", "fname73", "lname73", "pnumber73" },
                    { 74, "address74", "email74", "fname74", "lname74", "pnumber74" },
                    { 75, "address75", "email75", "fname75", "lname75", "pnumber75" },
                    { 76, "address76", "email76", "fname76", "lname76", "pnumber76" },
                    { 77, "address77", "email77", "fname77", "lname77", "pnumber77" },
                    { 78, "address78", "email78", "fname78", "lname78", "pnumber78" },
                    { 79, "address79", "email79", "fname79", "lname79", "pnumber79" },
                    { 80, "address80", "email80", "fname80", "lname80", "pnumber80" },
                    { 81, "address81", "email81", "fname81", "lname81", "pnumber81" },
                    { 82, "address82", "email82", "fname82", "lname82", "pnumber82" },
                    { 83, "address83", "email83", "fname83", "lname83", "pnumber83" },
                    { 84, "address84", "email84", "fname84", "lname84", "pnumber84" },
                    { 85, "address85", "email85", "fname85", "lname85", "pnumber85" },
                    { 86, "address86", "email86", "fname86", "lname86", "pnumber86" },
                    { 87, "address87", "email87", "fname87", "lname87", "pnumber87" },
                    { 88, "address88", "email88", "fname88", "lname88", "pnumber88" },
                    { 89, "address89", "email89", "fname89", "lname89", "pnumber89" },
                    { 90, "address90", "email90", "fname90", "lname90", "pnumber90" },
                    { 91, "address91", "email91", "fname91", "lname91", "pnumber91" },
                    { 92, "address92", "email92", "fname92", "lname92", "pnumber92" },
                    { 93, "address93", "email93", "fname93", "lname93", "pnumber93" },
                    { 94, "address94", "email94", "fname94", "lname94", "pnumber94" },
                    { 95, "address95", "email95", "fname95", "lname95", "pnumber95" },
                    { 96, "address96", "email96", "fname96", "lname96", "pnumber96" },
                    { 97, "address97", "email97", "fname97", "lname97", "pnumber97" },
                    { 98, "address98", "email98", "fname98", "lname98", "pnumber98" },
                    { 99, "address99", "email99", "fname99", "lname99", "pnumber99" },
                    { 100, "address100", "email100", "fname100", "lname100", "pnumber100" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Category", "Cost", "Details", "Image", "Name", "Rating", "SellerId" },
                values: new object[,]
                {
                    { 1, 1964502363, 1, 1000m, "details1", new byte[0], "name1", 4f, 2 },
                    { 2, 1913878565, 1, 2000m, "details2", new byte[0], "name2", 4f, 3 },
                    { 3, 875907490, 1, 3000m, "details3", new byte[0], "name3", 4f, 4 },
                    { 4, 193212366, 1, 4000m, "details4", new byte[0], "name4", 4f, 5 },
                    { 5, 842712581, 1, 5000m, "details5", new byte[0], "name5", 4f, 6 },
                    { 6, 457238689, 1, 6000m, "details6", new byte[0], "name6", 4f, 7 },
                    { 7, 993592298, 1, 7000m, "details7", new byte[0], "name7", 4f, 8 },
                    { 8, 1631866741, 1, 8000m, "details8", new byte[0], "name8", 4f, 9 },
                    { 9, 7197298, 1, 9000m, "details9", new byte[0], "name9", 4f, 10 },
                    { 10, 2017545726, 1, 10000m, "details10", new byte[0], "name10", 4f, 11 },
                    { 11, 1450962708, 1, 11000m, "details11", new byte[0], "name11", 4f, 12 },
                    { 12, 2133430547, 1, 12000m, "details12", new byte[0], "name12", 4f, 13 },
                    { 13, 965663367, 1, 13000m, "details13", new byte[0], "name13", 4f, 14 },
                    { 14, 1535236818, 1, 14000m, "details14", new byte[0], "name14", 4f, 15 },
                    { 15, 590286302, 1, 15000m, "details15", new byte[0], "name15", 4f, 16 },
                    { 16, 763596265, 1, 16000m, "details16", new byte[0], "name16", 4f, 17 },
                    { 17, 929910497, 1, 17000m, "details17", new byte[0], "name17", 4f, 18 },
                    { 18, 922359607, 1, 18000m, "details18", new byte[0], "name18", 4f, 19 },
                    { 19, 144580601, 1, 19000m, "details19", new byte[0], "name19", 4f, 20 },
                    { 20, 587098372, 1, 20000m, "details20", new byte[0], "name20", 4f, 21 },
                    { 21, 1704328340, 1, 21000m, "details21", new byte[0], "name21", 4f, 22 },
                    { 22, 1212042485, 1, 22000m, "details22", new byte[0], "name22", 4f, 23 },
                    { 23, 1980101972, 1, 23000m, "details23", new byte[0], "name23", 4f, 24 },
                    { 24, 897815876, 1, 24000m, "details24", new byte[0], "name24", 4f, 25 },
                    { 25, 534596424, 1, 25000m, "details25", new byte[0], "name25", 4f, 26 },
                    { 26, 1270707976, 1, 26000m, "details26", new byte[0], "name26", 4f, 27 },
                    { 27, 1580453875, 1, 27000m, "details27", new byte[0], "name27", 4f, 28 },
                    { 28, 857266313, 1, 28000m, "details28", new byte[0], "name28", 4f, 29 },
                    { 29, 408731775, 1, 29000m, "details29", new byte[0], "name29", 4f, 30 },
                    { 30, 1089297454, 1, 30000m, "details30", new byte[0], "name30", 4f, 31 },
                    { 31, 492534038, 1, 31000m, "details31", new byte[0], "name31", 4f, 32 },
                    { 32, 635698626, 1, 32000m, "details32", new byte[0], "name32", 4f, 33 },
                    { 33, 1366786030, 1, 33000m, "details33", new byte[0], "name33", 4f, 34 },
                    { 34, 467290030, 1, 34000m, "details34", new byte[0], "name34", 4f, 35 },
                    { 35, 93466486, 1, 35000m, "details35", new byte[0], "name35", 4f, 36 },
                    { 36, 1999810515, 1, 36000m, "details36", new byte[0], "name36", 4f, 37 },
                    { 37, 1059435824, 1, 37000m, "details37", new byte[0], "name37", 4f, 38 },
                    { 38, 490783501, 1, 38000m, "details38", new byte[0], "name38", 4f, 39 },
                    { 39, 1783149952, 1, 39000m, "details39", new byte[0], "name39", 4f, 40 },
                    { 40, 1053139929, 1, 40000m, "details40", new byte[0], "name40", 4f, 41 },
                    { 41, 1149700699, 1, 41000m, "details41", new byte[0], "name41", 4f, 42 },
                    { 42, 1019556603, 1, 42000m, "details42", new byte[0], "name42", 4f, 43 },
                    { 43, 774075916, 1, 43000m, "details43", new byte[0], "name43", 4f, 44 },
                    { 44, 1923576848, 1, 44000m, "details44", new byte[0], "name44", 4f, 45 },
                    { 45, 1303128352, 1, 45000m, "details45", new byte[0], "name45", 4f, 46 },
                    { 46, 320757052, 1, 46000m, "details46", new byte[0], "name46", 4f, 47 },
                    { 47, 1745506778, 1, 47000m, "details47", new byte[0], "name47", 4f, 48 },
                    { 48, 1932731571, 1, 48000m, "details48", new byte[0], "name48", 4f, 49 },
                    { 49, 1162668518, 1, 49000m, "details49", new byte[0], "name49", 4f, 50 },
                    { 50, 483595725, 1, 50000m, "details50", new byte[0], "name50", 4f, 51 },
                    { 51, 1800871539, 1, 51000m, "details51", new byte[0], "name51", 4f, 52 },
                    { 52, 1993302948, 1, 52000m, "details52", new byte[0], "name52", 4f, 53 },
                    { 53, 1375169157, 1, 53000m, "details53", new byte[0], "name53", 4f, 54 },
                    { 54, 1557127746, 1, 54000m, "details54", new byte[0], "name54", 4f, 55 },
                    { 55, 1755707714, 1, 55000m, "details55", new byte[0], "name55", 4f, 56 },
                    { 56, 1189638294, 1, 56000m, "details56", new byte[0], "name56", 4f, 57 },
                    { 57, 1668225753, 1, 57000m, "details57", new byte[0], "name57", 4f, 58 },
                    { 58, 1958957064, 1, 58000m, "details58", new byte[0], "name58", 4f, 59 },
                    { 59, 1750623386, 1, 59000m, "details59", new byte[0], "name59", 4f, 60 },
                    { 60, 322876758, 1, 60000m, "details60", new byte[0], "name60", 4f, 61 },
                    { 61, 1694312729, 1, 61000m, "details61", new byte[0], "name61", 4f, 62 },
                    { 62, 176705419, 1, 62000m, "details62", new byte[0], "name62", 4f, 63 },
                    { 63, 61033724, 1, 63000m, "details63", new byte[0], "name63", 4f, 64 },
                    { 64, 239611770, 1, 64000m, "details64", new byte[0], "name64", 4f, 65 },
                    { 65, 187461914, 1, 65000m, "details65", new byte[0], "name65", 4f, 66 },
                    { 66, 767691152, 1, 66000m, "details66", new byte[0], "name66", 4f, 67 },
                    { 67, 742660243, 1, 67000m, "details67", new byte[0], "name67", 4f, 68 },
                    { 68, 1838895042, 1, 68000m, "details68", new byte[0], "name68", 4f, 69 },
                    { 69, 357278724, 1, 69000m, "details69", new byte[0], "name69", 4f, 70 },
                    { 70, 1197530261, 1, 70000m, "details70", new byte[0], "name70", 4f, 71 },
                    { 71, 1228463537, 1, 71000m, "details71", new byte[0], "name71", 4f, 72 },
                    { 72, 1288524305, 1, 72000m, "details72", new byte[0], "name72", 4f, 73 },
                    { 73, 1770918046, 1, 73000m, "details73", new byte[0], "name73", 4f, 74 },
                    { 74, 1985604814, 1, 74000m, "details74", new byte[0], "name74", 4f, 75 },
                    { 75, 442935459, 1, 75000m, "details75", new byte[0], "name75", 4f, 76 },
                    { 76, 1062642846, 1, 76000m, "details76", new byte[0], "name76", 4f, 77 },
                    { 77, 1516722235, 1, 77000m, "details77", new byte[0], "name77", 4f, 78 },
                    { 78, 1872003081, 1, 78000m, "details78", new byte[0], "name78", 4f, 79 },
                    { 79, 209594083, 1, 79000m, "details79", new byte[0], "name79", 4f, 80 },
                    { 80, 271791528, 1, 80000m, "details80", new byte[0], "name80", 4f, 81 },
                    { 81, 89134266, 1, 81000m, "details81", new byte[0], "name81", 4f, 82 },
                    { 82, 653530380, 1, 82000m, "details82", new byte[0], "name82", 4f, 83 },
                    { 83, 1596875382, 1, 83000m, "details83", new byte[0], "name83", 4f, 84 },
                    { 84, 733944106, 1, 84000m, "details84", new byte[0], "name84", 4f, 85 },
                    { 85, 457571591, 1, 85000m, "details85", new byte[0], "name85", 4f, 86 },
                    { 86, 1644525076, 1, 86000m, "details86", new byte[0], "name86", 4f, 87 },
                    { 87, 382901656, 1, 87000m, "details87", new byte[0], "name87", 4f, 88 },
                    { 88, 420058322, 1, 88000m, "details88", new byte[0], "name88", 4f, 89 },
                    { 89, 1575440318, 1, 89000m, "details89", new byte[0], "name89", 4f, 90 },
                    { 90, 1442986222, 1, 90000m, "details90", new byte[0], "name90", 4f, 91 },
                    { 91, 926691668, 1, 91000m, "details91", new byte[0], "name91", 4f, 92 },
                    { 92, 1000678905, 1, 92000m, "details92", new byte[0], "name92", 4f, 93 },
                    { 93, 414054850, 1, 93000m, "details93", new byte[0], "name93", 4f, 94 },
                    { 94, 1122363530, 1, 94000m, "details94", new byte[0], "name94", 4f, 95 },
                    { 95, 1364136868, 1, 95000m, "details95", new byte[0], "name95", 4f, 96 },
                    { 96, 146199991, 1, 96000m, "details96", new byte[0], "name96", 4f, 97 },
                    { 97, 1248035898, 1, 97000m, "details97", new byte[0], "name97", 4f, 98 },
                    { 98, 1024395556, 1, 98000m, "details98", new byte[0], "name98", 4f, 99 },
                    { 99, 1647275238, 1, 99000m, "details99", new byte[0], "name99", 4f, 100 },
                    { 100, 383932441, 1, 100000m, "details100", new byte[0], "name100", 4f, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_ShoppingCart_ProductId",
                table: "CustomerProduct_ShoppingCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferProduct_ProductId",
                table: "OfferProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewedProductId",
                table: "Reviews",
                column: "ReviewedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewingCustomerId",
                table: "Reviews",
                column: "ReviewingCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerProduct_ShoppingCart");

            migrationBuilder.DropTable(
                name: "OfferProduct");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
