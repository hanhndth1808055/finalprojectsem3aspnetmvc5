namespace OfficialFinalProjectSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Thumbnails", c => c.String());
            AddColumn("dbo.Products", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Products", "Code");
            DropColumn("dbo.Products", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "Code", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "Status");
            DropColumn("dbo.Products", "CreatedAt");
            DropColumn("dbo.Products", "Thumbnails");
            DropColumn("dbo.Products", "Price");
        }
    }
}
