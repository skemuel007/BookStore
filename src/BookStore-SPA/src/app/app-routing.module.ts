import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './book-list/book-list.component';
import { BookComponent } from './book/book.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { CategoryComponent } from './category/category.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'books', component: BookListComponent },
  { path: 'book', component: BookComponent },
  { path: 'book/:id', component: BookComponent },
  { path: 'categories', component: CategoryListComponent },
  { path: 'category', component: CategoryComponent },
  { path: 'category/:id', component: CategoryComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
