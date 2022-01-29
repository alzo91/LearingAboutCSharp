using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonTasks.Migrations
{
    public partial class SolvedSomethigInRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_Todos_Todoid",
                table: "person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person_todos",
                table: "person_todos");

            migrationBuilder.DropIndex(
                name: "IX_person_todos_PersonId",
                table: "person_todos");

            migrationBuilder.DropIndex(
                name: "IX_person_Todoid",
                table: "person");

            migrationBuilder.DropColumn(
                name: "Todoid",
                table: "person");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: -1,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldDefaultValue: (short)-1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_todos",
                table: "person_todos",
                columns: new[] { "PersonId", "TodoId" });

            migrationBuilder.CreateIndex(
                name: "IX_person_todos_TodoId",
                table: "person_todos",
                column: "TodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_person_todos",
                table: "person_todos");

            migrationBuilder.DropIndex(
                name: "IX_person_todos_TodoId",
                table: "person_todos");

            migrationBuilder.AlterColumn<short>(
                name: "status",
                table: "Todos",
                type: "smallint",
                nullable: false,
                defaultValue: (short)-1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: -1);

            migrationBuilder.AddColumn<int>(
                name: "Todoid",
                table: "person",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_person_todos",
                table: "person_todos",
                columns: new[] { "TodoId", "PersonId" });

            migrationBuilder.CreateIndex(
                name: "IX_person_todos_PersonId",
                table: "person_todos",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_person_Todoid",
                table: "person",
                column: "Todoid");

            migrationBuilder.AddForeignKey(
                name: "FK_person_Todos_Todoid",
                table: "person",
                column: "Todoid",
                principalTable: "Todos",
                principalColumn: "id");
        }
    }
}
