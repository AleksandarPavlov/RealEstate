import { ListingType } from './propertyListingType.enum';
import { PropertyType } from './propertyType.enum';

export class PropertyQueryParams {
  City?: string;
  ListingType?: ListingType;
  PropertyType?: PropertyType;
  SizeFrom?: number;
  PriceTo?: number;
  GroundFloor?: boolean;
  NumberOfRooms?: number;
  Page?: number = 0;
  SortAsc?: boolean = true;

  constructor(params?: Partial<PropertyQueryParams>) {
    if (params) {
      this.City = params.City;
      this.ListingType = params.ListingType;
      this.PropertyType = params.PropertyType;
      this.SizeFrom = params.SizeFrom;
      this.PriceTo = params.PriceTo;
      this.GroundFloor = params.GroundFloor;
      this.NumberOfRooms = params.NumberOfRooms;
      this.Page = params.Page;
      this.SortAsc = params.SortAsc;
    }
  }
}
