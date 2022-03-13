using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarryCashWebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    Owner_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.Owner_Id);
                });

            migrationBuilder.CreateTable(
                name: "payee",
                columns: table => new
                {
                    Payee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payee_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsKyc = table.Column<bool>(type: "bit", nullable: false),
                    IsKyb = table.Column<bool>(type: "bit", nullable: false),
                    Is_Individual = table.Column<bool>(type: "bit", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payee", x => x.Payee_Id);
                });

            migrationBuilder.CreateTable(
                name: "payee_kyb",
                columns: table => new
                {
                    Document_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Document_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payee_Id = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payee_kyb", x => x.Document_no);
                });

            migrationBuilder.CreateTable(
                name: "payee_kyc",
                columns: table => new
                {
                    Document_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Document_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payee_Id = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payee_kyc", x => x.Document_no);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Tranx_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tranx_Date_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tranx_Amt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Merchant_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Tranx_Id);
                });

            migrationBuilder.CreateTable(
                name: "merchant",
                columns: table => new
                {
                    Merchant_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Owner_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Business_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type_of_business = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Excepted_amount_of_disbursment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anually_Income = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Registration_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_merchant", x => x.Merchant_Id);
                    table.ForeignKey(
                        name: "FK_merchant_owner_Owner_Id",
                        column: x => x.Owner_Id,
                        principalTable: "owner",
                        principalColumn: "Owner_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_merchant_Owner_Id",
                table: "merchant",
                column: "Owner_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "merchant");

            migrationBuilder.DropTable(
                name: "payee");

            migrationBuilder.DropTable(
                name: "payee_kyb");

            migrationBuilder.DropTable(
                name: "payee_kyc");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "owner");
        }
    }
}
