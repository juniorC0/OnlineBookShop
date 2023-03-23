import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-date-filter',
  templateUrl: './date-filter.component.html',
  styleUrls: ['./date-filter.component.css'],
})
export class DateFilterComponent {
  @Output() rangeChanged: EventEmitter<{ startDate: Date; endDate: Date }> =
    new EventEmitter<{ startDate: Date; endDate: Date }>();
  selectedPeriod: string = 'All books';
  startDate: Date = new Date(1800, 0, 1);
  endDate: Date = new Date();
  periods: string[] = ['This month', 'This year', 'Choose period', 'All books'];

  onPeriodChange(): void {
    switch (this.selectedPeriod) {
      case 'This month':
        const monthStart = new Date(
          new Date().getFullYear(),
          new Date().getMonth(),
          1
        );
        const monthEnd = new Date();
        this.startDate = monthStart;
        this.endDate = monthEnd;
        this.emitRangeChanged();
        break;
      case 'This year':
        const yearStart = new Date(new Date().getFullYear(), 0, 1);
        const yearEnd = new Date();
        this.startDate = yearStart;
        this.endDate = yearEnd;
        this.emitRangeChanged();
        break;
      case 'All books':
        this.startDate = new Date(1800, 0);
        this.endDate = new Date();
        this.emitRangeChanged();
        break;
    }
  }

  changeStartDate(): void {
    if (this.startDate > this.endDate) {
      this.startDate = this.endDate;
    }
    this.emitRangeChanged();
  }

  changeEndDate(): void {
    if (this.endDate < this.startDate) {
      this.endDate = this.startDate;
    }
    this.emitRangeChanged();
  }

  emitRangeChanged(): void {
    const range = {
      startDate: this.startDate,
      endDate: this.endDate,
    };
    this.rangeChanged.emit(range);
  }
}
