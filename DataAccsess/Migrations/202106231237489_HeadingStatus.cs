namespace DataAccsess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HeadingStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "Status", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Headings", "Status");
        }
    }
}
