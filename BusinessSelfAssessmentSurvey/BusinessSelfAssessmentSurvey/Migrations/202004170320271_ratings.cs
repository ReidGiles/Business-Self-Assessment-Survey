namespace BusinessSelfAssessmentSurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyOptions", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyOptions", "Rating");
        }
    }
}
