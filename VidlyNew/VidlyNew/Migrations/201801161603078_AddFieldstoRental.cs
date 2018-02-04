namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldstoRental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rentals", "DateReturn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "DateReturn");
            DropColumn("dbo.Rentals", "DateRented");
        }
    }
}
