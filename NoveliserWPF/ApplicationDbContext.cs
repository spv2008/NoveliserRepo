namespace NoveliserWPF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationDbContext : DbContext
    {
        // Your context has been configured to use a 'ApplicationDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'NoveliserWPF.ApplicationDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ApplicationDbContext' 
        // connection string in the application configuration file.
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual IDbSet<NovelProject> NovelProjects { get; set; }
        public virtual IDbSet<Folder> Folders { get; set; }
        public virtual IDbSet<FolderFile> FolderFiles { get; set; }
        public virtual IDbSet<FileImage> FileImages { get; set; }
        public virtual IDbSet<FileText> FileTexts { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class NovelProject
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<Folder> Folders { get; set; }
    }



    public class Folder
    {
        [Key]
        public int Id { get; set; }
        public string folderName { get; set; }
        public string iconType { get; set; }

        public virtual ICollection<Folder> parentFolder { get; set; }
        public virtual ICollection<FolderFile> Files { get; set; }
    }


    #region Files

    public class FolderFile
    {
        [Key]
        public int Id { get; set; }

        public string fileName { get; set; }


    }

    public class FileText : FolderFile
    {
        public string content { get; set; }
    }

    public class FileImage : FolderFile
    {
        public string path { get; set; }
    }

    #endregion


    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}