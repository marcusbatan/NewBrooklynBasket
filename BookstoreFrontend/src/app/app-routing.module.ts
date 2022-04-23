import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddBlogpostComponent } from './blog-folder/add-blogpost/add-blogpost/add-blogpost.component';
import { AddBookProposalComponent } from './books/add-book-proposal/add-book-proposal/add-book-proposal.component';
import { AddBooksComponent } from './books/add-books/add-books/add-books.component';
import { SearchForBooksComponent } from './books/search-for-books/search-for-books/search-for-books.component';
import { ChatComponent } from './chat/chat.component';
import { NewNavBarComponent } from './new-nav-bar/new-nav-bar.component';
import { PlayerComponent } from './PlayerFolder/player/player.component';
import { RegStatlineComponent } from './reg-statline/reg-statline/reg-statline.component';
import { LoginComponent } from './User/Login/login/login.component';

const routes: Routes = [
  {path: 'add-books', component: AddBooksComponent},
  {path: 'search-for-books', component: SearchForBooksComponent},
  {path: 'add-book-proposal', component: AddBookProposalComponent},
  {path: 'main', component: NewNavBarComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register-statline', component: RegStatlineComponent},
  {path: 'add-blogpost', component: AddBlogpostComponent},
  {path: 'view-players', component: PlayerComponent},
  {path: 'chat', component: ChatComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
