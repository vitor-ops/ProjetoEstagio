using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elapsed = table.Column<int>(type: "int", nullable: false),
                    ClientIPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
