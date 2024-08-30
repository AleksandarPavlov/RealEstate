import { Component } from '@angular/core';
import { SelectOption } from 'src/app/models/select-option-model';

@Component({
  selector: 'app-search-input-group',
  templateUrl: './search-input-group.component.html',
  styleUrls: ['./search-input-group.component.css'],
})
export class SearchInputGroupComponent {
  locationSelectOptions: SelectOption[] = [
    { label: 'Novi Sad', value: 'Novi Sad' },
    { label: 'Belgrade', value: 'Belgrade' },
  ];

  typeSelectOptions: SelectOption[] = [
    { label: 'Apartment', value: 'Apartment' },
    { label: 'House', value: 'House' },
    { label: 'Parking', value: 'Parking' },
    { label: 'Land', value: 'Land' },
  ];
}
