namespace BusinessSelfAssessmentSurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SurveyQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        SurveyCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyCategories", t => t.SurveyCategory_Id)
                .Index(t => t.SurveyCategory_Id);
            
            CreateTable(
                "dbo.SurveyOptions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionID, t.Id })
                .ForeignKey("dbo.SurveyQuestions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyQuestions", "SurveyCategory_Id", "dbo.SurveyCategories");
            DropForeignKey("dbo.SurveyOptions", "QuestionID", "dbo.SurveyQuestions");
            DropIndex("dbo.SurveyOptions", new[] { "QuestionID" });
            DropIndex("dbo.SurveyQuestions", new[] { "SurveyCategory_Id" });
            DropTable("dbo.SurveyOptions");
            DropTable("dbo.SurveyQuestions");
            DropTable("dbo.SurveyCategories");
        }
    }
}
