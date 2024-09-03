export class Property {
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

  constructor(
    image: string,
    propertyName: string,
    address: string,
    sizeInMmSquared: number,
    numberOfRooms: number,
    floorNumber: string,
    isFurnished: boolean,
    price: number,
    pricePerMmSquared: number,
    isForRent: boolean
  ) {
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
  }
}
