import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { bookProposalModel } from '../Models/bookProposalModel';
import { searchStringModel } from '../Models/searchStringModel';
import { bookModel } from '../Models/bookModel';

@Injectable({
  providedIn: 'root'
})
export class BookService
{
  APIurl = 'http://localhost:50536/api/BookInfo';

  constructor(private http: HttpClient) { }

  AddBook(bookModel: bookModel) : Observable<any>
  {
    return this.http.post<any>(this.APIurl + "/CreateBooks", bookModel);
  }

  SearchForBook(searchStringMdl: searchStringModel) : Observable<any>
  {
    return this.http.post<any>(this.APIurl + "/SearchForBooksByAuthorTitleOrISBN", searchStringMdl);
  }

  AddBookProposal(bookPropModel: bookProposalModel) : Observable<any>
  {
    return this.http.post<any>(this.APIurl + "/BookProposal", bookPropModel);
  }

}
