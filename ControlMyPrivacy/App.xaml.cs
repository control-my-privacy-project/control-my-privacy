using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace ControlMyPrivacy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        }

        private Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (!args.Name.StartsWith("CefSharp")) return null;

            var assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
            var architectureSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, Environment.Is64BitProcess ? "x64" : "x86", assemblyName);

            return File.Exists(architectureSpecificPath) ? Assembly.LoadFile(architectureSpecificPath) : null;
        }
    }

    
}
