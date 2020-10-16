﻿#pragma checksum "..\..\MainWindow_LinqToSQL.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BA5FE837E4C76C6E3EF15821354C11A3CB8D9A88B8C270909F22A0D02EFD7300"
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
using WpfApp_ADO_NET_LinqToSQL;


namespace WpfApp_ADO_NET_LinqToSQL {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\MainWindow_LinqToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel dockPanel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainWindow_LinqToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menuManufacturerAirplane;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindow_LinqToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menuProjectsEmployees;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\MainWindow_LinqToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_main;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MainWindow_LinqToSQL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid_Main;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp_ADO_NET_LinqToSQL;component/mainwindow_linqtosql.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow_LinqToSQL.xaml"
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
            this.dockPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.menuManufacturerAirplane = ((System.Windows.Controls.Menu)(target));
            return;
            case 3:
            
            #line 18 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowManufacturer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 19 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddManufacturer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 20 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteManufacturer_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 24 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowAirplane_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 25 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddAirplane_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 26 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteAirplane_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 30 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_3);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 31 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_4);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 32 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_5);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 36 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 37 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_1);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 38 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_2);
            
            #line default
            #line hidden
            return;
            case 15:
            this.menuProjectsEmployees = ((System.Windows.Controls.Menu)(target));
            return;
            case 16:
            
            #line 44 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowProjects_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 45 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddProjects_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 46 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteProjects_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 50 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowEmployees_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 51 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddEmployees_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 52 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteEmployees_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 56 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_13);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 57 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_14);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 58 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_15);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 62 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click2);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 63 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_11);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 64 "..\..\MainWindow_LinqToSQL.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_12);
            
            #line default
            #line hidden
            return;
            case 28:
            this.grid_main = ((System.Windows.Controls.Grid)(target));
            return;
            case 29:
            this.dataGrid_Main = ((System.Windows.Controls.DataGrid)(target));
            
            #line 69 "..\..\MainWindow_LinqToSQL.xaml"
            this.dataGrid_Main.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGrid_Main_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

