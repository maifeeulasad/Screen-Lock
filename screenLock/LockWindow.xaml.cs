﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace screenLock
{
    /// <summary>
    /// Interaction logic for LockWindow.xaml
    /// </summary>
    public partial class LockWindow : Window
    {
        public LockWindow()
        {
            InitializeComponent();
            Task.Factory.StartNew(() =>
            {
                InvokeMethodExample();
            });
        }

        private void InvokeMethodExample()
        {
            Thread.Sleep(3000);
            Dispatcher.Invoke(() =>
            {
                Background = Brushes.Aqua;
            });
            
        }

        private void unlockButton_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "1234" || (DateTime.Now-Util.lockingTime).Seconds<=3)
            {
                MainWindow standbyWindow = new MainWindow();
                standbyWindow.Show();
                Close();
                

            }
            else
            {
                SystemSounds.Beep.Play();
                lockWindow.Background = Brushes.Red;


            }

        }

    }
}
