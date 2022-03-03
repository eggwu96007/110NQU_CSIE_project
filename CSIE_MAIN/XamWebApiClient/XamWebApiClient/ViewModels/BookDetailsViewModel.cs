using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Models;
using XamWebApiClient.Services;

namespace XamWebApiClient.ViewModels
{
    [QueryProperty(nameof(BookId), nameof(BookId))]
    public class BookDetailsViewModel : BaseViewModel
    {
        private string bookId;
        private string name;
        private int quantity;
        private double price;
        private bool state;

        private readonly IBookService _bookService;

        public BookDetailsViewModel(IBookService bookService)
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
                    Id = int.Parse(BookId),
                    Name = Name,
                    Quantity = Quantity,
                    Price = Price,
                    State = State
                };

                await _bookService.SaveBook(book);

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
                if(bookId != null)
                {
                    Name = book.Name;
                    Quantity = book.Quantity;
                    Price = book.Price;
                    State = book.State;
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
