import { Component, OnInit } from '@angular/core';
import { ChartDataset } from 'chart.js/auto';
import { ChartOptions, ChartType } from 'chart.js/auto';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book-chart',
  templateUrl: './book-chart.component.html',
  styleUrls: ['./book-chart.component.css'],
})
export class BookChartComponent implements OnInit {
  public barChartOptions: ChartOptions = {
    responsive: true,
  };

  public barChartLabels: string[] = [];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [];
  public barChartData: ChartDataset[] = [
    { data: [], label: 'Number of books' },
  ];

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.bookService.getBooksByYear().subscribe((booksByYear) => {
      this.barChartLabels = booksByYear.map((data) => data.year.toString());
      this.barChartData[0].data = booksByYear.map((data) => data.count);
    });
  }
}
