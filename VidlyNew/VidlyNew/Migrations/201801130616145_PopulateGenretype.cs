namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenretype : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes(Id,Name) VALUES(1,'Comedy')");
            Sql("INSERT INTO GenreTypes(Id,Name) VALUES(2,'Action')");
            Sql("INSERT INTO GenreTypes(Id,Name) VALUES(3,'Family')");
            Sql("INSERT INTO GenreTypes(Id,Name) VALUES(4,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
