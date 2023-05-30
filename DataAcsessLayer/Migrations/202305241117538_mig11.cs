namespace DataAcsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 200));
            AddColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            DropColumn("dbo.Writers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "Password", c => c.String(maxLength: 20));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterTitle");
            DropColumn("dbo.Writers", "WriterAbout");
            DropColumn("dbo.Writers", "WriterPassword");
        }
    }
}
