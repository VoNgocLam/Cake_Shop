﻿#pragma checksum "..\..\UCNewProduct.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C7E56947E1109FFA243BE9BE251DE22E042A666A4FFB470C68D2F45C8B236100"
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
    /// UCNewProduct
    /// </summary>
    public partial class UCNewProduct : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel WorkScreen;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgSave;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgCancel;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrice;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTitle;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCategory;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCategory;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDescription;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvlistImages;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\UCNewProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ListImagesButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Cake_Shop_App;component/ucnewproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UCNewProduct.xaml"
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
            
            #line 16 "..\..\UCNewProduct.xaml"
            ((Cake_Shop_App.UCNewProduct)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.WorkScreen = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 3:
            this.imgSave = ((System.Windows.Controls.Image)(target));
            
            #line 22 "..\..\UCNewProduct.xaml"
            this.imgSave.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.imgSave_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.imgCancel = ((System.Windows.Controls.Image)(target));
            
            #line 23 "..\..\UCNewProduct.xaml"
            this.imgCancel.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.imgCancel_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tbCategory = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.cbCategory = ((System.Windows.Controls.ComboBox)(target));
            
            #line 55 "..\..\UCNewProduct.xaml"
            this.cbCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbCategory_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.tbDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.lvlistImages = ((System.Windows.Controls.ListView)(target));
            return;
            case 12:
            this.ListImagesButton = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\UCNewProduct.xaml"
            this.ListImagesButton.Click += new System.Windows.RoutedEventHandler(this.ListImagesButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

