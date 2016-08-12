namespace Car_Sale_Web_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        PostCar_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.PostCars", t => t.PostCar_Id)
                .Index(t => t.PostCar_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "PostCar_Id", "dbo.PostCars");
            DropIndex("dbo.Files", new[] { "PostCar_Id" });
            DropTable("dbo.Files");
        }
    }
}
