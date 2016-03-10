using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ReceiptTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPage : Page
    {
        BitmapImage bmpImage;
        List<Receipt> receipts = new List<Receipt>();

        public AddPage()
        {
            this.InitializeComponent();
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested +=
    App_BackRequested;
        }

        private void App_BackRequested(object sender,
    Windows.UI.Core.BackRequestedEventArgs e)
        {
            cancelBtn_Click(null, null);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            bmpImage = e.Parameter as BitmapImage;
            receiptPic.Source = bmpImage;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> info = new List<string>();
            string name = rName.Text;

            info.Add(rDate.Date.ToString());
            info.Add(rTime.Time.ToString());
            info.Add(rTotal.Text);
            info.Add(rNotes.PlaceholderText);

            Receipt r = new Receipt(name, bmpImage, info);
           
            //receiptsList.Items.Add(r.name);
            this.Frame.Navigate(typeof(MainPage_Mobile), r);
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog d = new MessageDialog("Are you sure you want to cancel?");

            this.Frame.Navigate(typeof(MainPage_Mobile), null);
        }
    }
}
