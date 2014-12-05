﻿using System;
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
using System.Windows.Shapes;

namespace NoveliserWPF.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateProject.xaml
    /// </summary>
    public partial class CreateProject : Window
    {
        public CreateProject()
        {
            InitializeComponent();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
