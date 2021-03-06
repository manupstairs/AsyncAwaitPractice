﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppWithException
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AsyncExceptionTester ExceptionTester = new AsyncExceptionTester();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCannotCatch_Click(object sender, RoutedEventArgs e)
        {
            ExceptionTester.SomethingWrongCannotCatch();
        }

        private void ButtonNothing_Click(object sender, RoutedEventArgs e)
        {
            ExceptionTester.TaskWrongWithNothing();
        }

        private void ButtonCatch_Click(object sender, RoutedEventArgs e)
        {
            ExceptionTester.TaskWrongButCatchAsync();
        }

        private void ButtonLambdaAsyncVoid_Click(object sender, RoutedEventArgs e)
        {
            ExceptionTester.LambdaAsyncVoidMethodAsync();
        }

        private void ButtonLambdaAsyncTask_Click(object sender, RoutedEventArgs e)
        {
            ExceptionTester.LambdaAsyncTaskMethodAsync();
        }
    }
}
