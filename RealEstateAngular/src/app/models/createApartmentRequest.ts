import { FormGroup } from '@angular/forms';
import { ListingType, toListingType } from './propertyListingType.enum';

export class CreateApartmentRequest {
  constructor(
    public name: string,
    public listingType: ListingType,
    public city: string,
    public address: string,
    public price: number,
    public sizeInMmSquared: number,
    public isPremium: boolean,
    public isFurnished: boolean,
    public floorNumber: string,
    public numberOfRooms: number,
    public description: string
  ) {}

  static fromForm(propertyForm: FormGroup): CreateApartmentRequest {
    return new CreateApartmentRequest(
      propertyForm.get('advertismentName')?.value,
      toListingType(propertyForm.get('sellOrRent')?.value),
      propertyForm.get('city')?.value,
      propertyForm.get('address')?.value,
      propertyForm.get('price')?.value,
      propertyForm.get('sizeInMmSquared')?.value,
      false,
      propertyForm.get('isFurnished')?.value === 'Da',
      propertyForm.get('floorNumber')?.value,
      propertyForm.get('numberOfRooms')?.value,
      propertyForm.get('description')?.value
    );
  }
}
