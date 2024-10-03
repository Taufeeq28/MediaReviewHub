using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaReviewHub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedReviewsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewID", "Category", "DateReviewed", "Rating", "ReviewText", "Title" },
                values: new object[,]
                {
                    { 1, "Movies", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Utc), 5, "A mind-bending thriller with stunning visuals.", "Inception" },
                    { 2, "Books", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, "A classic novel about the American dream.", "The Great Gatsby" },
                    { 3, "Movies", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), 5, "A visually stunning space exploration journey.", "Interstellar" },
                    { 4, "Books", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), 5, "A magical fable about following your dreams.", "The Alchemist" },
                    { 5, "Music", new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Utc), 5, "A legendary song by Queen.", "Bohemian Rhapsody" },
                    { 6, "Movies", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), 5, "An epic tale of a mafia family.", "The Godfather" },
                    { 7, "Books", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Utc), 5, "A novel about racial injustice in the American South.", "To Kill a Mockingbird" },
                    { 8, "Games", new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Utc), 4, "An epic adventure game with stunning combat.", "God of War" },
                    { 9, "Games", new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), 5, "An open-world Western adventure.", "Red Dead Redemption 2" },
                    { 10, "Music", new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), 5, "A legendary album by The Beatles.", "The Beatles - Abbey Road" },
                    { 11, "Movies", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), 5, "A sci-fi movie about reality and human existence.", "The Matrix" },
                    { 12, "Books", new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Utc), 4, "A dystopian novel about surveillance and totalitarianism.", "1984" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 12);
        }
    }
}
