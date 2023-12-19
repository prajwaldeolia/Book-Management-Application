import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookService } from '../book.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-allbooks',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './allbooks.component.html',
  styleUrl: './allbooks.component.scss'
})
export class AllbooksComponent implements OnInit
{
  public books: any;
  constructor(private service: BookService) {}
  
  ngOnInit(): void {
    this.getBooks();
  }
  
  private getBooks(): void
  {
    this.service.getBooks().subscribe((result: any) => {
      this.books = result;
    });
  }
}
