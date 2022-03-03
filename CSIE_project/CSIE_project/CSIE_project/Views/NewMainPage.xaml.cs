using CSIE_project;
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

    public partial class NewMainPage : ContentPage
    {
        private readonly BooksViewModel _booksViewModel;
        public NewMainPage()
        {
            InitializeComponent();

            _booksViewModel = Startup.Resolve<BooksViewModel>();
            BindingContext = _booksViewModel;
        }
       
    }
}