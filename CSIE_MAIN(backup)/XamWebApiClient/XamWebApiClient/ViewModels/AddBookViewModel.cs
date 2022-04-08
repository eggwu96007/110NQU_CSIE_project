using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Models;
using XamWebApiClient.Services;

namespace XamWebApiClient.ViewModels
{
    public class AddBookViewModel : BaseViewModel
    {
        private readonly IBookService _bookService;
        private string name;
        private int quantity;
        private double price;
        private bool state;

        public AddBookViewModel(IBookService bookService)
        {
            _bookService = bookService;

            SaveBookCommand = new Command(async () => await SaveBook());
        }

        private async Task SaveBook()
        {
            try
            {
                var book = new Book
                {
                    Name = Name,
                    Quantity = Quantity,
                    Price = Price,
                    State=State
                };

                await _bookService.AddBook(book);              

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string Name
        {
            get => name; 
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int Quantity
        {
            get => quantity; 
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public double Price
        {
            get => price; 
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public bool State
        {
            get => state;
            set
            {
                state = value;
                OnPropertyChanged(nameof(State));
            }
        }


        public ICommand SaveBookCommand { get; }
    }
}
