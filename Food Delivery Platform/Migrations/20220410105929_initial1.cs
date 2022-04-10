using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Platform.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "cash_balance",
                table: "users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "cash_balance",
                table: "hotels",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cash_balance",
                table: "users");

            migrationBuilder.DropColumn(
                name: "cash_balance",
                table: "hotels");
        }
    }
}
