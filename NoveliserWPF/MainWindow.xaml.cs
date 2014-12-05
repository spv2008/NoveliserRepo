using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NoveliserWPF.Dialogs;
using XCToolkit = Xceed.Wpf.Toolkit;

namespace NoveliserWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static readonly RoutedCommand TabCloseCommand = new RoutedCommand();

        public static readonly RoutedEvent NewProjectEvent = EventManager.RegisterRoutedEvent("NewProjectCommand", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(StartPage));

        public event RoutedEventHandler NewProject
        {
            add { AddHandler(NewProjectEvent, value); }
            remove { RemoveHandler(NewProjectEvent, value); }
        }

        public static readonly RoutedEvent OpenProjectEvent = EventManager.RegisterRoutedEvent("OpenProjectCommand", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(StartPage));

        public event RoutedEventHandler OpenProject
        {
            add { AddHandler(NewProjectEvent, value); }
            remove { RemoveHandler(NewProjectEvent, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<NovelProject> entityList = new List<NovelProject>();
            MainNavigation.ItemsSource = entityList;
            //DEBUGLoadData();
            ShowStartPage();
            MainTabs.Items.RemoveAt(0);
        }

        private void DEBUGLoadData()
        {
            using (var context = new ApplicationDbContext())
            {
                var proj = new NovelProject();
                proj.ProjectName = "Cold Reboot";
                var fold = new Folder();
                var subfold = new Folder();
                fold.folderName = "Characters";
                subfold.folderName = "Good";
                fold.SubFolders.Add(subfold);
                subfold = new Folder();
                subfold.folderName = "Bad";
                fold.SubFolders.Add(subfold);
                subfold = new Folder();
                subfold.folderName = "Neutral";
                fold.SubFolders.Add(subfold);
                proj.Folders.Add(fold);
                fold = new Folder();
                fold.folderName = "Locations";
                proj.Folders.Add(fold);
                fold = new Folder();
                fold.folderName = "Plot Line";
                subfold = new Folder();
                subfold.folderName = "Events";
                fold.SubFolders.Add(subfold);
                proj.Folders.Add(fold);
                context.NovelProjects.Add(proj);

                proj = new NovelProject();
                proj.ProjectName = "Shadow of a Hero";
                fold = new Folder();
                subfold = new Folder();
                fold.folderName = "Characters";
                subfold = new Folder();
                subfold.folderName = "Good";
                fold.SubFolders.Add(subfold);
                subfold = new Folder();
                subfold.folderName = "Bad";
                fold.SubFolders.Add(subfold);
                subfold = new Folder();
                subfold.folderName = "Neutral";
                fold.SubFolders.Add(subfold);
                proj.Folders.Add(fold);
                fold = new Folder();
                fold.folderName = "Locations";
                proj.Folders.Add(fold);
                fold = new Folder();
                fold.folderName = "Plot Line";
                subfold = new Folder();
                subfold.folderName = "Events";
                fold.SubFolders.Add(subfold);
                proj.Folders.Add(fold);
                proj = new NovelProject();
                context.NovelProjects.Add(proj);

                proj = new NovelProject();
                proj.ProjectName = "Rift Incursion";
                fold = new Folder();
                subfold = new Folder();
                fold.folderName = "Characters";
                subfold = new Folder();
                subfold.folderName = "Good";
                fold.SubFolders.Add(subfold);
                subfold = new Folder();
                subfold.folderName = "Bad";
                fold.SubFolders.Add(subfold);
                subfold = new Folder();
                subfold.folderName = "Neutral";
                fold.SubFolders.Add(subfold);
                proj.Folders.Add(fold);
                fold = new Folder();
                fold.folderName = "Locations";
                proj.Folders.Add(fold);
                fold = new Folder();
                fold.folderName = "Plot Line";
                subfold = new Folder();
                subfold.folderName = "Events";
                fold.SubFolders.Add(subfold);
                proj.Folders.Add(fold);
                proj = new NovelProject();
                context.NovelProjects.Add(proj);
            }
        }
        #region Routed Commands

        private void TabCloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void TabCloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TabItem ti = (TabItem)e.Source;

            if (MainTabs.Items.Count == 1)
            {
                ShowStartPage();
                MainTabs.Items.Remove(ti);
            }
            else
            {
                MainTabs.Items.Remove(ti);
            }
        }

        #endregion

        #region Main Event Handler Methods

        private void ShowStartPage()
        {
            TabItem ti = new TabItem();
            ContextMenu cm = new ContextMenu();
            ti.Name = "startPageTab";
            ti.Header = "Start Page";
            Frame fr = new Frame();
            StartPage startPage = new StartPage();
            fr.Margin = new Thickness(0, 0, 0, 0);
            fr.Padding = new Thickness(35, 35, 35, 35);
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#454854");
            if (brush != null)
            {
                brush.Freeze();
                fr.Background = brush;
            }
            startPage.Margin = new Thickness(0, 0, 0, 0);
            fr.Content = startPage;
            ti.Content = fr;
            MainTabs.Items.Add(ti);
        }

        private MenuItem CreateMenuItem(string name, string header, RoutedEventHandler eventHandler)
        {
            MenuItem mi = new MenuItem();
            mi.Click += eventHandler;
            mi.Name = name;
            mi.Header = header;
            return mi;
        }

        private enum FileType
        {
            File,
            Folder,
            Project
        };

        private TreeViewItem CreateTreeViewItem(string name, string header, FileType type)
        {
            TreeViewItem tvi = new TreeViewItem();
            tvi.Name = name;
            tvi.Header = header;

            ContextMenu cm = new ContextMenu();
            switch (type)
            {
                case FileType.File:
                    cm.Items.Add(CreateMenuItem("openFile", "Open File", OpenFile));
                    cm.Items.Add(CreateMenuItem("deleteFile", "Delete File", DeleteFile));
                    cm.Items.Add(new Separator());
                    cm.Items.Add(CreateMenuItem("fileProperties", "Properties", FileProperties));
                    tvi.ContextMenu = cm;
                    tvi.MouseDoubleClick += OpenFile;
                    break;
                case FileType.Folder:
                    cm.Items.Add(CreateMenuItem("newFile", "Create File", NewFile));
                    cm.Items.Add(CreateMenuItem("openFolder", "Open Folder", OpenFolder));
                    cm.Items.Add(CreateMenuItem("deleteFolder", "Delete Folder", DeleteFolder));
                    tvi.ContextMenu = cm;
                    tvi.MouseDoubleClick += OpenFolder;
                    break;
                case FileType.Project:
                    cm.Items.Add(CreateMenuItem("newFolder", "Create Folder", NewFolder));
                    cm.Items.Add(CreateMenuItem("newFile", "Create File", NewFile));
                    cm.Items.Add(new Separator());
                    cm.Items.Add(CreateMenuItem("deleteProject", "DeleteProject", DeleteProject));
                    tvi.ContextMenu = cm;
                    tvi.MouseDoubleClick += OpenProjectTree;
                    break;
            }
            return tvi;
        }

        private void CreateProject()
        {
            CreateProject projDialog = new CreateProject();
            if (projDialog.ShowDialog() == true)
            {
                //TODO: Finish Create Project Dialog
            }
            return;
        }

        #endregion

        #region Routed Events - Calling other events

        private void NewProjectCommand(object sender, RoutedEventArgs e)
        {
            //TODO: Call New Project
        }

        private void OpenProjectCommand(object sender, RoutedEventArgs e)
        {
            //TODO: Call Open Project
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            ShowStartPage();
        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            //TODO: Finish Open File
        }

        private void OpenFolder(object sender, RoutedEventArgs e)
        {
            //TODO: Finish Open Folder
        }

        private void OpenProjectTree(object sender, RoutedEventArgs e)
        {
            //TODO: Finish Open Project Tree
        }

        private void NewFolder(object sender, RoutedEventArgs e)
        {
            //TODO: Finish New Folder
        }

        private void NewFile(object sender, RoutedEventArgs e)
        {
            //TODO: Finish New File
        }

        private void DeleteProject(object sender, RoutedEventArgs e)
        {
            //TODO: Finish Delete Project Option
        }

        private void DeleteFile(object sender, RoutedEventArgs e)
        {
            //TODO: Finish Delete File Option
        }

        private void DeleteFolder(object sender, RoutedEventArgs e)
        {
            //TODO: Finish Delete Folder Action
        }

        private void FileProperties(object sender, RoutedEventArgs e)
        {
            //TODO: Finish File Properties
        }

        private void SearchBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            SearchMenuItem.IsSubmenuOpen = false;
        }

        #endregion

    }
}
