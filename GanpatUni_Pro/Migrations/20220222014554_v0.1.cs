using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GanpatUni_Pro.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Users_User_Id",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Users_User_Id",
                table: "Mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_User_Id",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Announcement_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Announcement_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mentor_Id = table.Column<int>(type: "int", nullable: false),
                    Group_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Announcement_Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Group_Masters_Group_Id",
                        column: x => x.Group_Id,
                        principalTable: "Group_Masters",
                        principalColumn: "Group_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Announcements_Mentors_Mentor_Id",
                        column: x => x.Mentor_Id,
                        principalTable: "Mentors",
                        principalColumn: "Mentor_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Userms",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_type = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Email_id = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Mobile_no = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userms", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "Querys",
                columns: table => new
                {
                    Query_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Type = table.Column<int>(type: "int", nullable: false),
                    Query_Desc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Query_Date = table.Column<int>(type: "int", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Mentor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Querys", x => x.Query_Id);
                    table.ForeignKey(
                        name: "FK_Querys_Mentors_Mentor_id",
                        column: x => x.Mentor_id,
                        principalTable: "Mentors",
                        principalColumn: "Mentor_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Querys_Userms_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Userms",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_Group_Id",
                table: "Announcements",
                column: "Group_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_Mentor_Id",
                table: "Announcements",
                column: "Mentor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Querys_Mentor_id",
                table: "Querys",
                column: "Mentor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Querys_User_Id",
                table: "Querys",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Userms_User_Id",
                table: "Meetings",
                column: "User_Id",
                principalTable: "Userms",
                principalColumn: "User_id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Userms_User_Id",
                table: "Mentors",
                column: "User_Id",
                principalTable: "Userms",
                principalColumn: "User_id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Userms_User_Id",
                table: "Students",
                column: "User_Id",
                principalTable: "Userms",
                principalColumn: "User_id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Userms_User_Id",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Userms_User_Id",
                table: "Mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Userms_User_Id",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Querys");

            migrationBuilder.DropTable(
                name: "Userms");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email_id = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Mobile_no = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    User_type = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Users_User_Id",
                table: "Meetings",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Users_User_Id",
                table: "Mentors",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_User_Id",
                table: "Students",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
