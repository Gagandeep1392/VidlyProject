namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGenreFields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
        }
    }
}
