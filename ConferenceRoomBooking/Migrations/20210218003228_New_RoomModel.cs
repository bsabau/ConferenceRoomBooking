using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferenceRoomBooking.Migrations
{
    public partial class New_RoomModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Room",
                type: "varchar(512)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(512)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Room",
                type: "varchar(512)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldNullable: true);
        }
    }
}
