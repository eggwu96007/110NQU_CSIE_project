using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Models;
using XamWebApiClient.Services;

namespace XamWebApiClient.ViewModels
{
    [QueryProperty(nameof(BookId), nameof(BookId))]
    public class PickDataUpdate : BaseViewModel
    {
        private string bookId;
        private string name;
        private int quantity;
        private double price;
        private string state;
        private string state2;
        private string state3;

        private readonly IBookService _bookService;

        public PickDataUpdate(IBookService bookService)
        {
            _bookService = bookService;

            DeletePickCommand = new Command(async () => await SaveBook());
        }

        private async Task SaveBook()
        {
            try
            {
                var book = new Book
                {
                    Id = int.Parse(BookId),
                    Name = Name,
                    Quantity = Quantity,
                    Price = Price,
                    State = State,
                    State2 = State2,
                    State3 = State3
                };

                await _bookService.DeletePickBook(book);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void LoadBook(string bookId)
        {
            try
            {
                var book = await _bookService.GetBook(int.Parse(bookId));
                if (bookId != null)
                {
                    Name = book.Name;
                    Quantity = book.Quantity;
                    Price = book.Price;
                    State = book.State;
                    State2 = book.State2;
                    State3 = book.State3;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string BookId
        {
            get => bookId;
            set
            {
                bookId = value;
                LoadBook(bookId);
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
                price = 50000;
                OnPropertyChanged(nameof(Price));
            }
        }

        public string State
        {
            get => state;
            set
            {
                state = "true";
                OnPropertyChanged(nameof(State));
            }
        }

        public string State2
        {
            get => state2;
            set
            {
                state2 = value;
                OnPropertyChanged(nameof(State2));
            }
        }

        public string State3
        {
            get => state3;
            set
            {
                state3 = value;
                OnPropertyChanged(nameof(State3));
            }
        }

        public ICommand DeletePickCommand { get; }
    }
}
