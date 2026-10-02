using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountOpening.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateApplicationMetadataEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationMetadatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionalPassword = table.Column<short>(type: "smallint", maxLength: 6, nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationMetadatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationMetadatas_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationMetadatas_ClientId",
                table: "ApplicationMetadatas",
                column: "ClientId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationMetadatas");
        }
    }
}
