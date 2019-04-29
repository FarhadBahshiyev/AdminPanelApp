namespace MyRealProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asfsfas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pictures", "UploadDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "UploadDate", c => c.DateTime(nullable: false));
        }
    }
}
