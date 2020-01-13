﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppWithException
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += (sender, e) =>
              {
                  Debug.WriteLine(e);
              };

            //TaskScheduler.UnobservedTaskException += (sender, e) =>
            // {
            //     Debug.WriteLine(e);
            // };
        }
    }
}
