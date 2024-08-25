using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrudApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Code", "Description", "EntryDate", "IsActive", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "m2wbxp", "The Football Is Good For Training And Recreational Purposes", null, false, "Practical Concrete Tuna", null },
                    { 2, "bwd3cm", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, true, "Unbranded Plastic Shirt", null },
                    { 3, "ifrw7n", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, true, "Refined Steel Chair", null },
                    { 4, "h2rz0w", "The Football Is Good For Training And Recreational Purposes", null, true, "Tasty Cotton Soap", null },
                    { 5, "a8q25b", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, false, "Intelligent Soft Bacon", null },
                    { 6, "4stfcl", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, true, "Handmade Concrete Shirt", null },
                    { 7, "1ehdcr", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, false, "Handcrafted Frozen Sausages", null },
                    { 8, "un3768", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, true, "Incredible Plastic Tuna", null },
                    { 9, "yk322g", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, true, "Practical Fresh Towels", null },
                    { 10, "cyuwot", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, true, "Generic Cotton Bike", null },
                    { 11, "s2c6cv", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, true, "Handmade Plastic Hat", null },
                    { 12, "0hzhkq", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, true, "Gorgeous Concrete Chips", null },
                    { 13, "f95qui", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, true, "Practical Metal Towels", null },
                    { 14, "gcinx6", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, true, "Practical Soft Bike", null },
                    { 15, "h7ggoh", "The Football Is Good For Training And Recreational Purposes", null, false, "Awesome Cotton Computer", null },
                    { 16, "8ji8b9", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, true, "Unbranded Fresh Chicken", null },
                    { 17, "faqyb5", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, false, "Tasty Wooden Soap", null },
                    { 18, "pnfz3n", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, true, "Awesome Fresh Fish", null },
                    { 19, "02j7fa", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, false, "Ergonomic Cotton Soap", null },
                    { 20, "t5mire", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, false, "Gorgeous Concrete Chicken", null },
                    { 21, "xehe9p", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, true, "Practical Fresh Table", null },
                    { 22, "aoz5li", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, true, "Small Metal Chips", null },
                    { 23, "57jgak", "The Football Is Good For Training And Recreational Purposes", null, true, "Small Frozen Car", null },
                    { 24, "wc41nc", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, true, "Rustic Granite Fish", null },
                    { 25, "inpvlk", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, false, "Sleek Granite Keyboard", null },
                    { 26, "yk6vda", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, true, "Small Wooden Bike", null },
                    { 27, "ygb56v", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, false, "Licensed Frozen Mouse", null },
                    { 28, "kuz7sd", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, false, "Intelligent Cotton Towels", null },
                    { 29, "ebirm6", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, false, "Handcrafted Rubber Soap", null },
                    { 30, "47vbvn", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, false, "Handcrafted Fresh Chair", null },
                    { 31, "ehkcgs", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, false, "Incredible Steel Bike", null },
                    { 32, "un9i95", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, false, "Tasty Soft Mouse", null },
                    { 33, "oxzsm2", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, true, "Rustic Metal Gloves", null },
                    { 34, "38vzx7", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, false, "Rustic Metal Tuna", null },
                    { 35, "a7rkip", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, true, "Intelligent Soft Car", null },
                    { 36, "bnzi38", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, true, "Ergonomic Cotton Ball", null },
                    { 37, "m4274x", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, false, "Small Soft Keyboard", null },
                    { 38, "yqfyo7", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, true, "Small Fresh Table", null },
                    { 39, "m84kd1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, false, "Gorgeous Steel Soap", null },
                    { 40, "7u773l", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, true, "Small Wooden Table", null },
                    { 41, "ekm3gq", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, false, "Incredible Rubber Shirt", null },
                    { 42, "imdqdq", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, true, "Ergonomic Steel Shirt", null },
                    { 43, "he3xjx", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, true, "Handmade Metal Bacon", null },
                    { 44, "2rwpm2", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, false, "Incredible Metal Car", null },
                    { 45, "ikpbrg", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, false, "Generic Rubber Soap", null },
                    { 46, "rqtdz4", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, false, "Generic Soft Shirt", null },
                    { 47, "ojogc7", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, true, "Fantastic Plastic Chips", null },
                    { 48, "qo49js", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, true, "Licensed Fresh Shirt", null },
                    { 49, "9epp33", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, true, "Generic Plastic Shoes", null },
                    { 50, "629aai", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, true, "Practical Soft Tuna", null },
                    { 51, "xiz1x7", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, true, "Handmade Soft Hat", null },
                    { 52, "cp3qdf", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, false, "Awesome Concrete Tuna", null },
                    { 53, "ygvk7m", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, false, "Sleek Concrete Mouse", null },
                    { 54, "h4m5xj", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, true, "Handmade Plastic Chair", null },
                    { 55, "cxkwah", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, true, "Tasty Cotton Pizza", null },
                    { 56, "3ffyjr", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, true, "Licensed Steel Fish", null },
                    { 57, "4vjtjv", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, true, "Awesome Concrete Hat", null },
                    { 58, "1wde53", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, true, "Sleek Steel Pants", null },
                    { 59, "2sowq8", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, false, "Gorgeous Rubber Pizza", null },
                    { 60, "dovxde", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, false, "Sleek Cotton Sausages", null },
                    { 61, "0jb34x", "The Football Is Good For Training And Recreational Purposes", null, false, "Incredible Plastic Soap", null },
                    { 62, "28669i", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, false, "Handcrafted Fresh Bacon", null },
                    { 63, "bts8wq", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, false, "Refined Steel Tuna", null },
                    { 64, "dosc0j", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, true, "Generic Granite Shirt", null },
                    { 65, "s9ec88", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, false, "Ergonomic Concrete Salad", null },
                    { 66, "qh3kav", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, false, "Licensed Cotton Keyboard", null },
                    { 67, "wdfvb5", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, true, "Refined Frozen Fish", null },
                    { 68, "kbuxwi", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, false, "Gorgeous Granite Table", null },
                    { 69, "iwaiwv", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, true, "Sleek Steel Hat", null },
                    { 70, "1pyjri", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, false, "Fantastic Soft Shirt", null },
                    { 71, "5rxw0x", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, false, "Refined Granite Cheese", null },
                    { 72, "rjzqof", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, true, "Intelligent Metal Pizza", null },
                    { 73, "hyy3nj", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, false, "Handmade Plastic Sausages", null },
                    { 74, "7l651p", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, true, "Gorgeous Fresh Bike", null },
                    { 75, "n4xfjk", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, true, "Unbranded Rubber Computer", null },
                    { 76, "a6gy44", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, false, "Refined Cotton Hat", null },
                    { 77, "uarxpi", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, true, "Practical Plastic Chair", null },
                    { 78, "o2mj8f", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, true, "Generic Steel Shoes", null },
                    { 79, "w1s3q3", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, true, "Unbranded Soft Ball", null },
                    { 80, "zx0bx4", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, false, "Rustic Cotton Tuna", null },
                    { 81, "jxkmix", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, true, "Handcrafted Fresh Chair", null },
                    { 82, "d3bg9k", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, false, "Refined Metal Tuna", null },
                    { 83, "w06dv2", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, true, "Fantastic Frozen Shirt", null },
                    { 84, "2hs7ax", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, false, "Ergonomic Wooden Bike", null },
                    { 85, "slspab", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, false, "Sleek Wooden Salad", null },
                    { 86, "kdkppe", "The Football Is Good For Training And Recreational Purposes", null, true, "Gorgeous Frozen Chips", null },
                    { 87, "iaow8o", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, false, "Ergonomic Soft Keyboard", null },
                    { 88, "jmh7wv", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, true, "Practical Metal Shirt", null },
                    { 89, "69l4tn", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, false, "Refined Concrete Salad", null },
                    { 90, "d6s4bs", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, false, "Refined Plastic Fish", null },
                    { 91, "3g9qms", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, false, "Ergonomic Soft Cheese", null },
                    { 92, "jki98z", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, false, "Intelligent Plastic Soap", null },
                    { 93, "6zt6z8", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, true, "Awesome Rubber Fish", null },
                    { 94, "nj8odf", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, false, "Intelligent Frozen Shirt", null },
                    { 95, "tdj2a7", "The Football Is Good For Training And Recreational Purposes", null, false, "Rustic Plastic Chair", null },
                    { 96, "odrdtg", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, true, "Ergonomic Wooden Sausages", null },
                    { 97, "ee5bgi", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, false, "Incredible Soft Soap", null },
                    { 98, "0cc5xm", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, true, "Tasty Metal Gloves", null },
                    { 99, "qlx648", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, true, "Ergonomic Steel Cheese", null },
                    { 100, "0y6sev", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, false, "Tasty Rubber Cheese", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

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
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
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
                name: "Product");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
