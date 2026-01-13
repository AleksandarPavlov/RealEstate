import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  Input,
} from '@angular/core';
import * as L from 'leaflet';
import 'leaflet.bouncemarker';
import 'leaflet.sidepanel';
import { Subject, takeUntil } from 'rxjs';
import {
  ListingType,
  listingTypeToSerbianLanguage,
  toListingType,
} from 'src/app/models/propertyListingType.enum';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';
import { SelectOption } from 'src/app/models/select-option.model';
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
  currentProperty: PropertyResponse | undefined = undefined;
  isPanelOpen: boolean = false;
  distance: number | null = 5;
  selectedListingType: string | null = null;

  private map: L.Map | undefined;
  private popup: L.Popup | undefined;
  private currentMarkers: L.Marker[] = [];
  private currentMarker: L.Marker | undefined;
  private unsubscribe$ = new Subject<void>();
  private panel: L.Control.SidePanel | undefined;

  listingSelectOptions: SelectOption[] = [
    { label: listingTypeToSerbianLanguage(ListingType.RENT), value: 'Rent' },
    { label: listingTypeToSerbianLanguage(ListingType.SELL), value: 'Sell' },
  ];

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
          this.panel = L.control
            .sidepanel('panelID', {
              panelPosition: 'left',
              hasTabs: false,
              tabsPosition: 'top',
              pushControls: true,
              darkMode: false,
              defaultTab: 'tab-5',
              onToggle: (opened) => {
                this.isPanelOpen = opened;
              },
            })
            .addTo(this.map!);
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

      this.fetchNearbyProperties(
        lat,
        lon,
        this.distance ? this.distance : 5,
        this.selectedListingType
          ? toListingType(this.selectedListingType)
          : undefined
      );
    }
  }

  fetchNearbyProperties(
    lat: number,
    lon: number,
    distance: number,
    selectedListingType?: ListingType
  ) {
    this.propertyService
      .fetchNearby(lat, lon, distance, selectedListingType)
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
            const marker = L.marker(
              [
                Number.parseFloat(property.coordinates.lat),
                Number.parseFloat(property.coordinates.lon),
              ],
              {
                bounceOnAdd: true,
                bounceOnAddOptions: { duration: 600, height: 200 },
              }
            ).addTo(this.map);

            marker.on('click', () => {
              this.fetchCurrentProperty(property.id);
              this.cdr.detectChanges();
              if (this.panel) {
                this.panel.open();
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

  fetchCurrentProperty(id: number) {
    this.propertyService
      .fetchById(id)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((response) => {
        this.currentProperty = response;
      });
  }

  onDistanceChange(newDistance: number | null) {
    this.distance = newDistance;
  }

  onListingTypeChange(newListingType: string | null) {
    this.selectedListingType = newListingType;
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
