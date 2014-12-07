using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for TextControl.xaml
    /// </summary>
    public partial class TextControl : UserControl
    {
        int TextId;

        public TextControl(int id)
        {
            TextId = id;
            InitializeComponent();
        }

        private void TextControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer(60);
            timer.Elapsed += TimerOnElapsed;
            MainWindow main = (MainWindow)Application.Current.MainWindow;

        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            SaveData();
        }

        private void SaveData()
        {
            //TODO: Add code to save to database in text control.
        }

        private void LoadData()
        {
            if (TextId == -1)
            {
                return;
            }
            //TODO: Add code to load from database in text control.
        }
    }
}
