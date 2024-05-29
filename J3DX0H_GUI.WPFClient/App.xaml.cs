using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace J3DX0H_GUI.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<IBandsViaWindowService, BandsViaWindow>()
                    .AddSingleton<IMerchViaWindowService, MerchViaWindow>()
                    .AddSingleton<IRCViaWindowService, RCViaWindow>()
                    .BuildServiceProvider()

                );
        }


    }
}
