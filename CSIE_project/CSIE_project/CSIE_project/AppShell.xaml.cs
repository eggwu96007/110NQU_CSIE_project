using CSIE_project;
using CSIE_project.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamWebApiClient.ViewModels;
using XamWebApiClient.Views;

namespace XamWebApiClient
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewMainPage), typeof(NewMainPage));
            Routing.RegisterRoute(nameof(AddBook), typeof(AddBook));
            Routing.RegisterRoute(nameof(BookDetails), typeof(BookDetails));
            Routing.RegisterRoute(nameof(Data), typeof(Data));
            Routing.RegisterRoute(nameof(Pick), typeof(Pick));
            Routing.RegisterRoute(nameof(PickUpdateView), typeof(PickUpdateView));

        }
    }
}
