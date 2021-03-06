
using CSIE_project.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using XamWebApiClient.Services;
using XamWebApiClient.ViewModels;
using XamWebApiClient.Views;

namespace XamWebApiClient
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add services
            services.AddHttpClient<IBookService, ApiBookService>(c => 
            {
                //之後要改成server domain!!!
                c.BaseAddress = new Uri("http://172.105.238.90:5000/api/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            //add viewmodels
            services.AddTransient<NewMainPage>();
            services.AddTransient<BooksViewModel>();
            services.AddTransient<AddBookViewModel>();
            services.AddTransient<BookDetailsViewModel>();
            services.AddTransient<PickDataUpdate>();
           

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
