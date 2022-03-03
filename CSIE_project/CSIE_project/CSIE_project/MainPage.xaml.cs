using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamWebApiClient;
using XamWebApiClient.Views;

namespace CSIE_project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void Pick_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pick());
            
        }

        async void Data_Click(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AppShell()));

        }
    }
}
