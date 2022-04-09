using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamWebApiClient.ViewModels;
using XamWebApiClient.Views;

namespace CSIE_project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRcode : ContentPage
    {
        internal static string qrcode;

        public QRcode()
        {
            InitializeComponent();

        }
        public void scanView_OnScanResult(ZXing.Result result)
        {
                qrcode = result.Text;
                Device.BeginInvokeOnMainThread(async () => await Shell.Current.GoToAsync(nameof(Pick)));
 
        }
        

    }
}