namespace WSkills1509.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gender = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 255, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 255, unicode: false),
                        Patronymic = c.String(maxLength: 255, unicode: false),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        PhoneNumber = c.String(maxLength: 255, unicode: false),
                        Email = c.String(maxLength: 255, unicode: false),
                        AdditionDate = c.DateTime(storeType: "date"),
                        LastVisitDate = c.DateTime(storeType: "date"),
                        VisitsCount = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tag");
            DropTable("dbo.Client");
        }
    }
}
