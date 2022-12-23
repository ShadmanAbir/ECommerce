using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Domain.Migrations
{
    public partial class Multipleisssuefixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockedUserID",
                table: "UserBlockList");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "UserBlockList");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "UserBlockList");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "UserBlockList");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SellPostWiseTag");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SellPostWiseTag");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "SellPostWiseTag");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SellPosts");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SellPosts");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "SellPosts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "Messages");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserBlockList",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlockedUser",
                table: "UserBlockList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserBlockList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostCreator",
                table: "SellPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockedUser",
                table: "UserBlockList");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserBlockList");

            migrationBuilder.DropColumn(
                name: "PostCreator",
                table: "SellPosts");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Messages");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserBlockList",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "BlockedUserID",
                table: "UserBlockList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "UserBlockList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "UserBlockList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "UserBlockList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tag",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "Tag",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SellPostWiseTag",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "SellPostWiseTag",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "SellPostWiseTag",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SellPosts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "SellPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "SellPosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Product",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Messages",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "Messages",
                type: "datetime2",
                nullable: true);
        }
    }
}
