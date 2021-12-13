using System;
using ConsoleBookLibrary.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleBookLibrary
{
    class Program
    {
        public static string NameOfReader { get; set; }
        public static DateTime DateOfToday { get; set; }
        public static DateTime DateOfReturn { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Welcome to the library by Sarunas Vaitiekunas");

            MainChoice();

            Console.ReadLine();
        }

        private static void MainChoice()
        {
            Console.WriteLine("\n===== Main menu =====");
            Console.WriteLine("Choose what you want to do next:");
            Console.WriteLine("1 - View the list of books");
            Console.WriteLine("2 - Add a new book to the list");
            Console.WriteLine("3 - Take books");
            Console.WriteLine("4 - Return books");
            Console.WriteLine("5 - Delete a book");
            Console.WriteLine("\n6 - Exit library");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    FilterChoice();
                    MainChoice();
                    break;
                case 2:
                    AddBook();
                    MainChoice();
                    break;
                case 3:
                    TakeBook();
                    MainChoice();
                    break;
                case 4:
                    ReturnBook();
                    MainChoice();
                    break;
                case 5:
                    FilterAll();
                    Console.WriteLine("\nPlease enter Id of the book which you want to delete from the list:");
                    DeleteBook(Convert.ToInt32(Console.ReadLine()));
                    MainChoice();
                    break;
                case 6:
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("There is no such choice.");
                    MainChoice();
                    break;
            }
        }

        private static void FilterChoice()
        {
            CheckListFile();
            Console.WriteLine("\n===== Book list filter =====");
            Console.WriteLine("Choose what you want to do next:");
            Console.WriteLine("1 - List all the books");
            Console.WriteLine("2 - Filter by author");
            Console.WriteLine("3 - Filter by category");
            Console.WriteLine("4 - Filter by language");
            Console.WriteLine("5 - Filter by ISBN");
            Console.WriteLine("6 - Filter by name");
            Console.WriteLine("7 - Filter taken or available books");
            Console.WriteLine("\n8 - Back to main menu");
            Console.WriteLine("9 - Exit library");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nList all the books:");
                    FilterAll();
                    FilterChoice();
                    break;
                case 2:
                    Console.WriteLine("\nFilter by author. Please enter word or fragment:");
                    FilterByAuthor(Console.ReadLine());
                    FilterChoice();
                    break;
                case 3:
                    Console.WriteLine("\nFilter by category. Please enter word or fragment:");
                    FilterByCategory(Console.ReadLine());
                    FilterChoice();
                    break;
                case 4:
                    Console.WriteLine("\nFilter by language. Please enter word or fragment:");
                    FilterByLanguage(Console.ReadLine());
                    FilterChoice();
                    break;
                case 5:
                    Console.WriteLine("\nFilter by ISBN. Please enter word or fragment:");
                    FilterByISBN(Console.ReadLine());
                    FilterChoice();
                    break;
                case 6:
                    Console.WriteLine("\nFilter by name. Please enter word or fragment:");
                    FilterByName(Console.ReadLine());
                    FilterChoice();
                    break;
                case 7:
                    Console.WriteLine("\nFilter by availability. Please enter true or false:");
                    FilterByAvailability(Console.ReadLine());
                    FilterChoice();
                    break;
                case 8:
                    MainChoice();
                    break;
                case 9:
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("There is no such choice.");
                    FilterChoice();
                    break;
            }
        }

        private static void CheckListFile()
        {
            if (!File.Exists(@"D:\BookList.json"))
            {
                Console.WriteLine("The book list file does not exist, so a new one will be created.");

                using (StreamWriter writeListLine = File.AppendText(@"D:\BookList.json"))
                {
                    Console.WriteLine("\nThe book list file was created.");
                }
            }
        }

        private static List<Book> DeserializeBookList()
        {
            string bookListData = System.IO.File.ReadAllText(@"D:\BookList.json");
            List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(bookListData);

            return bookList;
        }

        private static void FilterAll()
        {
            List<Book> books = DeserializeBookList();

            foreach (var book in books)
            {
                Console.WriteLine(book.Id + " - Name: " + book.Name + " - Author: " + book.Author + " - Category: " + book.Category + " - Language: " + book.Language + " Year - " + book.PublicationDate);
            }
        }

        private static void FilterByAuthor(string fragment)
        {
            List<Book> books = DeserializeBookList();

            foreach (var book in books)
            {
                if (book.Author.Contains(fragment, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(book.Id + " - Author: " + book.Author + " - Name: " + book.Name + " - Category: " + book.Category + " - Language: " + book.Language + " Year - " + book.PublicationDate);
                }
            }
        }

        private static void FilterByCategory(string fragment)
        {
            List<Book> books = DeserializeBookList();

            foreach (var book in books)
            {
                if (book.Category.Contains(fragment, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(book.Id + " - Category: " + book.Category + " - Name: " + book.Name + " - Author: " + book.Author + " - Category: " + book.Category + " - Language: " + book.Language + " Year - " + book.PublicationDate);
                }
            }
        }

        private static void FilterByLanguage(string fragment)
        {
            List<Book> books = DeserializeBookList();

            foreach (var book in books)
            {
                if (book.Language.Contains(fragment, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(book.Id + " - Language: " + book.Language + " - Name: " + book.Name + " - Author: " + book.Author + " - Category: " + book.Category + " Year - " + book.PublicationDate);
                }
            }
        }

        private static void FilterByISBN(string fragment)
        {
            List<Book> books = DeserializeBookList();

            foreach (var book in books)
            {
                if (book.ISBN.Contains(fragment, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(book.Id + " - ISBN: " + book.ISBN + " - Name: " + book.Name + " - Author: " + book.Author + " - Category: " + book.Category + " - Language: " + book.Language + " Year - " + book.PublicationDate);
                }
            }
        }

        private static void FilterByName(string fragment)
        {
            List<Book> books = DeserializeBookList();

            foreach (var book in books)
            {
                if (book.Name.Contains(fragment, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(book.Id + " - Name: " + book.Name + " - Author: " + book.Author + " - Category: " + book.Category + " - Language: " + book.Language + " Year - " + book.PublicationDate);
                }
            }
        }

        private static void FilterByAvailability(string fragment)
        {
            bool availBool = bool.Parse(fragment);

            List<Book> books = DeserializeBookList();

            foreach (var book in books)
            {
                if (book.Availability.Equals(availBool))
                {
                    Console.WriteLine(book.Id + " - Available: " + book.Availability + " - Taken by: " + book.ReaderName + " - Name: " + book.Name + " - Author: " + book.Author + " - Category: " + book.Category + " - Language: " + book.Language + " Year - " + book.PublicationDate);
                }
            }
        }

        private static void GetReaderName()
        {
            Console.WriteLine("Please enter your name:");
            NameOfReader = Console.ReadLine();
        }

        private static void GetTodayDate()
        {
            Console.WriteLine("Please enter date of today YYYY-MM-DD (it's for app testing):");
            DateOfToday = Convert.ToDateTime(Console.ReadLine());
        }

        private static void GetReturnDate()
        {
            Console.WriteLine("Please enter date of planned return:");
            DateOfReturn = Convert.ToDateTime(Console.ReadLine());
            TimeSpan diff = DateOfReturn.Date - DateOfToday.Date;
            int period = (int)diff.TotalDays;

            while (period < 0 || period > 62)
            {
                if (period < 0)
                {
                    Console.WriteLine("Planned return date must be from the future not from the past :) Please enter another:");
                }
                else if (period > 62)
                {
                    Console.WriteLine("Planned return date is very far away (More than 2 months). Please enter another:");
                }
                DateOfReturn = Convert.ToDateTime(Console.ReadLine());
                diff = DateOfReturn.Date - DateOfToday.Date;
                period = (int)diff.TotalDays;
            }

            if (period == 0)
            {
                Console.WriteLine("\nFast reader, but it's OK :)");
            }
        }

        private static void AddBook()
        {
            Console.WriteLine("Enter name of new book:");
            string bookName = Console.ReadLine();
            Console.WriteLine("Enter author of new book:");
            string bookAuthor = Console.ReadLine();
            Console.WriteLine("Enter category of new book:");
            string bookCategory = Console.ReadLine();
            Console.WriteLine("Enter language of new book:");
            string bookLanguage = Console.ReadLine();
            Console.WriteLine("Enter publication date of new book:");
            string bookPublicationDate = Console.ReadLine();
            Console.WriteLine("Enter ISBN of new book:");
            string bookIsbn = Console.ReadLine();

            List<Book> books = DeserializeBookList();

            int maxId = 0;
            foreach (var book in books)
            {
                if (book.Id > maxId)
                {
                    maxId = book.Id;
                }
            }

            books.Add(new Book()
            {
                Id = maxId += 1,
                Name = bookName,
                Author = bookAuthor,
                Category = bookCategory,
                Language = bookLanguage,
                PublicationDate = bookPublicationDate,
                ISBN = bookIsbn,
                Availability = true,
                ReaderName = ""
            }
            );

            string newBookList = JsonConvert.SerializeObject(books, Formatting.Indented);
            System.IO.File.WriteAllText(@"D:\BookList.json", newBookList);

            Console.WriteLine("\nNew book was added to the list file.");
        }

        private static void TakeBook()
        {
            CheckListFile();

            GetReaderName();

            GetTodayDate();

            GetReturnDate();

            Console.WriteLine("\n===== All available books =====");

            FilterByAvailability("true");

            Console.WriteLine("\nHow many books you will take? (Max 3 books) If you will enter 0, you will return to the main menu:");

            int numberOfBooks = Convert.ToInt32(Console.ReadLine());

            while (numberOfBooks < 1 || numberOfBooks > 3)
            {
                if (numberOfBooks < 0)
                {
                    Console.WriteLine("Wrong number. Please enter another number:");
                }
                else if (numberOfBooks == 0)
                {
                    MainChoice();
                }
                else if (numberOfBooks > 3)
                {
                    Console.WriteLine("You can take max 3 books. Please enter another number:");
                }
                numberOfBooks = Convert.ToInt32(Console.ReadLine());
            }

            for (var i = 1; i < numberOfBooks + 1; i++)
            {
                Console.WriteLine("Please enter " + i + " book Id:");
                int rId = Convert.ToInt32(Console.ReadLine());
                RewriteBook(rId);
                Console.WriteLine("\nHave a good reading!");
            }
        }

        private static void ReturnBook()
        {
            GetReaderName();

            GetTodayDate();

            Console.WriteLine("===== Books you've taken =====");

            List<Book> books = DeserializeBookList();

            foreach (var book in books)
            {
                if (book.ReaderName.Contains(NameOfReader, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(book.Id + " - Available: " + book.Availability + " - Taken by: " + book.ReaderName + " - Name: " + book.Name + " - Author: " + book.Author + " - Category: " + book.Category + " - Language: " + book.Language + " Year - " + book.PublicationDate);
                }
            }

            Console.WriteLine("Please enter return book Id:");
            int rId = Convert.ToInt32(Console.ReadLine());
            RewriteBook(rId);
            Console.WriteLine("\nThanks for reading!");
        }

        private static void RewriteBook(int rId)
        {
            List<Book> books = DeserializeBookList();

            var book = books.Find(r => r.Id == rId);

            if (book.Id.Equals(rId))
            {
                int oldId = book.Id;
                string oldName = book.Name;
                string oldAuthor = book.Author;
                string oldCategory = book.Category;
                string oldLanguage = book.Language;
                string oldPublicationDate = book.PublicationDate;
                string oldISBN = book.ISBN;
                bool oldAvailability = book.Availability;
                string oldReaderName = book.ReaderName;
                DateTime oldTakeDate = book.TakeDate;
                DateTime oldReturnDate = book.ReturnDate;

                var bookToRemove = books.SingleOrDefault(r => r.Id == rId);
                if (bookToRemove != null)
                {
                    books.Remove(bookToRemove);
                }

                if (oldAvailability == false) //For ReturnBook
                {
                    books.Add(new Book()
                    {
                        Id = oldId,
                        Name = oldName,
                        Author = oldAuthor,
                        Category = oldCategory,
                        Language = oldLanguage,
                        PublicationDate = oldPublicationDate,
                        ISBN = oldISBN,
                        Availability = true,
                        ReaderName = ""
                    }
                    );

                    TimeSpan diff = DateOfToday.Date - oldTakeDate.Date;
                    int period = (int)diff.TotalDays;

                    if (period > 62)
                    {
                        Console.WriteLine("\nIt's not nice to be late. Next time penalty: a euro, a kiss and a bun :)");
                    }
                }
                else if (oldAvailability == true) //For TakeBook
                {
                    books.Add(new Book()
                    {
                        Id = oldId,
                        Name = oldName,
                        Author = oldAuthor,
                        Category = oldCategory,
                        Language = oldLanguage,
                        PublicationDate = oldPublicationDate,
                        ISBN = oldISBN,
                        Availability = false,
                        ReaderName = NameOfReader,
                        TakeDate = DateOfToday,
                        ReturnDate = DateOfReturn
                    }
                    );
                }
                books = books.OrderBy(book => book.Id).ToList();
            }

            string newBookList = JsonConvert.SerializeObject(books, Formatting.Indented);
            System.IO.File.WriteAllText(@"D:\BookList.json", newBookList);
        }
               
        private static void DeleteBook(int dId)
        {
            List<Book> books = DeserializeBookList();

            foreach (var book in books)
            {
                Console.WriteLine(book.Id + " - Name: " + book.Name + " - Author: " + book.Author + " - Category: " + book.Category + " - Language: " + book.Language + " Year - " + book.PublicationDate);
            }

            var bookToRemove = books.SingleOrDefault(r => r.Id == dId);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }

            string newBookList = JsonConvert.SerializeObject(books, Formatting.Indented);
            System.IO.File.WriteAllText(@"D:\BookList.json", newBookList);
            Console.WriteLine("\nThe book was deleted from the list file.");
        }
    }
}