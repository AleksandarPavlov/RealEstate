export enum PropertyType {
  APARTMENT = 0,
  HOUSE = 1,
  LAND = 2,
  UNKNOWN = 3,
}

export function toPropertyType(value: string): PropertyType {
  switch (value.toUpperCase()) {
    case '0':
    case 'APARTMENT':
      return PropertyType.APARTMENT;
    case '1':
    case 'HOUSE':
      return PropertyType.HOUSE;
    case '2':
    case 'LAND':
      return PropertyType.LAND;
    default:
      return PropertyType.UNKNOWN;
  }
}

export function propertyTypeToSerbianLanguage(value: PropertyType): string {
  switch (value) {
    case PropertyType.APARTMENT:
    case 0:
      return 'Stan';
    case PropertyType.HOUSE:
    case 1:
      return 'Kuća';
    case PropertyType.LAND:
    case 2:
      return 'Zemljište';
    default:
      return 'Stan';
  }
}
