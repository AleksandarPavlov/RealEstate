import { FormGroup } from '@angular/forms';
import { ListingType, toListingType } from './propertyListingType.enum';

export class CreateLandRequest {
  constructor(
    public name: string,
    public listingType: ListingType,
    public city: string,
    public address: string,
    public price: number,
    public sizeInMmSquared: number,
    public isPremium: boolean,
    public description: string
  ) {}

  static fromForm(propertyForm: FormGroup): CreateLandRequest {
    return new CreateLandRequest(
      propertyForm.get('advertismentName')?.value,
      toListingType(propertyForm.get('sellOrRent')?.value),
      propertyForm.get('city')?.value,
      propertyForm.get('address')?.value,
      propertyForm.get('price')?.value,
      propertyForm.get('sizeInMmSquared')?.value,
      false,
      propertyForm.get('description')?.value
    );
  }
}
