import { Component } from '@angular/core';
import { SelectOption } from 'src/app/models/select-option.model';

@Component({
  selector: 'app-search-input-group',
  templateUrl: './search-input-group.component.html',
  styleUrls: ['./search-input-group.component.css'],
})
export class SearchInputGroupComponent {
  listingSelectOptions: SelectOption[] = [
    { label: 'Izdavanje', value: 'Rent' },
    { label: 'Prodaja', value: 'Sell' },
  ];

  typeSelectOptions: SelectOption[] = [
    { label: 'Stan', value: 'Apartment' },
    { label: 'Kuća', value: 'House' },
    { label: 'Zemljište', value: 'Land' },
  ];
}
