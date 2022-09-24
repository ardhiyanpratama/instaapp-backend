using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace instaapp_backend.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    mobile_number = table.Column<string>(type: "character(16)", fixedLength: true, maxLength: 16, nullable: false, defaultValueSql: "16"),
                    ispost = table.Column<bool>(type: "boolean", nullable: true),
                    islike = table.Column<bool>(type: "boolean", nullable: true),
                    iscomment = table.Column<bool>(type: "boolean", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'-infinity'::timestamp with time zone"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'-infinity'::timestamp with time zone")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posting",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    posts = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'-infinity'::timestamp with time zone"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'-infinity'::timestamp with time zone")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posting", x => x.id);
                    table.ForeignKey(
                        name: "posting_fk",
                        column: x => x.id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "like",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    posting_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_like = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'-infinity'::timestamp with time zone"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'-infinity'::timestamp with time zone")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_like", x => x.id);
                    table.ForeignKey(
                        name: "like_fk",
                        column: x => x.id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "like_fk_1",
                        column: x => x.id,
                        principalTable: "posting",
                        principalColumn: "id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "like");

            migrationBuilder.DropTable(
                name: "posting");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
