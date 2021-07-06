namespace DataAccsess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AdminStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Status", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Admins", "Status");
        }
    }
}
