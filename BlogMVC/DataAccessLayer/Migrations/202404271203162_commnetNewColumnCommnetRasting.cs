namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commnetNewColumnCommnetRasting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentRating");
        }
    }
}
