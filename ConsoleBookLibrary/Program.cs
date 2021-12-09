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
            
            MakeChoice();

            Console.ReadLine();


        }

        private static void MakeChoice()
        {
            Console.WriteLine();
            Console.WriteLine("Choose what you want to do next:");
            Console.WriteLine("1 - View the list of books");
            Console.WriteLine("2 - Add a new book to the list");
            Console.WriteLine("3 - Take books");
            Console.WriteLine("4 - Return books");
            Console.WriteLine("5 - Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    LoadBookList();
                    MakeChoice();
                    break;
                case 2:
                    AddBook();
                    MakeChoice();
                    break;
                case 3:
                    TakeBook();
                    MakeChoice();
                    break;
                case 4:
                    ReturnBook();
                    MakeChoice();
                    break;
                case 5:
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("There is no such choice.");
                    MakeChoice();
                    break;
            }
        }

        private static void ReturnBook()
        {
            throw new NotImplementedException();
        }

        private static void TakeBook()
        {
            throw new NotImplementedException();
        }

        private static void LoadBookList()
        {
            if (File.Exists(@"D:\BookList.json"))
            {
                //using (StreamReader r = new StreamReader(@"D:\BookList.json"))
                //{

                    //string json = r.ReadToEnd();
                    //JObject parsed = JObject.Parse(json);

                    //foreach (var pair in parsed)
                    //{
                    //    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                    //}
                //}

                var bookListData = System.IO.File.ReadAllText(@"D:\BookList.json");

                List<Book> myDeserializedObjList = (List<Book>)Newtonsoft.Json.JsonConvert.DeserializeObject(bookListData, typeof(List<Book>));

                
                

                //string.Join(", ", bookListData);


                Console.WriteLine(bookListData);

                //using (StreamReader readBookList = new StreamReader(@"D:\BookList.json"))
                //{
                //    string readListLine;
                //    Console.WriteLine("Book List:");
                //    do
                //    {
                //        readListLine = readBookList.ReadLine();
                //        Console.WriteLine(readListLine);
                //    } while (readListLine != null);
                //}
            }
            else
            {
                Console.WriteLine("The book list file does not exist, so a new one will be created.");

                using (StreamWriter writeListLine = File.AppendText(@"D:\BookList.json"))
                {
                    Console.WriteLine("The book list file was created.");
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

            var bookListData = System.IO.File.ReadAllText(@"D:\BookList.json");

            var bookList = JsonConvert.DeserializeObject<List<Book>>(bookListData);
            
            bookList.Add(new Book()
            {
                Id = 3,
                Name = bookName,
                Author = bookAuthor,
                Category = bookCategory,
                Language = bookLanguage,
                PublicationDate = bookPublicationDate,
                ISBN = bookIsbn
            }
            );

            var serializeJson = JsonConvert.SerializeObject(bookList, Formatting.Indented);
            System.IO.File.WriteAllText(@"D:\BookList.json", serializeJson);

            Console.WriteLine("New book was added to the list file.");
        }
    }
}

