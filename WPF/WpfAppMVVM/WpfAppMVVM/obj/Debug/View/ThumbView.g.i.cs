﻿#pragma checksum "..\..\..\View\ThumbView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B0AF0C51A8D60889E96E8D4BE1ED20BC4B204858"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfAppMVVM.View;
using WpfAppMVVM.ViewModelLocator;


namespace WpfAppMVVM.View {
    
    
    /// <summary>
    /// ThumbView
    /// </summary>
    public partial class ThumbView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\View\ThumbView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LeftText;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\View\ThumbView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RightText;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\View\ThumbView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridSplitter MyGridSplitter;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfAppMVVM;component/view/thumbview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ThumbView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LeftText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.RightText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.MyGridSplitter = ((System.Windows.Controls.GridSplitter)(target));
            
            #line 29 "..\..\..\View\ThumbView.xaml"
            this.MyGridSplitter.DragStarted += new System.Windows.Controls.Primitives.DragStartedEventHandler(this.MyGridSplitter_DragStarted);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\View\ThumbView.xaml"
            this.MyGridSplitter.DragCompleted += new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.MyGridSplitter_DragCompleted);
            
            #line default
            #line hidden
            
            #line 31 "..\..\..\View\ThumbView.xaml"
            this.MyGridSplitter.DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(this.MyGridSplitter_DragDelta);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
