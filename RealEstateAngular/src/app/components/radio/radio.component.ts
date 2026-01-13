import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { RadioSize } from 'src/app/models/radioSize.enum';

@Component({
  selector: 'app-radio',
  templateUrl: './radio.component.html',
  styleUrls: ['./radio.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => RadioComponent),
      multi: true,
    },
  ],
})
export class RadioComponent implements ControlValueAccessor {
  @Input() options: string[] = [];
  @Input() name: string = '';
  @Input() size: RadioSize = RadioSize.Medium;
  @Input() firstOptionSelectedByDefault: boolean = false;
  radioSize = RadioSize;
  selectedValue: string | null = null;

  onChange = (value: any) => {};
  onTouched = () => {};

  writeValue(value: any): void {
    this.selectedValue = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  handleSelectionChange(value: string) {
    this.selectedValue = value;
    this.onChange(value);
    this.onTouched();
  }

  ngOnInit() {
    if (
      this.firstOptionSelectedByDefault &&
      this.options.length > 0 &&
      !this.selectedValue
    ) {
      this.selectedValue = this.options[0];
      this.onChange(this.selectedValue);
    }
  }
}
