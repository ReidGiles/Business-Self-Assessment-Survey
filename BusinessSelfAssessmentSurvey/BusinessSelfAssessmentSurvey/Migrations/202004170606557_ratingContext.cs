namespace BusinessSelfAssessmentSurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Admin = c.Int(nullable: false),
                        Business = c.Int(nullable: false),
                        Architecture = c.Int(nullable: false),
                        Development = c.Int(nullable: false),
                        Security = c.Int(nullable: false),
                        Documentation = c.Int(nullable: false),
                        Compliance = c.Int(nullable: false),
                        Processes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SurveyRatings");
        }
    }
}
