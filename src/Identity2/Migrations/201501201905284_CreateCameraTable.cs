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
                    CameraUrl = c.String(nullable: false),
                    Description = c.String(nullable: true, maxLength: 80)
                }).PrimaryKey(t => t.Id);

            CreateTable("dbo.CameraLock",
                c => new
                {
                    Id = c.Int(nullable:false, identity:true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    CameraId = c.Int(nullable: false),
                    TimeStamp = c.DateTime(nullable: true)
                }).PrimaryKey(k => k.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Cameras");
        }         
    }
}
