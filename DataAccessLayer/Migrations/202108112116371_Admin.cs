namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminName", c => c.String());
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary());
            DropColumn("dbo.Admins", "AdminMail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminMail", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminStatus");
            DropColumn("dbo.Admins", "AdminName");
        }
    }
}
