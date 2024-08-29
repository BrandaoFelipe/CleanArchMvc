using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mB)
        {
            mB.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" + 
                "VALUES('Estojo Escolar', 'Estojo escolar cinza',5.65,70,'estojo1.jpg',1)");

            mB.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
                "VALUES('Caderno Espiral', 'Caderno Espiral 100 folhas',7.65,50,'caderno100f.jpg',1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mB)
        {
            mB.Sql("DELETE FROM Products");
        }
    }
}
