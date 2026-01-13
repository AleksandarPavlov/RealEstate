import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { SelectOption } from 'src/app/models/select-option.model';
import { GeoAutocompleteService } from 'src/app/services/geo-autocomplete.service';
import { NumberInputComponent } from '../number-input/number-input.component';
import { SearchBarComponent } from '../search-bar/search-bar.component';
import { SelectComponent } from '../select/select.component';

@Component({
  selector: 'app-search-input-group',
  templateUrl: './search-input-group.component.html',
  styleUrls: ['./search-input-group.component.css'],
})
export class SearchInputGroupComponent {
  @ViewChild('searchBar') searchBar!: SearchBarComponent;
  @ViewChild('listingSelect') listingSelect!: SelectComponent;
  @ViewChild('propertyTypeSelect') propertyTypeSelect!: SelectComponent;
  @ViewChild('sizeFromInput') sizeFromInput!: NumberInputComponent;
  @ViewChild('priceToInput') priceToInput!: NumberInputComponent;

  private unsubscribe$ = new Subject<void>();
  searchInputValue: string = '';
  suggestions: string[] = [];

  constructor(
    private geoAutocompleteService: GeoAutocompleteService,
    private router: Router
  ) {}

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

  onSearchClick() {
    const location = this.searchBar.searchInputValue;
    const listingType = this.listingSelect.selectedOption;
    const propertyType = this.propertyTypeSelect.selectedOption;
    const sizeFrom = this.sizeFromInput.value;
    const priceTo = this.priceToInput.value;
    const queryParams: any = {};

    if (location) {
      queryParams['City'] = location;
    }
    if (listingType) {
      queryParams['ListingType'] = listingType;
    }
    if (propertyType) {
      queryParams['PropertyType'] = propertyType;
    }
    if (sizeFrom !== null) {
      queryParams['SizeFrom'] = sizeFrom;
    }
    if (priceTo !== null) {
      queryParams['PriceTo'] = priceTo;
    }

    this.router.navigate(['/list'], { queryParams });
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
