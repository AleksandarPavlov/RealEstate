import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PropertyQueryParams } from '../models/propertyFilterParams.model';
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
}
