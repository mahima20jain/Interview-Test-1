using Microsoft.EntityFrameworkCore.Migrations;

namespace TestCore.Migrations
{
    public partial class AddStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[ResetGenre]
	                    @id int = id
                        AS
	                    UPDATE [dbo].Movie SET Genre = '' WHERE id = 2
                        RETURN";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropSp = "DROP PROCEDURE [dbo].[ResetGenre]";

            migrationBuilder.Sql(dropSp);
        }
    }
}
