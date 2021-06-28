namespace DataAccsess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class IsDraft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Messages", "IsDraft");
        }
    }
}
