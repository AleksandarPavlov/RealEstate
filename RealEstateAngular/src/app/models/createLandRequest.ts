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
    public advertiserFullName: string,
    public advertiserContact: string,
    public advertiserEmailAddress: string,
    public advertiserSocialMediaLink: string,
    public description: string
  ) {}

  static fromForm(
    propertyForm: FormGroup,
    advertiserForm: FormGroup
  ): CreateLandRequest {
    return new CreateLandRequest(
      propertyForm.get('advertismentName')?.value,
      toListingType(propertyForm.get('sellOrRent')?.value),
      propertyForm.get('city')?.value,
      propertyForm.get('address')?.value,
      propertyForm.get('price')?.value,
      propertyForm.get('sizeInMmSquared')?.value,
      false,
      advertiserForm.get('advertiserName')?.value,
      advertiserForm.get('phoneNumber')?.value,
      advertiserForm.get('emailAddress')?.value,
      advertiserForm.get('socialMediaLink')?.value,
      propertyForm.get('description')?.value
    );
  }
}
