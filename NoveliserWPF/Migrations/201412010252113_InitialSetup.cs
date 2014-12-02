namespace NoveliserWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FolderFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fileName = c.String(),
                        path = c.String(),
                        content = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Folder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Folders", t => t.Folder_Id)
                .Index(t => t.Folder_Id);
            
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        folderName = c.String(),
                        iconType = c.String(),
                        Folder_Id = c.Int(),
                        NovelProject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Folders", t => t.Folder_Id)
                .ForeignKey("dbo.NovelProjects", t => t.NovelProject_Id)
                .Index(t => t.Folder_Id)
                .Index(t => t.NovelProject_Id);
            
            CreateTable(
                "dbo.NovelProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Folders", "NovelProject_Id", "dbo.NovelProjects");
            DropForeignKey("dbo.Folders", "Folder_Id", "dbo.Folders");
            DropForeignKey("dbo.FolderFiles", "Folder_Id", "dbo.Folders");
            DropIndex("dbo.Folders", new[] { "NovelProject_Id" });
            DropIndex("dbo.Folders", new[] { "Folder_Id" });
            DropIndex("dbo.FolderFiles", new[] { "Folder_Id" });
            DropTable("dbo.NovelProjects");
            DropTable("dbo.Folders");
            DropTable("dbo.FolderFiles");
        }
    }
}
