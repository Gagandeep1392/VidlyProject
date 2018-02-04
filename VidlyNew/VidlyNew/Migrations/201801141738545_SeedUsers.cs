namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'889c8682-1ce7-4d95-847e-fdb3325bb5f6', N'guest@vidly.com', 0, N'AA8uVIgxX/PzY9OASSMZFcuTT2MGN3tYUTK+AN5Q3bb1th9LX5cgK+UWd2En1OZeNQ==', N'8ac3471c-b31a-40dd-b69e-79d311001660', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bcac00f7-06a1-4fcc-bc63-ee474dd7ae62', N'admin@vidly.com', 0, N'AL8mKbzPlc73uJ4ygDqddI+WDxwEgugJhJ9kCBKzvO6m2yHTKlbVJOk4qb2iZThUsA==', N'25953e87-09d7-417b-bfcb-082fa7553ffc', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2466807a-b7d5-439a-992d-45ced11ce74a', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bcac00f7-06a1-4fcc-bc63-ee474dd7ae62', N'2466807a-b7d5-439a-992d-45ced11ce74a')
");
        }
        
        public override void Down()
        {
        }
    }
}
