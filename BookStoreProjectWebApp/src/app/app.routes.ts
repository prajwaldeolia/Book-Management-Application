import { Routes } from '@angular/router';
import { AllbooksComponent } from './allbooks/allbooks.component';
import { AddBookComponent } from './add-book/add-book.component';

export const routes: Routes = [
    { path: 'books', component: AllbooksComponent },
    { path: 'add', component: AddBookComponent }
];
