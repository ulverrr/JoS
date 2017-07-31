namespace JoS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToDbStartStudyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StartStudies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StudyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfo", t => t.Id)
                .Index(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StartStudies", "Id", "dbo.UserInfo");
            DropIndex("dbo.StartStudies", new[] { "Id" });
            DropTable("dbo.StartStudies");
        }
    }
}
