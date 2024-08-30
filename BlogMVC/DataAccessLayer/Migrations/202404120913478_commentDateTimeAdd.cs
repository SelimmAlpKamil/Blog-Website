namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentDateTimeAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentTime");
        }
    }
}
