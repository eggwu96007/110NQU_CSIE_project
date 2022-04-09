using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamWebApiClient.ViewModels;

namespace XamWebApiClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Data : ContentPage
    {
        private readonly BooksViewModel _booksViewModel;
        public Data()
        {
            InitializeComponent();
            _booksViewModel = Startup.Resolve<BooksViewModel>();
            BindingContext = _booksViewModel;
        }
        protected override void OnAppearing()
        {
            _booksViewModel?.PopulateBooks();
        }
    }
}