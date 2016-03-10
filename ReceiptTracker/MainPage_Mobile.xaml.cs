using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
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
    public sealed partial class MainPage_Mobile : Page
    {
        List<Receipt> receipts = new List<Receipt>();
        private const string JSONFILENAME = "data.xml";

        public MainPage_Mobile()
        {
            this.InitializeComponent();
            editBtn.IsEnabled = false;
            deleteBtn.IsEnabled = false;
            viewBtn.IsEnabled = false;
            load();
        }
        
        async void load()
        {
            await deserializeJsonAsync();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            load();
            try
            {
                Receipt r = e.Parameter as Receipt;
                receipts.Add(r);
                receiptsList.Items.Add(r.name);
                await writeJsonAsync();
            }
            catch(Exception E)
            {
                
            }

            if(e.Parameter.GetType() == typeof(List<Receipt>))
            {
                receipts = e.Parameter as List<Receipt>;
            }
        }

        protected async override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //await writeJsonAsync();
            base.OnNavigatedFrom(e);
        }

        private void viewBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewPage), receipts[receiptsList.SelectedIndex]);
        }

        private void quickAddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CapturePage), "q");
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CapturePage), "n");
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddPage), receipts[receiptsList.SelectedIndex]);
        }

        private async void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            receipts.RemoveAt(receiptsList.SelectedIndex);
            receiptsList.Items.Remove(receiptsList.SelectedIndex);
            //await writeJsonAsync();
        }

        private void receiptsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editBtn.IsEnabled = true;
            deleteBtn.IsEnabled = true;
            viewBtn.IsEnabled = true;
        }

        private async Task writeJsonAsync()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Receipt>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                          JSONFILENAME,
                          CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, receipts);
            }
        }

        private async Task deserializeJsonAsync()
        {
            string content = String.Empty;

            List<Receipt> R;

            try
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(List<Receipt>));

                var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);

                R = (List<Receipt>)jsonSerializer.ReadObject(myStream);

                receipts = R;

                foreach (Receipt r in R)
                {
                    receiptsList.Items.Add(r.name);
                }
            }
            catch(Exception e)
            {

            }
        }

    }
}
