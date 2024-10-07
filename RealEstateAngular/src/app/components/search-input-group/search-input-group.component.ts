import { Component } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { SelectOption } from 'src/app/models/select-option.model';
import { GeoAutocompleteService } from 'src/app/services/geo-autocomplete.service';

@Component({
  selector: 'app-search-input-group',
  templateUrl: './search-input-group.component.html',
  styleUrls: ['./search-input-group.component.css'],
})
export class SearchInputGroupComponent {
  private unsubscribe$ = new Subject<void>();
  searchInputValue: string = '';
  suggestions: string[] = [];

  constructor(private geoAutocompleteService: GeoAutocompleteService) {}

  handleSearchInput(value: string) {
    this.searchInputValue = value;
    this.getAutocompleteSuggestions(this.searchInputValue);
  }

  listingSelectOptions: SelectOption[] = [
    { label: 'Izdavanje', value: 'Rent' },
    { label: 'Prodaja', value: 'Sell' },
  ];

  typeSelectOptions: SelectOption[] = [
    { label: 'Stan', value: 'Apartment' },
    { label: 'Kuća', value: 'House' },
    { label: 'Zemljište', value: 'Land' },
  ];

  getAutocompleteSuggestions(input: string) {
    if (input.length > 2) {
      this.geoAutocompleteService
        .getSuggestions(input)
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe((response) => {
          this.suggestions = response.features
            .map((feature: any) =>
              feature.properties.city
                ? feature.properties.city.trim()
                : undefined
            )
            .filter((city: string | undefined) => city !== undefined);

          this.suggestions = Array.from(new Set(this.suggestions));
        });
    }
  }
  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
