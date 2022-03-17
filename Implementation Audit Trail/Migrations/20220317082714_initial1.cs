using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Implementation_Audit_Trail.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuditId",
                table: "auditentries",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_auditentries",
                table: "auditentries",
                column: "AuditId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_auditentries",
                table: "auditentries");

            migrationBuilder.DropColumn(
                name: "AuditId",
                table: "auditentries");
        }
    }
}
