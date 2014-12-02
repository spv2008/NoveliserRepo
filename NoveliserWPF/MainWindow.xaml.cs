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

namespace NoveliserWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand TabCloseCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();
            //CommandBinding cb = new CommandBinding(TabCloseCommand, TabCloseCommand_Executed, TabCloseCommand_CanExecute);
            //this.CommandBindings.Add(cb);
            //KeyGesture kg = new KeyGesture(Key.W, ModifierKeys.Control);
            //InputBinding ib = new InputBinding(TabCloseCommand, kg);
            //this.InputBindings.Add(ib);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //TODO: Remove initial setup of test tab when finished.
            TabItem ti = new TabItem();
            ti.Name = "TestName";
            ti.Header = "TestHeader";
            Frame fr = new Frame();
            TextControl textControl = new TextControl();
            fr.Margin = new Thickness(0, 0, 0, 0);
            textControl.Margin = new Thickness(0, 0, 0, 0);
            fr.Content = textControl;
            ti.Content = fr;
            MainTabs.Items.Add(ti);
            //TODO: Add start page setup.
            //Use user control to create start page and allow it to be instanced.
            //Start Page can be accessed from View.
        }

        private void TabCloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void TabCloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string UID = (string)e.Parameter;
            TabItem ti = (TabItem)e.Source;

            MainTabs.Items.Remove(ti);

            //MessageBox.Show("Tab Item Header = " + ti.Header.ToString() + ", Tab Page Name = " + ti.Name);
        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MainNavigation_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem tvi = sender as TreeViewItem;
            //TODO: Finish main navigation logic.
        }
    }
}
