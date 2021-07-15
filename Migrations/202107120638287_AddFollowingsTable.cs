namespace BS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "CourseID", "dbo.Courses");
            DropIndex("dbo.Attendances", new[] { "CourseID" });
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
            AddColumn("dbo.Attendances", "Course_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Attendances", "Course_Id");
            AddForeignKey("dbo.Attendances", "Course_Id", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropIndex("dbo.Attendances", new[] { "Course_Id" });
            DropColumn("dbo.Attendances", "Course_Id");
            DropTable("dbo.Followings");
            CreateIndex("dbo.Attendances", "CourseID");
            AddForeignKey("dbo.Attendances", "CourseID", "dbo.Courses", "Id");
        }
    }
}
