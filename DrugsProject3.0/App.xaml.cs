﻿using DrugsProject3._0.Navigation;
using DrugsProject3._0.Tools;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DrugsProject3._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
      public NavigationClass navigation = new NavigationClass();

        public ControlManage controlManage = new ControlManage();

    }
}
