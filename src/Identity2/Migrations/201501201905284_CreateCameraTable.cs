namespace Identity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCameraTable : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.Cameras",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CameraName = c.String(nullable: false, maxLength: 50),
                    CameraGroup = c.Int(nullable: false),
                    CameraUrl = c.String(nullable: false)
                }).PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Cameras");
        }         
    }
}
