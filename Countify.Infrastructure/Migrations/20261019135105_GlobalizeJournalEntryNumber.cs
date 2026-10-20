using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Countify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GlobalizeJournalEntryNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Legacy: CntDocumentos.Documento era PK [Key(true)] autoincrementada → número
            // único global. Se renumeran las partidas existentes en orden cronológico para
            // eliminar los duplicados que producía la numeración por período anterior.
            migrationBuilder.Sql(@"
WITH ordered AS (
    SELECT Id, ROW_NUMBER() OVER (ORDER BY ReferenceDate, Id) AS rn
    FROM JournalEntries
)
UPDATE je
SET EntryNumber = ordered.rn
FROM JournalEntries je
INNER JOIN ordered ON ordered.Id = je.Id;");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_EntryNumber",
                table: "JournalEntries",
                column: "EntryNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_EntryNumber",
                table: "JournalEntries");
        }
    }
}
