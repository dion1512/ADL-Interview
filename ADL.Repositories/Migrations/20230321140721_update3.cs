using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADL.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Callout_Category_CategoryId",
                table: "Callout");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Callout",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Callout_CategoryId",
                table: "Callout",
                newName: "IX_Callout_CategoryID");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Callout",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_Callout_Category_CategoryID",
                table: "Callout",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Callout_Category_CategoryID",
                table: "Callout");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Callout",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Callout_CategoryID",
                table: "Callout",
                newName: "IX_Callout_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Callout",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Callout_Category_CategoryId",
                table: "Callout",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
