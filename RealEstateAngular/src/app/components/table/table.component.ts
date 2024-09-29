import { Component, Input } from '@angular/core';
import { ListingType } from 'src/app/models/propertyListingType.enum';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent {
  @Input() properties: PropertyResponse[] = [];
  listingType = ListingType;
}
