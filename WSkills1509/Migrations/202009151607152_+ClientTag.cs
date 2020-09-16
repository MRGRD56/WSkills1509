namespace WSkills1509.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Client_Id = c.Int(),
                        Tag_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.Client_Id)
                .ForeignKey("dbo.Tag", t => t.Tag_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Tag_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientTags", "Tag_Id", "dbo.Tag");
            DropForeignKey("dbo.ClientTags", "Client_Id", "dbo.Client");
            DropIndex("dbo.ClientTags", new[] { "Tag_Id" });
            DropIndex("dbo.ClientTags", new[] { "Client_Id" });
            DropTable("dbo.ClientTags");
        }
    }
}
