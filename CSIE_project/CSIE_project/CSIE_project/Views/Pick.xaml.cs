using System;
using System.Collections.Generic;
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
        private readonly BooksViewModel _booksViewModel;
        public Pick()
        {
            InitializeComponent();
            _booksViewModel = Startup.Resolve<BooksViewModel>();
            BindingContext = _booksViewModel;
        }
        protected override void OnAppearing()
        {
            _booksViewModel?.Pick_PopulateBooks();
        }
    }
}