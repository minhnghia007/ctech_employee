using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjectApiCompanyCTECH.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(maxLength: 100, nullable: false),
                    birthday = table.Column<DateTime>(nullable: false),
                    gender = table.Column<bool>(nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(maxLength: 10, nullable: true),
                    salary = table.Column<decimal>(nullable: false),
                    department = table.Column<int>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    biography = table.Column<string>(maxLength: 100, nullable: false),
                    create_date = table.Column<DateTime>(nullable: true),
                    modified_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
