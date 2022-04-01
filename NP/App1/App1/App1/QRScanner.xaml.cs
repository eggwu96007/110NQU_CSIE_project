using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRScanner : ContentPage
    {
        public QRScanner()
        {
            InitializeComponent();
        }
        
        private void scanView_OnScanResult(ZXing.Result result)
        {
            /*OpenWebCommand = new Command(async () => await Browser.OpenAsync(result));
            public ICommand OpenWebCommand { get; }*/
        /*Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("掃描結果", result.Text, "yes");

               await Browser.OpenAsync("https://aka.ms/xamarin-quickstart")
            });*/

        Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("掃描結果", result.Text, "yes");
                await Navigation.PushAsync(new menu());
                //await Browser.OpenAsync(result.ToString());
            });


    }

}
}