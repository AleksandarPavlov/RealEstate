import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-number-input',
  templateUrl: './number-input.component.html',
  styleUrls: ['./number-input.component.css'],
})
export class NumberInputComponent {
  @Input() icon: string = '';
  @Input() placeholder: string = '';
}
