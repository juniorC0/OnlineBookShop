import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book';
import { BooksByYear } from '../models/books-by-year';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  constructor(private http: HttpClient) {}

  getAllBooks(): Observable<Book[]> {
    return this.http.get<Book[]>('/api/Book');
  }

  addBook(newBook: Book): Observable<Book> {
    return this.http.post<Book>('/api/Book', newBook);
  }

  deleteBook(book: Book) {
    if (book.id != null) {
      const url = `/api/Book/${book.id}`;
      return this.http.delete<Book>(url);
    } else {
      throw new Error('Book id is null');
    }
  }

  updateBook(book: Book) {
    if (book.id != null) {
      const url = `/api/Book/${book.id}`;
      return this.http.put<Book>(url, book);
    } else {
      throw new Error('Book id is null');
    }
  }

  getBooksByYear() {
    return this.http.get<BooksByYear[]>('api/Book/books-per-year');
  }
}
