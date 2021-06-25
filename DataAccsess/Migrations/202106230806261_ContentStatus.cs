namespace DataAccsess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ContentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "Status", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Contents", "Status");
        }
    }
}
