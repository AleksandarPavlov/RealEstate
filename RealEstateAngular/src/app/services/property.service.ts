import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GenerateDescriptionRequest } from '../models/generateDescriptionRequest.model';
import { PropertyQueryParams } from '../models/propertyFilterParams.model';
import { ListingType } from '../models/propertyListingType.enum';
import { PropertyResponse } from '../models/propertyResponse.model';

@Injectable({
  providedIn: 'root',
})
export class PropertyService {
  constructor(private httpClient: HttpClient) {}

  fetchProperties(queryParams?: PropertyQueryParams) {
    let params = new HttpParams();

    if (queryParams) {
      for (const [key, value] of Object.entries(queryParams)) {
        if (value !== undefined && value !== null) {
          params = params.append(
            key,
            typeof value === 'boolean' ? value.toString() : value
          );
        }
      }
    }

    return this.httpClient.get<PropertyResponse[]>(
      'http://localhost:5157/property',
      { params }
    );
  }

  fetchById(id: number) {
    return this.httpClient.get<PropertyResponse>(
      'http://localhost:5157/property/' + id
    );
  }

  fetchLatest(amount: number) {
    return this.httpClient.get<PropertyResponse[]>(
      'http://localhost:5157/property/latest/' + amount
    );
  }

  fetchNearby(
    lat: number,
    lon: number,
    distance: number,
    listingType?: ListingType
  ) {
    let params = new HttpParams()
      .set('lat', lat.toString())
      .set('lon', lon.toString())
      .set('distance', distance);

    if (listingType !== undefined) {
      params = params.set('listingType', listingType.toString());
    }

    return this.httpClient.get<PropertyResponse[]>(
      'http://localhost:5157/property/find-nearby',
      { params }
    );
  }

  generateDescription(generateDescriptionRequest: GenerateDescriptionRequest) {
    return this.httpClient.post(
      'http://localhost:5157/property/generate-description',
      generateDescriptionRequest,
      { responseType: 'text' }
    );
  }
}
