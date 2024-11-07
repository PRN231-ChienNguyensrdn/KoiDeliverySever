using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiDeliv.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GSP",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    index = table.Column<int>(type: "int", nullable: false),
                    vehicleID = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    pStart = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    pTerm = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    pEnd = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    preRouted = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    freg = table.Column<int>(type: "int", nullable: false),
                    label = table.Column<bool>(type: "bit", nullable: false),
                    regions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSP", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PriceList",
                columns: table => new
                {
                    PriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightRange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    AdditionalServicePrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PriceLis__4957584F8015DBAE", x => x.PriceID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    AuthorID = table.Column<int>(type: "int", nullable: true),
                    PriceListID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK__Blogs__AuthorID__75A278F5",
                        column: x => x.AuthorID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__Blogs__PriceList__76969D2E",
                        column: x => x.PriceListID,
                        principalTable: "PriceList",
                        principalColumn: "PriceID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfiles",
                columns: table => new
                {
                    ProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    TotalOrders = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    TotalSpent = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValueSql: "((0))"),
                    LastOrderDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__290C8884D738E605", x => x.ProfileID);
                    table.ForeignKey(
                        name: "FK__CustomerP__Custo__778AC167",
                        column: x => x.CustomerID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    ShippingMethod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AdditionalServices = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('Pending')"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DateShip = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneContact = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FishType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NameUserGet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(13,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Orders__Customer__787EE5A0",
                        column: x => x.CustomerID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingsFeedbacks",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RatingsF__6A4BEDF667F8AC4A", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK__RatingsFe__Order__797309D9",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ShipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    SalesStaffID = table.Column<int>(type: "int", nullable: true),
                    DeliveringStaffID = table.Column<int>(type: "int", nullable: true),
                    HealthCheckStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PackingStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShippingStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('In-Progress')"),
                    ForeignImportStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateIssued = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(13,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ShipmentID);
                    table.ForeignKey(
                        name: "FK__Shipments__Deliv__7B5B524B",
                        column: x => x.DeliveringStaffID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Shipments__Order__7C4F7684",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Shipments__Sales__7D439ABD",
                        column: x => x.SalesStaffID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankTranNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentInfor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransasctionStatus = table.Column<int>(type: "int", nullable: true),
                    PaymentAccount = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Transaction_Orders",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RoutedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Notice = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DateSetting = table.Column<DateTime>(type: "date", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "date", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sourceLatitude = table.Column<double>(type: "float", nullable: true),
                    sourceLongitude = table.Column<double>(type: "float", nullable: true),
                    destinationLatitude = table.Column<double>(type: "float", nullable: true),
                    destinationLongitude = table.Column<double>(type: "float", nullable: true),
                    Distance = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(13,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RoutedID);
                    table.ForeignKey(
                        name: "FK_Route_Shipments",
                        column: x => x.ShipmentID,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorID",
                table: "Blogs",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_PriceListID",
                table: "Blogs",
                column: "PriceListID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_CustomerID",
                table: "CustomerProfiles",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_RatingsFeedbacks_OrderID",
                table: "RatingsFeedbacks",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_ShipmentID",
                table: "Route",
                column: "ShipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_DeliveringStaffID",
                table: "Shipments",
                column: "DeliveringStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_OrderID",
                table: "Shipments",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_SalesStaffID",
                table: "Shipments",
                column: "SalesStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_OrderID",
                table: "Transaction",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534D2ED00FB",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "CustomerProfiles");

            migrationBuilder.DropTable(
                name: "GSP");

            migrationBuilder.DropTable(
                name: "RatingsFeedbacks");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "PriceList");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
