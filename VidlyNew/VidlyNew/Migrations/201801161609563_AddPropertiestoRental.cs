namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiestoRental : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "DateReturn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "DateReturn", c => c.DateTime(nullable: false));
        }
    }
}
