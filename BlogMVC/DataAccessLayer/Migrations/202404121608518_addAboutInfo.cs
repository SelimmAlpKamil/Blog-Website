namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAboutInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutInfoes",
                c => new
                    {
                        AboutInfoId = c.Int(nullable: false, identity: true),
                        Addres = c.String(maxLength: 1000),
                        Phone = c.String(maxLength: 20),
                        EmailAddress = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AboutInfoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutInfoes");
        }
    }
}
