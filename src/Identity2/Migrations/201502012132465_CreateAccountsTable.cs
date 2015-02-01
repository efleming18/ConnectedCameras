namespace Identity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAccountsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.Accounts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Selected = c.Boolean(defaultValue: false)
                }).PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Accounts");
        }  
    }
}
