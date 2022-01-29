using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonTasks.Migrations
{
    public partial class ChangeRelManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_person_userId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_userId",
                table: "Todos");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Todos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Todoid",
                table: "person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "person_todos",
                columns: table => new
                {
                    TodoId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_todos", x => new { x.TodoId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_person_todos_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_todos_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person_Todoid",
                table: "person",
                column: "Todoid");

            migrationBuilder.CreateIndex(
                name: "IX_person_todos_PersonId",
                table: "person_todos",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_person_Todos_Todoid",
                table: "person",
                column: "Todoid",
                principalTable: "Todos",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_Todos_Todoid",
                table: "person");

            migrationBuilder.DropTable(
                name: "person_todos");

            migrationBuilder.DropIndex(
                name: "IX_person_Todoid",
                table: "person");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Todoid",
                table: "person");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_userId",
                table: "Todos",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_person_userId",
                table: "Todos",
                column: "userId",
                principalTable: "person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
