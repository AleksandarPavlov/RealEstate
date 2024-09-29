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

  constructor(
    private propertyService: PropertyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    window.scroll(0, 0);

    this.route.queryParams.subscribe((params) => {
      const queryParams = new PropertyQueryParams({
        City: params['City'] ? params['City'] : undefined,
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
      });

      this.fetchProperties(queryParams);
      this.propertyTypeName = propertyTypeToSerbianLanguage(
        toPropertyType(params['PropertyType'])
      );
      this.listingTypeName = listingTypeToSerbianLanguage(
        toListingType(params['ListingType'])
      );
      this.cityName = params['City'];
    });
  }

  fetchProperties(queryParams: PropertyQueryParams) {
    this.propertyService
      .fetchProperties(queryParams)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((response) => {
        this.properties = response;
      });
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
