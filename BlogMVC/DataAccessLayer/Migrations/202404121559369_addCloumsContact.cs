namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCloumsContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Addres", c => c.String(maxLength: 1000));
            AddColumn("dbo.Contacts", "Phone", c => c.String(maxLength: 20));
            AddColumn("dbo.Contacts", "EmailAddress", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "EmailAddress");
            DropColumn("dbo.Contacts", "Phone");
            DropColumn("dbo.Contacts", "Addres");
        }
    }
}
