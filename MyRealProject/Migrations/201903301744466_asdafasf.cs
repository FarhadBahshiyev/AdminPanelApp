namespace MyRealProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdafasf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        URL = c.String(),
                        UploadDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        Reads = c.Int(),
                        UserId = c.Int(),
                        İmage = c.String(),
                        UploadDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        NewsId = c.Int(),
                        UploadDate = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .Index(t => t.NewsId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                        UploadDate = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 15),
                        UploadDate = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "User_Id", "dbo.User");
            DropForeignKey("dbo.News", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Pictures", "NewsId", "dbo.News");
            DropForeignKey("dbo.News", "Category_Id", "dbo.Categories");
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.Pictures", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "Category_Id" });
            DropIndex("dbo.News", new[] { "UserId" });
            DropIndex("dbo.Categories", new[] { "User_Id" });
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Pictures");
            DropTable("dbo.News");
            DropTable("dbo.Categories");
        }
    }
}
