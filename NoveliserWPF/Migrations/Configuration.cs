using System.Threading;

namespace NoveliserWPF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.IO;

    internal sealed class Configuration : DbMigrationsConfiguration<NoveliserWPF.ApplicationDbContext>
    {
        public Configuration()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Empty));
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NoveliserWPF.ApplicationDbContext context)
        {
            //var proj = new NovelProject();
            //proj.ProjectName = "Cold Reboot";
            //var fold = new Folder();
            //var subfold = new Folder();
            //fold.folderName = "Characters";
            //subfold = new Folder();
            //subfold.folderName = "Good";
            //fold.SubFolders.Add(subfold);
            //subfold = new Folder();
            //subfold.folderName = "Bad";
            //fold.SubFolders.Add(subfold);
            //subfold = new Folder();
            //subfold.folderName = "Neutral";
            //fold.SubFolders.Add(subfold);
            //proj.Folders.Add(fold);
            //fold = new Folder();
            //fold.folderName = "Locations";
            //proj.Folders.Add(fold);
            //fold = new Folder();
            //fold.folderName = "Plot Line";
            //subfold = new Folder();
            //subfold.folderName = "Events";
            //fold.SubFolders.Add(subfold);
            //proj.Folders.Add(fold);
            //context.NovelProjects.Add(proj);

            //proj = new NovelProject();
            //proj.ProjectName = "Shadow of a Hero";
            //fold = new Folder();
            //subfold = new Folder();
            //fold.folderName = "Characters";
            //subfold = new Folder();
            //subfold.folderName = "Good";
            //fold.SubFolders.Add(subfold);
            //subfold = new Folder();
            //subfold.folderName = "Bad";
            //fold.SubFolders.Add(subfold);
            //subfold = new Folder();
            //subfold.folderName = "Neutral";
            //fold.SubFolders.Add(subfold);
            //proj.Folders.Add(fold);
            //fold = new Folder();
            //fold.folderName = "Locations";
            //proj.Folders.Add(fold);
            //fold = new Folder();
            //fold.folderName = "Plot Line";
            //subfold = new Folder();
            //subfold.folderName = "Events";
            //fold.SubFolders.Add(subfold);
            //proj.Folders.Add(fold);
            //proj = new NovelProject();
            //context.NovelProjects.Add(proj);

            //proj = new NovelProject();
            //proj.ProjectName = "Rift Incursion";
            //fold = new Folder();
            //subfold = new Folder();
            //fold.folderName = "Characters";
            //subfold = new Folder();
            //subfold.folderName = "Good";
            //fold.SubFolders.Add(subfold);
            //subfold = new Folder();
            //subfold.folderName = "Bad";
            //fold.SubFolders.Add(subfold);
            //subfold = new Folder();
            //subfold.folderName = "Neutral";
            //fold.SubFolders.Add(subfold);
            //proj.Folders.Add(fold);
            //fold = new Folder();
            //fold.folderName = "Locations";
            //proj.Folders.Add(fold);
            //fold = new Folder();
            //fold.folderName = "Plot Line";
            //subfold = new Folder();
            //subfold.folderName = "Events";
            //fold.SubFolders.Add(subfold);
            //proj.Folders.Add(fold);
            //proj = new NovelProject();
            //context.NovelProjects.Add(proj);


            //using (var context = new ApplicationDbContext())
            //{
            //    var folder = new Folder()
            //    {

            //    }
            //    var proj = new NovelProject()
            //    {

            //    }
            //} 


            //context.NovelProjects.AddOrUpdate(
            //        p => p.ProjectName,
            //        new NovelProject
            //        {
            //            ProjectName = "Cold Reboot",
            //        }
            //    );
            //context.Folders.AddOrUpdate(
            //    f=>f.folderName = 
            //    );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
