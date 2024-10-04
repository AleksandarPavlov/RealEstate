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
  @Input() fontSize: 'medium' | 'large' = 'medium';
  @Input() hasButton: boolean = false;
  @Input() hasDescription: boolean = false;

  listingType = ListingType;
  propertyType = PropertyType;
}
