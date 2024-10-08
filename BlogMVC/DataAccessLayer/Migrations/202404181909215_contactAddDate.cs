﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactAddDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "MailDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "MailDate");
        }
    }
}
