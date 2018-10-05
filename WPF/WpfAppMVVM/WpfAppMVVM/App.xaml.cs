using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppMVVM.BindingErrorExceptionClass;
using WpfAppMVVM.ViewModel;
using WpfBindingErrors;

namespace WpfAppMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //PresentationTraceSources.Refresh();
            //PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Error;
            //PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorTraceListener());

            //DispatcherUnhandledException += App_DispatcherUnhandledException;

            //using wpf Binding Error Assembly
            //BindingExceptionThrower.Attach();
        }
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //var bex = e.Exception as BindingErrorException;
            //if (bex != null)
            //{
            //    MessageBox.Show($"Binding error. {bex.SourceObject}.{bex.SourceProperty} => {bex.TargetElement}.{bex.TargetProperty}");
            //}
            MessageBox.Show(e.Exception.Message);
        }
    }
}
