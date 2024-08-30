import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css'],
})
export class SearchBarComponent {
  @Input() buttonClass: string = '';
  @Input() buttonColor: string = '';
  @Input() placeholder: string = '';

  searchInputValue: string = '';
  isDisabled: boolean = true;
}
