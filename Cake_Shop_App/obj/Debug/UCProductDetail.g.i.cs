﻿#pragma checksum "..\..\UCProductDetail.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "63B85A2249EB9DFE4BAD5DA3BE60425C10AA539E547E5085AD8234A12AF2130C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Cake_Shop_App;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Cake_Shop_App {
    
    
    /// <summary>
    /// UCProductDetail
    /// </summary>
    public partial class UCProductDetail : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\UCProductDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel WorkScreen;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\UCProductDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl PreviewPhoto;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\UCProductDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Category;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\UCProductDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel editProduct;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\UCProductDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border OrderButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Cake_Shop_App;component/ucproductdetail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UCProductDetail.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 16 "..\..\UCProductDetail.xaml"
            ((Cake_Shop_App.UCProductDetail)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.WorkScreen = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 3:
            this.PreviewPhoto = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 4:
            this.Category = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.editProduct = ((System.Windows.Controls.StackPanel)(target));
            
            #line 91 "..\..\UCProductDetail.xaml"
            this.editProduct.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.editProduct_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.OrderButton = ((System.Windows.Controls.Border)(target));
            
            #line 111 "..\..\UCProductDetail.xaml"
            this.OrderButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OrderButton_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

