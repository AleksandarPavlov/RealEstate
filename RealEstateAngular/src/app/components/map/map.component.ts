import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  Input,
} from '@angular/core';
import * as L from 'leaflet';
import { Subject, takeUntil } from 'rxjs';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';
import { PropertyService } from 'src/app/services/property.service';

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
  @Input() setView: boolean = false;

  areCoordinatesValid: boolean = false;
  properties: PropertyResponse[] = [];

  private map: L.Map | undefined;
  private popup: L.Popup | undefined;
  private currentMarkers: L.Marker[] = [];
  private currentMarker: L.Marker | undefined;
  private unsubscribe$ = new Subject<void>();

  constructor(
    private cdr: ChangeDetectorRef,
    private propertyService: PropertyService
  ) {}

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
        this.map = L.map(mapElement).setView([lat, lon], this.setView ? 7 : 13);

        if (!this.setView) {
          this.currentMarker = L.marker([lat, lon]).addTo(this.map);
        }

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
          maxZoom: 18,
          attribution: '© OpenStreetMap',
        }).addTo(this.map);

        this.popup = L.popup();

        if (this.setView) {
          this.map.on('click', this.onMapClick.bind(this));
        }
      }
    }
  }

  onMapClick(e: L.LeafletMouseEvent): void {
    if (this.map && this.popup) {
      if (this.currentMarker) {
        this.map.removeLayer(this.currentMarker);
      }

      this.currentMarker = L.marker(e.latlng).addTo(this.map);
      const lat = e.latlng.lat;
      const lon = e.latlng.lng;

      this.fetchNearbyProperties(lat, lon, 5);
    }
  }

  fetchNearbyProperties(lat: number, lon: number, distance: number) {
    this.propertyService
      .fetchNearby(lat, lon, distance)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((response) => {
        this.properties = response;

        this.clearMarkers();

        this.properties.forEach((property) => {
          if (
            property.coordinates.lat &&
            property.coordinates.lon &&
            this.map
          ) {
            const marker = L.marker([
              Number.parseFloat(property.coordinates.lat),
              Number.parseFloat(property.coordinates.lon),
            ])
              .addTo(this.map)
              .bindPopup(property.name);

            marker.on('click', () => {
              if (this.map) {
                this.map.setView(
                  [
                    Number.parseFloat(property.coordinates.lat),
                    Number.parseFloat(property.coordinates.lon),
                  ],
                  13
                );
              }
            });

            this.currentMarkers.push(marker);
          }
        });
      });
  }

  private clearMarkers() {
    if (this.currentMarkers) {
      this.currentMarkers.forEach((marker) => {
        if (this.map) {
          this.map.removeLayer(marker);
        }
      });
      this.currentMarkers = [];
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
