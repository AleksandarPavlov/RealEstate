import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  Input,
} from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
})
export class MapComponent implements AfterViewInit {
  @Input() mapId: string = '';
  @Input() mapWidth: string = '0';
  @Input() mapHeight: string = '0';
  @Input() lat: string | null = '0';
  @Input() lon: string | null = '0';

  areCoordinatesValid: boolean = false;

  private map: L.Map | undefined;

  constructor(private cdr: ChangeDetectorRef) {}

  ngAfterViewInit(): void {
    if (this.lat !== null && this.lon !== null) {
      this.areCoordinatesValid = true;
      const lat = Number.parseFloat(this.lat);
      const lon = Number.parseFloat(this.lon);
      this.cdr.detectChanges();
      this.initMap(lat, lon);
    }
  }

  private initMap(lat: number, lon: number): void {
    if (this.mapId && !isNaN(lat) && !isNaN(lon)) {
      const mapElement = document.getElementById(this.mapId);
      if (mapElement) {
        this.map = L.map(mapElement).setView([lat, lon], 12);
        L.marker([lat, lon]).addTo(this.map);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
          maxZoom: 18,
          attribution: '© OpenStreetMap',
        }).addTo(this.map);
      }
    }
  }
}
