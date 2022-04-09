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
    public partial class PickUpdateView : ContentPage
    {
        public PickUpdateView()
        {
            InitializeComponent();
            BindingContext = Startup.Resolve<PickDataUpdate>();
        }
    }
}