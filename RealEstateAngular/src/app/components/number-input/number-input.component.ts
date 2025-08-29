import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  forwardRef,
  Input,
  Output,
} from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-number-input',
  templateUrl: './number-input.component.html',
  styleUrls: ['./number-input.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => NumberInputComponent),
      multi: true,
    },
  ],
})
export class NumberInputComponent implements ControlValueAccessor {
  @Input() icon: string = '';
  @Input() placeholder: string = '';
  @Input() marginTop: boolean = false;
  @Input() placeholderSize: 'small' | 'medium' = 'medium';
  @Input() width: 'small' | 'medium' | 'large' = 'medium';

  value: number | null = null;

  @Output() valueChange = new EventEmitter<number | null>();

  onChange: any = () => {};
  onTouched: any = () => {};

  onValueChange(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input && input.value !== '') {
      const newValue = Number(input.value);
      if (!isNaN(newValue)) {
        this.value = newValue;
        this.onChange(this.value);
        this.valueChange.emit(this.value);
      }
    } else {
      this.value = null;
      this.onChange(this.value);
      this.valueChange.emit(this.value);
    }
    this.onTouched();
  }

  writeValue(value: number | null): void {
    this.value = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
}
