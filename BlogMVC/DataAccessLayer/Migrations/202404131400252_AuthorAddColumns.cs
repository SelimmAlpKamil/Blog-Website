namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorAddColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorTitle", c => c.String(maxLength: 100));
            AddColumn("dbo.Authors", "AuthorMail", c => c.String(maxLength: 100));
            AddColumn("dbo.Authors", "AuthorPassWord", c => c.String(maxLength: 100));
            AddColumn("dbo.Authors", "AuthorPhoneNumber", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "AuthorPhoneNumber");
            DropColumn("dbo.Authors", "AuthorPassWord");
            DropColumn("dbo.Authors", "AuthorMail");
            DropColumn("dbo.Authors", "AuthorTitle");
        }
    }
}
