﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theater.Migrations
{
    /// <inheritdoc />
    public partial class pieceUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Pieces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pieces");
        }
    }
}
