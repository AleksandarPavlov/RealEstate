import { FormGroup } from '@angular/forms';
import { ListingType, toListingType } from './propertyListingType.enum';

export class CreateHouseRequest {
  constructor(
    public name: string,
    public listingType: ListingType,
    public city: string,
    public address: string,
    public price: number,
    public sizeInMmSquared: number,
    public isPremium: boolean,
    public isFurnished: boolean,
    public advertiserFullName: string,
    public advertiserContact: string,
    public advertiserEmailAddress: string,
    public advertiserSocialMediaLink: string,
    public floorNumber: string,
    public numberOfRooms: number,
    public description: string
  ) {}

  static fromForm(
    propertyForm: FormGroup,
    advertiserForm: FormGroup
  ): CreateHouseRequest {
    return new CreateHouseRequest(
      propertyForm.get('advertismentName')?.value,
      toListingType(propertyForm.get('sellOrRent')?.value),
      propertyForm.get('city')?.value,
      propertyForm.get('address')?.value,
      propertyForm.get('price')?.value,
      propertyForm.get('sizeInMmSquared')?.value,
      false,
      propertyForm.get('isFurnished')?.value,
      advertiserForm.get('advertiserName')?.value,
      advertiserForm.get('phoneNumber')?.value,
      advertiserForm.get('emailAddress')?.value,
      advertiserForm.get('socialMediaLink')?.value,
      propertyForm.get('floorNumber')?.value,
      propertyForm.get('numberOfRooms')?.value,
      propertyForm.get('description')?.value
    );
  }
}
