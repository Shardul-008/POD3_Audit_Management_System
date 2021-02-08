using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditManagementPortalClientMVC.Migrations
{
    public partial class changeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_storeAuditResponses",
                table: "storeAuditResponses");

            migrationBuilder.RenameTable(
                name: "storeAuditResponses",
                newName: "StoreAuditResponses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreAuditResponses",
                table: "StoreAuditResponses",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreAuditResponses",
                table: "StoreAuditResponses");

            migrationBuilder.RenameTable(
                name: "StoreAuditResponses",
                newName: "storeAuditResponses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_storeAuditResponses",
                table: "storeAuditResponses",
                column: "ID");
        }
    }
}
