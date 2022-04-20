import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { bookModel } from 'src/app/Models/bookModel';
import { BookService } from 'src/app/Services/bookService.service';

@Component({
  selector: 'app-add-books',
  templateUrl: './add-books.component.html',
  styleUrls: ['./add-books.component.css']
})
export class AddBooksComponent implements OnInit {

  constructor(private bookService: BookService, private fb: FormBuilder) { }

  bookMdl = new bookModel();
  registerationForm!: FormGroup;

  ngOnInit(): void {
    this.validationForm();
  }

  validationForm()
  {
    this.registerationForm = this.fb.group({
      ISBN: new FormControl(null, Validators.required),
      title: new FormControl(null, Validators.required),
      author: new FormControl(null, Validators.required),
    });
  }

  addBooks()
  {
    if(this.registerationForm.valid)
     {

      console.log(this.bookMdl);
      this.bookService.AddBook(this.bookMdl).subscribe(data => {
        console.log(data);

        if(data == "Det finns redan en bok med samma ISBN")
        {
          alert(data);
        }

        else
        {
          alert("Grattis! Du har nu laddat upp en ny bok!")
        }
      })
    }

    else
    {
      alert("Korrekt input har inte skrivits in!");
    }

  }

  get ISBN(){
    return this.registerationForm.get('ISBN') as FormControl;
  }

  get title(){
    return this.registerationForm.get('title') as FormControl;
  }

  get author(){
    return this.registerationForm.get('author') as FormControl;
  }

}
