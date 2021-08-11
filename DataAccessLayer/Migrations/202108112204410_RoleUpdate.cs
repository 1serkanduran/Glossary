namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "RoleName", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "RoleName", c => c.String(maxLength: 50));
        }
    }
}
