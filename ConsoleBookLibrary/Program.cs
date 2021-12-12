using System;
using ConsoleBookLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleBookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Welcome to the library.");

            MainChoice();

            Console.ReadLine();
        }

        private static void MainChoice()
        {
            Console.WriteLine("===== Main menu =====");
            Console.WriteLine("Choose what you want to do next:");
            Console.WriteLine("1 - View the list of books");
            Console.WriteLine("2 - Add a new book to the list");
            Console.WriteLine("3 - Take books");
            Console.WriteLine("4 - Return books");
            Console.WriteLine("5 - Delete a book");
            Console.WriteLine("6 - Exit library");

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
                    ReturnBook(8);
                    MainChoice();
                    break;
                case 5:
                    FilterAll();
                    Console.WriteLine("\nPlease enter Id of the book which you want to delete from the list.");
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
            Console.WriteLine("===== Book list filter =====");
            Console.WriteLine("Choose what you want to do next:");
            Console.WriteLine("1 - List all the books");
            Console.WriteLine("2 - Filter by author");
            Console.WriteLine("3 - Filter by category");
            Console.WriteLine("4 - Filter by language");
            Console.WriteLine("5 - Filter by ISBN");
            Console.WriteLine("6 - Filter by name");
            Console.WriteLine("7 - Filter taken or available books");
            Console.WriteLine("8 - Back to main menu");
            Console.WriteLine("9 - Exit library");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nList all the books.");
                    FilterAll();
                    FilterChoice();
                    break;
                case 2:
                    Console.WriteLine("\nFilter by author. Please enter word or fragment.");
                    FilterByAuthor(Console.ReadLine());
                    FilterChoice();
                    break;
                case 3:
                    Console.WriteLine("\nFilter by category. Please enter word or fragment.");
                    FilterByCategory(Console.ReadLine());
                    FilterChoice();
                    break;
                case 4:
                    Console.WriteLine("\nFilter by language. Please enter word or fragment.");
                    FilterByLanguage(Console.ReadLine());
                    FilterChoice();
                    break;
                case 5:
                    Console.WriteLine("\nFilter by ISBN. Please enter word or fragment.");
                    FilterByISBN(Console.ReadLine());
                    FilterChoice();
                    break;
                case 6:
                    Console.WriteLine("\nFilter by name. Please enter word or fragment.");
                    FilterByName(Console.ReadLine());
                    FilterChoice();
                    break;
                case 7:
                    Console.WriteLine("\nFilter by availability. Please enter true or false.");
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
                    Console.WriteLine("The book list file was created.");
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
            Console.WriteLine();

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
                ReaderName = null
            }
            );

            string newBookList = JsonConvert.SerializeObject(books, Formatting.Indented);
            System.IO.File.WriteAllText(@"D:\BookList.json", newBookList);

            Console.WriteLine("New book was added to the list file.");
        }

        private static void TakeBook()
        {
            CheckListFile();

            Console.WriteLine("Please enter yout name");
            String readerName = Console.ReadLine();

            Console.WriteLine("Please enter date of today YYYY-MM-DD (it's for app testing)");
            DateTime today = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please enter date of planned return");
            DateTime plReturnDate = Convert.ToDateTime(Console.ReadLine());
            TimeSpan diff = plReturnDate.Date - today.Date;
            int period = (int)diff.TotalDays;

            while (period < 0 || period > 62)
            {
                if (period < 0)
                {
                    Console.WriteLine("Planned return date must be from the future not from the past :) Please enter another");
                }
                else if (period > 62)
                {
                    Console.WriteLine("Planned return date is very far away (More than 2 months). Please enter another");
                }
                plReturnDate = Convert.ToDateTime(Console.ReadLine());
                diff = plReturnDate.Date - today.Date;
                period = (int)diff.TotalDays;
            }

            if (period == 0)
            {
                Console.WriteLine("Fast reader, but it's OK :)");
            }

            Console.WriteLine("===== All available books =====");
            FilterByAvailability("true");
            Console.WriteLine("\nHow many books you will take? (Max 3 books):");
            int b = Convert.ToInt32(Console.ReadLine());

            for (var i = 1; i < b + 1; i++)
            {
                Console.WriteLine("Please enter " + i + " book Id:");
                Console.ReadLine();
            }
        }

        private static void ReturnBook(int rId)
        {
            Console.WriteLine("Please enter yout name");
            String readerName = Console.ReadLine();

            Console.WriteLine("Please enter date of today YYYY-MM-DD (it's for app testing)");
            DateTime today = Convert.ToDateTime(Console.ReadLine());

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
                    ReaderName = null
                }
                );
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
        }
    }
}

