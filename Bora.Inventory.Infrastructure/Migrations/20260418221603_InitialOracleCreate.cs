using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bora.Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialOracleCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STOCK_ITEMS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    QUANTITY = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("P_K__S_T_O_C_K__I_T_E_M_S", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STOCK_ITEMS");
        }
    }
}
