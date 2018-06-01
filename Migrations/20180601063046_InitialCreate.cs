using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication5.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(nullable: false),
                    OrganizationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    OrganizationID = table.Column<int>(nullable: false),
                    OrganizationID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Organization_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organization",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Organization_OrganizationID1",
                        column: x => x.OrganizationID1,
                        principalTable: "Organization",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplaintText = table.Column<string>(nullable: true),
                    OrganizationID = table.Column<int>(nullable: false),
                    OrganizationID1 = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Complaint_Organization_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organization",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaint_Organization_OrganizationID1",
                        column: x => x.OrganizationID1,
                        principalTable: "Organization",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaint_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_OrganizationID",
                table: "Complaint",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_OrganizationID1",
                table: "Complaint",
                column: "OrganizationID1");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_UserID",
                table: "Complaint",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganizationID",
                table: "User",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganizationID1",
                table: "User",
                column: "OrganizationID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
