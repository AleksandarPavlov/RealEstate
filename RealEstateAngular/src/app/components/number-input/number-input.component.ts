import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-number-input',
  templateUrl: './number-input.component.html',
  styleUrls: ['./number-input.component.css'],
})
export class NumberInputComponent {
  @Input() icon: string = '';
  @Input() placeholder: string = '';
  @Input() marginTop: boolean = false;
  @Input() placeholderSize: 'small' | 'medium' = 'medium';
  @Input() width: 'small' | 'medium' | 'large' = 'medium';

  value: number | null = null;

  @Output() valueChange = new EventEmitter<number | null>();

  onValueChange(event: Event) {
    const input = event.target as HTMLInputElement;

    if (input && input.value) {
      const newValue = Number(input.value);
      if (!isNaN(newValue)) {
        this.value = newValue;
        this.valueChange.emit(this.value);
      }
    } else {
      this.value = null;
      this.valueChange.emit(this.value);
    }
  }
}
