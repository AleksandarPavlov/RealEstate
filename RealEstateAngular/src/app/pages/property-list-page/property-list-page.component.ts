import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { PropertyQueryParams } from 'src/app/models/propertyFilterParams.model';
import {
  listingTypeToSerbianLanguage,
  toListingType,
} from 'src/app/models/propertyListingType.enum';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';
import {
  propertyTypeToSerbianLanguage,
  toPropertyType,
} from 'src/app/models/propertyType.enum';
import { PropertyService } from 'src/app/services/property.service';

@Component({
  selector: 'app-property-list-page',
  templateUrl: './property-list-page.component.html',
  styleUrls: ['./property-list-page.component.css'],
})
export class PropertyListPageComponent {
  properties: PropertyResponse[] = [];
  private unsubscribe$ = new Subject<void>();
  propertyTypeName?: string = '';
  listingTypeName?: string = '';
  cityName?: string = '';
  isFetching = false;
  currentFilters: Partial<PropertyQueryParams> = {};
  currentPage = 0;

  constructor(
    private propertyService: PropertyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.propertyTypeName = undefined;
      this.listingTypeName = undefined;
      this.cityName = undefined;

      this.currentPage = params['Page'] ? +params['Page'] : 0;

      this.currentFilters = {
        City: params['City'] || undefined,
        ListingType: params['ListingType']
          ? toListingType(params['ListingType'])
          : undefined,
        PropertyType: params['PropertyType']
          ? toPropertyType(params['PropertyType'])
          : undefined,
        SizeFrom: params['SizeFrom'] ? +params['SizeFrom'] : undefined,
        PriceTo: params['PriceTo'] ? +params['PriceTo'] : undefined,
        GroundFloor: params['GroundFloor'] === 'true' ? true : undefined,
        NumberOfRooms: params['NumberOfRooms']
          ? +params['NumberOfRooms']
          : undefined,
      };

      this.propertyTypeName = params['PropertyType']
        ? propertyTypeToSerbianLanguage(toPropertyType(params['PropertyType']))
        : undefined;

      this.listingTypeName = params['ListingType']
        ? listingTypeToSerbianLanguage(toListingType(params['ListingType']))
        : undefined;
      this.cityName = params['City'];

      this.fetchCurrentPage();
    });
  }

  fetchCurrentPage() {
    window.scroll(0, 0);
    const queryParams = new PropertyQueryParams({
      ...this.currentFilters,
      Page: this.currentPage,
    });

    this.fetchProperties(queryParams);
  }

  fetchProperties(queryParams: PropertyQueryParams) {
    this.isFetching = true;
    this.propertyService
      .fetchProperties(queryParams)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (response) => {
          this.properties = response;
          this.isFetching = false;
        },
        () => {
          this.isFetching = false;
        }
      );
  }

  handleNextPage() {
    this.currentPage++;
    this.fetchCurrentPage();
  }

  handlePreviousPage() {
    if (this.currentPage > 0) {
      this.currentPage--;
      this.fetchCurrentPage();
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
