﻿#pragma checksum "..\..\..\Frames\UpdateMb.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6908DF76F6BB6753DCC0C08F530D590E4BBA6622BD5048EC446A8721A1A961FE"
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
    /// UpdateMb
    /// </summary>
    public partial class UpdateMb : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\Frames\UpdateMb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock datum;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Frames\UpdateMb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image slika;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Frames\UpdateMb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dodajSliku;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Frames\UpdateMb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox unosRTB;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Frames\UpdateMb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dugmeNazad;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Frames\UpdateMb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dugmeKraj;
        
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
            System.Uri resourceLocater = new System.Uri("/ContentManagementSystem;component/frames/updatemb.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Frames\UpdateMb.xaml"
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
            this.datum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.slika = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.dodajSliku = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\Frames\UpdateMb.xaml"
            this.dodajSliku.Click += new System.Windows.RoutedEventHandler(this.addImageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.unosRTB = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 5:
            this.dugmeNazad = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\Frames\UpdateMb.xaml"
            this.dugmeNazad.Click += new System.Windows.RoutedEventHandler(this.ReturnBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dugmeKraj = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\Frames\UpdateMb.xaml"
            this.dugmeKraj.Click += new System.Windows.RoutedEventHandler(this.ConfirmBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

