using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineFoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class DropYourTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userrole",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userrole", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "registerUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emailID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobileNumber = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    roleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registerUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegisterVM_UserRole",
                        column: x => x.roleID,
                        principalTable: "userrole",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_registerUser_emailID",
                table: "registerUser",
                column: "emailID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterVM_RoleID",
                table: "registerUser",
                column: "roleID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registerUser");

            migrationBuilder.DropTable(
                name: "userrole");
        }
    }
}
