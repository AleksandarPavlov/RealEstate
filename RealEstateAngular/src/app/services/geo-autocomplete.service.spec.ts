import { TestBed } from '@angular/core/testing';

import { GeoAutocompleteService } from './geo-autocomplete.service';

describe('GeoAutocompleteService', () => {
  let service: GeoAutocompleteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GeoAutocompleteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
