import { Component, Input } from '@angular/core';
import { ListingType } from 'src/app/models/propertyListingType.enum';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';
import { PropertyType } from 'src/app/models/propertyType.enum';

@Component({
  selector: 'app-image-card',
  templateUrl: './image-card.component.html',
  styleUrls: ['./image-card.component.css'],
})
export class ImageCardComponent {
  @Input() property!: PropertyResponse;
  listingType = ListingType;
  propertyType = PropertyType;
}
