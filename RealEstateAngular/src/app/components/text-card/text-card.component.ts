import { Component, Input } from '@angular/core';
import { ListingType } from 'src/app/models/propertyListingType.enum';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';
import { PropertyType } from 'src/app/models/propertyType.enum';

@Component({
  selector: 'app-text-card',
  templateUrl: './text-card.component.html',
  styleUrls: ['./text-card.component.css'],
})
export class TextCardComponent {
  @Input() property!: PropertyResponse;
  listingType = ListingType;
  propertyType = PropertyType;
}
