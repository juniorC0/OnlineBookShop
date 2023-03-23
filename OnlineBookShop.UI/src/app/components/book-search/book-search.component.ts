import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-book-search',
  templateUrl: './book-search.component.html',
  styleUrls: ['./book-search.component.css'],
})
export class BookSearchComponent {
  searchTerm = new FormControl();

  @Output() searchEvent = new EventEmitter<string>();

  constructor() {
    this.searchTerm.valueChanges.subscribe((value) => {
      this.searchEvent.emit(value);
    });
  }
}
