import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GeoAutocompleteService {
  private apiKey = environment.GEO_AUTOCOMPLETE_KEY;
  constructor(private httpClient: HttpClient) {}

  getSuggestions(input: string) {
    const url = `https://api.geoapify.com/v1/geocode/autocomplete?text=${input}&apiKey=${this.apiKey}&filter=countrycode:rs&type=city`;
    return this.httpClient.get<any>(url);
  }
}
