using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamWebApiClient;
using XamWebApiClient.ViewModels;

namespace CSIE_project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pick : ContentPage
    {
   
        string a = QRcode.qrcode;
        private  BooksViewModel _booksViewModel;
        internal static string color;
        public Pick()
        {
           
        InitializeComponent();
           
            
           

            if (a == "Books/search/state1/true")
            {

                //BindingContext = this;
                color = "Red";


                DisplayAlert("Alert", "您分配到的顏色是紅色", "OK");
                

            }

            if (a == "Books/search/state2/true")
            {
                color = "#FFD2D2";
                DisplayAlert("Alert", "您分配到的顏色是白色", "OK");
                



            }

            if (a == "Books/search/state3/true")
            {
                color = "Green";
                DisplayAlert("Alert", "您分配到的顏色是綠色", "OK");
               
               
            }
            _booksViewModel = Startup.Resolve<BooksViewModel>();
            BindingContext = _booksViewModel;
        }
       
        protected override void OnAppearing()
        {
            _booksViewModel?.Pick_PopulateBooks();

        }
        
    }
}