namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seeduser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a9302aac-be1c-4151-9ff8-c610a1902928', N'guest@vidly.com', 0, N'AH9coFeJA9wJMYyo5fJO+qUBnmzDqFQ3ym27bTmdSW922pW4llJreiiG/i5Hv8YCNw==', N'3aaf82a6-99d4-43db-b93e-eb12224b8741', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'acd57c1e-cad4-46f7-8396-dc4a8d3846fe', N'admin@vidly.com', 0, N'AEj/wBhX6HY3e/6Hq36QRh1x6TJhnR0UDfpx+njzy5NukhkScyG5C9M5TPi/Vm78lg==', N'fe7f8f11-8ef1-4983-93b8-1bc516c81a72', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3fb36ab4-e27e-4a87-a512-44eecfe2ca4e', N'canmanagemovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'acd57c1e-cad4-46f7-8396-dc4a8d3846fe', N'3fb36ab4-e27e-4a87-a512-44eecfe2ca4e')

");
        }
        
        public override void Down()
        {
        }
    }
}
