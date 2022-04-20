using Bookstore_API.Models;
using Bookstore_API.Repository;
using Microsoft.VisualBasic.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bookstore_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("")]
    public class BookInfoController : ApiController
    {
        private LibraryRepository library = new LibraryRepository();
        private Log logger = new Log();
        string apiResponse;

        [HttpPost]
        [ActionName("BookProposal")]
        public IHttpActionResult BookProposal(BookProposalModel bookPropModel)
        {
            try
            {
                apiResponse = CheckStatus(bookPropModel.NameOfUserWithRequest, bookPropModel.Author, bookPropModel.Title);

                if (apiResponse == "The input is valid")
                {
                    library.AddBookProposal(bookPropModel);
                    apiResponse = "The BookProposal has been created successfully!";
                    return Ok(200);
                }

                else
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, apiResponse);
                }
            }

            catch (Exception e)
            {
                this.logger.WriteException(e);
                throw;
            }
        }


        [HttpPost]
        [ActionName("SearchBook")]
        public IHttpActionResult SearchBook(SearchStringModel searchStringMdl)
        {
            try
            {
                apiResponse = CheckStatus(searchStringMdl.SearchString);

                if (apiResponse != "The input is valid")
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, apiResponse);
                }

                var book = library.GetBook(searchStringMdl.SearchString);

                if (book.Title.Contains("book not found!"))
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, "There was no book found by the ISBN");
                }

                else
                {
                    return Ok(book);
                }
            }

            catch (Exception e)
            {
                this.logger.WriteException(e);
                throw;
            }
        }

        [HttpPost]
        [ActionName("SearchForBooksByAuthorTitleOrISBN")]
        public IHttpActionResult SearchForBooksByAuthorTitleOrISBN(SearchStringModel searchStringMdl)
        {
            try
            {
                apiResponse = CheckStatus(searchStringMdl.SearchString);

                if (apiResponse != "The input is valid")
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, apiResponse);
                }

                var books = library.GetBooksBySearchString(searchStringMdl.SearchString);

                if (books.Count > 0)
                {
                    return Ok(books);
                }

                else
                {
                    return Ok("Det fanns inga böcker som matchade söksträngen");
                }
            }

            catch (Exception e)
            {
                this.logger.WriteException(e);
                throw;
            }
        }
        

        [HttpPost]
        public IHttpActionResult CreateBooks(BookModel bookMdl)
        {
            try
            {
                apiResponse = CheckStatus(bookMdl.ISBN, bookMdl.Author, bookMdl.Title);

                if (apiResponse == "The input is valid")
                {
                    string createBookResponse = library.CreateBook(bookMdl);

                    if (createBookResponse == "Det finns redan en bok med samma ISBN")
                    {
                        return Ok(createBookResponse);
                    }

                    apiResponse = "The Book has been created successfully!";
                    return Ok(apiResponse);
                }

                else
                {
                    return Content(System.Net.HttpStatusCode.NoContent, apiResponse);
                }
            }

            catch (Exception e)
            {
                this.logger.WriteException(e);
                throw;
            }
        }

        private string CheckStatus(string input1)
        {
            string response;

            if (string.IsNullOrEmpty(input1))
            {
                response = "One or more values of the input fields are null or empty!";

                if (string.IsNullOrWhiteSpace(input1))
                {
                    response = "One or more values of the input fields are null or does only contain whitespaces!";
                }
            }
            else
            {
                response = "The input is valid";
            }

            return response;
        }

        private string CheckStatus(string input1, string input2, string input3)
        {
            string response;

            if (string.IsNullOrEmpty(input1) || string.IsNullOrEmpty(input2) || string.IsNullOrEmpty(input3))
            {
                response = "One or more values of the input fields are null or empty!";

                if (string.IsNullOrWhiteSpace(input1) || string.IsNullOrWhiteSpace(input2) || string.IsNullOrEmpty(input3))
                {
                    response = "One or more values of the input fields are null or does only contain whitespaces!";
                }
            }

            else
            {
                response = "The input is valid";
            }

            return response;
        }

    }
}
