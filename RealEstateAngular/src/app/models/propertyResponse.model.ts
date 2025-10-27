import { Advertiser } from './advertiser.model';
import { Coordinates } from './coordinates.model';
import { ListingType } from './propertyListingType.enum';
import { PropertyStatus } from './propertyStatus.enum';
import { PropertyType } from './propertyType.enum';

export class PropertyResponse {
  constructor(
    public id: number,
    public name: string,
    public listingType: ListingType,
    public type: PropertyType,
    public status: PropertyStatus,
    public city: string,
    public address: string,
    public price: number,
    public sizeInMmSquared: number,
    public creationTime: Date,
    public isPremium: boolean,
    public isFurnished: boolean,
    public floorNumber: boolean,
    public numberOfRooms: number,
    public coordinates: Coordinates,
    public advertiser: Advertiser,
    public images: string[],
    public description: string,
    public pricePerMmSquared: number
  ) {}
}
