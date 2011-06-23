using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Autofac;
using Autofac.Core;
using TwitterFriendsSearcher.Twitter;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<MainWindowViewModel>();
            containerBuilder.RegisterType<TwitterFriendsService>().As<ITwitterWrapper>();
            IContainer container = containerBuilder.Build();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.DataContext = container.Resolve<MainWindowViewModel>();
            mainWindow.Show();

        }
    }
}
