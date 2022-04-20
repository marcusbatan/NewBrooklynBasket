import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddBookProposalComponent } from './books/add-book-proposal/add-book-proposal/add-book-proposal.component';
import { AddBooksComponent } from './books/add-books/add-books/add-books.component';
import { SearchForBooksComponent } from './books/search-for-books/search-for-books/search-for-books.component';
import { NewNavBarComponent } from './new-nav-bar/new-nav-bar.component';

const routes: Routes = [
  {path: 'add-books', component: AddBooksComponent},
  {path: 'search-for-books', component: SearchForBooksComponent},
  {path: 'add-book-proposal', component: AddBookProposalComponent},
  {path: 'new-nav-bar', component: NewNavBarComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
