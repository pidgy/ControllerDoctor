﻿#pragma checksum "C:\Users\trash\Documents\dev\ControllerDoctorUWP\ControllerDoctorUWP\HomePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D7EF7751925D27A220242E0EED541B55"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControllerDoctorUWP
{
    partial class HomePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // HomePage.xaml line 11
                {
                    this.HomePageGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // HomePage.xaml line 19
                {
                    this.HomePageSettingsGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4: // HomePage.xaml line 21
                {
                    this.Default_Controller_TextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // HomePage.xaml line 24
                {
                    this.Controller_Vendor_TextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // HomePage.xaml line 27
                {
                    this.Controller_Product_TextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // HomePage.xaml line 30
                {
                    this.Controller_Battery_TextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // HomePage.xaml line 33
                {
                    this.Controller_Connected_TextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // HomePage.xaml line 35
                {
                    this.Refresh_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Refresh_Button).Click += this.Refresh_Button_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

