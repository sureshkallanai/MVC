namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Rid", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Rid" });
            AddColumn("dbo.Roles", "Users_Uid", c => c.Int());
            CreateIndex("dbo.Roles", "Users_Uid");
            AddForeignKey("dbo.Roles", "Users_Uid", "dbo.Users", "Uid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "Users_Uid", "dbo.Users");
            DropIndex("dbo.Roles", new[] { "Users_Uid" });
            DropColumn("dbo.Roles", "Users_Uid");
            CreateIndex("dbo.Users", "Rid");
            AddForeignKey("dbo.Users", "Rid", "dbo.Roles", "Rid", cascadeDelete: true);
        }
    }
}
