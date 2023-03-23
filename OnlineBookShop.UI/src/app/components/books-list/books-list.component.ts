import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css'],
})
export class BooksListComponent implements OnInit {
  displayedColumns: string[] = [
    'index',
    'name',
    'publicationDate',
    'numberOfPages',
  ];
  filteredBooks: Book[] = [];
  allBooks: Book[] = [];
  searchTerm: string = '';

  constructor(private bookService: BookService) {
    this.filteredBooks = this.allBooks;
  }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks(): void {
    this.bookService.getAllBooks().subscribe((books) => {
      this.allBooks = books;
      this.filteredBooks = books;
    });
  }

  filterBooks() {
    this.filteredBooks = this.allBooks.filter((book) =>
      book.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}
