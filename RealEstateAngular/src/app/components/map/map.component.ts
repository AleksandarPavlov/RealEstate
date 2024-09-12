import { AfterViewInit, Component, Input } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
})
export class MapComponent implements AfterViewInit {
  @Input() mapWidth: string = '0';
  @Input() mapHeight: string = '0';

  private map: L.Map | undefined;

  constructor() {}

  ngAfterViewInit(): void {
    this.initMap();
  }

  private initMap(): void {
    this.map = L.map('map').setView([45.24834, 19.82466], 13);
    L.marker([45.24834, 19.82466]).addTo(this.map);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 18,
      attribution: '© OpenStreetMap',
    }).addTo(this.map);
  }
}
