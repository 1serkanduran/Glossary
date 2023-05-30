namespace DataAcsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadingStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            DropColumn("dbo.Headings", "HeadingStatus");
        }
    }
}
