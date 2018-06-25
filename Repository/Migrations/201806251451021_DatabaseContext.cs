namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseContext : DbMigration
    {
        public override void Up()
        {
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
                        Role_Rid = c.Int(),
                    })
                .PrimaryKey(t => t.Uid)
                .ForeignKey("dbo.Roles", t => t.Role_Rid)
                .Index(t => t.Role_Rid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Rid", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_Rid" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
