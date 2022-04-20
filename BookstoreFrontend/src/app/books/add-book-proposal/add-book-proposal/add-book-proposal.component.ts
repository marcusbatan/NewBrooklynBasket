import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { bookProposalModel } from 'src/app/Models/bookProposalModel';
import { BookService } from 'src/app/Services/bookService.service';

@Component({
  selector: 'app-add-book-proposal',
  templateUrl: './add-book-proposal.component.html',
  styleUrls: ['./add-book-proposal.component.css']
})
export class AddBookProposalComponent implements OnInit {

  bookProposalMdl = new bookProposalModel
  registerationForm!: FormGroup;

  constructor(private bookService: BookService, private fb: FormBuilder) { }

  ngOnInit() {
    this.validationForm()
  }

  validationForm()
  {
    this.registerationForm = this.fb.group({
      nameOfUserWithRequest: new FormControl(null, Validators.required),
      title: new FormControl(null, Validators.required),
      author: new FormControl(null, Validators.required),
    });
  }

  addBookProposal()
  {
    if(this.registerationForm.valid)
    {

      this.bookService.AddBookProposal(this.bookProposalMdl).subscribe((data) => {
        if(data == 200)
        {
          alert("Grattis! Du har skapat en proposal");
        }
        else
        {
          alert("Du gick inte att lägga till en proposal");
        }
        });
    }
    else
    {
      alert("Korrekt input har inte skrivits in!");
    }

  }

  get nameOfUserWithRequest(){
    return this.registerationForm.get('nameOfUserWithRequest') as FormControl;
  }

  get title(){
    return this.registerationForm.get('title') as FormControl;
  }

  get author(){
    return this.registerationForm.get('author') as FormControl;
  }
}
