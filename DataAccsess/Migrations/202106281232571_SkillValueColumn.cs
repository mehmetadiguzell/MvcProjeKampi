namespace DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillValueColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "SkillValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "SkillValue");
        }
    }
}
