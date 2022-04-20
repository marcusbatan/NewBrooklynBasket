import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddBooksComponent } from './books/add-books/add-books/add-books.component';
import { NavBarComponent } from './nav-bar/nav-bar/nav-bar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchForBooksComponent } from './books/search-for-books/search-for-books/search-for-books.component';
import { AddBookProposalComponent } from './books/add-book-proposal/add-book-proposal/add-book-proposal.component';
import { NewNavBarComponent } from './new-nav-bar/new-nav-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    AddBooksComponent,
    NavBarComponent,
    SearchForBooksComponent,
    AddBookProposalComponent,
    NewNavBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
