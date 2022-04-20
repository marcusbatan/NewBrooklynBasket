import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { bookModel } from 'src/app/Models/bookModel';
import { searchStringModel } from 'src/app/Models/searchStringModel';
import { BookService } from 'src/app/Services/bookService.service';

@Component({
  selector: 'app-search-for-books',
  templateUrl: './search-for-books.component.html',
  styleUrls: ['./search-for-books.component.css']
})
export class SearchForBooksComponent implements OnInit {

  constructor(private bookService: BookService, private fb: FormBuilder) { }

  ngOnInit() {
    this.validationForm();
  }

  searchStringMdl = new searchStringModel();
  result: any | undefined;
  registerationForm!: FormGroup;

  validationForm()
  {
    this.registerationForm = this.fb.group({
      searchString: new FormControl(null, Validators.required),
    });
  }

  searchForBooks()
  {
    if(this.registerationForm.valid)
     {
        this.bookService.SearchForBook(this.searchStringMdl).subscribe(data => {
        console.log(data);
        this.result = data;
        if(this.result == "Det fanns inga böcker som matchade söksträngen")
        {
            alert("Det fanns inga böcker som matchade söksträngen");
        }
        })

     }
     else
     {
      alert("Söksträngen får inte vara tom!");
     }
  }

  get searchString(){
    return this.registerationForm.get('searchString') as FormControl;
  }

}
