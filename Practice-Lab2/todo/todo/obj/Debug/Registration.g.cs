﻿#pragma checksum "..\..\Registration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "08202FFE3BE4321E62118EE1F7174FF9EE0CB3FD94DC616E7ADF705858348D0B"
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
using todo;


namespace todo {
    
    
    /// <summary>
    /// Registration
    /// </summary>
    public partial class Registration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTB;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailTB;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordTB;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox againPasswordTB;
        
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
            System.Uri resourceLocater = new System.Uri("/todo;component/registration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Registration.xaml"
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
            this.nameTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\Registration.xaml"
            this.nameTB.GotFocus += new System.Windows.RoutedEventHandler(this.RemoveText);
            
            #line default
            #line hidden
            
            #line 13 "..\..\Registration.xaml"
            this.nameTB.LostFocus += new System.Windows.RoutedEventHandler(this.AddText);
            
            #line default
            #line hidden
            
            #line 13 "..\..\Registration.xaml"
            this.nameTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.nameTB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.emailTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\Registration.xaml"
            this.emailTB.GotFocus += new System.Windows.RoutedEventHandler(this.RemoveText);
            
            #line default
            #line hidden
            
            #line 19 "..\..\Registration.xaml"
            this.emailTB.LostFocus += new System.Windows.RoutedEventHandler(this.AddText);
            
            #line default
            #line hidden
            return;
            case 3:
            this.passwordTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\Registration.xaml"
            this.passwordTB.GotFocus += new System.Windows.RoutedEventHandler(this.RemoveText);
            
            #line default
            #line hidden
            
            #line 25 "..\..\Registration.xaml"
            this.passwordTB.LostFocus += new System.Windows.RoutedEventHandler(this.AddText);
            
            #line default
            #line hidden
            return;
            case 4:
            this.againPasswordTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\Registration.xaml"
            this.againPasswordTB.GotFocus += new System.Windows.RoutedEventHandler(this.RemoveText);
            
            #line default
            #line hidden
            
            #line 31 "..\..\Registration.xaml"
            this.againPasswordTB.LostFocus += new System.Windows.RoutedEventHandler(this.AddText);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 39 "..\..\Registration.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 46 "..\..\Registration.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

