import { AfterViewInit, Component, Input } from '@angular/core';
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

  private map: L.Map | undefined;

  constructor() {}

  ngAfterViewInit(): void {
    this.initMap();
  }

  private initMap(): void {
    if (this.mapId) {
      const mapElement = document.getElementById(this.mapId);
      if (mapElement) {
        this.map = L.map(mapElement).setView(
          [44.42658525, 21.93424910358389],
          13
        );
        L.marker([44.42658525, 21.93424910358389]).addTo(this.map);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
          maxZoom: 18,
          attribution: '© OpenStreetMap',
        }).addTo(this.map);
      }
    }
  }
}
