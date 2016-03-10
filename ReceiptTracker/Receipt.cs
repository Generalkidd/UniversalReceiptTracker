using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace ReceiptTracker
{
    class Receipt
    {
        public string name = "";
        public BitmapImage image = new BitmapImage();
        public List<string> details = new List<string>();

        public Receipt(string n, BitmapImage img, List<string> d)
        {
            name = n;
            image = img;
            details = d;
        }
    }
}
