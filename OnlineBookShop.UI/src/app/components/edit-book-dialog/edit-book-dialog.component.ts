import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-edit-book-dialog',
  templateUrl: './edit-book-dialog.component.html',
  styleUrls: ['./edit-book-dialog.component.css'],
})
export class EditBookDialogComponent implements OnInit {
  bookForm!: FormGroup;
  book: Book;

  constructor(
    private formBuilder: FormBuilder,
    private bookService: BookService,
    public dialogRef: MatDialogRef<EditBookDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.book = data.book;
  }

  ngOnInit(): void {
    this.bookForm = this.formBuilder.group({
      name: [this.book.name, Validators.required],
      publicationDate: [this.book.publicationDate, Validators.required],
      numberOfPages: [this.book.numberOfPages, Validators.required],
      description: [this.book.description, Validators.required],
    });
  }

  onSubmit() {
    const updatedBook: Book = {
      id: this.book.id,
      name: this.bookForm.value.name,
      publicationDate: this.bookForm.value.publicationDate,
      description: this.bookForm.value.description,
      numberOfPages: this.bookForm.value.numberOfPages,
    };

    this.bookService.updateBook(updatedBook).subscribe(
      (result) => {
        this.dialogRef.close(result);
      },
      () => {
        alert('Error updating book:');
      }
    );
  }

  onCancel() {
    this.dialogRef.close();
  }
}
