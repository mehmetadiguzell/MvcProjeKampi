﻿namespace DataAccsess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class MessageEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                {
                    MessageId = c.Int(nullable: false, identity: true),
                    Subject = c.String(maxLength: 100),
                    SenderMail = c.String(maxLength: 50),
                    ReceiverMail = c.String(maxLength: 50),
                    MessageContent = c.String(),
                    MessageDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.MessageId);

        }

        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
