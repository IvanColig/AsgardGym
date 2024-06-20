using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsgardGym.Migrations
{
    /// <inheritdoc />
    public partial class AddPosjeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UslugaID",
                table: "Posjete",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Korisnici",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Posjete_UslugaID",
                table: "Posjete",
                column: "UslugaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posjete_Usluge_UslugaID",
                table: "Posjete",
                column: "UslugaID",
                principalTable: "Usluge",
                principalColumn: "UslugaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posjete_Usluge_UslugaID",
                table: "Posjete");

            migrationBuilder.DropIndex(
                name: "IX_Posjete_UslugaID",
                table: "Posjete");

            migrationBuilder.DropColumn(
                name: "UslugaID",
                table: "Posjete");

            migrationBuilder.AlterColumn<int>(
                name: "Telefon",
                table: "Korisnici",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
