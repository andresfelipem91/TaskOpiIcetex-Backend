using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskOpiIcetex.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    notification = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TaskOpiTasks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsState = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Priority = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Detail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UsersUserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskOpiTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskOpiTasks_UserModels_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "UserModels",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskOpiTasks_UsersUserId",
                table: "TaskOpiTasks",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskOpiTasks");

            migrationBuilder.DropTable(
                name: "UserModels");
        }
    }
}
