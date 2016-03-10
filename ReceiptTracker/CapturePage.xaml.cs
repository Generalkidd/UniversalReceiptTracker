using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
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
    public sealed partial class CapturePage : Page
    {
        MediaCapture captureManager;
        BitmapImage bmpImage;
        bool quick = false;

        List<Receipt> receipts = new List<Receipt>();

        public CapturePage()
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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            string tmp = e.Parameter as string;

            if(tmp == "q")
            {
                quick = true;
            }
            else
            {
                quick = false;
            }

            try
            {
                captureManager = new MediaCapture();
                await captureManager.InitializeAsync();

                capturePreview.Source = captureManager;
                await captureManager.StartPreviewAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private async void captureBtn_Click(object sender, RoutedEventArgs e)
        {
            ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();

            // create storage file in local app storage
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                "receiptPic.jpg",
                CreationCollisionOption.GenerateUniqueName);

            // take photo
            await captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);

            // Get photo as a BitmapImage
            bmpImage = new BitmapImage(new Uri(file.Path));

            //capturePreview.Visibility = Visibility.Collapsed;
            //captureBtn.Visibility = Visibility.Collapsed;
            // imagePreivew is a <Image> object defined in XAML
            //receiptPic.Source = bmpImage;
            if (quick == true)
            {
                List<string> info = new List<string>();
                info.Add(DateTime.Now.Date.ToString());
                info.Add(DateTime.Now.TimeOfDay.ToString());
                info.Add("0.00");
                info.Add("");

                Receipt r = new Receipt("Quick Add - " + DateTime.Now, bmpImage, info);
                receipts.Add(r);
                captureManager.Dispose();
                this.Frame.Navigate(typeof(MainPage_Mobile), r);
            }
            else
            {
                this.Frame.Navigate(typeof(AddPage), bmpImage);
            }
        }
    }
}
