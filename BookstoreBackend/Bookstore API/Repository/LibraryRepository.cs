using Bookstore_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Configuration;
using System.Xml.Serialization;

namespace Bookstore_API.Repository
{
    internal class LibraryRepository
    {
        private string _databasePath = AppDomain.CurrentDomain.BaseDirectory + WebConfigurationManager.AppSettings["DatabasePath"];
        List<BookModel> bookModelList = new List<BookModel>();
        internal BookModel GetBook(string ISBN)
        {
            var book = new BookModel();
            var xmlSerializer = new XmlSerializer(typeof(LibraryModel));
            using (var context = new StreamReader(_databasePath))
            {
                var library = (LibraryModel)xmlSerializer.Deserialize(context);
                book = library.Books.FirstOrDefault(x => x.ISBN.Equals(ISBN));
                if (book == null)
                {
                    book = new BookModel()
                    {
                        Title = "book not found!"
                    };
                }
            }
            return book;
        }

        internal List<BookModel> GetBooksByAuthor(string author)
        {
            var xmlSerializer = new XmlSerializer(typeof(LibraryModel));

            using (var context = new StreamReader(_databasePath))
            {
                var library = (LibraryModel)xmlSerializer.Deserialize(context);
                bookModelList = library.Books.Where(b => b.Author.Equals(author)).ToList();
            }

            return bookModelList;
        }

        internal List<BookModel> GetBooksBySearchString(string searchString)
        {
            var xmlSerializer = new XmlSerializer(typeof(LibraryModel));

            using (var context = new StreamReader(_databasePath))
            {
                var library = (LibraryModel)xmlSerializer.Deserialize(context);
                bookModelList = library.Books.Where(b => b.Author.Equals(searchString) || b.Title.Equals(searchString) || b.ISBN.Equals(searchString)).ToList();
            }

            return bookModelList;
        }

        internal string CreateBook(BookModel bookMdl)
        {
            string response;
            LibraryModel libModel = new LibraryModel();
            var xmlSerializer = new XmlSerializer(typeof(LibraryModel));

            using (var context = new StreamReader(_databasePath))
            {
                var library = (LibraryModel)xmlSerializer.Deserialize(context);
                bookModelList = library.Books.Where(b => b.Title != "").ToList();
            }

            bool bookExists = CheckIfBookExists(bookModelList, bookMdl);

            if (bookExists == false)
            {
                bookModelList.Add(bookMdl);
            }

            else
            {
                response = "Det finns redan en bok med samma ISBN";
                return response;
            }

            libModel.Books = bookModelList;

            using (var fileStream = new FileStream(_databasePath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, libModel);
                response = "Din bok har nu lagts till!";
                return response;
            }

        }

        internal void AddBookProposal(BookProposalModel bookPropModel)
        {
            string firstLetterName = bookPropModel.NameOfUserWithRequest[0].ToString().ToUpper();
            string todaysDate = DateTime.Now.ToString("yyMMdd");
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string firstLetterOfTitle = bookPropModel.Title[0].ToString().ToUpper();

            string fileName = firstLetterName + "_" + todaysDate + "_" + firstLetterOfTitle;
            int numberIfFileNameExists = 1;
            bool fileExists = true;
            bool isFirst = false;

            //P_2019-01-31_H.

            if (!Directory.Exists(Path.Combine(path, todaysDate)))
            {
                Directory.CreateDirectory(Path.Combine(path, todaysDate));
            }

            while (fileExists == true)
            {
                if (!File.Exists(Path.Combine(path, todaysDate, fileName)))
                {
                    isFirst = true;
                }

                if (isFirst == true)
                {
                    fileExists = false;
                    File.Create(Path.Combine(path, todaysDate, fileName));
                }

                else
                {
                    if (!File.Exists(Path.Combine(path, todaysDate, fileName) + numberIfFileNameExists.ToString()))
                    {
                        File.Create(Path.Combine(path, todaysDate, fileName) + numberIfFileNameExists.ToString());
                        fileExists = false;
                    }

                    else
                    {
                        numberIfFileNameExists++;
                    }
                }
            }
        }

        private bool CheckIfBookExists(List<BookModel> listOfBooks, BookModel bookModel)
        {
            bool bookExists = false;
            int index = 0;
            
            while(index < listOfBooks.Count)
            {
                if(bookModel.ISBN == listOfBooks[index].ISBN)
                {
                    bookExists = true;
                }
                index++;
            }

            if(bookExists == false)
            {
                //Returnerar false och boken är redo att läggas till.
                bookExists = false;
                return bookExists;
            }

            else
            {
                // Returnerar att det redan finns en bok med den titeln.
                return bookExists;
            }
        }
    }
}