import {
  Component,
  EventEmitter,
  HostListener,
  Input,
  Output,
} from '@angular/core';

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

  onSuggestionClick(suggestion: string) {
    this.searchInputValue = suggestion;
    this.suggestions = [];
  }

  @HostListener('document:click', ['$event.target'])
  onClick(targetElement: HTMLElement) {
    const clickedInside = targetElement.closest('.search-bar-wrapper');
    if (!clickedInside) {
      this.suggestions = [];
    }
  }
}
