export class Coordinates {
  lat: string = '';
  lon: string = '';
  constructor(lat: string, lon: string) {
    (this.lat = lat), (this.lon = lon);
  }
}
