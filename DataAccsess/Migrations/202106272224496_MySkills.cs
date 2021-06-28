namespace DataAccsess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class MySkills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                {
                    PersonId = c.Int(nullable: false, identity: true),
                    NameSurName = c.String(),
                    Job = c.String(),
                })
                .PrimaryKey(t => t.PersonId);

            CreateTable(
                "dbo.Skills",
                c => new
                {
                    SkillId = c.Int(nullable: false, identity: true),
                    SkillName = c.String(),
                    SkillRate = c.String(),
                })
                .PrimaryKey(t => t.SkillId);

        }

        public override void Down()
        {
            DropTable("dbo.Skills");
            DropTable("dbo.People");
        }
    }
}
