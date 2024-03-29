﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcTodo.Migrations {
    public partial class InitialCreate : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Users",
                columns : table => new {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                        Username = table.Column<string>(nullable: true),
                        Password = table.Column<string>(nullable: true)
                },
                constraints : table => {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
