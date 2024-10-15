export class Property {
  id: number = 0;
  image: string = '';
  propertyName: string = '';
  address: string = '';
  sizeInMmSquared: number = 0;
  numberOfRooms: number = 0;
  floorNumber: string = '';
  isFurnished: boolean = false;
  price: number = 0;
  pricePerMmSquared?: number = 0;
  isForRent: boolean = false;
  isPremium: boolean = false;

  constructor(
    id: number,
    image: string,
    propertyName: string,
    address: string,
    sizeInMmSquared: number,
    numberOfRooms: number,
    floorNumber: string,
    isFurnished: boolean,
    price: number,
    pricePerMmSquared: number,
    isForRent: boolean,
    isPremium: boolean
  ) {
    this.id = id;
    this.image = image;
    this.propertyName = propertyName;
    this.address = address;
    this.sizeInMmSquared = sizeInMmSquared;
    this.numberOfRooms = numberOfRooms;
    this.floorNumber = floorNumber;
    this.isFurnished = isFurnished;
    this.price = price;
    this.pricePerMmSquared = pricePerMmSquared;
    this.isForRent = isForRent;
    this.isPremium = isPremium;
  }
}
