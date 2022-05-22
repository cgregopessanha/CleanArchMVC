﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Caderno espiral','Caderno espiral 100 folhas',7.45,50,'caderno1.jpg',1)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Estojo','Estojo escolar - Cinza',9.99,70,'estojo1.jpg',1)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Borracha','Borracha branca - Pequena',3.99,80,'borracha1.jpg',1)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
            "VALUES('Calculadora','Calculadora portátil',17.89,30,'calculadora1.jpg',2)");

        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
