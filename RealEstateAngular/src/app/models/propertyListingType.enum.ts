export enum ListingType {
  SELL = 0,
  RENT = 1,
  UNKNOWN = 2,
}

export function toListingType(value: string): ListingType {
  switch (value.toUpperCase()) {
    case '0':
    case 'SELL':
      return ListingType.SELL;
    case '1':
    case 'RENT':
      return ListingType.RENT;
    default:
      return ListingType.UNKNOWN;
  }
}

export function listingTypeToSerbianLanguage(value: ListingType): string {
  switch (value) {
    case ListingType.SELL:
      return 'Prodaja';
    case ListingType.RENT:
      return 'Izdavanje';
    default:
      return 'Prodaja';
  }
}
