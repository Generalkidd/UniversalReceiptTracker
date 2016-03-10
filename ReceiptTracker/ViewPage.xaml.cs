using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ReceiptTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewPage : Page
    {
        Receipt temp;

        public ViewPage()
        {
            this.InitializeComponent();
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested +=
    App_BackRequested;
        }

        private void App_BackRequested(object sender,
    Windows.UI.Core.BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;

            // Navigate back if possible, and if the event has not 
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            temp = e.Parameter as Receipt;
            List<string> temp2 = new List<string>();
            temp2 = temp.details;

            receiptPic.Source = temp.image;

            d1.Text = d1.Text + " " + temp.name;
            d2.Text = d2.Text + " " + temp2[0];
            d3.Text = d3.Text + " " + temp2[1];
            d4.Text = d4.Text + " " + temp2[2];
            d5.Text = d5.Text + " " + temp2[3];
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            d1.Text = "Name: ";
            d2.Text = "Date: ";
            d3.Text = "Time: ";
            d4.Text = "Total: ";
            d5.Text = "Notes: ";

            this.Frame.Navigate(typeof(MainPage_Mobile));
        }
    }
}
