using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReceiptTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MediaCapture captureManager;
        BitmapImage bmpImage;
        bool quick = false;

        List<Receipt> receipts = new List<Receipt>();

        public MainPage()
        {
            this.InitializeComponent();
            editBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
        }

        private void viewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void quickAddBtn_Click(object sender, RoutedEventArgs e)
        {
            receiptsList.Width = 330;

            quick = true;

            capturePreview.Visibility = Visibility.Visible;
            captureBtn.Visibility = Visibility.Visible;

            try
            {
                captureManager = new MediaCapture();
                await captureManager.InitializeAsync();

                capturePreview.Source = captureManager;
                await captureManager.StartPreviewAsync();
            }
            catch(Exception ex)
            {

            }
        }

        private async void addBtn_Click(object sender, RoutedEventArgs e)
        {
            receiptsList.Width = 330;

            quick = false;

            capturePreview.Visibility = Visibility.Visible;
            captureBtn.Visibility = Visibility.Visible;

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

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            d1.Text = "Name: ";
            d2.Text = "Date: ";
            d3.Text = "Time: ";
            d4.Text = "Total: ";
            d5.Text = "Notes: ";

            d1.Visibility = Visibility.Visible;
            d2.Visibility = Visibility.Visible;
            d3.Visibility = Visibility.Visible;
            d4.Visibility = Visibility.Visible;
            d5.Visibility = Visibility.Visible;

            rName.Visibility = Visibility.Visible;
            rDate.Visibility = Visibility.Visible;
            rTime.Visibility = Visibility.Visible;
            rTime.Visibility = Visibility.Visible;
            rNotes.Visibility = Visibility.Visible;

            saveBtn.Visibility = Visibility.Visible;
            cancelBtn.Visibility = Visibility.Visible;

            Receipt temp = receipts[receiptsList.SelectedIndex];
            receiptPic.Source = temp.image;
            receiptPic.Visibility = Visibility.Visible;

            List<string> temp2 = new List<string>();
            temp2 = temp.details;

            rName.Text = temp.name;
            rTotal.Text = temp2[2];
            rNotes.PlaceholderText = temp2[3]; 
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            receipts.RemoveAt(receiptsList.SelectedIndex);
            receiptsList.Items.Remove(receiptsList.SelectedIndex);
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

            capturePreview.Visibility = Visibility.Collapsed;
            captureBtn.Visibility = Visibility.Collapsed;
            // imagePreivew is a <Image> object defined in XAML
            receiptPic.Source = bmpImage;
            if (quick == true)
            {
                quickAdd();
            }
            else
            {
                add();
            }
        }

        private void quickAdd()
        {
            List<string> info = new List<string>();
            info.Add(DateTime.Now.Date.ToString());
            info.Add(DateTime.Now.TimeOfDay.ToString());
            info.Add("0.00");
            info.Add("");

            Receipt r = new Receipt("Quick Add - " + DateTime.Now, bmpImage, info);
            receipts.Add(r);
            captureManager.Dispose();
            receiptsList.Items.Add(r.name);
            receiptPic.Visibility = Visibility.Collapsed;

            receiptsList.Width = 775;
        }

        private void add()
        {
            d1.Visibility = Visibility.Visible;
            d2.Visibility = Visibility.Visible;
            d3.Visibility = Visibility.Visible;
            d4.Visibility = Visibility.Visible;
            d5.Visibility = Visibility.Visible;

            rName.Visibility = Visibility.Visible;
            rDate.Visibility = Visibility.Visible;
            rTime.Visibility = Visibility.Visible;
            rTime.Visibility = Visibility.Visible;
            rTotal.Visibility = Visibility.Visible;
            rNotes.Visibility = Visibility.Visible;

            saveBtn.Visibility = Visibility.Visible;
            cancelBtn.Visibility = Visibility.Visible;
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
            receipts.Add(r);
            captureManager.Dispose();
            receiptsList.Items.Add(r.name);
            receiptPic.Visibility = Visibility.Collapsed;

            cancelBtn_Click(null, null);
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            receiptsList.Width = 775;

            d1.Visibility = Visibility.Collapsed;
            d2.Visibility = Visibility.Collapsed;
            d3.Visibility = Visibility.Collapsed;
            d4.Visibility = Visibility.Collapsed;
            d5.Visibility = Visibility.Collapsed;

            rName.Visibility = Visibility.Collapsed;
            rDate.Visibility = Visibility.Collapsed;
            rTime.Visibility = Visibility.Collapsed;
            rTime.Visibility = Visibility.Collapsed;
            rTotal.Visibility = Visibility.Collapsed;
            rNotes.Visibility = Visibility.Collapsed;

            saveBtn.Visibility = Visibility.Collapsed;
            cancelBtn.Visibility = Visibility.Collapsed;

            receiptPic.Visibility = Visibility.Collapsed;
        }

        private void receiptsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            receiptsList.Width = 330;

            editBtn.IsEnabled = true;
            deleteBtn.IsEnabled = true;

            d1.Text = "Name: ";
            d2.Text = "Date: ";
            d3.Text = "Time: ";
            d4.Text = "Total: ";
            d5.Text = "Notes: ";

            Receipt temp = receipts[receiptsList.SelectedIndex];
            List<string> temp2 = new List<string>();
            temp2 = temp.details;

            receiptPic.Source = temp.image;
            receiptPic.Visibility = Visibility.Visible;

            d1.Visibility = Visibility.Visible;
            d2.Visibility = Visibility.Visible;
            d3.Visibility = Visibility.Visible;
            d4.Visibility = Visibility.Visible;
            d5.Visibility = Visibility.Visible;

            d1.Text = d1.Text + " " + temp.name;
            d2.Text = d2.Text + " " + temp2[0];
            d3.Text = d3.Text + " " + temp2[1];
            d4.Text = d4.Text + " " + temp2[2];
            d5.Text = d5.Text + " " + temp2[3];

            closeBtn.Visibility = Visibility.Visible;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            receiptsList.Width = 775;

            d1.Text = "Name: ";
            d2.Text = "Date: ";
            d3.Text = "Time: ";
            d4.Text = "Total: ";
            d5.Text = "Notes: ";

            d1.Visibility = Visibility.Collapsed;
            d2.Visibility = Visibility.Collapsed;
            d3.Visibility = Visibility.Collapsed;
            d4.Visibility = Visibility.Collapsed;
            d5.Visibility = Visibility.Collapsed;

            rName.Visibility = Visibility.Collapsed;
            rDate.Visibility = Visibility.Collapsed;
            rTime.Visibility = Visibility.Collapsed;
            rTime.Visibility = Visibility.Collapsed;
            rNotes.Visibility = Visibility.Collapsed;

            saveBtn.Visibility = Visibility.Collapsed;
            cancelBtn.Visibility = Visibility.Collapsed;

            receiptPic.Visibility = Visibility.Collapsed;

            closeBtn.Visibility = Visibility.Collapsed;
        }
    }
}
