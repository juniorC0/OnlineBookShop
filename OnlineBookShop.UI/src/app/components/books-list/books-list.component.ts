import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
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
  dataSource!: MatTableDataSource<Book>;
  searchTerm: string = '';

  @ViewChild(MatSort) sort!: MatSort;

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks(): void {
    this.bookService.getAllBooks().subscribe((books) => {
      this.allBooks = books;
      this.filteredBooks = books;
      this.dataSource = new MatTableDataSource(books);
      this.dataSource.sort = this.sort;
    });
  }

  filterBooks() {
    this.filteredBooks = this.allBooks.filter((book) =>
      book.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
    this.dataSource = new MatTableDataSource(this.filteredBooks);
    this.dataSource.sort = this.sort;
  }

  onSearch(value: string): void {
    this.searchTerm = value;
    this.filterBooks();
  }
}
