﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBlog : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(maxLength: 100));
        }
    }
}
