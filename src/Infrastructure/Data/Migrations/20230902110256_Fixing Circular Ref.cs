using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaDB.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingCircularRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ActorId",
                table: "ActorMovie",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MovieId",
                table: "ActorMovie",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "ActorMovie");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "ActorMovie");
        }
    }
}
