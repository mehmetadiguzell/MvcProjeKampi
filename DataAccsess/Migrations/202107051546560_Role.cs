namespace DataAccsess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminRoles",
                c => new
                {
                    RoleId = c.Int(nullable: false, identity: true),
                    RoleName = c.String(maxLength: 1),
                })
                .PrimaryKey(t => t.RoleId);

            AddColumn("dbo.Admins", "RoleId", c => c.Int());
            CreateIndex("dbo.Admins", "RoleId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.AdminRoles", "RoleId");
            DropColumn("dbo.Admins", "AdminRole");
        }

        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropForeignKey("dbo.Admins", "RoleId", "dbo.AdminRoles");
            DropIndex("dbo.Admins", new[] { "RoleId" });
            DropColumn("dbo.Admins", "RoleId");
            DropTable("dbo.AdminRoles");
        }
    }
}
