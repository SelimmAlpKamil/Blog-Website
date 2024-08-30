namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commnetNewCloumnStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommnetStatuse", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommnetStatuse");
        }
    }
}
