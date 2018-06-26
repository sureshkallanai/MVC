namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseContext1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Role_Rid", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_Rid" });
            RenameColumn(table: "dbo.Users", name: "Role_Rid", newName: "Rid");
            AlterColumn("dbo.Users", "Rid", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "Rid");
            AddForeignKey("dbo.Users", "Rid", "dbo.Roles", "Rid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Rid", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Rid" });
            AlterColumn("dbo.Users", "Rid", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "Rid", newName: "Role_Rid");
            CreateIndex("dbo.Users", "Role_Rid");
            AddForeignKey("dbo.Users", "Role_Rid", "dbo.Roles", "Rid");
        }
    }
}
