import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css'],
})
export class SearchBarComponent {
  @Input() buttonClass: string = '';
  @Input() buttonColor: string = '';
  @Input() placeholder: string = '';
  @Input() suggestions: string[] = [];
  searchInputValue: string = '';
  isDisabled: boolean = true;

  @Output() inputChange = new EventEmitter<string>();

  onInputChange(value: string) {
    this.searchInputValue = value;
    this.inputChange.emit(this.searchInputValue);
  }
}
