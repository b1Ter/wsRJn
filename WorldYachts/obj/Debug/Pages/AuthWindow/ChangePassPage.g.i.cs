﻿#pragma checksum "..\..\..\..\Pages\AuthWindow\ChangePassPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "44E650BD54FDC6D2A5F3BF269A324779FEA4D98EE6C79EC16BC505D163DF8673"
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
using WorldYachts.Pages.AuthWindow;


namespace WorldYachts.Pages.AuthWindow {
    
    
    /// <summary>
    /// ChangePassPage
    /// </summary>
    public partial class ChangePassPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\Pages\AuthWindow\ChangePassPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassNow;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Pages\AuthWindow\ChangePassPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassNew;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Pages\AuthWindow\ChangePassPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtRepeatedPass;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Pages\AuthWindow\ChangePassPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtWarning;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Pages\AuthWindow\ChangePassPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEnter;
        
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
            System.Uri resourceLocater = new System.Uri("/WorldYachts;component/pages/authwindow/changepasspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AuthWindow\ChangePassPage.xaml"
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
            this.txtPassNow = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 2:
            this.txtPassNew = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.txtRepeatedPass = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.txtWarning = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.btnEnter = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\..\Pages\AuthWindow\ChangePassPage.xaml"
            this.btnEnter.Click += new System.Windows.RoutedEventHandler(this.btnEnter_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

