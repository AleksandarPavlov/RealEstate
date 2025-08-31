import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ListingType } from 'src/app/models/propertyListingType.enum';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent {
  @Input() properties: PropertyResponse[] = [];
  @Input() isFetching: boolean = false;
  @Input() currentPage: number = 0;
  @Output() nextPage = new EventEmitter<void>();
  @Output() previousPage = new EventEmitter<void>();
  listingType = ListingType;

  handleNextPage() {
    this.nextPage.emit();
  }

  handlePreviousPage() {
    this.previousPage.emit();
  }
}
