﻿#pragma checksum "..\..\..\Frames\Table.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9FEA2999A3E24FFB59B7E3B1BC9DC6983DCCE8B2CF91FC92E6A6C8278029F40C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ContentManagementSystem.Frames;
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


namespace ContentManagementSystem.Frames {
    
    
    /// <summary>
    /// Table
    /// </summary>
    public partial class Table : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 27 "..\..\..\Frames\Table.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dugmeOdjava;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Frames\Table.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label naslov;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Frames\Table.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridSveMaticnePloce;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Frames\Table.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn izborZaBrisanje;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Frames\Table.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridHyperlinkColumn model;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Frames\Table.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel adminPanel;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Frames\Table.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dugmeBrisanje;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Frames\Table.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dugmeDodavanje;
        
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
            System.Uri resourceLocater = new System.Uri("/ContentManagementSystem;component/frames/table.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Frames\Table.xaml"
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
            this.dugmeOdjava = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Frames\Table.xaml"
            this.dugmeOdjava.Click += new System.Windows.RoutedEventHandler(this.LogoutBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.naslov = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.dataGridSveMaticnePloce = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.izborZaBrisanje = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 5:
            this.model = ((System.Windows.Controls.DataGridHyperlinkColumn)(target));
            return;
            case 7:
            this.adminPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.dugmeBrisanje = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Frames\Table.xaml"
            this.dugmeBrisanje.Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dugmeDodavanje = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\Frames\Table.xaml"
            this.dugmeDodavanje.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 6:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Documents.Hyperlink.ClickEvent;
            
            #line 62 "..\..\..\Frames\Table.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.OnHyperlink_Click);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

