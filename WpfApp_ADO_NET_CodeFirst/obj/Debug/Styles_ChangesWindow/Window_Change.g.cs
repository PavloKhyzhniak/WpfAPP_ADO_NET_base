﻿#pragma checksum "..\..\..\Styles_ChangesWindow\Window_Change.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1CDFA1222C95094F9815FB33D2B5774F5CFB425841C63DE848C940D86A8C5402"
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
using WpfApp_ADO_NET_CodeFirst;


namespace WpfApp_ADO_NET_CodeFirst {
    
    
    /// <summary>
    /// Window_Change
    /// </summary>
    public partial class Window_Change : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Styles_ChangesWindow\Window_Change.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonOK;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Styles_ChangesWindow\Window_Change.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonADD;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Styles_ChangesWindow\Window_Change.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCancel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Styles_ChangesWindow\Window_Change.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl mainGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp_ADO_NET_CodeFirst;component/styles_changeswindow/window_change.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Styles_ChangesWindow\Window_Change.xaml"
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
            
            #line 8 "..\..\..\Styles_ChangesWindow\Window_Change.xaml"
            ((WpfApp_ADO_NET_CodeFirst.Window_Change)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonOK = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Styles_ChangesWindow\Window_Change.xaml"
            this.buttonOK.Click += new System.Windows.RoutedEventHandler(this.buttonUPDATE_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonADD = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Styles_ChangesWindow\Window_Change.xaml"
            this.buttonADD.Click += new System.Windows.RoutedEventHandler(this.buttonINSERT_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Styles_ChangesWindow\Window_Change.xaml"
            this.buttonCancel.Click += new System.Windows.RoutedEventHandler(this.buttonCANCEL_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mainGrid = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

