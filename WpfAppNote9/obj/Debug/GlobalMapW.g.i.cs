#pragma checksum "..\..\GlobalMapW.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C37553FD2BE0D31AB057528929DF4A8D5F3BA96"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Maps.MapControl.WPF;
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
using WpfAppNote9;


namespace WpfAppNote9 {
    
    
    /// <summary>
    /// GlobalMapW
    /// </summary>
    public partial class GlobalMapW : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\GlobalMapW.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Map MMap;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\GlobalMapW.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BBack;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfAppNote9;component/globalmapw.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GlobalMapW.xaml"
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
            
            #line 9 "..\..\GlobalMapW.xaml"
            ((WpfAppNote9.GlobalMapW)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MMap = ((Microsoft.Maps.MapControl.WPF.Map)(target));
            
            #line 22 "..\..\GlobalMapW.xaml"
            this.MMap.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Map_MouseRightButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BBack = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\GlobalMapW.xaml"
            this.BBack.Click += new System.Windows.RoutedEventHandler(this.BBack_Click);
            
            #line default
            #line hidden
            
            #line 71 "..\..\GlobalMapW.xaml"
            this.BBack.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.BBack_MouseRightButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

