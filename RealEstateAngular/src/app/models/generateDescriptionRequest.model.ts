import { ListingType } from './propertyListingType.enum';
import { PropertyType } from './propertyType.enum';

export class GenerateDescriptionRequest {
  constructor(
    public size: string,
    public address: string,
    public listingType: ListingType,
    public propertyType: PropertyType
  ) {}
}
