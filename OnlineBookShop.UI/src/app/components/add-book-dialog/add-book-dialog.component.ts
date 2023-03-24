import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book-dialog',
  templateUrl: './add-book-dialog.component.html',
  styleUrls: ['./add-book-dialog.component.css'],
})
export class AddBookDialogComponent {
  bookForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<AddBookDialogComponent>,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    this.bookForm = this.formBuilder.group({
      name: ['', Validators.required],
      publicationDate: ['', Validators.required],
      description: ['', Validators.required],
      numberOfPages: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.bookForm.valid) {
      const newBook: Book = {
        name: this.bookForm.value.name,
        publicationDate: this.bookForm.value.publicationDate,
        description: this.bookForm.value.description,
        numberOfPages: this.bookForm.value.numberOfPages,
      };

      this.bookService.addBook(newBook).subscribe(
        () => {
          alert('Book added successfully');
        },
        () => {
          alert('Error adding book:');
        }
      );
      this.dialogRef.close();
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
