import { Component } from '@angular/core';
import { ChartConfiguration } from 'chart.js/auto';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book-chart',
  templateUrl: './book-chart.component.html',
  styleUrls: ['./book-chart.component.css'],
})
export class BookChartComponent {
  public barChartLegend = true;
  public barChartPlugins = [];
  public barChartData: ChartConfiguration<'bar'>['data'] = {
    labels: [],
    datasets: [],
  };
  public barChartOptions: ChartConfiguration<'bar'>['options'] = {
    responsive: false,
  };
  constructor(private bookService: BookService) {}
  ngOnInit(): void {
    this.bookService.getBooksByYear().subscribe((booksByYear) => {
      this.barChartData.labels = booksByYear.map((data) =>
        data.year.toString()
      );
      this.barChartData.datasets[0].data = booksByYear.map(
        (data) => data.count
      );
    });
  }
}
