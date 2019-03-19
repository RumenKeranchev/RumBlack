using Microsoft.EntityFrameworkCore.Migrations;

namespace RB.Data.Migrations
{
    public partial class blah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInShoppingCart_Tickets_CartId",
                table: "TicketInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketInShoppingCart_ShoppingCarts_TicketId",
                table: "TicketInShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInShoppingCart",
                table: "TicketInShoppingCart");

            migrationBuilder.RenameTable(
                name: "TicketInShoppingCart",
                newName: "TicketsInShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInShoppingCart_CartId",
                table: "TicketsInShoppingCart",
                newName: "IX_TicketsInShoppingCart_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsInShoppingCart",
                table: "TicketsInShoppingCart",
                columns: new[] { "TicketId", "CartId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsInShoppingCart_Tickets_CartId",
                table: "TicketsInShoppingCart",
                column: "CartId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsInShoppingCart_ShoppingCarts_TicketId",
                table: "TicketsInShoppingCart",
                column: "TicketId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketsInShoppingCart_Tickets_CartId",
                table: "TicketsInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketsInShoppingCart_ShoppingCarts_TicketId",
                table: "TicketsInShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsInShoppingCart",
                table: "TicketsInShoppingCart");

            migrationBuilder.RenameTable(
                name: "TicketsInShoppingCart",
                newName: "TicketInShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_TicketsInShoppingCart_CartId",
                table: "TicketInShoppingCart",
                newName: "IX_TicketInShoppingCart_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInShoppingCart",
                table: "TicketInShoppingCart",
                columns: new[] { "TicketId", "CartId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInShoppingCart_Tickets_CartId",
                table: "TicketInShoppingCart",
                column: "CartId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInShoppingCart_ShoppingCarts_TicketId",
                table: "TicketInShoppingCart",
                column: "TicketId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
