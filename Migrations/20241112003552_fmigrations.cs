using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAP_PROJETO_CSHARP.Migrations
{
    /// <inheritdoc />
    public partial class fmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TRUCKS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PLATE_CODE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DRIVER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    REGISTRATION_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    LOCATION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRUCKS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USERNAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PASSWORD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRUCKS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
