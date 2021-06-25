﻿namespace DataAccsess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class WriterAddStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "Status", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Writers", "Status");
        }
    }
}
