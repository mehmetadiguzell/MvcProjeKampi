namespace DataAccsess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AboutStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "Status", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Abouts", "Status");
        }
    }
}
