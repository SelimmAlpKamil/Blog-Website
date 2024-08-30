namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "Addres");
            DropColumn("dbo.Contacts", "Phone");
            DropColumn("dbo.Contacts", "EmailAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "EmailAddress", c => c.String(maxLength: 100));
            AddColumn("dbo.Contacts", "Phone", c => c.String(maxLength: 20));
            AddColumn("dbo.Contacts", "Addres", c => c.String(maxLength: 1000));
        }
    }
}
