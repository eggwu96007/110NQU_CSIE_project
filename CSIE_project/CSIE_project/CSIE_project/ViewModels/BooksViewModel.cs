using CSIE_project;
using CSIE_project.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Models;
using XamWebApiClient.Services;
using XamWebApiClient.Views;

namespace XamWebApiClient.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {
        private ObservableCollection<Book> books;
        private Book selectedBook;
        private readonly IBookService _bookService;

        public BooksViewModel(IBookService bookService)
        {
            _bookService = bookService;

            Books = new ObservableCollection<Book>();

            DeleteBookCommand = new Command<Book>(async b => await DeleteBook(b));

            DeletePickCommand = new Command<Book>(async b => await DeletePickBook(b));

            AddNewBookCommand = new Command(async ()=> await GoToAddbookView());
            WatchCommand = new Command<Book>(async b => await GoToWatchView(b));
            //如果binding datacommand會跑來這裡接去dataview
            DataCommand = new Command(async () => await GoToDataView());
           // PickCommand = new Command(async () => await GoToPickView());
            QRcodeCommand = new Command(async () => await GoToQRcodeView());
        }

        private async Task DeleteBook(Book b)
        {
            await _bookService.DeleteBook(b);

            PopulateBooks();
        }
        
        private async Task DeletePickBook(Book b)
        {
            await _bookService.DeletePickBook(b);

            Pick_PopulateBooks();
        }

        private async Task GoToAddbookView() 
            => await Shell.Current.GoToAsync(nameof(AddBook));

        private async Task GoToWatchView(Book b)
        {
            if (b == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(PickUpdateView)}?{nameof(PickDataUpdate.BookId)}={b.Id}");

        }
            

        private async Task GoToDataView()
            => await Shell.Current.GoToAsync(nameof(Data));

       /* private async Task GoToPickView()
            => await Shell.Current.GoToAsync(nameof(Pick));*/

        private async Task GoToQRcodeView()
            => await Shell.Current.GoToAsync(nameof(QRcode));



        public async void PopulateBooks()
        {
            try
            {
                Books.Clear();

                var books = await _bookService.GetBooks();
                foreach (var book in books)
                {
                    Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //pick data
        public async void Pick_PopulateBooks()
        {
            try
            {
                Books.Clear();

                var books = await _bookService.Pick_GetBooks();
                foreach (var book in books)
                {
                    Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        async void OnBookSelected(Book book)
        {
            if (book == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(BookDetails)}?{nameof(BookDetailsViewModel.BookId)}={book.Id}");
        }

        public ObservableCollection<Book> Books
        {
            get => books;
            set
            {
                books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                if(selectedBook != value)
                {
                    selectedBook = value;

                    OnBookSelected(SelectedBook);
                }
            }
        }

        public ICommand DeleteBookCommand { get; }

        public ICommand DeletePickCommand { get; }

        public ICommand DataCommand { get; }

        public ICommand PickCommand { get; }

        public ICommand WatchCommand { get; }

        public ICommand QRcodeCommand { get; }


        public ICommand AddNewBookCommand { get; }
    }
}
