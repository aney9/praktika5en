﻿#pragma checksum "..\..\status.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "81DEC07E6DAAE2E168C3CA73119482E9EC82906A54EB92D4077B2FCBA332F875"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using praktika5;


namespace praktika5 {
    
    
    /// <summary>
    /// status
    /// </summary>
    public partial class status : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\status.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\status.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stat;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\status.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dob;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\status.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button izm;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\status.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uda;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\status.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button vyh;
        
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
            System.Uri resourceLocater = new System.Uri("/praktika5;component/status.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\status.xaml"
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
            this.dg1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 26 "..\..\status.xaml"
            this.dg1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dg1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.stat = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\status.xaml"
            this.stat.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.proverkast);
            
            #line default
            #line hidden
            
            #line 32 "..\..\status.xaml"
            this.stat.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.proverkast1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dob = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\status.xaml"
            this.dob.Click += new System.Windows.RoutedEventHandler(this.dobavl);
            
            #line default
            #line hidden
            return;
            case 4:
            this.izm = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\status.xaml"
            this.izm.Click += new System.Windows.RoutedEventHandler(this.izmen);
            
            #line default
            #line hidden
            return;
            case 5:
            this.uda = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\status.xaml"
            this.uda.Click += new System.Windows.RoutedEventHandler(this.udal);
            
            #line default
            #line hidden
            return;
            case 6:
            this.vyh = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\status.xaml"
            this.vyh.Click += new System.Windows.RoutedEventHandler(this.vyhod);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

