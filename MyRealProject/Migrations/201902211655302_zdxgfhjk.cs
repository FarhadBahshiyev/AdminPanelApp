namespace MyRealProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zdxgfhjk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Role_Id", "dbo.Role");
            DropIndex("dbo.Categories", new[] { "Role_Id" });
            DropColumn("dbo.Categories", "Role_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Role_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Role_Id");
            AddForeignKey("dbo.Categories", "Role_Id", "dbo.Role", "Id");
        }
    }
}
