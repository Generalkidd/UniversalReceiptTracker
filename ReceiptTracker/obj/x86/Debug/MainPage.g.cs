﻿#pragma checksum "C:\Users\Plasm\Documents\Visual Studio 2015\Projects\ReceiptTracker\ReceiptTracker\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DD5B8CCADD2D40AB6CB687CFFC495C4E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReceiptTracker
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.receiptsList = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 11 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.receiptsList).SelectionChanged += this.receiptsList_SelectionChanged;
                    #line default
                }
                break;
            case 2:
                {
                    this.quickAddBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 14 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.quickAddBtn).Click += this.quickAddBtn_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.addBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 15 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.addBtn).Click += this.addBtn_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.editBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 16 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.editBtn).Click += this.editBtn_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.deleteBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 17 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.deleteBtn).Click += this.deleteBtn_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.receiptPic = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 7:
                {
                    this.capturePreview = (global::Windows.UI.Xaml.Controls.CaptureElement)(target);
                }
                break;
            case 8:
                {
                    this.captureBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 20 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.captureBtn).Click += this.captureBtn_Click;
                    #line default
                }
                break;
            case 9:
                {
                    this.rName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10:
                {
                    this.d1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.rDate = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 12:
                {
                    this.d2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.rTime = (global::Windows.UI.Xaml.Controls.TimePicker)(target);
                }
                break;
            case 14:
                {
                    this.d3 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15:
                {
                    this.rTotal = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16:
                {
                    this.d4 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17:
                {
                    this.d5 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18:
                {
                    this.rNotes = (global::Windows.UI.Xaml.Controls.RichEditBox)(target);
                }
                break;
            case 19:
                {
                    this.saveBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 31 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.saveBtn).Click += this.saveBtn_Click;
                    #line default
                }
                break;
            case 20:
                {
                    this.cancelBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 32 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.cancelBtn).Click += this.cancelBtn_Click;
                    #line default
                }
                break;
            case 21:
                {
                    this.closeBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 33 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.closeBtn).Click += this.closeBtn_Click;
                    #line default
                }
                break;
            case 22:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

