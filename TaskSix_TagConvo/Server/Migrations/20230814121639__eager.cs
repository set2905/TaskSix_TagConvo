using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSix_TagConvo.Server.Migrations
{
    /// <inheritdoc />
    public partial class _eager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SentDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_MessageTagRelations_MessageId",
                table: "MessageTagRelations",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageTagRelations_TagId",
                table: "MessageTagRelations",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTagRelations_Messages_MessageId",
                table: "MessageTagRelations",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTagRelations_Tags_TagId",
                table: "MessageTagRelations",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageTagRelations_Messages_MessageId",
                table: "MessageTagRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageTagRelations_Tags_TagId",
                table: "MessageTagRelations");

            migrationBuilder.DropIndex(
                name: "IX_MessageTagRelations_MessageId",
                table: "MessageTagRelations");

            migrationBuilder.DropIndex(
                name: "IX_MessageTagRelations_TagId",
                table: "MessageTagRelations");

            migrationBuilder.DropColumn(
                name: "SentDate",
                table: "Messages");
        }
    }
}
