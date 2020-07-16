namespace ShooesStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Shoes",
                c => new
                {
                    ShoesId = c.Int(nullable: false, identity: true),
                    NameShoes = c.String(nullable: false),
                    Discription = c.String(nullable: false),
                    Manufacturer = c.String(nullable: false),
                    ShoesType = c.String(nullable: false),
                    Price = c.Int(nullable: false),
                    ImgPath = c.String(),
                })
                .PrimaryKey(t => t.ShoesId);

            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropTable("dbo.Users");
            DropTable("dbo.Shoes");
            DropTable("dbo.Roles");
        }
    }
}
