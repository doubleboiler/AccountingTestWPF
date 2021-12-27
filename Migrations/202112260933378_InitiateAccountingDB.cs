namespace AccountingTestWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiateAccountingDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperationDate = c.DateTime(nullable: false),
                        Note = c.String(nullable: false, maxLength: 100),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsIncome = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        RecipientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Recipients", t => t.RecipientId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipientName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Operations", "RecipientId", "dbo.Recipients");
            DropForeignKey("dbo.Operations", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Operations", new[] { "RecipientId" });
            DropIndex("dbo.Operations", new[] { "CategoryId" });
            DropIndex("dbo.Operations", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Recipients");
            DropTable("dbo.Operations");
            DropTable("dbo.Categories");
        }
    }
}
