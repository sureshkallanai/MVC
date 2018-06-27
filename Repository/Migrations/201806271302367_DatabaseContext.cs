namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventsNames",
                c => new
                    {
                        Eid = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                    })
                .PrimaryKey(t => t.Eid);
            
            CreateTable(
                "dbo.EventDatas",
                c => new
                    {
                        EventDataid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        District = c.String(),
                        City = c.String(),
                        Eid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventDataid)
                .ForeignKey("dbo.EventsNames", t => t.Eid, cascadeDelete: true)
                .Index(t => t.Eid);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Rid = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Rid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Uid = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Rid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Uid)
                .ForeignKey("dbo.Roles", t => t.Rid, cascadeDelete: true)
                .Index(t => t.Rid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Rid", "dbo.Roles");
            DropForeignKey("dbo.EventDatas", "Eid", "dbo.EventsNames");
            DropIndex("dbo.Users", new[] { "Rid" });
            DropIndex("dbo.EventDatas", new[] { "Eid" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.EventDatas");
            DropTable("dbo.EventsNames");
        }
    }
}
