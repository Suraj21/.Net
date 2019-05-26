using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

namespace WpfAppMVVM.View
{
    /// <summary>
    /// Interaction logic for AvalonDock.xaml
    /// </summary>
    public partial class AvalonDock : UserControl
    {
        List<Assembly> themes;
        public bool IsDoclLoaded = false;
        public AvalonDock()
        {
            InitializeComponent();
            themes = new List<Assembly>();
            this.Loaded += AvalonDock_Loaded;
            _themeCombo.SelectionChanged -= _themeCombo_SelectionChanged;
        }

        private void AvalonDock_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsDoclLoaded == false)
            {
                DirectoryInfo di = new DirectoryInfo("../../Themes");

                foreach (FileInfo fi in di.GetFiles())
                {
                    try
                    {
                        themes.Add(Assembly.LoadFile(fi.FullName));
                    }
                    catch (Exception ex)
                    {
                        Trace.Write(ex);
                    }
                }
                IsDoclLoaded = true;
            }
            _themeCombo.SelectionChanged += _themeCombo_SelectionChanged;
        }

        private void _themeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTheme = _themeCombo.SelectedItem.ToString();
            var selectedContent = ((ContentControl)_themeCombo.SelectedItem).Content;

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\SiQuoteSettings");
            var regValue = registryKey.GetValue("SelectedTheme");

            if (registryKey != null)
            {
                registryKey = Registry.CurrentUser.CreateSubKey(@"Software\SiQuoteSettings");
                registryKey.SetValue("SelectedTheme", selectedContent); 
            }

            registryKey.Dispose();
            if(selectedContent.ToString() == "Aero")
            {
                Assembly a = themes.Where(p => p.GetName().Name.Equals("Theme1")).FirstOrDefault();
                NewMethod(a);
            }
            else if(selectedContent.ToString() == "VS2010")
            {
                Assembly a = themes.Where(p => p.GetName().Name.Equals("Theme2")).FirstOrDefault();

                if (a != null)
                {
                    ((App)Application.Current).Resources.MergedDictionaries.Clear();
                    foreach (Type t in a.GetTypes())
                    {
                        Trace.WriteLine(t.FullName);
                        if (t.IsSubclassOf(typeof(ResourceDictionary)))
                        {
                            ConstructorInfo ci = t.GetConstructor(Type.EmptyTypes);
                            ResourceDictionary rd = (ResourceDictionary)ci.Invoke(new object[] { });
                            ((App)Application.Current).Resources.MergedDictionaries.Add(rd);
                        }
                    }

                }
            }
        }

        private static void NewMethod(Assembly a)
        {
            if (a != null)
            {
                ((App)Application.Current).Resources.MergedDictionaries.Clear();
                foreach (Type t in a.GetTypes())
                {
                    Trace.WriteLine(t.FullName);
                    if (t.IsSubclassOf(typeof(ResourceDictionary)))
                    {
                        ConstructorInfo ci = t.GetConstructor(Type.EmptyTypes);
                        ResourceDictionary rd = (ResourceDictionary)ci.Invoke(new object[] { });
                        ((App)Application.Current).Resources.MergedDictionaries.Add(rd);
                    }
                }

            }
        }

        private void _themeCombo_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void _themeCombo_DropDownClosed(object sender, EventArgs e)
        {

        }


        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //DirectoryInfo di = new DirectoryInfo("../../MyThemes");
        //    //foreach (FileInfo fi in di.GetFiles())
        //    //{
        //    //    try
        //    //    {
        //    //        themes.Add(Assembly.LoadFile(fi.FullName));
        //    //    }
        //    //    catch { }
        //    //}
        //    //cbThemes.ItemsSource = themes.Select(p => p.GetName().Name).ToList();
        //}
    }
}
