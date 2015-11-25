namespace Phase2Nandoso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FeedbackID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        Content = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Feedback", t => t.FeedbackID, cascadeDelete: true)
                .Index(t => t.FeedbackID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(unicode: false),
                        Comment = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Special",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Dish = c.String(unicode: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "FeedbackID", "dbo.Feedback");
            DropForeignKey("dbo.Reply", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.Reply", new[] { "EmployeeID" });
            DropIndex("dbo.Reply", new[] { "FeedbackID" });
            DropTable("dbo.Special");
            DropTable("dbo.Feedback");
            DropTable("dbo.Reply");
            DropTable("dbo.Employee");
        }
    }
}
