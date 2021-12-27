namespace AccountingTestWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLogin : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Login");
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "Login", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
