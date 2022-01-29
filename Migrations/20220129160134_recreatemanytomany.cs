using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonTasks.Migrations
{
    public partial class recreatemanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_todos_person_PersonId",
                table: "person_todos");

            migrationBuilder.DropForeignKey(
                name: "FK_person_todos_Todos_TodoId",
                table: "person_todos");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "person_todos",
                newName: "personid");

            migrationBuilder.RenameColumn(
                name: "TodoId",
                table: "person_todos",
                newName: "todosid");

            migrationBuilder.RenameIndex(
                name: "IX_person_todos_TodoId",
                table: "person_todos",
                newName: "IX_person_todos_todosid");

            migrationBuilder.AddForeignKey(
                name: "FK_person_todos_person_personid",
                table: "person_todos",
                column: "personid",
                principalTable: "person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_todos_Todos_todosid",
                table: "person_todos",
                column: "todosid",
                principalTable: "Todos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_todos_person_personid",
                table: "person_todos");

            migrationBuilder.DropForeignKey(
                name: "FK_person_todos_Todos_todosid",
                table: "person_todos");

            migrationBuilder.RenameColumn(
                name: "personid",
                table: "person_todos",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "todosid",
                table: "person_todos",
                newName: "TodoId");

            migrationBuilder.RenameIndex(
                name: "IX_person_todos_todosid",
                table: "person_todos",
                newName: "IX_person_todos_TodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_person_todos_person_PersonId",
                table: "person_todos",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_person_todos_Todos_TodoId",
                table: "person_todos",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
